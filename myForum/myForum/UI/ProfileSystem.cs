using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace myForum
{
    public class ProfileSystem : ContentPage
    {
        public ProfileSystem()
        {
            //Set title for profile page
            Title = "Profile";
			//Backgound colour 
			BackgroundColor = Color.FromHex("#fcf0cd");

            checkLogin();
        }

        //Load
        public  async void checkLogin()
		{
            //Load database
			List<ItemData> list = await App.Database.GetItemsAsync();
            //Check the database is not null
			if (list.Count != 0)
			{
				ItemData item = await App.Database.Load();

				//User profile image 
				Button button = new Button
				{
					BorderRadius = 50,
					HeightRequest = 100,
					WidthRequest = 100,
					BackgroundColor = Color.FromHex("#e176fc"),
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Start
				};

				//Username label
				Label label = new Label
				{
					TextColor = Color.FromHex("#ff9130"),
					FontSize = 28,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					FontAttributes = FontAttributes.Bold
				};
                label.Text = item.Username;

				// Username and image frame
				Frame container = new Frame
				{
					BackgroundColor = Color.FromHex("#daf1ee"),
					HasShadow = false,

					//Create view for container
					Content = new StackLayout
					{
						//Append input text to container
						Children = { button, label }
					}
				};
				//Add to view
				Content = new StackLayout
				{
					Children = { container }
				};

				//After login
				ToolbarItem logOut = new ToolbarItem
				{
					Text = "Logout"
				};
				ToolbarItems.Add(logOut);
				logOut.Clicked += logout;
			}
			else
			{
				// for User image
				Button button = new Button
				{
					BorderRadius = 50,
					HeightRequest = 100,
					WidthRequest = 100,
					BackgroundColor = Color.FromHex("#c8cbca"),
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Start
				};

				//Name label for username
				Label label = new Label
				{
					Text = "Username",
					TextColor = Color.FromHex("#ff9130"),
					FontSize = 28,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					FontAttributes = FontAttributes.Bold
				};

				// name and image frame
				Frame container = new Frame
				{
					BackgroundColor = Color.FromHex("#daf1ee"),
					HasShadow = false,

					//Create view for container
					Content = new StackLayout
					{
						//Append input text to container
						Children = { button, label }
					}
				};

				Content = new StackLayout
				{
					Children = { container }
				};

				//item bar button
				ToolbarItem signIn = new ToolbarItem
				{
					Text = "Login"
				};
				ToolbarItems.Add(signIn);
				signIn.Clicked += showLogin;
			}
		}

		//Logout
		async void logout(object sender, System.EventArgs e)
		{
            //Delete login data
            App.Database.DeleteItemAsync();

			await DisplayAlert("Logout", "Logout success!", "Ok");
          
			await Navigation.PushModalAsync(new NaviationTab());
		}

		//Login
		async void showLogin(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new LoginSystem
			{

				BindingContext = new ItemData()
			}));
		}
    }
}

