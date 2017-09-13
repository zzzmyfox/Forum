﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
        //Initialise listview
        ListView listView;

        //Post string
		class Post
		{
			public Post(string title, string detail, string time)
			{
				this.PostTitle = title;
				this.PostDetail = detail;
				this.PostTime = time;
			}

			public string PostTitle { private set; get; }
			public string PostDetail { private set; get;}
			public string PostTime { private set; get; }

		}

        //View Cell customer
		public class PostCell : ViewCell
		{

			public PostCell()
			{
				// Create post title for cell
				Label titleLabel = new Label();
				titleLabel.SetBinding(Label.TextProperty, "Text");

                //Create post detail label for the cell
				Label detailLabel = new Label();
				detailLabel.SetBinding(Label.TextProperty, "Description");

                //Create time label for the cell
				Label read = new Label();
				StackLayout horizontal = new StackLayout();
                read.Text = "Read";
                read.SetBinding(VisualElement.IsVisibleProperty, "Read");
				horizontal.Orientation = StackOrientation.Horizontal;
				read.HorizontalOptions = LayoutOptions.EndAndExpand;

				//the cell for each views
				StackLayout cellWrapper = new StackLayout();

				//Set cell design
				cellWrapper.BackgroundColor = Color.FromHex("#fcf0cd");
				titleLabel.TextColor = Color.FromHex("#f35e20");
				detailLabel.TextColor = Color.FromHex("#75ebf9");
                read.TextColor = Color.FromHex("#503026");


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
										Children ={titleLabel,detailLabel}
									}
								}
                };

				//add views to the view hierarchy
				View = cellWrapper;
                horizontal.Children.Add(box);
                horizontal.Children.Add(cells);
                horizontal.Children.Add(read);
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
                RowHeight = 70
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
        //Login clicked
        async void myPost(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new PostSystem());
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
            await Navigation.PushAsync(new Details(e.SelectedItem));
        }
    }
}

