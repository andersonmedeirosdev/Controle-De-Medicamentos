using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario
{
    public class Funcionario : Entidade
    {
        public string nome;
        public string codigo;
        public string cracha;
        public string unidadeSaude;

        public Funcionario(string nome, string cracha, string unidadeSaude)
        {
            this.nome = nome;
            this.cracha = cracha;
            this.unidadeSaude = unidadeSaude;
        }

        public void EditarFuncionario(Funcionario funcionario)
        {
            this.nome = funcionario.nome;
            this.cracha = funcionario.cracha;
            this.unidadeSaude = funcionario.unidadeSaude;
        }

        public override string ToString()
        {
            return $"Id: {id} | Nome: {nome} | Cracha: {cracha} | UBS: {unidadeSaude}";
        }
    }
}
