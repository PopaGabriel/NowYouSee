﻿using Proiecty_MLSA.Classes;
using Proiecty_MLSA.Static_Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiecty_MLSA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public List<Saved_Movie> GoodMovies { get; set; }
        public List<Saved_Movie> BadMovies { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
            setColors();

            GoodMovies = User.getInstance().GoodMovies;
            Console.Out.WriteLine(GoodMovies.Count);
            ListGoodMovies.ItemsSource = GoodMovies;

            BadMovies = User.getInstance().BadMovies;
            ListBadMovies.ItemsSource = BadMovies;
            
            ICommand refreshCommand = new Command(() =>
            {
                RefreshGood.IsRefreshing = false;
                RefreshBad.IsRefreshing = false;
            });
            RefreshGood.Command = refreshCommand;
            RefreshBad.Command = refreshCommand;
        }
        private void setColors()
        {
            BackgroundColor = ColorPallet.BackgroundMain;
            ListGoodMovies.BackgroundColor = ColorPallet.BackgroundButton;
            ListBadMovies.BackgroundColor = ColorPallet.BackgroundButton;
            LabelBad.TextColor = ColorPallet.TextColorInfo;
            LabelGood.TextColor = ColorPallet.TextColorInfo;
        }
        private async void ShowAllMovies(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void ListMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SavedMovieInstance = e.CurrentSelection.FirstOrDefault() as Saved_Movie;
            
            if (SavedMovieInstance == null)
                return;

            await Navigation.PushAsync(new MoviePage(SavedMovieInstance));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}