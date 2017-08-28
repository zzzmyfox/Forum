using System;

using Xamarin.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace myForum
{
	// Username and password info
	public class User
	{
		public static string HTTPServer = "http://introtoapps.com/datastore.php?appid=215197324";

		public string username;
		public string password;

		public static User CreateJson(string json)
		{
			User data = JsonConvert.DeserializeObject<User>(json);
			return data;
		}


		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);

		}

        //Get response from server
        public static async Task<string> ServerResponse(WebRequest request){

            string result = "";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream())
				{
                    StreamReader objStream = new StreamReader(stream);
                    string sLine = "";
                    while(sLine != null){
                        sLine = objStream.ReadLine();
                        if (sLine != null)
                            result += sLine + "\n";
                    }
				}
			}
            return result;
        }
       
		//Create user
		public async void CreateUser()
		{
			try
			{
				string jsonString = ToJsonString();
				jsonString = WebUtility.UrlEncode(jsonString);

				string action = HTTPServer + "&action=save&objectid=" + username + "&data=" + jsonString;
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

                await ServerResponse(request);
			}
			catch (Exception exception)
			{
				Debug.WriteLine(exception);
			}
		}

        //Retrieve username and password
        public static async Task<User> LoadUser(string username){

            try
            {
                string action = HTTPServer + "&action=load&objectid=" + username;
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.ContentType = "application/json";
                request.Method = "GET";

                 string result = await ServerResponse(request);

                return CreateJson(result);

            }
			catch (Exception exception)
			{
				Debug.WriteLine(exception);
                return null;
			}
        }
	}
}

