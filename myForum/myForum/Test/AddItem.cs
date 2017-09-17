using System;

using Xamarin.Forms;

namespace myForum
{
    public class AddItem : ContentPage
    {
        public AddItem()
        {
            Title = "Login";

            var usernameEntry = new Entry();
            usernameEntry.SetBinding(Entry.TextProperty, "Username");

            var passwordEntry = new Entry();
            passwordEntry.SetBinding(Entry.TextProperty, "Password");


            var loginButton = new Button { Text = "Login" };
            loginButton.Clicked += async (sender, e) =>
            {
                var item = (ItemData)BindingContext;
                await App.Database.SaveItemAsync(item);
                await Navigation.PopAsync();

            };

            var loggoutButton = new Button { Text = "Loggout" };
            loggoutButton.Clicked += async (sender, e) =>
            {
                var item = (ItemData)BindingContext;
                await App.Database.DeleteItemAsync(item);
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Username" },
                    usernameEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                   
                    loginButton,
                    loggoutButton,
                }
            };
        }
    }
}


