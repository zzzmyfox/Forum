using System;

using Xamarin.Forms;

namespace myForum
{
    public class Details : ContentPage
    {
        public Details()
        {
            //Set up background color 
            BackgroundColor = Color.FromHex("#f5e7b2");


            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text = "Reply"
            };
            ToolbarItems.Add(toolbarItem);

            toolbarItem.Clicked += (object sender, EventArgs e) => {
                Navigation.PushModalAsync(new NavigationPage(new ReplySystem()));
            };

            //Set up title label
            Label titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 24
            };

            titleLabel.SetBinding(Label.TextProperty, "Text");


			//Set up content label
			Label contentLabel = new Label
            {

                TextColor = Color.FromHex("#503026")
              

            };
			contentLabel.SetBinding(Label.TextProperty, "Description");


            //Set up username label
            Label nameLabel = new Label
            {
                TextColor = Color.Orange,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.End
   
            };
            nameLabel.SetBinding(Label.TextProperty, "Username");


            //Set the time label
            Label timeLabel = new Label
            {
				TextColor = Color.Orange,
				FontSize = 15,
                HorizontalOptions = LayoutOptions.End
            };
            timeLabel.SetBinding(Label.TextProperty, "Time");


            //Button for the speak
			var speakButton = new Button
			{
				Text = "Speak",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#fdbe68"),
				BorderRadius = 30,
				HeightRequest = 60,
				WidthRequest = 60,
                HorizontalOptions =  LayoutOptions.CenterAndExpand
			};

			//Speak button clicked
			speakButton.Clicked += (sender, e) =>
			{
				var item = (Post)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(item.Text + " " + item.Description);
			};

			//Create frame for hot topics
			Frame containerTitle = new Frame
			{
				BackgroundColor = Color.FromHex("#fcf5c3"),
				HasShadow = false,

				VerticalOptions = LayoutOptions.Center,
				//Create view for container
				Content = new StackLayout
				{
					//Append input text to container
					Children = { titleLabel }
				}
			};


            //Create frame for hot topics
            Frame containerContent = new Frame
            {
                BackgroundColor = Color.FromHex("#fcf5c3"),
                HasShadow = false,

                //Create view for container
                Content = new StackLayout
                {
					//Append input text to container
                    Children = { contentLabel }
				}
			};


			//Create frame for hot topics
			Frame containerName = new Frame
			{
				BackgroundColor = Color.FromHex("#fcf5c3"),
				HasShadow = false,

				//Create view for container
				Content = new StackLayout
				{
					//Append input text to container
					Children = { nameLabel,timeLabel, speakButton }
				}
			};

      
			// Head for other topic label
			Label comments = new Label
			{
				Text = "Comments",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.FromHex("#50bffe"),
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold
			};

            //Add to view
			Content = new StackLayout
			{
                Spacing = 0,
                Children ={ containerTitle, containerContent,containerName, comments }
			};
		}
	}
}


