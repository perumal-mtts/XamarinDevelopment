using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using ChatAppService.Models;

public partial class Account_Register : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnRegister_Click(object sender, EventArgs e)
	{
		try
		{
			if (Page.IsValid)
			{
				using (UserService service = new UserService())
				{
					User user = new User();
					user.ID = Guid.NewGuid().ToString();
					user.EmailId = Email.Text.Trim();
					user.Name = UserName.Text.Trim();
					user.Password = Password.Text.Trim();

					service.CreateUser(user);
					Session["loggedUser"] = user;

					FormsAuthentication.SetAuthCookie(user.Name, createPersistentCookie: false);

					Response.Redirect("UsersList.aspx");
				}
			}
		}
		catch (Exception ex)
		{
			ErrorMessage.Text = ex.Message;
		}
	}
}