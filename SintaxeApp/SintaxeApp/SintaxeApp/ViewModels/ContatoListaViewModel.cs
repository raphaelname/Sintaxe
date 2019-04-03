using SintaxeApp.Models;
using SintaxeApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SintaxeApp.ViewModels
{
    public class ContatoListaViewModel
    {
        public IList<Contato> Items { get; private set; }
        public int ItemsCount { get; private set; }
        public string MeuNumero { get; set; } = "+55 (11) 1111-1111";

        public ContatoListaViewModel()
        {
            var repo = new ContatoRepository();
            Items = repo.GetContatos.OrderBy(c => c.Nome).ToList();
            ItemsCount = repo.GetContatos.Count;
        }
    }
}
