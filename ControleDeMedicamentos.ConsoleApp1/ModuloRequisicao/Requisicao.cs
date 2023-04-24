using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp1.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloRequisicao
{
    public class Requisicao : Entidade
    { 
        public string descricao;
        public int quantidade;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public Paciente paciente;

        public Requisicao(string descricao, int quantidade, Medicamento medicamento, Funcionario funcionario, Paciente paciente)
        {
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            this.paciente = paciente;
        }

        public void Editar(Requisicao requisicao)
        {
            this.descricao = requisicao.descricao;
            this.medicamento = requisicao.medicamento;
            this.funcionario = requisicao.funcionario;
            this.paciente = requisicao.paciente;
        }

        public override string ToString()
        {
            return $"Id: {id} | Descrição: {descricao} | Medicamento: {medicamento.nomeMedicamento} | Funcionario: {funcionario.nome} | Paciente: {paciente.nome}";
        }
    }
}
