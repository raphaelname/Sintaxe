using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface ITabela1Repositorio
    {
        IEnumerable<Tabela1> GetAll();
        Tabela1 Get(int id);
        Tabela1 Add(Tabela1 item);
        void Remove(int id);
        bool Update(Tabela1 item);
    }
}
