﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sofisa.Desafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipalDetail : ContentPage
    {
        public MenuPrincipalDetail()
        {
            InitializeComponent();
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}