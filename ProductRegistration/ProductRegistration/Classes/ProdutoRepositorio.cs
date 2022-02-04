using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductRegistration.interfaces;

namespace ProductRegistration.Classes
{
    internal class ProdutoRepositorio : IRepositorio<Produtos>
    {

        private List<Produtos> listaProdutos = new List<Produtos> ();
        public void Atualiza(int id, Produtos entidade)
        {
            listaProdutos[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaProdutos[id].Excluir();
        }

        public void Insere(Produtos entidade)
        {
            listaProdutos.Add(entidade);
        }

        public List<Produtos> Lista()
        {
            return listaProdutos;
        }

        public int ProximoId()
        {
            return listaProdutos.Count;
        }

        public Produtos RetonadoPorId(int id)
        {
            return listaProdutos [id];
        }
    }
}
