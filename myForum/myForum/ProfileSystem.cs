using System;

using Xamarin.Forms;

namespace myForum
{
    public class ProfileSystem : ContentPage
    {
        public ProfileSystem()
        {

            Title = "Profile";
            BackgroundColor = Color.FromHex("#eee");

            //Button in navigation bar for sign in and sign out
            if (App.IsUserLoggedIn == false)
            {
                //if not sign in
                ToolbarItem signIn = new ToolbarItem
                {
                    Text = "Sign in"
                };
                ToolbarItems.Add(signIn);
                signIn.Clicked += showLogin;
            }
            else
            {
                // After sign in
                ToolbarItem signOut = new ToolbarItem
                {
                    Text = "Sign out"
                };
                ToolbarItems.Add(signOut);
                signOut.Clicked += logout;
            }

            //Login
            async void showLogin(object sender, System.EventArgs e)
            {
                await Navigation.PushAsync(new LoginSystem());
            }

            //Logout
            async void logout(object sender, System.EventArgs e)
            {
                App.IsUserLoggedIn = false;
                await DisplayAlert("Logout", "Logout success!", "Ok");
                await Navigation.PushModalAsync(new NaviationTab());
            }
        }
    }
}

