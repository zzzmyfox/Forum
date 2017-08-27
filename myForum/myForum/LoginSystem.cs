﻿using System;

using Xamarin.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;

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

			//Get username and password from entry
			var user = new User
			{
				username = usernameEntry.Text,
				password = passwordEntry.Text
			};



            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            //Setup the checkuser 
            var isValid = CheckUser(user);
            if(isValid)
            {
				//If login success
				App.IsUserLoggedIn = true; 
                await Navigation.PushModalAsync(new NaviationTab()) ;
			}
            else
            {
                //Show Alert if the username or password not correct
               
				//User data = User.CreateJson("{\"username\":\"zhewang\",\"password\":\"zhewang123\"}");
               
                User data =  User.CreateJson("{\"username\":\""+username+"\",\"password\":\""+password+"\"}");

                await DisplayAlert("Error", data.ToJsonString() ,"Ok" );
                data.CreateUser();
            }
        }


		//register
        async void register(object sender, EventArgs e)
        {
            //register page   
            await Navigation.PushAsync(new RegisterSystem());

        }

		//Check username and password
		bool CheckUser(User user)
		{

            //return user.username == UserData.username && user.password == UserData.password;
            return false;
		}
	}

    // Username and password info
	public class User
	{
		public static string HTTPServer = "http://introtoapps.com/datastore.php?appid=215197324";

        public string username;
		public string password;

		public static User CreateJson(string json)
		{
			User data = JsonConvert.DeserializeObject<User>(json);
			return data;
		}


		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);

		}
		//Connect to the server
		 public async void CreateUser()
        {
            try{
				string jsonString = ToJsonString();
				jsonString = WebUtility.UrlEncode(jsonString);

				string action = HTTPServer + "&action=save&objectid=" + username + "&data=" + jsonString;
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";
  
				WebResponse response = await request.GetResponseAsync();
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception);  
            }
		}
	}
}

