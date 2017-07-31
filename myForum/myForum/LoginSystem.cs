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
			Label label = new Label
			{
				Text = "Login",
				TextColor = Color.White,
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

                    //Append input text to view
                    Children = {usernameEntry, passwordEntry}
                }

            };


        }
    }
}

