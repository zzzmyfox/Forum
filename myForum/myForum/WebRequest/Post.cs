using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace myForum
{
	public class Post
	{

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
		public async void NewPost(string json)
		{
			try
			{
				string action = HTTPServer + "&action=save&objectid=zelda.topic" + "&data=" + json;
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "POST";

	
				await ServerResponse(request);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		//Retrieve post
        public async Task<string> LoadPost()
        {
			try
			{
                string action = HTTPServer + "&action=load&objectid=zelda.topic";
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "POST";

				string result = await ServerResponse(request);
				return result;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				return null;
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

