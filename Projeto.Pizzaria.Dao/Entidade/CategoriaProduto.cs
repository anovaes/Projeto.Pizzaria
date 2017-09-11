using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Pizzaria.Dao.Entidade
{
    public class CategoriaProduto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PercentualDesconto { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
