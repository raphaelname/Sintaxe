using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using MobileApp.Entities;

namespace MobileApp.Services
{
    public class Tabela1Service
    {
        HttpClient client = new HttpClient();

        /// <summary>
        /// Obtém os registros de tabela1
        /// </summary>
        public async Task<List<Tabela1>> GetTabela1Async()
        {
            var response = await client.GetStringAsync("http://localhost/sintaxe/api/tabela1");
            var lista = JsonConvert.DeserializeObject<List<Tabela1>>(response);
            return lista;
        }






        /*
        /// <summary>
        /// Adiciona um item de produto
        /// </summary>
        /// <param name="itemToAdd">Item a adicionar.</param>
        public async Task<int> AddProdutoAsync(Produto itemToAdd)
        {
            var data = JsonConvert.SerializeObject(itemToAdd);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://macoratti-001-site1.etempurl.com/api/produtos", content);
            var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
        /// <summary>
        /// Atualiza um item
        /// </summary>
        /// <param name="itemIndex">indice do Item.</param>
        /// <param name="itemToUpdate">Item a atualizar.</param>
        public async Task<int> UpdateProdutoAsync(int itemIndex, Produto itemToUpdate)
        {
            var data = JsonConvert.SerializeObject(itemToUpdate);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(string.Concat("http://macoratti-001-site1.etempurl.com/api/produtos",
 itemIndex), content);
            return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
        }
        /// <summary>
        /// Deleta um item 
        /// </summary>
        /// <returns>O id do item a deletar.</returns>
        /// <param name="itemIndex">indice do item.</param>
       public async Task DeleteProdutoAsync(int itemIndex)
        {
            await client.DeleteAsync(string.Concat("http://macoratti-001-site1.etempurl.com/api/produtos", itemIndex));
        }*/
    }
}
