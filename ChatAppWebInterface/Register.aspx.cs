using ChatAppService;
using ChatAppService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatAppWebInterface
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnRegister_Click(object sender, EventArgs e)
		{

			bool isException = false;
			try
			{
				if (Page.IsValid)
				{
					using (UserService service = new UserService())
					{
						User user = new User();
						user.ID = Guid.NewGuid().ToString();
						user.EmailId = txtEmailId.Text.Trim();
						user.Name = txtName.Text.Trim();
						user.Password = txtPwd1.Text.Trim();

						if(!string.Equals(txtPwd1.Text.Trim(), txtPwd2.Text.Trim()))
						{
							lblInfo.Text = "Passwords should match";
							return;
						}

						service.CreateUser(user);
					}
				}
			}
			catch (Exception ex)
			{
				isException = true;
				lblInfo.Text = ex.Message;
			}
			finally
			{
				if (isException == false)
				{
					Response.Redirect("Login.aspx");
				}
			}
		}
	}
}