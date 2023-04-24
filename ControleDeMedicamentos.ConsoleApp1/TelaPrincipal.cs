using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1
{
    internal class TelaPrincipal
    {
       public string ApresentarMenu()
       {
            Console.WriteLine("--MENU DE OPÇÕES--");
            Console.WriteLine("[1] PARA MENU PACIENTE");
            Console.WriteLine("[2] PARA MENU FUNCIONÁRIO");
            Console.WriteLine("[3] PARA MENU FORNECEDOR");
            Console.WriteLine("[4] PARA MENU MEDICAMENTOS");
            Console.WriteLine("[5] PARA MENU REQUISIÇÕES");
            Console.WriteLine("[6] PARA MENU REPOSIÇÕES");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
