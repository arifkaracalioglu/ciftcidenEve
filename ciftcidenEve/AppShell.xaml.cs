﻿using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ciftcidenEve
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(UrunSatisPage), typeof(UrunSatisPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
