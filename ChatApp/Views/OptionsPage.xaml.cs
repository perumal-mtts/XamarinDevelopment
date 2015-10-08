using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChatApp
{
	public partial class OptionsPage : ContentPage
	{
		public OptionsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			this.listView.ItemsSource = new string[]{
				"Update Profile",
				"My Friends",
				"My Requests",
				"Users",
				"ChangePassword",
				"Logout",
			};
		}

		public void SelectedOptionHandler(object sender, SelectedItemChangedEventArgs e)
		{
			string selectedOption = e.SelectedItem as string;

			switch (selectedOption)
			{
				case "Update Profile":
				case "My Friends":
				case "ChangePassword":
				case "Logout":
					{
						DisplayAlert("Chat App", "To be implemented", "Ok");
					}
					break;
				case "My Requests":
					{
						Navigation.PushAsync(new RequestListPage());
					}
					break;
				case "Users":
					{
						Navigation.PushAsync(new UserListPage());
					}
					break;
				default:
					break;
			}

		}
	}
}

