using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sofisa.Desafio.Models;
using Sofisa.Desafio.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sofisa.Desafio.Test
{
    [TestClass]
    public class UnitTestAPI
    {
        #region Testes Favoritos
        [TestMethod]
        public void a_IncluirNovoFavorito()
        {
            try
            {
                Repositorio favorito = new Repositorio
                {
                    id = 12345,
                    full_name = "RodrigoCoelhoDev/Teste",
                    name = "Teste",
                    language = "C#",
                    updated_at = DateTime.Now,
                    description = "Teste"
                };

                Assert.IsTrue(new FavoritoVM().InserirFavoritoNaAPI(favorito).Result);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void a_NaoPermitirIncluirFavoritoVazio()
        {
            try
            {
                Repositorio favorito = new Repositorio();
                Assert.IsTrue(new FavoritoVM().InserirFavoritoNaAPI(favorito).Result == false);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task b_ObterListaDeFavoritos()
        {
            try
            {
                List<Repositorio> lstFavoritos = await new FavoritoVM().ObterListaDeFavoritosDaAPI();
                Assert.IsTrue(lstFavoritos.Count > 0);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void b_ObterFavoritoPorID()
        {
            try
            {
                Repositorio favorito = new FavoritoVM().ObterFavoritosPorIDnaAPI(12345).Result;
                Assert.IsTrue(favorito.id == 12345);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void c_DeletarFavorito()
        {
            try
            {

                Assert.IsTrue(new FavoritoVM().DeletarFavoritoNaAPI(12345).Result);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        #endregion
    }
}
