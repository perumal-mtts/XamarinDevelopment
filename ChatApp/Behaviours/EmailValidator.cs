using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace ChatApp
{
	public class EmailValidatorBehavior : Behavior<Entry>
	{
			const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
			@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
		
		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool),
			typeof(EmailValidatorBehavior), false);
		
		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
		public bool IsValid
		{
			get { return (bool)base.GetValue(IsValidProperty); }
			private set { base.SetValue(IsValidPropertyKey, value); }
		}

		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.Completed += HandleTextChanged;
		}

		void HandleTextChanged(object sender, EventArgs e)
		{
			IsValid = (Regex.IsMatch(((Entry)sender).Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
			((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
		}
			
		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.Completed -= HandleTextChanged;
		}
	}
}

