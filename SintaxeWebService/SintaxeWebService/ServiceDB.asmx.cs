using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SintaxeWebService
{
    /// <summary>
    /// Descrição resumida de ServiceDB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceDB : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable getDados()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexaoTeste"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tabela1"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "resultado";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
