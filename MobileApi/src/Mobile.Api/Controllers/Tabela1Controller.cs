using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mobile.Entity;

namespace Mobile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabela1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Tabela1> Get()
        {
            Tabela1Service service = new Tabela1Service();
            return service.ObterRegistros();
        }
    }
}
