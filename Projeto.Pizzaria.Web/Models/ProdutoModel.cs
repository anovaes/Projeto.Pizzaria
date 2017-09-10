using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Pizzaria.Web.Models
{
    public class ProdutoModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public bool Disponivel { get; private set; }

        public ProdutoModel(int id, string nome, string descricao, double valor, bool disponivel)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Disponivel = disponivel;

        }

    }
}