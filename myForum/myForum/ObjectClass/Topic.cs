using System;

using Xamarin.Forms;

namespace myForum
{
    public class Topic
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }

		public Topic(string text, string description, string username)
		{
			this.Text = text;
			this.Description = description;
            this.Username = username;
		}
    }
}

