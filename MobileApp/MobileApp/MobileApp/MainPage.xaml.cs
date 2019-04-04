using MobileApp.Entities;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        Tabela1Service service;
        List<Tabela1> items;

        public MainPage()
        {
            InitializeComponent();
            service = new Tabela1Service();
            AtualizaDados();
        }

        private async void AtualizaDados()
        {
            items = await service.GetTabela1Async();
            lista.ItemsSource = Listar();
        }
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        public IEnumerable<Agrupar<string, Tabela1>> Listar(string filtro = "")
        {
            IEnumerable<Tabela1> itensFiltrados = this.items;

            if (!string.IsNullOrEmpty(filtro))
                itensFiltrados = items.Where(l => (l.Descricao.ToLower().Contains(filtro.ToLower())));

            return from tabela1 in itensFiltrados
                orderby tabela1.Descricao
                group tabela1 by tabela1.Descricao into grupos
                select new Agrupar<string, Tabela1>(grupos.Key, grupos);
        }
    }
}
