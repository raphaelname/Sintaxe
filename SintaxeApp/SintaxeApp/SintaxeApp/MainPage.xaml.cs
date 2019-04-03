using Xamarin.Forms;
using SintaxeApp.ViewModels;
using System;

namespace XF_AgendaContatos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ContatoListaViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
