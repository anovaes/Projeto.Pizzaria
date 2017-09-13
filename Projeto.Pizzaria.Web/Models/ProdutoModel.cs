using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Pizzaria.Web.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoriaProduto { get; set; }
        public string NomeCategoriaProduto { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public bool Disponivel { get; set; }

        public IEnumerable<CategoriaProdutoModel> CategoriaProduto { get; set; }
    }
}