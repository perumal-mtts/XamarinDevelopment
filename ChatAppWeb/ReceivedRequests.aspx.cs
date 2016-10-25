using ChatAppService.Models;
using ChatAppWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : BasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		using (UserService service = new UserService())
		{
			grdData.DataSource = service.GetMyRequests(LoggedUser.ID);
			grdData.DataBind();
		}
	}

	protected void linkBtnAddFriend_Click(object sender, EventArgs e)
	{
		try
		{
			using (UserService service = new UserService())
			{
				LinkButton button = ((LinkButton)sender);

				if (button.CommandName == "Approve")
				{
					FriendRequest request = new FriendRequest();
					request.FromUserId = button.CommandArgument;
					request.ToUserId = LoggedUser.ID;
					service.ApproveFriendRequest(request);

					FailureText.Text = "Approved Successfully..";
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}