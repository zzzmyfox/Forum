﻿using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
        //Initialise listview
        ListView listView;
		//Initial List 
		List<Post> list = new List<Post>();
        //Initial sarch bar
        SearchBar searchBar;

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

        public ForumSystem(string logo)
        {
            //Set the title name
            Title = logo;
            //Navigation bar item
            ToolbarItem newPost = new ToolbarItem
            {
                Text = "+"
            };

            ToolbarItems.Add(newPost);
            newPost.Clicked += myPost;

			//Create Search bar on forum page
			 searchBar = new SearchBar
			{
				Placeholder = "Search"
			};

            searchBar.BackgroundColor = Color.FromHex("#EFF3F0");

			//Search bar
			searchBar.TextChanged += (object sender, TextChangedEventArgs e) => {
				var keyword = searchBar.Text;
				var suggestion = list.Where(s => s.Text.ToLower().Contains(keyword.ToLower()));
				listView.ItemsSource = suggestion;
			};

            //Create ListView
            listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(PostCell)),
                RowHeight = 85,
            };


            //ListView Cell selected
            listView.ItemSelected += ItemSelected;

            //Add scrollview makes suer the search bar can scroll up
            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children = {searchBar,listView}
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
            //Get the value from user click
            string topics = ((App)App.Current).TopicName;
            //Get the result from the server
            string result = await connection.LoadPost(topics);
			//Initial the GetTopic class
            JsonStringPost jsonPost = new JsonStringPost();
	
            //Check whatever the list is exist
            if(result != null){
				//Set the data from the cloud to the list
                list = jsonPost.ToList(result);
				//Add the list to the listview
                listView.ItemsSource = list;

            }else{
                //Handle the error if the cloud storage is null
                await DisplayAlert("Oops", "This topic is empty, feel free to discuss at here!", "Ok");
            }  
		}

        //Post bar item clicked
        async void myPost(object sender, System.EventArgs e)
		{
			//Load database
			List<ItemData> list = await App.Database.GetItemsAsync();
            //Not login
            if (list.Count != 0)
            {
				await Navigation.PushAsync(new PostSystem());
            }
            else
            {
				await DisplayAlert("You must Login first", "You haven't login yet.", "Ok");
				await Navigation.PushModalAsync(new NavigationPage(new LoginSystem())
				{
					BindingContext = new ItemData()
				});
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

