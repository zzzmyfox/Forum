using System;

using Xamarin.Forms;

namespace myForum
{
    public class RegisterSystem : ContentPage
    {
        //Set up the entry for the register page to handle the user info.
        Entry usernameEntry, passwordEntry, confirmEntry;

        public RegisterSystem()
        {
            Label label = new Label
            {
                Text = "Register",
                TextColor = Color.DarkGreen,
				FontSize = 40,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center

			};

            usernameEntry = new Entry
            {
                Placeholder = "Username",
                Keyboard = Keyboard.Create(KeyboardFlags.None),
                HeightRequest = 40
            };

            passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
				HeightRequest = 40
            };

            confirmEntry = new Entry
            {
                Placeholder = "Confirm",
                IsPassword = true,
				HeightRequest = 40
            };


            Frame container = new Frame
            {
				BackgroundColor = Color.FromHex("#f1e1cf"),
				HasShadow = false,

				//Create view for container
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					Spacing = 0,

					//Append input text to container
                    Children = { usernameEntry, passwordEntry, confirmEntry}
				}
            };


			//Create login button
			Button registerButton = new Button
			{
				Text = "Register",
				TextColor = Color.White,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.FromHex("#fa9b2f"),
				HorizontalOptions = LayoutOptions.FillAndExpand
			};


			Content = new StackLayout
            {
				Padding = 20,
				Spacing = 30,
                Children = {label, container,registerButton}
            };
        }
    }
}

