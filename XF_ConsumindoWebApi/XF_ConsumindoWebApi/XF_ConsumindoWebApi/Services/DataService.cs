using System.Net.Http;
using XF_ConsumindoWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace XF_ConsumindoWebApi
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        /// <summary>
        /// Obtém os itens de produtos
        /// </summary>
        public async Task<List<Produto>> GetProdutosAsync()
        {
            var response = await client.GetStringAsync("http://macoratti-001-site1.etempurl.com/api/produtos");
            var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
            return produtos;
        }
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
        }
    }
}