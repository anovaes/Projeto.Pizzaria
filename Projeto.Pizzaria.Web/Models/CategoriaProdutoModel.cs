using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Pizzaria.Web.Models
{
    public class CategoriaProdutoModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double PercentualDesconto { get; private set; }

        public CategoriaProdutoModel(int id, string nome, string descricao, double percentual)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            PercentualDesconto = percentual;
        }
    }
}