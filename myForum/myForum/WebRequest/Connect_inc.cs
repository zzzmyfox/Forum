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
        private static string HTTPServer = "http://introtoapps.com/datastore.php?appid=215197324";

        public string username { get; set; }
        public string password { get; set; }

        //Create Json from user
		public static User CreateJson(string json)
		{
			User data = JsonConvert.DeserializeObject<User>(json);
			return data;
		}

		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);

		}

        public User(){
            
        }

        //Object 
        public User(string username){
            this.username = username;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password; 
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
                    while(sLine != null)
                    {
                        sLine = objStream.ReadLine();
                        if (sLine != null)
                            result += sLine + "\n";
                    }
				}
			}
            return result;
        }

        //Get the list 
        public static async Task<string> GetList()
        {
            try
            {
			    string action = HTTPServer + "&action=list";
			    Uri uri = new Uri(action);
			    WebRequest request = WebRequest.Create(uri);
			    request.Method = "GET";

                string result = await ServerResponse(request);

                return result;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);

                return null;
            }
        }

		//Create user
		public async void CreateUser()
		{
			try
			{
                //Encode the json to the url
                string jsonString = ToJsonString();
				jsonString = WebUtility.UrlEncode(jsonString);
                //The request url
				string action = HTTPServer + "&action=save&objectid=" + username + ".user" + "&data=" + jsonString;
				Uri uri = new Uri(action);
				WebRequest request = WebRequest.Create(uri);
				request.Method = "GET";

                await ServerResponse(request);
			}
			catch(Exception e)
			{
				Debug.WriteLine(e);
			}
		}

        //Retrieve username and password
        public static async Task<User> LoadUser(string username)
        {
            try
            {
                string action = HTTPServer + "&action=load&objectid=" + username + ".user";
                Uri uri = new Uri(action);
                WebRequest request = WebRequest.Create(uri);
                request.Method = "GET";

                string result = await ServerResponse(request);
                return CreateJson(result);

            }
			catch (Exception e)
			{
				Debug.WriteLine(e);
                return null;
			}
        }
	}
}

