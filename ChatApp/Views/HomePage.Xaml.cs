using System;
using Xamarin.Forms;

namespace ChatApp
{
	public partial class HomePage: ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

		void LoginClickHandler (object sender, EventArgs e)
		{
			var user = new User ();
			var page = new LoginPage ();
			page.BindingContext = user;
			Navigation.PushAsync (page);
		}

		void RegisterClickHandler (object sender, EventArgs e)
		{
			var user = new User ();
			var registerPage = new UserPage (true);
			registerPage.BindingContext = user;
			Navigation.PushAsync (registerPage);
		}
	}
}
