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

				Post myPost = new Post();
                GetTopic getTopic = new GetTopic();
                string result = await myPost.LoadPost();
               //The user post data
               Topic topic = new Topic(postTitle, postContent, "zhewang");

            if (result != null)
            {
               string json = getTopic.ToJsonString(topic);
               myPost.NewPost(json);

            }else{
                //Create list
				List<Topic> list = new List<Topic>();
				list.Add(topic);
				string json = getTopic.ListToJson(list);
				myPost.NewPost(json);
            }


			
        }
    }
}