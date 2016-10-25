using ChatAppService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		RegisterHyperLink.NavigateUrl = "Register.aspx";

		var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
		if (!String.IsNullOrEmpty(returnUrl))
		{
			RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
		}

		if (!IsPostBack)
		{
			if (HttpContext.Current.Request.Cookies["ASP.NET_SessionId"] != null)
			{
				string sessionId = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value;
				if (OnlineUserService.OnlineUsers.Where(item => item.SessionId == sessionId).Count() > 0)
				{
					OnlineUserService.OnlineUsers.Remove(OnlineUserService.OnlineUsers
						.Where(item => item.SessionId == sessionId).FirstOrDefault());
				}
			}
		}
	}

	protected void btnLogin_Click(object sender, EventArgs e)
	{
		try
		{
			User user = new User();
			user.EmailId = UserName.Text;
			user.Password = Password.Text;

			UserService userService = new UserService();

			var loggedUser = userService.GetValidUser(user);

			if (loggedUser.Name != null)
			{
				Session["loggedUser"] = loggedUser;

				FormsAuthentication.SetAuthCookie(loggedUser.Name, RememberMe.Checked);

				Response.Redirect("UsersList.aspx");
			}
			else
			{
				FailureText.Text = "Invalid credentials";
			}
		}
		catch (Exception ex)
		{
			FailureText.Text = "Something went wrong..!!";
		}
	}
}