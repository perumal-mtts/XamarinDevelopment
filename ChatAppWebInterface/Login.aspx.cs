using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatAppService.Models;
using ChatAppService;
using System.Web.Security;

namespace ChatAppWebInterface
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
            try
            {
                User user = new User();
                user.EmailId = txtLogin.Text;
                user.Password = txtPassword.Text;

                UserService userService = new UserService();

                var loggedUser = userService.GetValidUser(user);

                if (loggedUser != null)
                {
                    Session["loggedUser"] = loggedUser;

                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    lblInfo.Text = "Invalid credentials";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Something went wrong..!!";
            }
		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
	}
}