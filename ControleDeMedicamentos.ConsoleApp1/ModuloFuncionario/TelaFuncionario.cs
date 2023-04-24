using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using System.Collections;


namespace ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario
{
    internal class TelaFuncionario : Tela
    {
        public RepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--MENU FUNCIONARIOS--");
            Console.WriteLine("([1] PARA CADASTRAR");
            Console.WriteLine("([2] PARA VISUALIZAR");
            Console.WriteLine("([3] PARA EDITAR");
            Console.WriteLine("([4] PARA EXCLUIR");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public Funcionario PreencherFormulario()
        {
            Console.Clear();

            MostrarCabecalho("INICIANDO CADASTRO DE NOVO FUNCIONÁRIO...", "Digite os dados solicitados no formulário abaixo.");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Número do crachá: ");
            string cracha = Console.ReadLine();
            Console.Write("Posto de Saúde: ");
            string unidadeSaude = Console.ReadLine();
            return new Funcionario(nome, cracha, unidadeSaude);
        }
        
        public void CadastrarFuncionario()
        {
            Funcionario funcionario = PreencherFormulario();
            repositorioFuncionario.Adicionar(funcionario);
        }

        public void VisualizarFuncionarios()
        {
            MostrarCabecalho("FUNCIONÁRIOS CADASTRADOS!", "Visualizando funcionários cadastrados...");
            ArrayList funcionarios = repositorioFuncionario.ListarTodos();
            if (funcionarios.Count == 0)
            {
                Console.WriteLine("Ainda não temos funcionários cadastrados...");
            }
            foreach (Funcionario funcionario in funcionarios)
            {
                Console.WriteLine(funcionario);
            }
            Console.ReadLine();
        }

        public void EditarFuncionario()
        {
            Console.WriteLine("EDITANDO DADOS DO FUNCIONÁRIO...");

            VisualizarFuncionarios();

            Console.WriteLine("ATUALIZAR DADOS...");
            Console.WriteLine("Comece digitando os dados do funcionário.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var funcionarioEncontrado = (Funcionario)repositorioFuncionario.ObterPorId(id);
            if (funcionarioEncontrado == null)
            {
                Console.WriteLine("funcionário não encontrado...");
                return;
            }
            Funcionario funcionarioEditado = PreencherFormulario();

            funcionarioEncontrado.EditarFuncionario(funcionarioEditado);
            MostrarMensagem("Funcionário atualizado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirFuncionario()
        {
            Console.WriteLine("EXCLUINDO DADOS DO FUNCIONÁRIO...");

            VisualizarFuncionarios();

            Console.WriteLine("SIGA AS INSTRUÇÕES...");
            Console.WriteLine("Comece digitando os dados do funcionário.");
            Console.WriteLine("Isso para que possamos encontrar no sistema.");
            Console.Write("Digite o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var funcionarioEncontrado = (Funcionario)repositorioFuncionario.ObterPorId(id);

            if (funcionarioEncontrado == null)
            {
                Console.WriteLine("funcionário não encontrado...");
                return;
            }

            repositorioFuncionario.Remover(funcionarioEncontrado);
            MostrarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
        }
    }
}
