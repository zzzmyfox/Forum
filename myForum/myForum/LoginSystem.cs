﻿using System;

using Xamarin.Forms;


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

            ////Create login button
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
            loginButton.Clicked += loggedIn;


            //Append all view to the login page
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 20,
                Children = {loginLabel, container, loginButton}
            };

        }

        //Check login
        async void loggedIn(object sender, EventArgs e) 
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;


			User acc = await User.LoadUser(username);
            string user = acc.username;
			string pass = acc.password;
            string empty = null;



			var isValid = CheckUser();






            if (username == empty){

                if (user != username){


                    await DisplayAlert("Error", "error", "Ok");

                }

				if (pass == password)
				{

					//If login success
					App.IsUserLoggedIn = true;
					await DisplayAlert("Logged in", "Username:" + acc.username + " ,Password:" + acc.password, "Ok");

				}
				else
				{


					await DisplayAlert("Error", "Your password is not correct, please try again.", "Ok");


				}

			}

           
   //         //Setup the checkuser 
   //         var isValid = CheckUser();
   //         if(isValid)
   //         {
				


			//	//User data = User.CreateJson("{\"username\":\"zhewang\",\"password\":\"zhewang123\"}");
			//	//User data =  User.CreateJson("{\"username\":\""+username+"\",\"password\":\""+password+"\"}");
			//	//await DisplayAlert("Message", "Pass:" + user.password, "Ok");






   //             //await Navigation.PushModalAsync(new NaviationTab()) ;
			//}
            //else
            //{
            //    //Show Alert if the username or password not correct
            //    await DisplayAlert("Erorr", "Pass:", "Ok");

            //}
        }

		//register
        async void register(object sender, EventArgs e)
        {
            //register page   
            await Navigation.PushAsync(new RegisterSystem());

        }

		//Check username and password
	    bool CheckUser()
		{
            return true;
		}
	}
}

