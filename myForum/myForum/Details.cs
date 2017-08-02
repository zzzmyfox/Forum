using System;

using Xamarin.Forms;

namespace myForum
{
    public class Details : ContentPage
    {
        public Details()
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

