﻿using Dapper;
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
    public class DaoCategoriaProduto : IDaoCategoriaProduto
    {
        public void Alterar(CategoriaProduto item)
        {
            var query = @"
                UPDATE t_categoria_produto
                   SET 
                    nome_categoria_produto  = @Nome, 
                    desc_categoria_produto  = @Descricao, 
                    percentual_desconto     = @PercentualDesconto
                WHERE id_categoria_produto = @Id";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute(query, item);
            }
        }

        public CategoriaProduto Buscar(int id)
        {
            var query = @"
                SELECT 
                    Id                  = id_categoria_produto,
                    Nome                = nome_categoria_produto,
                    Descricao           = desc_categoria_produto,
                    PercentualDesconto  = percentual_desconto
                FROM t_categoria_produto
                WHERE 
                    (id_categoria_produto = @IdCategoria)";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                var categoria = conn.Query<CategoriaProduto>(query, new { IdCategoria = id});
                return categoria.ToList().FirstOrDefault();
            }
        }

        public List<IDaoCategoriaProduto> BuscarTodos()
        {
            var query = @"
                SELECT 
                    Id                  = id_categoria_produto,
                    Nome                = nome_categoria_produto,
                    Descricao           = desc_categoria_produto,
                    PercentualDesconto  = percentual_desconto
                FROM t_categoria_produto";

            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                var categoria = conn.Query<IDaoCategoriaProduto>(query);
                return categoria.ToList();
            }
        }
        public IEnumerable<CategoriaProduto> Consultar(CategoriaProduto item)
        {
            var query = @"
                SELECT 
                    Id                  = id_categoria_produto,
                    Nome                = nome_categoria_produto,
                    Descricao           = desc_categoria_produto,
                    PercentualDesconto  = percentual_desconto
                FROM t_categoria_produto
                WHERE 
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
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("DELETE FROM t_categoria_produto WHERE id_categoria_produto = @Id", new { Id = id});
            }
        }


        public void DeletarCategoriasTodas()
        {
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("DELETE FROM t_categoria_produto");
            }
        }

        public void Incluir(CategoriaProduto item)
        {
            using (var conn = new SqlConnection(Util.Util.ConnectionString()))
            {
                conn.Execute("INSERT INTO t_categoria_produto(nome_categoria_produto, desc_categoria_produto, percentual_desconto) VALUES(@Nome, @Descricao, @PercentualDesconto)", item);
            }
        }
    }
}
