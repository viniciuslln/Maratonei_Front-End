﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maratonei_xamarin.Models;
using Maratonei_xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maratonei_xamarin.Views {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class SolucaoPage : ContentPage {
        private SolucaoViewModel viewModel;
        public SolucaoPage( ItemMaratonarModel p_Maratona, ObjectiveFunction p_Solucao ) {
            InitializeComponent();
            BindingContext = viewModel = new SolucaoViewModel( p_Maratona, p_Solucao );
        }

        private void ToolbarItem_Clicked_Lanchar(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                await Navigation.PushModalAsync(new NavigationPage(new SelecionarComidasPage(double.Parse(viewModel.Total), viewModel.g_SolucaoList)));
            });
        }
    }
}