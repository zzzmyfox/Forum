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
          



            Label hot = new Label
            {
                Text = "Hot Topics",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#fc7865"),
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold
            };

            Label other = new Label
            {
				Text = "Other Topics",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.FromHex("#a6fe73"),
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold
            };

			var zelda = new Frame
			{
				OutlineColor = Color.Accent,
				BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Content = new Label
				{
					Text = "Zelda",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
				}
			};

            var lol = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "LOL",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }

            };


			var wow = new Frame
			{
				OutlineColor = Color.Accent,
				BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Content = new Label
				{
					Text = "WoW",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
				}

			};

			var Others = new Frame
			{
				OutlineColor = Color.Accent,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Content = new Label
				{
					Text = "Others",
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
				}

			};

            //Create frame for hot topics
            Frame containerhot = new Frame
            {
				BackgroundColor = Color.FromHex("#fcf0cd"),
				HasShadow = false,

				//Create view for container
				Content = new StackLayout
				{
                    Orientation = StackOrientation.Horizontal,
					Spacing = 10,

					//Append input text to container
                    Children = {zelda, lol, wow}
				}
            };

            //Create frame for other topics
			Frame containerother = new Frame
			{
				BackgroundColor = Color.FromHex("#fcf0cd"),
				HasShadow = false,

				//Create view for container
				Content = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					Spacing = 10,

					//Append input text to container
                    Children = {Others}
				}
			};




			var tapGestureRecognizer = new TapGestureRecognizer();
			//tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            zelda.GestureRecognizers.Add(tapGestureRecognizer);
			lol.GestureRecognizers.Add(tapGestureRecognizer);
            wow.GestureRecognizers.Add(tapGestureRecognizer);
            Others.GestureRecognizers.Add(tapGestureRecognizer);

			Content = new StackLayout
			{
                Spacing = 0,
                Children ={hot,containerhot,other,containerother }
			};
		}

		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
            Navigation.PushAsync(new ForumSystem());
		}
	}
}
