using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChatApp
{
	public partial class MyFriends : ContentPage
	{
		public MyFriends ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = App.UserManager.GetMyFriends(App.LoggedUser.ID);
		}
	}
}

