using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace myForum
{
    public class PostSystem : ContentPage
    {


		Entry titleEntry, contentEntry;

        public PostSystem()
        {
            //Set page title title
            Title = "New Post";
            //Set background color
            BackgroundColor = Color.FromHex("#eee");

			//Add item button in navigation bar
			ToolbarItem toolbarItem = new ToolbarItem
			{
				Text = "Post"
			};
            //button click to post function
			toolbarItem.Clicked += post;
            //Add to navigation view
			ToolbarItems.Add(toolbarItem);

            titleEntry = new Entry
            {
				Placeholder = "Title",
				HeightRequest = 40
            };


            contentEntry = new Entry
            {
				Placeholder = "Content",
				HeightRequest = 40
            };

            //Add view to Content page
            Content = new StackLayout
            {
                Children = {titleEntry,contentEntry}
            };
        }


		//After post
		async void post(object sender, EventArgs e)
		{

            string postTitle = titleEntry.Text;
            string postContent = contentEntry.Text;

		  //Not login
			if(App.IsUserLoggedIn == false){
                await  DisplayAlert("You must Login first","You haven't login yet.","Ok");
                await Navigation.PushModalAsync(new NavigationPage(new LoginSystem()));
            }else{
                
				//The username and password encode to Json 
                Post data = Post.CreateJson("{\"post\":\"" + postTitle +  postContent + "\"}");

                Debug.WriteLine(data);
				//Create user by Json
                data.NewPost();
            }
		}
    }

    public class Post{

        private static string HTTPServer = "http://introtoapps.com/datastore.php?appid=215197324";

        public string post;


		public static Post CreateJson(string json)
		{
			Post data = JsonConvert.DeserializeObject<Post>(json);
			return data;
		}

		public string ToJsonString()
		{
            return JsonConvert.SerializeObject(this);

		}


        //Post the new topic
		public async void NewPost()
		{
			try
			{
				string jsonString = ToJsonString();
				jsonString = WebUtility.UrlEncode(jsonString);


				Debug.WriteLine(jsonString);
				string action = HTTPServer + "&action=append&objectid=test" + "&data=" + jsonString + "%0A";
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

				Debug.WriteLine(action);


				await ServerResponse(request);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		//Get response from server
		public static async Task<string> ServerResponse(WebRequest request)
		{
			string result = "";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream())
				{
					StreamReader objStream = new StreamReader(stream);

					string sLine = "";
					while (sLine != null)
					{
						sLine = objStream.ReadLine();
						if (sLine != null)
							result += sLine + "\n";
					}
				}
			}
			return result;
		}
	}
}
