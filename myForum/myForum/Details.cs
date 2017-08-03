using System;

using Xamarin.Forms;

namespace myForum
{
    public class Details : ContentPage
    {
        public Details(object details)
        {
            Title = details as string;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

