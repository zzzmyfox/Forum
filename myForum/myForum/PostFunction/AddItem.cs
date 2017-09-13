using System;

using Xamarin.Forms;

namespace myForum
{
    public class AddItem : ContentPage
    {
        public AddItem()
        {
            Title = "Post";

            var titleEntry = new Entry();
            titleEntry.SetBinding(Entry.TextProperty, "Text");

            var contentEntry = new Entry();
            contentEntry.SetBinding(Entry.TextProperty, "Description");

      
            ToolbarItem toolbarItem = new ToolbarItem
            {
				Text = "Post"
			};

            ToolbarItems.Add(toolbarItem);
            toolbarItem.Clicked += async (sender, e) =>
            {
                var item = (ItemData)BindingContext;
                await App.Database.SaveItemAsync(item);
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,

                Children =
                {
                    new Label { Text = "Title" },
                    titleEntry,
                    new Label { Text = "Content" },
                    contentEntry
                }
            };
        }
    }
}


