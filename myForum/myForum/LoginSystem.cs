using System;

using Xamarin.Forms;

namespace myForum
{
    public class LoginSystem : ContentPage
    {
        //Set up the entry to check the user login info.
        Entry usernameEntry, passwordEntry;

        public LoginSystem()
        {
            
            //Create Label for the login page
			Label loginLabel = new Label
			{
				Text = "Login",
                TextColor = Color.DarkRed,
				FontSize = 40,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center

			};

            //Create text input to handle username
            usernameEntry = new Entry
            {
                Placeholder = "Username",
                HeightRequest = 40,
                Keyboard = Keyboard.Create(KeyboardFlags.None)

            };

            //Create text input to hanlde password
            passwordEntry = new Entry
            {
                Placeholder = "Password",
                HeightRequest = 40,
                IsPassword = true
            };


            //Create container for text input
            Frame container = new Frame
            {
                BackgroundColor = Color.FromHex("#f1e1cf"),
                HasShadow = false,

                //Create view for container
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Spacing = 10,

                    //Append input text to container
                    Children = {usernameEntry, passwordEntry}
                }

            };


            ////Create login button
            Button loginButton = new Button
            {
                Text = "Login",
                TextColor = Color.White,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#fa9b2f"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            //When click login button
            loginButton.Clicked += loggedIn;


			////Create login button
			Button registerButton = new Button
			{
				Text = "Need an account?",
                TextColor = Color.DarkBlue,
				FontSize = 15,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

            //Append all view to the login page
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 30,
                Children = {loginLabel, container, loginButton, registerButton}
            };

        }

        //Check login
        async void loggedIn(object sender, System.EventArgs e) {

            await Navigation.PushModalAsync(new NavigationPage(new ForumSystem(){Title = "Forum"}));
        }
    }
}

