using Xamarin.Forms;

namespace myForum
{
    public partial class App : Application
    {
        //Log status 
        public static bool IsUserLoggedIn;
        //Initial database
		static SqliteDatabase database;
        public App()
        {
            InitializeComponent();

            //Set up the main screen page
            MainPage = new NaviationTab();

        }

        //Initial database and write or get data 
		public static SqliteDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new SqliteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("user.db3"));
				}
				return database;
			}
		}

        //Set up the index id of the database
		public int IndexID { get; set; }


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
