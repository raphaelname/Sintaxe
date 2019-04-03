using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tabela1Repositorio: ITabela1Repositorio
    {
        private List<Tabela1> itens = new List<Tabela1>();
        private int _nextId = 1;

        public Tabela1Repositorio()
        {
            //getdobanco dando add nos itens

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

                            int indexColunaId = dt.Columns["id"].Ordinal;
                            int indexColunaDescricao = dt.Columns["descricao"].Ordinal;
                            int indexColunaData = dt.Columns["data"].Ordinal;

                            foreach (DataRow linha in dt.Rows)
                            {
                                Tabela1 item = new Tabela1();

                                //Atribui os valores da linha de seu dataTable para o seu objeto que será adicionado na lista
                                item.id = (int)linha[indexColunaId];
                                item.descricao = ((string)linha[indexColunaDescricao]).Trim();
                                item.data = (DateTime)linha[indexColunaData];

                                Add(item);
                            }
                        }
                    }
                }
            }

            /*Add(new Tabela1 { descricao = "Guaraná Antartica"});
            Add(new Tabela1 { descricao = "Suco de Laranja Prats"});
            Add(new Tabela1 { descricao = "Mostarda Hammer"});
            Add(new Tabela1 { descricao = "Molho de Tomate Cepera"});
            Add(new Tabela1 { descricao = "Suco de Uva Aurora"});
            Add(new Tabela1 { descricao = "Pepsi-Cola"});*/

        }

        public Tabela1 Add(Tabela1 item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.id = _nextId++;
            itens.Add(item);
            return item;
        }

        public Tabela1 Get(int id)
        {
            return itens.Find(p => p.id == id);
        }

        public IEnumerable<Tabela1> GetAll()
        {
            return itens;
        }

        public void Remove(int id)
        {
            itens.RemoveAll(p => p.id == id);
        }

        public bool Update(Tabela1 item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = itens.FindIndex(p => p.id == item.id);

            if (index == -1)
            {
                return false;
            }
            itens.RemoveAt(index);
            itens.Add(item);
            return true;
        }
    }
}