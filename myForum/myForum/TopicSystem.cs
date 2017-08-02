using System;

using Xamarin.Forms;

namespace myForum
{
    public class TopicSystem : ContentPage
    {
        public TopicSystem()
        {
            //Set the title for topic page
            Title = "Topics";
            //Set the background color
            BackgroundColor = Color.FromHex("#eee");


            BoxView boxView = new BoxView
            {
                HeightRequest = 80,
                BackgroundColor = Color.Cyan
            };


            Button zelda = new Button
            {   Text = "Zelda",
                BackgroundColor = Color.DarkOrange,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            };

            Button lol = new Button
            {   
                Text = "LOL",
				BackgroundColor = Color.DarkOrange,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 50
            };

            Button wow = new Button
            {
                Text = "WoW",
				BackgroundColor = Color.DarkOrange,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 50
            };


            //Add view to Content page
             Content = new StackLayout
            {
                Padding = 20,
                Spacing = 30,

                Children = {boxView, zelda, lol, wow}
            };
        }
    }
}

