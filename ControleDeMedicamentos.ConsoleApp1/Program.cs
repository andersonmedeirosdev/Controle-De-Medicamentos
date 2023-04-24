using ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp1.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp1.ModuloReposicao;
using ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao;

namespace ControleDeMedicamentos.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioMedicamento, repositorioFornecedor, repositorioFuncionario, repositorioPaciente, repositorioRequisicao);
            RepositorioReposicao repositorioReposicao = new RepositorioReposicao();
            TelaReposicao telaReposicao = new TelaReposicao(repositorioMedicamento, repositorioFornecedor, repositorioFuncionario, repositorioReposicao);

            while (true)
            {
                Console.Clear();
                string opcao = telaPrincipal.ApresentarMenu();

                if (opcao == "1")
                {
                    string opcaoPaciente = telaPaciente.ApresentarMenu();

                    if (opcaoPaciente == "1")
                    {
                        telaPaciente.CadastrarPaciente();
                        Console.ReadLine();
                    }
                    else if (opcaoPaciente == "2")
                    {
                        telaPaciente.VisualizarPacientes();
                    }
                    else if (opcaoPaciente == "3")
                    {
                        telaPaciente.EditarPaciente();
                    }
                    else if (opcaoPaciente == "4")
                    {
                        telaPaciente.ExcluirPaciente();
                    }
                    continue;
                }
                else if (opcao == "2")
                {
                    telaFuncionario.ApresentarMenu();
                    {
                        string opcaoFuncionario = telaFuncionario.ApresentarMenu();

                        if (opcaoFuncionario == "1")
                        {
                            telaFuncionario.CadastrarFuncionario();
                            Console.ReadLine();
                        }
                        else if (opcaoFuncionario == "2")
                        {
                            telaFuncionario.VisualizarFuncionarios();
                        }
                        else if (opcaoFuncionario == "3")
                        {
                            telaFuncionario.EditarFuncionario();
                        }
                        else if (opcaoFuncionario == "4")
                        {
                            telaFuncionario.ExcluirFuncionario();
                        }
                        continue;
                    }
                }
                else if (opcao == "3")
                {
                    telaFornecedor.ApresentarMenu();
                    {
                        string opcaoFornecedor = telaFornecedor.ApresentarMenu();

                        if (opcaoFornecedor == "1")
                        {
                            telaFornecedor.CadastrarFornecedor();
                            Console.ReadLine();
                        }
                        else if (opcaoFornecedor == "2")
                        {
                            telaFornecedor.VisualizarFornecedores();
                        }
                        else if (opcaoFornecedor == "3")
                        {
                            telaFornecedor.EditarFornecedor();
                        }
                        else if (opcaoFornecedor == "4")
                        {
                            telaFornecedor.ExcluirFornecedor();
                        }
                        continue;
                    }
                }
                else if (opcao == "4")
                {
                    telaMedicamento.ApresentarMenu();
                    {
                        string opcaoMedicamento = telaMedicamento.ApresentarMenu();

                        if (opcaoMedicamento == "1")
                        {
                            telaMedicamento.CadastrarMedicamento();
                            Console.ReadLine();
                        }
                        else if (opcaoMedicamento == "2")
                        {
                            telaMedicamento.VisualizarMedicamentos();
                        }
                        else if (opcaoMedicamento == "3")
                        {
                            telaMedicamento.EditarMedicamento();
                        }
                        else if (opcaoMedicamento == "4")
                        {
                            telaMedicamento.ExcluirMedicamento();
                        }
                        else if (opcaoMedicamento == "5")
                        {
                            telaMedicamento.VisualizarMedicamentoOrdenados();
                        }
                        continue;
                    }
                }
                else if (opcao == "5")
                {
                    telaRequisicao.ApresentarMenu();
                    {
                        string opcaoRequisicao = telaRequisicao.ApresentarMenu();

                        if (opcaoRequisicao == "1")
                        {
                            telaRequisicao.CadastrarRequisicao();
                            Console.ReadLine();
                        }
                        else if (opcaoRequisicao == "2")
                        {
                            telaRequisicao.VisualizarRequisicoes();
                        }
                        else if (opcaoRequisicao == "3")
                        {
                            telaRequisicao.EditarRequisicao();
                        }
                        else if (opcaoRequisicao == "4")
                        {
                            telaRequisicao.ExcluirRequisicao();
                        }
                        else if (opcaoRequisicao == "5")
                        {
                            telaRequisicao.MedicamentosMaisSolicitados();
                        }
                        continue;
                    }
                }
                else if (opcao == "6")
                {
                    telaReposicao.ApresentarMenu();
                    {
                        string opcaoReposicao = telaReposicao.ApresentarMenu();

                        if (opcaoReposicao == "1")
                        {
                            telaReposicao.CadastrarReposicao();
                            Console.ReadLine();
                        }
                        else if (opcaoReposicao == "2")
                        {
                            telaReposicao.VisualizarReposicoes();
                        }
                        else if (opcaoReposicao == "3")
                        {
                            telaReposicao.EditarReposicao();
                        }
                        else if (opcaoReposicao == "4")
                        {
                            telaReposicao.ExcluirReposicao();
                        }
                        continue;
                    }
                }
            }
        }
    }
}