using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace myForum
{
    public class PostSystem : ContentPage
    {
        Entry titleEntry, contentEntry;

        public PostSystem()
        {
            //Set page title title
            Title = "New Post";
            //Set background color
            BackgroundColor = Color.FromHex("#eee");

            //Add item button in navigation bar
            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text = "Post"
            };
            //button click to post function
            toolbarItem.Clicked += post;
            //Add to navigation view
            ToolbarItems.Add(toolbarItem);

            titleEntry = new Entry
            {
                Placeholder = "Title",
                HeightRequest = 40
            };


            contentEntry = new Entry
            {
                Placeholder = "Content",
                HeightRequest = 40
            };

            //Add view to Content page
            Content = new StackLayout
            {
                Children = { titleEntry, contentEntry }
            };
        }


        //After post
        async void post(object sender, EventArgs e)
        {

            string postTitle = titleEntry.Text;
            string postContent = contentEntry.Text;

            //Not login
            if (App.IsUserLoggedIn == false)
            {
                await DisplayAlert("You must Login first", "You haven't login yet.", "Ok");
                await Navigation.PushModalAsync(new NavigationPage(new LoginSystem()));
            }
            else
            {
                //The username and password encode to Json 
                Post data = Post.CreateJson("{\"post\":\"" + postTitle + postContent + "\"}");

                Debug.WriteLine(data);
                //Create user by Json
                data.NewPost();
            }
        }
    }
}