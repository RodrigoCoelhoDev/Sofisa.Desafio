using Sofisa.Desafio.Models;
using Sofisa.Desafio.Servico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sofisa.Desafio.ViewModel
{
    public class FavoritoVM
    {
        WebAPI _webAPI;
        EnderecoAPI _endPointURL;

        public FavoritoVM()
        {
            _webAPI = new WebAPI();
            _endPointURL = new EnderecoAPI();
        }

        public async Task<List<Repositorio>> ObterListaDeFavoritosDaAPI()
        {
            try
            {
                var resultado = await _webAPI.GetListAPIAsync<Repositorio>(_endPointURL.ListarFavoritos);
                return resultado ?? new List<Repositorio>();
            }
            catch (System.Exception)
            {
                return new List<Repositorio>();
            }
        }

        public async Task<Repositorio> ObterFavoritosPorIDnaAPI(int id)
        {
            try
            {
                Repositorio resultado = await _webAPI.GetAPIAsync<Repositorio>(_endPointURL.ProcuraFavoritosPorID + id);
                return resultado ?? new Repositorio();
            }
            catch (System.Exception)
            {
                return new Repositorio();
            }
        }


        public async Task<bool> InserirFavoritoNaAPI(Repositorio favorito)
        {
            try
            {
                var resultado = await _webAPI.PostAPIAsync(_endPointURL.InserirFavoritos, favorito);
                return (resultado.id != 0);
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarFavoritoNaAPI(int id)
        {
            try
            {
                var resultado = await _webAPI.DeleteAPIAsync<Repositorio>(_endPointURL.ExcluirFavoritos + id);
                return (resultado.id != 0);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
