﻿using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using System.IO;
using System.Threading.Tasks;


namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        CardPageViewModel _viewModel;
        public CardPage()
        {
            InitializeComponent();
            _viewModel =new CardPageViewModel();
            BindingContext = _viewModel;
            Title = "Sepetim";
            
            
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            return true;
        }

        async void mRefreshViewCardPage_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewCardPage.IsRefreshing = false;
            changeTotal();
            
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
           await Task.Delay(3000);
            mRefreshViewCardPage.IsRefreshing = true;
            _viewModel.onAppearing(); 
           await _viewModel.ExecuteLoadItemsCommand();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.ExecuteLoadItemsCommand();
            _viewModel.onAppearing();
            changeTotal();
           

            mRefreshViewCardPage.IsRefreshing = true;
            collectionView.ItemsSource = _viewModel.BagProducts;
        }
        public void changeTotal()
        {
            var bagIt = App.shoppingCard.ListProducts();
            float ttl = 0;
            foreach (var item in bagIt)
            {

                ttl += item.Price;
                OnPropertyChanged();
            }
            btnPayment.Text = "Siparişi Tamamla"+" ( "+ttl+" )";
            this.OnPropertyChanged("btnPayment");
            OnPropertyChanged("btnPaymnet");
        }
        

    }
}