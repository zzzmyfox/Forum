using System;

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
            Title = "Do you have any questions?";

            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text = "Login"
            };
            toolbarItem.Clicked += showLogin;
            ToolbarItems.Add(toolbarItem);


			//Create Search bar on forum page
			SearchBar searchBar = new SearchBar
			{
				Placeholder = "Search"
			};

            //Create data for post
            var posts = new[]
            {
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
        async void showLogin(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new LoginSystem());
		}
    }
}

