﻿using Proiecty_MLSA.Classes;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User user { set; get; }
        public ProfilePage()
        {
            this.user = User.getInstance();
            InitializeComponent();
            ListGoodMovies.ItemsSource = user.GoodMovies;
            ListBadMovies.ItemsSource = user.BadMovies;
            BindingContext = this;
        }
        public async void ShowAllMovies(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        public async void ShowGoodMovies(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(user.GoodMovies[e.ItemIndex]));
        }
        public async void ShowBadMovies(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MoviePage(user.BadMovies[e.ItemIndex]));
        }
    }
}