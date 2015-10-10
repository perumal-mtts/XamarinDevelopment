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
			listView.ItemsSource = App.UserManager.GetRequests(App.LoggedUser.ID);
		}

		void AcceptRequestClickHandler(object sender, EventArgs e)
		{
			try
			{
				var user = (User)(((Button)sender).Parent).BindingContext;
				FriendRequest request = new FriendRequest();
				request.FromUserId = user.ID;
				request.ToUserId = App.LoggedUser.ID;
				App.UserManager.ApproveFriendRequest(request);

				DisplayAlert("Chat App", "Request Approved!!", "Ok");
			}
			catch (Exception ex)
			{
				DisplayAlert("Chat App", ex.Message,"Ok");
			}
		}
	}
}

