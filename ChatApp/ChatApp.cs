﻿using System;
using Xamarin.Forms;

namespace ChatApp
{
	public class App : Application
	{
		public static UserManager UserManager { get; set; }
		public static User LoggedUser { get; set; }

		public App ()
		{
			MainPage = new NavigationPage (new HomePage ());
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
	}
}
