using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor
{
    internal class TelaFornecedor : Tela
    {
        public RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU FORNECEDORES--");
            Console.WriteLine("([1] PARA CADASTRAR");
            Console.WriteLine("([2] PARA VISUALIZAR");
            Console.WriteLine("([3] PARA EDITAR");
            Console.WriteLine("([4] PARA EXCLUIR");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Fornecedor PreencherFormulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVO FORNECEDOR...", "Digite os dados solicitados no formulário abaixo.");

            Console.Write("Empresa: ");
            string nomeEmpresa = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefoneEmpresa = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            return new Fornecedor(nomeEmpresa, telefoneEmpresa, endereco);
        }

        public void CadastrarFornecedor()
        {
            Fornecedor fornecedor = PreencherFormulario();
            repositorioFornecedor.Adicionar(fornecedor);
        }

        public void VisualizarFornecedores()
        {
            MostrarCabecalho("FORNECEDORES CADASTRADOS!", "Visualizando funcionários cadastrados...");
            ArrayList fornecedores = repositorioFornecedor.ListarTodos();
            if (fornecedores.Count == 0)
            {
                Console.WriteLine("Ainda não temos fornecedores cadastrados...");
            }
            foreach (Fornecedor fornecedor in fornecedores)
            {
                Console.WriteLine(fornecedor);
            }
            Console.ReadLine();
        }

        public void EditarFornecedor()
        {
            Console.WriteLine("EDITANDO DADOS DO FORNECEDOR...");

            VisualizarFornecedores();

            Console.WriteLine("ATUALIZAR FORNECEDORES...");
            Console.WriteLine("Comece digitando os dados do forecedor.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var fornecedorEncontrado = (Fornecedor)repositorioFornecedor.ObterPorId(id);
            if (fornecedorEncontrado == null)
            {
                Console.WriteLine("funcionário não encontrado...");
                return;
            }
            Fornecedor fornecedorEditado = PreencherFormulario();

            fornecedorEncontrado.EditarFornecedor(fornecedorEditado);
            MostrarMensagem("Fornecedor atualizado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirFornecedor()
        {
            Console.WriteLine("EXCLUINDO DADOS DO FORNECEDOR...");

            VisualizarFornecedores();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados do fornecedor.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var funcionarioEncontrado = (Fornecedor)repositorioFornecedor.ObterPorId(id);

            if (funcionarioEncontrado == null)
            {
                Console.WriteLine("funcionário não encontrado...");
                return;
            }

            repositorioFornecedor.Remover(funcionarioEncontrado);
            MostrarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
        }
    }
}
