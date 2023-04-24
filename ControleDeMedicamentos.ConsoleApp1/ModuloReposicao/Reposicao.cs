using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp1.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloReposicao
{
    public class Reposicao : Entidade
    {
        public string descricao;
        public int quantidade;
        public Medicamento medicamento;
        public Funcionario funcionario;

        public Reposicao(string descricao, int quantidade, Medicamento medicamento, Funcionario funcionario)
        {
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
        }

        public void Editar(Reposicao reposicao)
        {
            this.descricao = reposicao.descricao;
            this.medicamento = reposicao.medicamento;
            this.funcionario = reposicao.funcionario;
        }

        public override string ToString()
        {
            return $"Id: {id} | Descrição: {descricao} | Medicamento: {medicamento.nomeMedicamento} | Funcionario: {funcionario.nome}";
        }
    }
}
