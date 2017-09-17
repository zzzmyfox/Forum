namespace myForum
{
    public class Post
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }

        public Post(string text, string description, string username)
        {
            this.Text = text;
            this.Description = description;
            this.Username = username;
        }
    }
}

