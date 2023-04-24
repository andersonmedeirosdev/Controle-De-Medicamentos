using ControleDeMedicamentos.ConsoleApp1.Compartilhados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {
        public string nomeEmpresa;
        public string telefoneEmpresa;
        public string endereco;

        public Fornecedor(string empresa, string telefoneEmpresa, string endereco)
        {
            this.nomeEmpresa = empresa;
            this.telefoneEmpresa = telefoneEmpresa;
            this.endereco = endereco;
        }

        public void EditarFornecedor(Fornecedor fornecedor)
        {
            this.nomeEmpresa = fornecedor.nomeEmpresa;
            this.telefoneEmpresa = fornecedor.telefoneEmpresa;
            this.endereco = fornecedor.endereco;
        }

        public override string ToString()
        {
            return $"Id: {id} | Empresa: {nomeEmpresa} | Telefone: {telefoneEmpresa} | Endereço: {endereco}";
        }
    }
}
