using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Pizzaria.Dao.Interface
{
    public interface IDao<T>
    {
        T Buscar(int id);
        IEnumerable<T> Consultar(T item);
        void Incluir(T item);
        void Alterar(T item);
        void Deletar(int id);
    }
}
