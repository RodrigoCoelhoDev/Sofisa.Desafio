using Sofisa.Desafio.Models;
using Sofisa.Desafio.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sofisa.Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeuRepositorio : ContentPage
    {
        public MeuRepositorio()
        {
            InitializeComponent();
            Progresso.IsVisible = false;

            lvRepositorio.Refreshing += lvRepositorio_Refreshing;
            Appearing += MeuRepositorio_Appearing;
        }

        private void MeuRepositorio_Appearing(object sender, EventArgs e)
        {
            AtivarProgresso(true);
            CarregarListaDeRepositorios();
        }

        private async void lvRepositorio_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            CarregarListaDeRepositorios();
            lvRepositorio.IsRefreshing = false;
        }

        private async void CarregarListaDeRepositorios()
        {
            var lstMeusRepositorios = await ObterListaDeRepositoriosDaAPI();
            lvRepositorio.ItemsSource = null;
            lvRepositorio.ItemsSource = lstMeusRepositorios;

            AtivarProgresso(false);
        }

        private async Task<List<Repositorio>> ObterListaDeRepositoriosDaAPI()
        {
            return await new RepositorioVM().ObterListaDeRepositoriosDaAPI();
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
    }
}