using System;

using Xamarin.Forms;

namespace myForum
{
    public class ForumSystem : ContentPage
    {
        public ForumSystem()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

