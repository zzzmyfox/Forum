using System;

using Xamarin.Forms;

namespace myForum
{
    public class ReplySystem : ContentPage
    {
        //Initial reply editor
        Editor replyEditor;

        public ReplySystem()
        {
            //Set the title
            Title = "Reply";
			//Set up background color 
			BackgroundColor = Color.FromHex("#f5e7b2");

			ToolbarItem toolbarItem = new ToolbarItem
			{
				Text = "Cancel"
			};
			ToolbarItems.Add(toolbarItem);

			toolbarItem.Clicked += (object sender, EventArgs e) => {
                Navigation.PopModalAsync();
			};
            //Create text editor
            replyEditor = new Editor
            {
                HeightRequest = 160
            };

            Button replyButton = new Button
            {
                Text = "Reply",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex("#fa9b2f")
            };

            replyButton.Clicked += reply;

			//Add view to Content page
			Content = new StackLayout
			{
				//Layout
				Padding = new Thickness(0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
                Spacing = 50,
				//Add view to content page
				Children = { replyEditor , replyButton }
			};
        }
        //Reply button clicked
        async void reply(object sender, EventArgs e)
        {
            //Get user input
            string reply = replyEditor.Text;
            //Check not null
            if(string.IsNullOrWhiteSpace(reply))
            {
                await DisplayAlert("Error", "Reply text field can not be null.", "Ok");
            }
            else
            {
                
                await Navigation.PopModalAsync();
            }
        }
    }
}

