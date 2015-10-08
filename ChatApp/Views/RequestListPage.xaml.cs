using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChatApp
{
	public partial class RequestListPage : ContentPage
	{
		public RequestListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = App.UserManager.GetMyRequests(App.LoggedUser.ID);
		}

		void AcceptRequestClickHandler(object sender, EventArgs e)
		{
			
		}
	}
}

