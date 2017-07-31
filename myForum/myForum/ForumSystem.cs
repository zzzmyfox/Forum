using System;

using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
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

            ListView listView = new ListView
            {

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

