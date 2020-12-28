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
    public partial class ListarFavorito : ContentPage
    {
        public ListarFavorito()
        {
            InitializeComponent();
            Progresso.IsVisible = false;

            lvFavoritos.Refreshing += lvFavoritos_Refreshing;
            Appearing += Favorito_Appearing;
        }
        private void Favorito_Appearing(object sender, EventArgs e)
        {
            AtivarProgresso(true);
            CarregarListaDeFavoritos();
        }

        private async void lvFavoritos_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            CarregarListaDeFavoritos();
            lvFavoritos.IsRefreshing = false;
        }

        private async void CarregarListaDeFavoritos()
        {
            var lstApontamento = await ObterListaDeFavoritosDaAPI();
            lvFavoritos.ItemsSource = null;
            lvFavoritos.ItemsSource = lstApontamento;

            AtivarProgresso(false);
        }

        private async Task<List<Repositorio>> ObterListaDeFavoritosDaAPI()
        {
            return await new FavoritoVM().ObterListaDeFavoritosDaAPI();
        }

        private void AtivarProgresso(bool statusProgresso)
        {
            Progresso.IsRunning = statusProgresso;
            Progresso.IsVisible = statusProgresso;
        }


        private void lvFavoritos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvFavoritos.SelectedItem = null;
        }

        private void lvFavoritos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var repositorio = e.Item as Repositorio;
            Navigation.PushAsync(new DetalheRepositorio(repositorio));
        }
    }
}