using System;
using Xamarin.Forms;

namespace ChatApp
{
	public partial class UserPage : ContentPage
	{
		bool isNewItem;

		public UserPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;
		}

		async void RegisterClickHandler (object sender, EventArgs e)
		{
			try
			{
				var user = (User)BindingContext;
				if (user != null)
				{
					if (string.IsNullOrEmpty(user.Name) ||
						string.IsNullOrEmpty(user.EmailId) ||
						string.IsNullOrEmpty(user.Password) ||
						string.IsNullOrEmpty(conPwdEntry.Text))
					{
						await DisplayAlert("Chat App", "All fields are mandatory", "Ok");
						return;
					}

					if (!string.Equals(user.Password, conPwdEntry.Text))
					{
						await DisplayAlert("Chat App", "Password and confirm password should match", "Ok");
						return;
					}

					user.ID = Guid.NewGuid().ToString();
					await App.UserManager.SaveUserAsync(user, true);
					await Navigation.PushAsync(new UserListPage());
				}
			}
			catch (Exception ex)
			{
				DisplayAlert("Chat App", ex.Message, "Ok");
			}
		}
	}
}

