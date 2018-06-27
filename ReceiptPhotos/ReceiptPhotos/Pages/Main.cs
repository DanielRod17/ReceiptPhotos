using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ReceiptPhotos.Pages
{
    public class Main : ContentPage
    {
        public Main()
        {
            ScrollView scroll = new ScrollView();
            var grid = new Grid();
            for (int i = 0; i < 12; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int j = 0; j < 16; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            scroll.Content = grid;
            scroll.BackgroundColor = Color.FromRgb(39, 99, 153);
            Content = scroll;
            //////////////////////////////////////
            var Logo = new Image
            {
                Source = "EPLogo.png",
                HeightRequest = 120,
                WidthRequest = 50,
                Aspect = Aspect.AspectFit
            };
            var username = new Entry
            {
                Placeholder = "Username",
                TextColor = Color.White,
                PlaceholderColor = Color.White,
            };
            var password = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
                PlaceholderColor = Color.White,
                TextColor = Color.White
            };
            var Boton = new Button
            {
                BackgroundColor = Color.FromHex("891687"),
                TextColor = Color.White,
                Text = "\nLOGIN\n",
                Margin = new Thickness(0, 7, 0, 0)
            };
            var Contenti = new StackLayout()
            {
                Padding = 40,
                Spacing = 5,
                BackgroundColor = Color.FromRgba(10, 10, 10, 0.1),
                Children =
                {
                    Logo, username, password,
                    new StackLayout()
                    {
                        VerticalOptions =       LayoutOptions.EndAndExpand,
                        Children =
                        {
                           Boton
                        }
                    }
                }
            };
            grid.Children.Add(Contenti, 2, 1);
            Grid.SetColumnSpan(Contenti, 12);
            Grid.SetRowSpan(Contenti, 10);
            Boton.Clicked += (object sender, EventArgs e) =>
            {
                var user = username.Text;
                var pass = password.Text;
                //CheckLogin(user, pass);
            };
        }
    }
}