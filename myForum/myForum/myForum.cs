using System;

using Xamarin.Forms;

namespace myForum
{
    public class App : Application
    {
		//Initial loggin status 
		public static bool IsUserLoggedIn;
        //Initial SQLite database
        static SqliteDatabase database;
        public int IndexID { get; set; }

        public App()
        {
            MainPage = new NaviationTab();
        }

        //Set the database path
		public static SqliteDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new SqliteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("myForum.db3"));
				}
				return database;
			}
		}

		protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
