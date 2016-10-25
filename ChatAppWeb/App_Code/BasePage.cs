using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatAppService.Models;
using System.Web.Security;

namespace ChatAppWeb
{
	public class BasePage : System.Web.UI.Page
	{
		public User LoggedUser
		{
			get
			{
				if (Session["LoggedUser"] == null)
				{
					Session.Clear();
					Request.Cookies.Clear();

					FormsAuthentication.SignOut();

					Response.Redirect("Login.aspx");
				}

				return Session["LoggedUser"] as User;
			}
		}

		public string SessionId
		{
			get
			{
				if (HttpContext.Current.Request.Cookies["ASP.NET_SessionId"] == null)
				{
					Session.Clear();
					Request.Cookies.Clear();

					FormsAuthentication.SignOut();
					Response.Redirect("Login.aspx");
				}

				return HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			if (string.IsNullOrEmpty(Context.User.Identity.Name))
			{
				Response.Redirect("Login.aspx");
			}

			base.OnLoad(e);
		}
	}
}