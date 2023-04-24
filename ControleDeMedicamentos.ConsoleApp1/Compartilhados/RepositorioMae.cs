using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp1.Compartilhados
{
    public class RepositorioMae
    {
        protected ArrayList registros = new ArrayList();

        private int contador = 1;

        public void Adicionar(Entidade entidade)
        {
            entidade.id = contador++;
            registros.Add(entidade);
        }

        public ArrayList ListarTodos()
        {
            return registros;
        }
        
        public Entidade ObterPorId(int id)
        {
            foreach (Entidade entidade in registros)
            {
                if(entidade.id == id)
                {
                    return entidade;
                }
            }
            return null;
        }

        public void Remover(Entidade entidade)
        {
            registros.Remove(entidade);
        }
    }
}
