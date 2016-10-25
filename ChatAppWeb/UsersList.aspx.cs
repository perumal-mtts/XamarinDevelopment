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
		if (!IsPostBack)
		{
			if (OnlineUserService.OnlineUsers.Where(item => item.SessionId == SessionId).Count() > 0)
			{
				OnlineUserService.OnlineUsers.Remove(OnlineUserService.OnlineUsers
					.Where(item => item.SessionId == SessionId).FirstOrDefault());
			}

			OnlineUserService.AddOnlineUser("", LoggedUser.Name, LoggedUser.ID, SessionId);

			using (UserService service = new UserService())
			{
				grdData.DataSource = service.GetUsers()
					.Except(service.GetMyFriends(LoggedUser.ID))
					.Where(x => x.ID != LoggedUser.ID);

				grdData.DataBind();
			}
		}
	}

	protected void linkBtnAddFriend_Click(object sender, EventArgs e)
	{
		try
		{
			using (UserService service = new UserService())
			{
				LinkButton button = ((LinkButton)sender);

				if (button.CommandName == "AddFriend")
				{
					FriendRequest request = new FriendRequest();
					request.FromUserId = LoggedUser.ID;
					request.ToUserId = button.CommandArgument;
					service.SendFriendRequest(request);

					FailureText.Text = "Request Sent sucessfully!!";
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}