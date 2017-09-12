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

    public class DaoProduto : IDao<Produto>
    {
        public void Alterar(Produto item)
        {
            var query = @"
                UPDATE t_produto
                   SET 
                    id_categoria_produto  = @IdProduto, 
                    nome_produto  = @NomeProduto, 
                    desc_produto     = @Descricao,
                    valor_produto   = @ValorProduto,
                    flag_disponivel  = @Disponivel
                WHERE id_produto = @Id";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute(query, item);
            }
        }

        public Produto Buscar(int id)
        {
            var query = @"
                SELECT 
                    Id                  = id_prosuto
                    IdCategoria         = id_categoria_produto,
                    Nome                = nome__produto,
                    Descricao           = desc__produto,
                    ValorProduto        = valor_produto,
                    Disponivel          = flag_disponivel
                FROM t_produto
                WHERE 
                    (id_produto = @Id)";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                var categoria = conn.Query<Produto>(query, new { Id = id });
                return categoria.ToList().FirstOrDefault();
            }
        }

        public IEnumerable<Produto> Consultar(Produto item)
        {
            var query = @"
                SELECT 
                    Id                  = id_produto
                    IdCategoria         = id_categoria_produto,
                    Nome                = nome__produto,
                    Descricao           = desc__produto,
                    ValorProduto        = valor_produto,
                    Disponivel          = flag_disponivel
                FROM t_produto
                WHERE (id_produto = @IdProduto) and
                    (@NomeCategoria is null or nome_produto = @NomeProduto)";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                var categorias = conn.Query<Produto>(query, new { IdProduto = item.Id, NomeProduto = item.Nome });
                return categorias.ToList();
            }
        }

        public void Deletar(int id)
        {
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("DELETE FROM t_produto WHERE id_produto = @Id", new { Id = id });
            }
        }

        public void DeletarProdutosTodos()
        {
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("DELETE FROM t_produto");
            }
        }

        public void Incluir(Produto item)
        {
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("INSERT INTO t_produto(id_categoria_produto,nome_produto, desc_produto,valor_produto,flag_disponivel) VALUES (@IdCategoria,@NomeProduto, @DescricaoProduto, @ValorProduto,@FlagDisponivel)", item);
            }
        }
    }
}
