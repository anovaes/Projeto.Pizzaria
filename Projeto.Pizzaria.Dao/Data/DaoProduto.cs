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

    public class DaoProduto : IDaoProduto
    {
        public void Alterar(Produto item)
        {
            var query = @"
                UPDATE t_produto
                   SET 
                    id_categoria_produto  = @IdCategoriaProduto, 
                    nome_produto  = @Nome, 
                    desc_produto     = @Descricao,
                    valor_produto   = @Valor,
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
                    Id                  = id_produto,
                    IdCategoriaProduto  = id_categoria_produto,
                    Nome                = nome_produto,
                    Descricao           = desc_produto,
                    Valor               = valor_produto,
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
                    Id                      = p.id_produto,
                    IdCategoria             = p.id_categoria_produto,
	                NomeCategoriaProduto	= cp.nome_categoria_produto,
                    Nome                    = p.nome_produto,
                    Descricao               = p.desc_produto,
                    Valor                   = p.valor_produto,
                    Disponivel              = p.flag_disponivel
                FROM t_produto p
                join t_categoria_produto cp
                 on(p.id_categoria_produto = cp.id_categoria_produto)";

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
                conn.Execute("INSERT INTO t_produto(id_categoria_produto,nome_produto, desc_produto,valor_produto,flag_disponivel) VALUES (@IdCategoriaProduto,@Nome, @Descricao, @Valor,@Disponivel)", item);
            }
        }
    }
}
