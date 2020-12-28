using Sofisa.Desafio.Models;
using Sofisa.Desafio.ViewModel;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sofisa.Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcurarRepositorio : ContentPage
    {
        public ProcurarRepositorio()
        {
            InitializeComponent();
            Progresso.IsVisible = false;
        }

        private void CarregarListaDeRepositorios(List<Repositorio> repositorio)
        {
            lvRepositorio.ItemsSource = null;
            lvRepositorio.ItemsSource = repositorio;

            AtivarProgresso(false);
        }

        private async void BuscarRepositorio(string nomeRepositorio)
        {
            if (nomeRepositorio != string.Empty)
            {
                CarregarListaDeRepositorios(await new RepositorioVM().ProcurarRepositoriosNaAPI(nomeRepositorio));
            }
            else
            {
                CarregarListaDeRepositorios(new List<Repositorio>());
            }
        }

        private void AtivarProgresso(bool statusProgresso)
        {
            Progresso.IsRunning = statusProgresso;
            Progresso.IsVisible = statusProgresso;
        }

        private void lvRepositorio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvRepositorio.SelectedItem = null;
        }

        private void lvRepositorio_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var repositorio = e.Item as Repositorio;
            Navigation.PushAsync(new DetalheRepositorio(repositorio));
        }

        private void btnBuscar_Clicked(object sender, System.EventArgs e)
        {
            AtivarProgresso(true);

            BuscarRepositorio(txtNomeRepositorio.Text);
        }
    }
}