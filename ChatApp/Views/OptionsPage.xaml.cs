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
				case "ChangePassword":
				{
				}
				break;
				case "Logout":
					{
						App.LoggedUser = null;
						Navigation.PopToRootAsync ();
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

				case "My Friends":
					{
						Navigation.PushAsync(new MyFriends());
					}
					break;

				default:
					break;
			}

		}
	}
}

