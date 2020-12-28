using Sofisa.Desafio.Models;
using Sofisa.Desafio.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sofisa.Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheRepositorio : ContentPage
    {
        Repositorio _repositorio;
        public DetalheRepositorio(Repositorio repositorio)
        {
            InitializeComponent();
            _repositorio = repositorio;
            CarregarDadosDoRepositorio();

        }

        private void CarregarDadosDoRepositorio()
        {
            txtNome.Text = _repositorio.name;
            txtDescricao.Text = _repositorio.description;
            txtLinguagem.Text = _repositorio.language;
            txtProprietario.Text = _repositorio.full_name.Split('/')[0];
            txtAtualizacao.Text = _repositorio.updated_at.ToString("dd/MM/yyyy HH:mm");

            CarregarListaDeContribuintes();
            VerificarRepositorioFavorito();
        }

        private async void CarregarListaDeContribuintes()
        {
            var lstContribuintes = await ObterListaDeContribuintesDaAPI();
            lvContibuinte.ItemsSource = null;
            lvContibuinte.ItemsSource = lstContribuintes;
        }

        private async Task<List<RepositorioContribuinte>> ObterListaDeContribuintesDaAPI()
        {
            string nomeProprietario = _repositorio.full_name.Split('/')[0];
            return await new RepositorioVM().ObterListaDeContribuintesDoRepositorioNaAPI(nomeProprietario, _repositorio.name);
        }

        private void lvContibuinte_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lvContibuinte.SelectedItem = null;
        }



        private async void VerificarRepositorioFavorito()
        {
            var resultado = await new FavoritoVM().ObterFavoritosPorIDnaAPI(_repositorio.id);

            if (resultado.id == 0)
            {
                btnFavorito.IconImageSource = "img_favoritoOFF.png";
                btnFavorito.Text = "OFF";
            }
            else
            {
                btnFavorito.IconImageSource = "img_favoritoON.png";
                btnFavorito.Text = "ON";
            }
        }

        private async void btnFavorito_Clicked(object sender, System.EventArgs e)
        {
            if (btnFavorito.Text == "OFF")
            {
                if (await new FavoritoVM().InserirFavoritoNaAPI(_repositorio))
                {
                    btnFavorito.IconImageSource = "img_favoritoON.png";
                    btnFavorito.Text = "ON";
                }

            }
            else
            {
                if (await new FavoritoVM().DeletarFavoritoNaAPI(_repositorio.id))
                {
                    btnFavorito.IconImageSource = "img_favoritoOFF.png";
                    btnFavorito.Text = "OFF";
                }
            }

        }
    }
}