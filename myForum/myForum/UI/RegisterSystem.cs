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
            //Set the navigation title
            Title = "Register";
			//Set background colour
			BackgroundColor = Color.FromHex("#fcf0cd");

			//Add item button in navigation bar
			ToolbarItem toolbarItem = new ToolbarItem
			{
				Text = "Cancel"
			};
			toolbarItem.Clicked += Cancel;
			//Add button to navigation
			ToolbarItems.Add(toolbarItem);


            //Label for sign up page
            Label label = new Label
            {
                Text = "Register",
                TextColor = Color.DarkGreen,
				FontSize = 35,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center

			};

            //register page username text input
            usernameEntry = new Entry
            {
                Placeholder = "Username",
                Keyboard = Keyboard.Create(KeyboardFlags.None),
                HeightRequest = 40
            };

			//register page password text input
			passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
				HeightRequest = 40
            };

			//register page password confirm text input
			confirmEntry = new Entry
            {
                Placeholder = "Confirm",
                IsPassword = true,
				HeightRequest = 40
            };


            //Text input container
            Frame container = new Frame
            {
				BackgroundColor = Color.FromHex("#fcf0cd"),
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

            registerButton.Clicked += registerFunction;

            //Add to view 
			Content = new StackLayout
            {
				Padding = 20,
				Spacing = 10,
                Children = {label, container,registerButton}
            };
        }

        //register account
        async void registerFunction(object sender, System.EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            string confirm = confirmEntry.Text;

            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm))
            {
                await DisplayAlert("Register error", "All input field must be entered!", "Ok");
            }
            else
            {
                CheckUser();

            }
        }

		//Check username and password match
		async void CheckUser()
		{
			//Initialise the username and password.
			string username = usernameEntry.Text;
			string password = passwordEntry.Text;
			string confirm = confirmEntry.Text;

			//Retrieve username list from server
			string userList = await Connection.GetList();

			//Check the username in the database or not
            if (username.Contains(userList))
			{
				//Show the error message when username is not correct.
				await DisplayAlert("Register error", "Username is already exist, please try again!", "Ok");
			}
			else
			{
                //check the password and confirm is match or not.
				if (password != confirm)
				{
                    //If not match show error message to user
					await DisplayAlert("Register error", "Password must be matched!", "Ok");
				}
				else
				{
                    //The username and password encode to Json 
                    User data = new User(username,password);
                    //Convert to json
                    JsonStringUser user = new JsonStringUser();
                    string result = user.ToJsonString(data);

                    //Create user by Json
                    await Connection.CreateUser(username, result);

                    await Navigation.PushModalAsync(new NaviationTab());
				}
			}
		}

		async void Cancel(object sender, EventArgs e)
		{
            //Cancel the page
            await Navigation.PopModalAsync();
		}

	}
}

