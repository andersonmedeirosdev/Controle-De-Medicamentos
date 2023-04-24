
using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloPaciente
{
    internal class TelaPaciente : Tela
    {
        private RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente) 
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU PACIENTES--");
            Console.WriteLine("([1] PARA CADASTRAR");
            Console.WriteLine("([2] PARA VISUALIZAR");
            Console.WriteLine("([3] PARA EDITAR");
            Console.WriteLine("([4] PARA EXCLUIR");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Paciente PreencherFomulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVO PACIENTE...", "Digite os dados solicitados no formulário abaixo.");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Número do cartão saúde: ");
            string cartaoSaude = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            string dataNascimento = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            return new Paciente(nome, cartaoSaude, dataNascimento, endereco);
        }

        public void CadastrarPaciente()
        {
            Paciente paciente = PreencherFomulario();
            repositorioPaciente.Adicionar(paciente);
        }

        public void VisualizarPacientes()
        {
            MostrarCabecalho("PACIENTES CADASTRADOS!", "Visualizando pacientes cadastrados...");
            ArrayList pacientes = repositorioPaciente.ListarTodos();
            if (pacientes.Count == 0)
            {
                Console.WriteLine("Ainda não temos pacientes cadastrados...");
            }
            foreach (Paciente paciente in pacientes) 
            {
                Console.WriteLine(paciente);
            }
            Console.ReadLine();
        }

        public void EditarPaciente()
        {
            Console.WriteLine("EDITANDO DADOS DO PACIENTE...");

            VisualizarPacientes();

            Console.WriteLine("ATUALIZAR DADOS...");
            Console.WriteLine("Comece digitando os dados do paciente.");
            Console.WriteLine("Isso para que possamos encontrá-lo no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var pacienteEncontrado = (Paciente)repositorioPaciente.ObterPorId(id);
            if (pacienteEncontrado == null)
            {
                Console.WriteLine("paciente não encontrado...");
                return;
            }
            Paciente pacienteEditado = PreencherFomulario();

            pacienteEncontrado.EditarPaciente(pacienteEditado);
            MostrarMensagem("Paciente atualizado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirPaciente()
        {
            Console.WriteLine("EXCLUINDO DADOS DO PACIENTE...");

            VisualizarPacientes();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados do paciente.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var pacienteEncontrado = (Paciente)repositorioPaciente.ObterPorId(id);

            if (pacienteEncontrado == null)
            {
                Console.WriteLine("paciente não encontrado...");
                return;
            }

            repositorioPaciente.Remover(pacienteEncontrado);
            MostrarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
        }
    }
}
