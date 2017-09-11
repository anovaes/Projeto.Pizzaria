using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Pizzaria.Web.Models
{
    public class CategoriaProdutoModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PercentualDesconto { get; set; }
    }
}