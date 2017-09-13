using System;

using Xamarin.Forms;

namespace myForum
{
    public class AddItem : ContentPage
    {
        public AddItem()
        {
            Title = "Post";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Text");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Description");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Read");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var todoItem = (ItemData)BindingContext;
                await App.Database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var todoItem = (ItemData)BindingContext;
                await App.Database.DeleteItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            var speakButton = new Button { Text = "Speak" };
            speakButton.Clicked += (sender, e) =>
            {
                var todoItem = (ItemData)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(todoItem.Text + " " + todoItem.Description);
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Description" },
                    notesEntry,
                    new Label { Text = "Read" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}


