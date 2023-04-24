using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp1.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao
{
    internal class TelaRequisicao : Tela
    {
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioPaciente repositorioPaciente;
        public RepositorioRequisicao repositorioRequisicao;

        public TelaRequisicao(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, RepositorioFuncionario repositorioFuncionario,
            RepositorioPaciente repositorioPaciente, RepositorioRequisicao repositorioRequisicao)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioRequisicao = repositorioRequisicao;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU REQUISIÇÕES--");
            Console.WriteLine("[1] PARA CADASTRAR");
            Console.WriteLine("[2] PARA VISUALIZAR");
            Console.WriteLine("[3] PARA EDITAR");
            Console.WriteLine("[4] PARA EXCLUIR");
            Console.WriteLine("[5] PARA MAIS SOLICITADOS");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Requisicao PreencherFormulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVA REQUISIÇÃO...", "Digite os dados solicitados no formulário abaixo.");

            ArrayList fornecedores = repositorioFornecedor.ListarTodos();
            foreach (Fornecedor item in fornecedores)
            {
                Console.WriteLine(item);
            }
            Console.Write("Informe o id do fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

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

            Console.Clear();
            ArrayList pacientes = repositorioPaciente.ListarTodos();
            foreach (Paciente item in pacientes)
            {
                Console.WriteLine(item);
            }
            Console.Write("Informe o id do paciente: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.ObterPorId(idFornecedor);
            Medicamento medicamento = (Medicamento)repositorioMedicamento.ObterPorId(idMedicamento);
            Funcionario funcionario = (Funcionario)repositorioFuncionario.ObterPorId(idFuncionario);
            Paciente paciente = (Paciente)repositorioPaciente.ObterPorId(idPaciente);

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            bool quantidadeSuficiente = medicamento.DiminuirQuantidade(quantidade);
            if (quantidadeSuficiente == false)
            {
                return null;
            }
        
            return new Requisicao(descricao, quantidade, medicamento, funcionario, paciente);
        }

        public void CadastrarRequisicao()
        {
            Requisicao requisicao = PreencherFormulario();
            if (requisicao == null)
            {
                Console.WriteLine("Quantidade em estoque é insuficiente");
                Console.ReadLine();
                return;
            }
            repositorioRequisicao.Adicionar(requisicao);
        }

        public void MedicamentosMaisSolicitados()
        {
            ArrayList requisicoes = repositorioRequisicao.ListarTodos();
            List<Requisicao> requisicao = new List<Requisicao>(requisicoes.Cast<Requisicao>());
            List<Requisicao> listaOrdenada = requisicao.OrderByDescending(i => i.quantidade).ToList();

            foreach (Requisicao item in listaOrdenada)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void VisualizarRequisicoes()
        {
            MostrarCabecalho("REQUISIÇÕES CADASTRADAS!", "Visualizando requisições cadastradas...");
            ArrayList requisicoes = repositorioRequisicao.ListarTodos();
            if (requisicoes.Count == 0)
            {
                Console.WriteLine("Ainda não temos requisições cadastradas...");
            }
            foreach (Requisicao requisicao in requisicoes)
            {
                Console.WriteLine(requisicao);
            }
            Console.ReadLine();
        }

        public void EditarRequisicao()
        {
            Console.WriteLine("EDITANDO DADOS DA REQUISIÇÃO...");

            VisualizarRequisicoes();

            Console.WriteLine("ATUALIZAR DADOS...");
            Console.WriteLine("Comece digitando os dados da requisição.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var requisicaoEncontrada = (Requisicao)repositorioRequisicao.ObterPorId(id);

            if (requisicaoEncontrada == null)
            {
                Console.WriteLine("requisição não encontrada...");
                return;
            }
            Requisicao requisicaoEditada = PreencherFormulario();

            requisicaoEncontrada.Editar(requisicaoEncontrada);
            MostrarMensagem("Medicamento atualizado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRequisicao()
        {
            Console.WriteLine("EXCLUINDO DADOS DA REQUISIÇÃO...");

            VisualizarRequisicoes();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados da requisição.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var requisicaoEncontrada = (Requisicao)repositorioRequisicao.ObterPorId(id);

            if (requisicaoEncontrada == null)
            {
                Console.WriteLine("requisição não encontrada...");
                return;
            }

            repositorioRequisicao.Remover(requisicaoEncontrada);
            MostrarMensagem("Reposição excluída com sucesso!", ConsoleColor.Green);
        }
    }
}
