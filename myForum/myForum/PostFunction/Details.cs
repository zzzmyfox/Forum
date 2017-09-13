using System;

using Xamarin.Forms;

namespace myForum
{
    public class Details : ContentPage
    {
        public Details()
        {
            var titleLabel = new Label();
			titleLabel.SetBinding(Label.TextProperty, "Text");

			var contentLabel = new Label();
			contentLabel.SetBinding(Label.TextProperty, "Description");

			var read = new Switch();
			read.SetBinding(Switch.IsToggledProperty, "Read");

			var saveButton = new Button 
            { 
                Text = "Save" 
            };
			saveButton.Clicked += async (sender, e) =>
			{
				var item = (ItemData)BindingContext;
				await App.Database.SaveItemAsync(item);
				await Navigation.PopAsync();
			};

			var deleteButton = new Button
            { 
                Text = "Delete"
            };

			deleteButton.Clicked += async (sender, e) =>
			{
				var item = (ItemData)BindingContext;
				await App.Database.DeleteItemAsync(item);
				await Navigation.PopAsync();
			};

			var cancelButton = new Button
            { 
                Text = "Cancel"
            };

			cancelButton.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};

			var speakButton = new Button 
            {
                Text = "Speak"
            };

			speakButton.Clicked += (sender, e) =>
			{
				var item = (ItemData)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(item.Text + " " + item.Description);
			};

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					new Label { Text = "Text" },
                    titleLabel,
					new Label { Text = "Description" },
                    contentLabel,
					new Label { Text = "Read" },
					read,
					saveButton,
					deleteButton,
					cancelButton,
					speakButton
				}
			};
		}
	}
}


