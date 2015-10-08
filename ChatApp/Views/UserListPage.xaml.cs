using System;
using Xamarin.Forms;

namespace ChatApp
{
	public partial class UserListPage : ContentPage
	{
		public UserListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = await App.UserManager.GetUsersAsync();
		}

		void OptionClickHandler(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionsPage());
		}

		void FriendRequestClickHandler(object sender, EventArgs e)
		{
			try
			{
				var user = (User)(((Button)sender).Parent).BindingContext;
				FriendRequest request = new FriendRequest();
				request.FromUserId = App.LoggedUser.ID;
				request.ToUserId = user.ID;
				App.UserManager.SendFriendRequest(request);

				DisplayAlert("Chat App", "Request Sent!!", "Ok");
			}
			catch (Exception ex)
			{
				DisplayAlert("Chat App", ex.Message,"Ok");
			}

		}
	}
}
