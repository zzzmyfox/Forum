using System;

using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
        public ForumSystem()
        {

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
    }
}

