using System;

using Xamarin.Forms;

namespace myForum
{
    public class TopicSystem : ContentPage
    {
        public TopicSystem()
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

