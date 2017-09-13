using Projeto.Pizzaria.Dao.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Pizzaria.Dao.Interface
{
    public interface IDaoCategoriaProduto
    {
        CategoriaProduto Buscar(int id);
        IEnumerable<CategoriaProduto> Consultar(CategoriaProduto item);
        void Incluir(CategoriaProduto item);
        void Alterar(CategoriaProduto item);
        void Deletar(int id);
    }
}
