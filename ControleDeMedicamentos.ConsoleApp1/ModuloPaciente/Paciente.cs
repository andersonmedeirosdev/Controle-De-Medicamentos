using ControleDeMedicamentos.ConsoleApp1.Compartilhados;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloPaciente
{
    public class Paciente : Entidade
    {
        public string nome;
        public string endereco;
        public string cartaoSaude;
        public string dataNascimento;

        public Paciente(string nome, string cartaoSaude, string dataNascimento, string endereco)
        {
            this.nome = nome;
            this.cartaoSaude = cartaoSaude;
            this.dataNascimento = dataNascimento;
            this.endereco = endereco;
        }
        
        public void EditarPaciente(Paciente paciente)
        {
            this.nome = paciente.nome;
            this.endereco = paciente.endereco;
            this.cartaoSaude = paciente.cartaoSaude;
            this.dataNascimento = paciente.dataNascimento;
        }

        public override string ToString()
        {
            return $"Id: {id} |  Nome: {nome} | Endereço: {endereco} | Número do cartão: {cartaoSaude} | Data de Nascimento: {dataNascimento}";
        }
    }
}