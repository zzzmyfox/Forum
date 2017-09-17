using System;

using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
            
namespace myForum
{
    public class PostList : ContentPage
    {
        ListView listView;
		//List<ItemData> list = new List<ItemData>();

        public PostList()
        { 
            Title = "Posts";
            //Toolbar item button
            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            ToolbarItems.Add(toolbarItem);
            toolbarItem.Clicked += addItem;


			listView = new ListView
            {
    			Margin = new Thickness(20),
    			ItemTemplate = new DataTemplate(() =>
    			{
    				var label = new Label
    				{
    					VerticalTextAlignment = TextAlignment.Center,
    					HorizontalOptions = LayoutOptions.StartAndExpand
    				};

    				label.SetBinding(Label.TextProperty, "Username");
                    //label.BindingContext = new ItemData();

					//var label1 = new Label
					//{
					//	VerticalTextAlignment = TextAlignment.Center,
					//	HorizontalOptions = LayoutOptions.StartAndExpand
					//};

					//label.SetBinding(Label.TextProperty, "Description");

					//var label2 = new Label
    				//{
    				//	//Source = ImageSource.FromFile("check.png"),
    				//	HorizontalOptions = LayoutOptions.End
    				//};
    				//label2.SetBinding(VisualElement.IsVisibleProperty, "Read");
                    //label2.Text = "Read";


    				var stackLayout = new StackLayout
    				{
    					Children = { label }
    				};

    				return new ViewCell { View = stackLayout };
    			})
            };

			//ListView Cell selected

			//listView.ItemSelected += ItemSelected;
           


			Content = new StackLayout
			{

				Children = {listView}
			};
        }
  
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).IndexID = -1;
             List<ItemData> list = await App.Database.GetItemsAsync();

            //PostList post = new PostList();
            //string s = post.ListToJson(list);

            //var s1 = string.Join("", s.Split(new char[] { '[', ']', '\'' }));

            //ItemData item = post.ToObject(s1);


			Label user = new Label
			{

			};


            //Debug.WriteLine(s1);


            if(list.Count != 0){

				
				await DisplayAlert("OK", "OK", "OK");

                //int myid = ((App)App.Current).IndexID;
                //Debug.WriteLine(myid);
                ItemData item = await App.Database.Load();
                user.Text = item.Username;
                
            }else{

               await DisplayAlert("No", "No", "No");
            }


        



		

			Content = new StackLayout
			{

                Children = { user }
			};
		}

		//Encode the List data to Json data
        public String ListToJson(List<ItemData> item)
		{
			String json = JsonConvert.SerializeObject(item);
			return json;
		}

		//Decode to object
        public ItemData ToObject(String json)
		{
            ItemData topic = JsonConvert.DeserializeObject<ItemData>(json);
			return topic;
		}


		async void addItem(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new AddItem
			{
                BindingContext = new ItemData()
			});
		}

		//async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
		//{
  //          ((App)App.Current).IndexID = (e.SelectedItem as ItemData).ID;

  //          Debug.WriteLine((e.SelectedItem as ItemData).ID);

  //          await Navigation.PushAsync(new AddItem
		//	{
  //              BindingContext = e.SelectedItem as ItemData
		//	});
		//}

    }
}

