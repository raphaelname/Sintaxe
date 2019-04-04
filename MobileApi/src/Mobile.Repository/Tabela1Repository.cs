using Dapper;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Mobile.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Mobile.Repository
{
    public class Tabela1Repository
    {
        public IEnumerable<Tabela1> ObterRegistros()
        {
            using (SqlConnection conexao = new SqlConnection(connectionString: "Server=localhost;Database=teste;User ID=sa;Password=teste"))
            {
                return conexao.Query<Tabela1>(sql: "SELECT * FROM tabela1");
            }
        }
    }
}
