namespace Sofisa.Desafio.Servico
{
    public class EnderecoAPI
    {
        private const string _listarRepositorios = "https://api.github.com/users/RodrigoCoelhoDev/repos";
        private const string _ProcurarRepositorios = "https://api.github.com/search/repositories?q=";
        private const string _listarContribuintes = "https://api.github.com/repos";

        private const string _listarFavoritos = "https://sofisadesafioapi20201227235651.azurewebsites.net/Favoritos/ObterListaDeFavoritos";
        private const string _procuraFavoritosPorID = "https://sofisadesafioapi20201227235651.azurewebsites.net/Favoritos/ObterListaDeFavoritosPorID/";
        private const string _excluirFavoritos = "https://sofisadesafioapi20201227235651.azurewebsites.net/Favoritos/Excluir/";
        private const string _inserirFavoritos = "https://sofisadesafioapi20201227235651.azurewebsites.net/Favoritos/Inserir";
 
        public string ListarRepositorios { get => _listarRepositorios; }
        public string ProcurarRepositorios { get => _ProcurarRepositorios; }
        public string ListarContribuintes { get => _listarContribuintes; }
        public string ListarFavoritos { get => _listarFavoritos; }
        public string InserirFavoritos { get => _inserirFavoritos; }
        public string ExcluirFavoritos { get => _excluirFavoritos; }
        public string ProcuraFavoritosPorID { get => _procuraFavoritosPorID; }
     
        public EnderecoAPI()
        {

        }
    }
}
