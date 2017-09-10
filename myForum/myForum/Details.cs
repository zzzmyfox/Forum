using System;

using Xamarin.Forms;

namespace myForum
{
    public class Details : ContentPage
    {
        public Details(object detail)
        {
            Title = detail as string;


            //Title
            Label title = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Text ="Hello there!",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))

            };
            //Content
            Label content = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.FillAndExpand,
				Text = "Woooooooooooo",
				FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            //Add to view
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 30,
                Orientation = StackOrientation.Vertical,
                Children ={title,content}
            };
        }
    }
}



