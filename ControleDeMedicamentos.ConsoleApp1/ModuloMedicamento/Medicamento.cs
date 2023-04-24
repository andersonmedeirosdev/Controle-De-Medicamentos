using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string nomeMedicamento;
        public string descricao;
        public int quantidade;
        public Fornecedor fornecedor;

        public Medicamento(string nomeMedicamento, string descricao, int quantidade, Fornecedor fornecedor)
        {
            this.nomeMedicamento = nomeMedicamento;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.fornecedor = fornecedor;
        }

        public void EditarMedicamento(Medicamento medicamento)
        {
            this.nomeMedicamento = medicamento.nomeMedicamento;
            this.descricao = medicamento.descricao;
            this.quantidade = medicamento.quantidade;
            this.fornecedor = medicamento.fornecedor;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            this.quantidade += quantidade;
        }

        public bool DiminuirQuantidade(int quantidade)
        {
            if (this.quantidade > quantidade)
            {
                this.quantidade -= quantidade;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Id: {id} | Medicamento: {nomeMedicamento} | Descrição: {descricao} | Fornecedor: {fornecedor.nomeEmpresa} | Quantidade: {quantidade}";
        }
    }
}
