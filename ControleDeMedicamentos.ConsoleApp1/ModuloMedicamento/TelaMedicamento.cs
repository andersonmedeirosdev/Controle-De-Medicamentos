using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento
{
    internal class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU MEDICAMENTOS--");
            Console.WriteLine("([1] PARA CADASTRAR");
            Console.WriteLine("([2] PARA VISUALIZAR");
            Console.WriteLine("([3] PARA EDITAR");
            Console.WriteLine("([4] PARA EXCLUIR");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Medicamento PreencherFormulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVO MEDICAMENTO...", "Digite os dados solicitados no formulário abaixo.");

            ArrayList fornecedores = repositorioFornecedor.ListarTodos();
            foreach (Fornecedor item in fornecedores)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nFORNECEDORES DISPONÍVEIS");

            Console.Write("Medicamento: ");
            string nomeMedicamento = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o id do fornecedor: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.ObterPorId(id);
            return new Medicamento(nomeMedicamento, descricao, quantidade, fornecedor);
        }

        public void CadastrarMedicamento()
        {
            Medicamento medicamento = PreencherFormulario();
            repositorioMedicamento.Adicionar(medicamento);
        }

        public void VisualizarMedicamentos()
        {
            MostrarCabecalho("MEDICAMENTOS CADASTRADOS!", "Visualizando medicamentos cadastrados...");
            ArrayList medicamentos = repositorioMedicamento.ListarTodos();
            if (medicamentos.Count == 0)
            {
                Console.WriteLine("Ainda não temos medicamentos cadastrados...");
            }

            foreach (Medicamento medicamento in medicamentos)
            {
                Console.WriteLine(medicamento);
            }
            Console.ReadLine();
        }

        public void VisualizarMedicamentoOrdenados()
        {
            MostrarCabecalho("MEDICAMENTOS!", "Visualizando medicamentos ordenados...");
            ArrayList medicamentos = repositorioMedicamento.ListarTodos();
            if (medicamentos.Count == 0)
            {
                Console.WriteLine("Ainda não temos medicamentos cadastrados...");
            }

            List<Medicamento> medicamentoLista = new List<Medicamento>(medicamentos.Cast<Medicamento>());
            List<Medicamento> listaOrdenada = medicamentoLista.OrderBy(i => i.quantidade).ToList();

            foreach (Medicamento medicamento in listaOrdenada)
            {
                Console.WriteLine(medicamento);
            }
            Console.ReadLine();
        }

        public void EditarMedicamento()
        {
            Console.WriteLine("EDITANDO DADOS DO MEDICAMENTO...");

            VisualizarMedicamentos();

            Console.WriteLine("ATUALIZAR DADOS...");
            Console.WriteLine("Comece digitando os dados do medicamento.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var medicamentoEncontrado = (Medicamento)repositorioMedicamento.ObterPorId(id);
            if (medicamentoEncontrado == null)
            {
                Console.WriteLine("medicamento não encontrado...");
                return;
            }
            Medicamento medicamentoEditado = PreencherFormulario();

            medicamentoEncontrado.EditarMedicamento(medicamentoEditado);
            MostrarMensagem("Medicamento atualizado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirMedicamento()
        {
            Console.WriteLine("EXCLUINDO DADOS DO MEDICAMENTO...");

            VisualizarMedicamentos();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados do medicamento.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var medicamentoEncontrado = (Medicamento)repositorioMedicamento.ObterPorId(id);

            if (medicamentoEncontrado == null)
            {
                Console.WriteLine("medicamento não encontrado...");
                return;
            }

            repositorioMedicamento.Remover(medicamentoEncontrado);
            MostrarMensagem("Medicamento excluído com sucesso!", ConsoleColor.Green);
        }
    }
}
