﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

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
										VerticalOptions = LayoutOptions.Center,
										Spacing = 5,
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

        //Load Data from could storage
        public async void GetJsonList()
        {
            Post post = new Post();
            string result = await post.LoadPost();
            GetTopic getTopic = new GetTopic();
            listView.ItemsSource = getTopic.List(result);
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

            GetJsonList();
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

        // Set the Index for the 
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			//Set the id for the database the app when the app is closed
            ((App)App.Current).IndexID = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

        //Post bar item clicked
        async void myPost(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new PostSystem());
			//{
			//	BindingContext = new ItemData()
			//});
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
                Title = (e.SelectedItem as Topic).Text,
                //Set the data to pass to the new page
				BindingContext = e.SelectedItem as Topic
			});
        }
    }
}
