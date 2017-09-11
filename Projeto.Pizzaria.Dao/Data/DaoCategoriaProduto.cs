using Dapper;
using Projeto.Pizzaria.Dao.Entidade;
using Projeto.Pizzaria.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Pizzaria.Dao.Data
{
    public class DaoCategoriaProduto : IDao<CategoriaProduto>
    {
        public void Alterar(CategoriaProduto item)
        {
            throw new NotImplementedException();
        }

        public CategoriaProduto Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaProduto> Consultar(CategoriaProduto item)
        {
            var query = @"
                select * from t_categoria_produto
                where 
                    (@IdCategoria is null or id_categoria_produto = @IdCategoria) and
                    (@NomeCategoria is null or nome_categoria_produto = @NomeCategoria)";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                var categorias = conn.Query<CategoriaProduto>(query, new { IdCategoria = item.Id, NomeCategoria = item.Nome });
                return categorias.ToList();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(CategoriaProduto item)
        {
            throw new NotImplementedException();
        }
    }
}
