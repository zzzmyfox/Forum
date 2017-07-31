using System;

using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
        public ForumSystem()
        {

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

          
            //Add View to forum page
            Content = new StackLayout
            {
                Children = {searchBar}
            };
        }
        async void showLogin(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new LoginSystem(){Title ="Login"});
		}
    }
}

