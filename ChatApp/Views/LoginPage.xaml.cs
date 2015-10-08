using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChatApp
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void LoginClickHandler(object sender, EventArgs e)
		{
			try
			{
				var user = (User)BindingContext;

				if (user == null ||
					string.IsNullOrEmpty(user.EmailId) ||
					string.IsNullOrEmpty(user.Password))
				{
					await DisplayAlert("Chat App", "All fields are mandatory", "Ok");
					return;
				}

				user = App.UserManager.GetValidUser(user);

				if (user != null)
				{
					App.LoggedUser = user;
					await Navigation.PushAsync(new UserListPage());
				}
				else
				{
					await DisplayAlert("Chat App", "Invalid Credentials", "Ok");
				}
			}
			catch (Exception ex)
			{
				DisplayAlert("Chat App", ex.Message, "Ok");
			}
		}
	}
}

