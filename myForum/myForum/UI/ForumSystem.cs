﻿using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
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
             
				//Create boxView
				BoxView box = new BoxView
				{
					WidthRequest = 5
				};

                //Costumer cell
				StackLayout cells = new StackLayout
				{
					Padding = new Thickness(0, 10),
					Orientation = StackOrientation.Horizontal,
					Children =
								{
									new StackLayout
									{
                                        VerticalOptions = LayoutOptions.StartAndExpand,
										Children ={titleLabel,userLabel }
									}
								}
                };

				//add views to the view hierarchy
				View = cellWrapper;
                horizontal.Children.Add(box);
                horizontal.Children.Add(cells);
                cellWrapper.Children.Add(horizontal);
			}
		}

        public ForumSystem()
        {
            Title = "Forum";
            //Navigation bar item
            ToolbarItem newPost = new ToolbarItem
            {
                Text = "+"
            };

            ToolbarItems.Add(newPost);
            newPost.Clicked += myPost;

			//Create Search bar on forum page
			SearchBar searchBar = new SearchBar
			{
				Placeholder = "Search"
			};

            //Create ListView
            listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(PostCell)),
                RowHeight = 85
            };

            //ListView Cell selected
            listView.ItemSelected += ItemSelected;
         
            //Add scrollview makes suer the search bar can scroll up
            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {searchBar, listView}
                }
            };

            //Add View to forum page
            Content = new StackLayout
            {
                Children = {scrollView}
            };
        }

		//Load Data from could storage
		protected override async void OnAppearing()
		{
			base.OnAppearing();
            //initial the post class
            Connection connection = new Connection();
            //Get the result from the server
            string result = await connection.LoadPost();
			//Initial the GetTopic class
            JsonStringPost jsonPost = new JsonStringPost();
			//Initial List 
            List<Post> list = new List<Post>();

            //Check whatever the list is exist
            if(result != null){
				//Set the data from the cloud to the list
                list = jsonPost.ToList(result);
				//Add the list to the listview
                listView.ItemsSource = list;
            }else{
                
                Post item = new Post("Welcome to this game forum!","Welcome here and always feel free to talk about the game you like and the way you are to play.","Developer");
                list.Add(item);
                listView.ItemsSource = list;
            }  
		}

        //Post bar item clicked
        async void myPost(object sender, System.EventArgs e)
		{
            //Not login
            if (App.IsUserLoggedIn == false)
            {
                await DisplayAlert("You must Login first", "You haven't login yet.", "Ok");
                await Navigation.PushModalAsync(new NavigationPage(new LoginSystem()));
            }
            else
            {
                await Navigation.PushAsync(new PostSystem());
            }
		}

        //Listview  cell select
        async void ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

             //Deselect row
            listView.SelectedItem = null;

			//Show page title
            //((App)App.Current).IndexID = (e.SelectedItem as ItemData).ID;

            //To the detail page
            await Navigation.PushAsync(new Details
            {
                //Set the navigation title name from the list view
                Title = (e.SelectedItem as Post).Text,
                //Set the data to pass to the new page
                BindingContext = e.SelectedItem as Post
			});
        }
    }
}

