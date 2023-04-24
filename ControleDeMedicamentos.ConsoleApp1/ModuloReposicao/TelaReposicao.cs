using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp1.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloReposicao
{
    public class TelaReposicao : Tela
    {
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioReposicao repositorioReposicao;

        public TelaReposicao(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, RepositorioFuncionario repositorioFuncionario,
            RepositorioReposicao repositorioReposicao)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioReposicao = repositorioReposicao;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU REPOSIÇÕES--");
            Console.WriteLine("[1] PARA CADASTRAR");
            Console.WriteLine("[2] PARA VISUALIZAR");
            Console.WriteLine("[3] PARA EDITAR");
            Console.WriteLine("[4] PARA EXCLUIR");
            Console.WriteLine("[5] PARA VISUALIZAR MECIDAMENTOS EM FALTA");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Reposicao PreencherFormulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVA REPOSIÇÃO...", "Digite os dados solicitados no formulário abaixo.");

            Console.Clear();
            ArrayList medicamentos = repositorioMedicamento.ListarTodos();
            foreach (Medicamento item in medicamentos)
            {
                Console.WriteLine(item);
            }
            Console.Write("Informe o id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            ArrayList funcionarios = repositorioFuncionario.ListarTodos();
            foreach (Funcionario item in funcionarios)
            {
                Console.WriteLine(item);
            }
            Console.Write("Informe o id do funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());


            Medicamento medicamento = (Medicamento)repositorioMedicamento.ObterPorId(idMedicamento);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.ObterPorId(idFuncionario);

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            medicamento.AdicionarQuantidade(quantidade);

            return new Reposicao(descricao, quantidade, medicamento, funcionario);
        }

        public void CadastrarReposicao()
        {
            Reposicao reposicao = PreencherFormulario();

            repositorioReposicao.Adicionar(reposicao);
        }


        public void VisualizarReposicoes()
        {
            MostrarCabecalho("REQUISIÇÕES CADASTRADAS!", "Visualizando requisições cadastradas...");
            ArrayList reposicoes = repositorioReposicao.ListarTodos();
            if (reposicoes.Count == 0)
            {
                Console.WriteLine("Ainda não temos reposições cadastradas...");
            }
            foreach (Reposicao reposicao in reposicoes)
            {
                Console.WriteLine(reposicao);
            }
            Console.ReadLine();
        }

        public void EditarReposicao()
        {
            Console.WriteLine("EDITANDO DADOS DA REPOSIÇÃO...");

            VisualizarReposicoes();

            Console.WriteLine("ATUALIZAR DADOS...");
            Console.WriteLine("Comece digitando os dados da reposição.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var reposicaoEncontrada = (Reposicao)repositorioReposicao.ObterPorId(id);

            if (reposicaoEncontrada == null)
            {
                Console.WriteLine("reposição não encontrada...");
                return;
            }
            Reposicao reposicaoEditada = PreencherFormulario();

            reposicaoEditada.Editar(reposicaoEditada);
            MostrarMensagem("Reposição atualizada com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirReposicao()
        {
            Console.WriteLine("EXCLUINDO DADOS DA REPOSIÇÃO...");

            VisualizarReposicoes();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados da reposição.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var reposicaoEncontrada = (Reposicao)repositorioReposicao.ObterPorId(id);

            if (reposicaoEncontrada == null)
            {
                Console.WriteLine("requisição não encontrada...");
                return;
            }

            repositorioReposicao.Remover(reposicaoEncontrada);
            MostrarMensagem("Reposição excluída com sucesso!", ConsoleColor.Green);
        }
    }
}
