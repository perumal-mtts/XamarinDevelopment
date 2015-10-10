using System;

using Xamarin.Forms;

namespace ChatApp
{
	public class MyNavigationPage : NavigationPage
	{

		public MyNavigationPage(Page page) : base(page)
		{
			
		}

		protected override bool OnBackButtonPressed ()
		{
			if (App.Instance.DoBack) 
			{
				return base.OnBackButtonPressed ();
			}

			return true;
		}
	}
}


