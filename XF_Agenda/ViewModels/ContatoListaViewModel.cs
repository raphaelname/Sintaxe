using System.Collections.Generic;
using System.Linq;
using XF_Agenda.Models;

namespace XF_Agenda.ViewModels
{
    public class ContatoListaViewModel
    {
        public IList<Contato> Items { get; private set; }
        public List<ObservableGroupCollection<string,Contato>> DadosAgrupados { get; set; }
        public int ItemsCount { get; private set; }
        public string MeuNumero { get; set; } = "+55 (11) 1111-1111";

        public ContatoListaViewModel()
        {
            var repo = new ContatoRepository();
            Items = repo.GetContatos.OrderBy(c => c.Nome).ToList();

            DadosAgrupados = Items.OrderBy(p => p.Nome)
                             .GroupBy(p => p.Nome[0].ToString())
                             .Select(p => new ObservableGroupCollection<string, Contato>(p)).ToList();

            ItemsCount = repo.GetContatos.Count;
        }
    }
}
