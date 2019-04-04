using System;
using System.Collections.Generic;
using System.Text;

namespace XF_ConsumindoWebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Foto { get; set; }
    }
}
