using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Gms.Common;
using Android.Util;
using Android.Content;
using ClientApp;

namespace ChatApp.Droid
{
	[Activity (Label = "ChatApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		string message ;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			if (IsPlayServicesAvailable())
			{
				var intent = new Intent(this, typeof(RegistrationIntentService));
				StartService(intent);
			}

			App.UserManager = new UserManager (new SoapService ());
			LoadApplication (new App ());
		}



		public bool IsPlayServicesAvailable()
		{
			int resultCode = GooglePlayServicesUtil.IsGooglePlayServicesAvailable(this);
			if (resultCode != ConnectionResult.Success)
			{
				if (GooglePlayServicesUtil.IsUserRecoverableError(resultCode))
					message = GooglePlayServicesUtil.GetErrorString(resultCode);
				else
				{
					message = "Sorry, this device is not supported";
					Finish();
				}
				
				return false;
			}
			else
			{
				message = "Google Play Services is available.";
				return true;
			}
		}
	}
}
