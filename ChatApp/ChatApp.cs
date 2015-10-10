using System;
using Xamarin.Forms;

namespace ChatApp
{
	public class App : Application
	{
		public static UserManager UserManager { get; set; }
		public static User LoggedUser { get; set; }

		private static App _app;
		public static App Instance
		{
			get
			{
				if (_app == null) 
				{
					_app = new App ();
				}

				return _app;
			}
		}

		public App ()
		{
			_app = this;
			MainPage = new MyNavigationPage (new HomePage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public bool DoBack
		{
			get
			{
				NavigationPage mainPage = App.Instance.MainPage as NavigationPage;
				if (mainPage != null)
				{
					return mainPage.Navigation.NavigationStack.Count > 1;
				}
				return true;                
			}
		}

	}
}
