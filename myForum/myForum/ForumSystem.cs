﻿using System;

using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {

		public class PostCell : ViewCell
		{

			public PostCell()
			{
				//instantiate each of our views
				var image = new Image();
				StackLayout cellWrapper = new StackLayout();
				StackLayout horizontalLayout = new StackLayout();
				Label left = new Label();
				Label right = new Label();

				//set bindings
				left.SetBinding(Label.TextProperty, "title");
				right.SetBinding(Label.TextProperty, "time");
				image.SetBinding(Image.SourceProperty, "image");

				//Set properties for desired design
				cellWrapper.BackgroundColor = Color.FromHex("#eee");
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				right.HorizontalOptions = LayoutOptions.EndAndExpand;
				left.TextColor = Color.FromHex("#f35e20");
				right.TextColor = Color.FromHex("503026");

				//add views to the view hierarchy
				horizontalLayout.Children.Add(image);
				horizontalLayout.Children.Add(left);
				horizontalLayout.Children.Add(right);
				cellWrapper.Children.Add(horizontalLayout);
				View = cellWrapper;
			}
		}
        
        public ForumSystem()
        {


            //Set navigation bar title
            NavigationPage navigationPage = new NavigationPage();
            navigationPage.Title = "Do you have any questions?";

        
            //Set tabbed bar title
            TabbedPage tabbedPage = new TabbedPage();
            tabbedPage.Title = "Post";


            //Navigation bar item
            ToolbarItem newPost = new ToolbarItem
            {
                Text = "New post"
            };

            ToolbarItems.Add(newPost);
            newPost.Clicked += myPost;

			//Create Search bar on forum page
			SearchBar searchBar = new SearchBar
			{
				Placeholder = "Search"
			};

            //Create data for post
            var posts = new[]
            {
                new {title="Hello welcome!", time="9:45" ,image=""},
                new {title="This is a forum!", time="9:47" ,image=""},
                new {title="Why does Zelda is a good game?", time="10:15" ,image=""},
                new {title="wooooooooo", time="11:05" ,image=""},
                new {title="I am the developer", time="11:21" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""},
                new {title="wooooooooo", time="1:45" ,image=""}
            };

            //Create ListView
            ListView listView = new ListView
            {
                ItemsSource = posts,
                ItemTemplate = new DataTemplate(typeof(PostCell)),
                RowHeight = 70
            };

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
            }else{

                var myTitle = e.SelectedItem.ToString();

				//Show page title
				await Navigation.PushAsync(new Details() { Title = myTitle });
            }

        }
    }
}

