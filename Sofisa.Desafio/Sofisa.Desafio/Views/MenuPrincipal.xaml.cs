using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sofisa.Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : MasterDetailPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuPrincipalDetail());
        }

        private void MeuRepositorio(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new MeuRepositorio());
            IsPresented = false;
        }

        private void ProcurarRepositorio(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new ProcurarRepositorio());
            IsPresented = false;
        }

        private void Favoritos(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new ListarFavorito());
            IsPresented = false;
        }
    }
}