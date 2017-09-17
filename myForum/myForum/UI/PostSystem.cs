using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;


namespace myForum
{
    public class PostSystem : ContentPage
    {
        Entry titleEntry, contentEntry;

        public PostSystem()
        {
            //Set page title title
            Title = "Post";
            //Set background color
            BackgroundColor = Color.FromHex("#f5e7b2");

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
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,

				Children =
				{
					new Label { Text = "Title" },
					titleEntry,
					new Label { Text = "Content" },
					contentEntry
				}
			};
        }

		//After post
		async void post(object sender, EventArgs e)
        {
             string postTitle = titleEntry.Text;
             string postContent = contentEntry.Text;
             //Initial connection
             Connection connection = new Connection();
             //Initial JsonStringPost
             JsonStringPost jsonPost = new JsonStringPost();
             //return result
             string result = await connection.LoadPost();
            //Load user loggin info from local database
            ItemData item = await App.Database.Load();
            //Set the username from data
            var postUser = item.Username;
             //The user post data
            Post postData = new Post(postTitle, postContent, postUser);

            if (result != null)
            {
                //Topic is exist the json will append to the clould
                string json = jsonPost.ToJsonString(postData);
                connection.NewPost(json);
            }else{
                //Create list
                List<Post> list = new List<Post>();
                //Add data to list
                list.Add(postData);
                //Encode from list to json
                string json = jsonPost.ListToJson(list);
                //post the json list
                connection.NewPost(json);
            }

            await Navigation.PopAsync();
        }
    }
}