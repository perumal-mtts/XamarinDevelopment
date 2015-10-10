using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChatApp
{
	public class MyNavigationPage : NavigationPage
	{
		public override void OnBackPressed()
		{
			if(App.Instance.DoBack)
			{
				base.OnBackPressed();
			}
		}

		public bool DoBack
		{
			get
			{
				NavigationPage mainPage = MainPage as NavigationPage;
				if (mainPage != null)
				{
					return mainPage.Navigation.NavigationStack.Count > 1;
				}
				return true;                
			}
		}
	}
}

