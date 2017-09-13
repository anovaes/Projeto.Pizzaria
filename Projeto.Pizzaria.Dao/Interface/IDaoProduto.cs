using Projeto.Pizzaria.Dao.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Pizzaria.Dao.Interface
{
    public interface IDaoProduto
    {
        Produto Buscar(int id);
        IEnumerable<Produto> Consultar(Produto item);
        void Incluir(Produto item);
        void Alterar(Produto item);
        void Deletar(int id);
    }
}
