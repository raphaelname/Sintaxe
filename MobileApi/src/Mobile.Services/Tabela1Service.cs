using Mobile.Entity;
using Mobile.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public class Tabela1Service
    {
        public IEnumerable<Tabela1> ObterRegistros()
        {
            Tabela1Repository rep = new Tabela1Repository();

            return rep.ObterRegistros();
            
        }
    }
}
