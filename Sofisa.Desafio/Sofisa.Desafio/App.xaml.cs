﻿using Sofisa.Desafio.Views;
using Xamarin.Forms;

namespace Sofisa.Desafio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

             MainPage = new MenuPrincipal();
         }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
