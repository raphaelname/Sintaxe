using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_Agenda.Models;
using XF_Agenda.ViewModels;

namespace XF_Agenda
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new ContatoListaViewModel();
        }
	}
}
