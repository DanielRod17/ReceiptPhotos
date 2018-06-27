using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ReceiptPhotos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ///////////////////////////////
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
                CheckLogin(user, pass);
            };
        }
        public async void CheckLogin(string username, string password)
        {
            var client = new HttpClient();
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });
            var URI = "https://eplserver.net/erp/AccountingReceipts/AccountingReceipts.php";
            using (var response = await client.PostAsync(URI, stringContent))
            {
                string responseData = await response.Content.ReadAsStringAsync();
                //await DisplayAlert("Wrong Credentials", responseData, "Ok");
                if (responseData == "success")
                {
                    await Navigation.PushModalAsync(new Pages.Main());
                }
                else
                {
                    await DisplayAlert("Wrong Credentials", "Check your password or username", "Ok");
                }
            };
        }
    }
}
