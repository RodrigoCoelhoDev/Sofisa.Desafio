using Sofisa.Desafio.Models;
using Sofisa.Desafio.Servico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sofisa.Desafio.ViewModel
{
    public class RepositorioVM
    {
        WebAPI _webAPI;
        EnderecoAPI _endPointURL;

        public RepositorioVM()
        {
            _webAPI = new WebAPI();
            _endPointURL = new EnderecoAPI();
        }

        public async Task<List<Repositorio>> ObterListaDeRepositoriosDaAPI()
        {
            try
            {
                var resultado = await _webAPI.GetListAPIAsync<Repositorio>(_endPointURL.ListarRepositorios);
                return resultado ?? new List<Repositorio>();
            }
            catch (System.Exception)
            {
                return new List<Repositorio>();
            }
        }

        public async Task<List<Repositorio>> ProcurarRepositoriosNaAPI(string nomeRepositorio)
        {
            try
            {
                RepositorioProcura resultado = await _webAPI.GetAPIAsync<RepositorioProcura>(_endPointURL.ProcurarRepositorios + nomeRepositorio);
                return resultado.items ?? new List<Repositorio>();

            }
            catch (System.Exception)
            {
                return new List<Repositorio>();
            }
        }

        public async Task<List<RepositorioContribuinte>> ObterListaDeContribuintesDoRepositorioNaAPI(string nomeProprietario, string nomeRepositorio)
        {
            try
            {
                string endereco = $"{_endPointURL.ListarContribuintes}/{nomeProprietario}/{nomeRepositorio}/contributors";
                var resultado = await _webAPI.GetListAPIAsync<RepositorioContribuinte>(endereco);
                return resultado ?? new List<RepositorioContribuinte>();
            }
            catch (System.Exception)
            {
                return new List<RepositorioContribuinte>(); ;
            }
        }

    }
}
