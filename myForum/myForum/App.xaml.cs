using Xamarin.Forms;

namespace myForum
{
    public partial class App : Application
    {
        //Log status 
        internal static bool IsUserLoggedIn;

        public App()
        {
            InitializeComponent();

            TabbedPage tabbedPage = new TabbedPage();

			for (int i = 0; i != 4; ++i)
			{
				tabbedPage.Children.Add(CreateTabPage(i));
			}

            MainPage = tabbedPage;

        }

		private Page CreateTabPage(int index)
		{
			var button = new Button { Text = "Push" };
			var page = new ContentPage
			{
				Content = button,
			};
			NavigationPage.SetHasNavigationBar(page, false);
			var navigationPage = new NavigationPage(page) { Title = index.ToString() };
			button.Clicked += (s, e) => navigationPage.PushAsync(new ContentPage());

			return navigationPage;
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
