﻿using System;

using Xamarin.Forms;
using System.Threading.Tasks;


namespace myForum
{
    public class LoginSystem : ContentPage
    {
        //Set up the entry to check the user login info.
        Entry usernameEntry, passwordEntry;

        public LoginSystem()
        {
            //Set navigation bar title
            Title = "Sign in";
            //Set background colour
            BackgroundColor = Color.FromHex("#fcf0cd");


            //Add item button in navigation bar
			ToolbarItem toolbarItem = new ToolbarItem
			{
				Text = "Sign up"
			};
            toolbarItem.Clicked += register;
            //Add button to navigation
			ToolbarItems.Add(toolbarItem);


            //Create Label for the login page
			Label loginLabel = new Label
			{
				Text = "Sign in",
                TextColor = Color.DarkRed,
				FontSize = 35,
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
                BackgroundColor = Color.FromHex("#fcf0cd"),
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

            //Create login button
            Button loginButton = new Button
            {
                Text = "Sign in",
                TextColor = Color.White,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#fa9b2f"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            //When click login button
            loginButton.Clicked += LoggedIn;


            //Append all view to the login page
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 20,
                Children = {loginLabel, container, loginButton}
            };

        }

        //Check login
        async void LoggedIn(object sender, EventArgs e) 
        {
            //Get input info
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)){
                
                await DisplayAlert("Login Error", "All input field must be entered!", "Ok");
            }
            else
            {
				CheckUser();
			}
        }

		//Check username and password
		async void CheckUser()
		{
			//Initialise the username and password.
			string username = usernameEntry.Text;
			string password = passwordEntry.Text;

			//Retrieve username list from server
			string userList = await User.CheckList();

			//Check the username in the database or not
			if (userList.Contains(username))
			{
				//Send input info request to server
				User data = await User.LoadUser(username);
				//Retrieve data for the username and password from server
				string user = data.username;
				string pass = data.password;
				//Check the password is correct or not.
				if (pass != password)
				{
					//Show Error message if the password is wrong.
					await DisplayAlert("Login Error", "Password is not correct, please try again.", "Ok");
				}
				else
				{
					//Password is correct
					await DisplayAlert("Logged in", "Username:" + user + ", Password:" + pass, "Ok");
					//await Navigation.PushModalAsync(new NaviationTab());
				}
			}
			else
			{
				//Show the error message when username is not correct.
				await DisplayAlert("Login Error", "Username does not exist, please try again!", "Ok");

			}
		}

		//register
        async void register(object sender, EventArgs e)
        {
            //register page   
            await Navigation.PushAsync(new RegisterSystem());

        }
	}
}

