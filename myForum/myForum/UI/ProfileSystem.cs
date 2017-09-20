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

		//Initialise listview
		ListView listView;

		//View Cell customer
		public class PostCell : ViewCell
		{
			public PostCell()
			{
				// Create post title for cell
				Label titleLabel = new Label();
				titleLabel.SetBinding(Label.TextProperty, "Text");

				//Create post detail label for the cell
				Label userLabel = new Label();
				userLabel.SetBinding(Label.TextProperty, "Username");
				userLabel.FontSize = 10;
				//Set the horizontal orientation
				StackLayout horizontal = new StackLayout();
				horizontal.Orientation = StackOrientation.Horizontal;

				//the cell for each views
				StackLayout cellWrapper = new StackLayout();

				//Set cell design
				cellWrapper.BackgroundColor = Color.FromHex("#fcf0cd");
				titleLabel.TextColor = Color.FromHex("#f35e20");
				userLabel.TextColor = Color.FromHex("#503026");


				//Costumer cell
				StackLayout cells = new StackLayout
				{
					Padding = new Thickness(20, 15),
					Orientation = StackOrientation.Horizontal,
					Children =
								{
									new StackLayout
									{
										VerticalOptions = LayoutOptions.StartAndExpand,
										Spacing = 30,
										Children ={titleLabel,userLabel }
									}
								}
				};

				//add views to the view hierarchy
				View = cellWrapper;
				horizontal.Children.Add(cells);
				cellWrapper.Children.Add(horizontal);
			}
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
                //List view
                listView = new ListView 
                {
					ItemTemplate = new DataTemplate(typeof(PostCell))
                };
				//initial the post class
				Connection connection = new Connection();
                //Get the result from the server
                string result = await connection.LoadUserPost(item.Username);
				//Initial the GetTopic class
                JsonUserPost jsonPost = new JsonUserPost();

			

                if(result != null){
					//Set the data from the cloud to the list
					List<UserPost> userpostlist = jsonPost.ToList(result);
                    //Add to list view
                    listView.ItemsSource = userpostlist;
                }

				//Add to view
				Content = new StackLayout
				{
					Children = { container,listView }
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
					Text = "Login",
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

