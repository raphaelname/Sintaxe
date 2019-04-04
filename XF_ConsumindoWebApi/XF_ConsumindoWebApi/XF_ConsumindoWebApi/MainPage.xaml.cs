using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF_ConsumindoWebApi.Models;
using XF_ConsumindoWebApi.Services;

namespace XF_ConsumindoWebApi
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        List<Produto> items;
        public MainPage()
        {
            InitializeComponent();
            dataService = new DataService();
            AtualizaDados();
        }

        private async void AtualizaDados()
        {
            items = await dataService.GetProdutosAsync();
            produtoLista.ItemsSource = Listar();
        }
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            produtoLista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        public IEnumerable<Agrupar<string, Produto>> Listar(string filtro = "")
        {
            IEnumerable<Produto> produtosFiltrados = this.items;

            if (!string.IsNullOrEmpty(filtro))
                produtosFiltrados = items.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower()))
                                                     || l.Categoria.ToLower().Contains(filtro.ToLower()));
            return from produto in produtosFiltrados
                orderby produto.Nome
                group produto by produto.Categoria into grupos
                select new Agrupar<string, Produto>(grupos.Key, grupos);
        }
    }
}