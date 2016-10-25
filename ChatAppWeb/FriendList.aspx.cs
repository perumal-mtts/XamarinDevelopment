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
		if (!Page.IsPostBack)
		{
			

			List<OnlineUser> onlineFriends = new List<OnlineUser>();

			using (UserService service = new UserService())
			{
				foreach (var item in service.GetMyFriends(LoggedUser.ID))
				{
					OnlineUser userModel = OnlineUserService.OnlineUsers.FirstOrDefault(x => x.UserId == item.ID);
					
					if (userModel == null)
					{
						userModel = new OnlineUser();
						userModel.UserId = item.ID;
						userModel.UserName = item.Name;
						userModel.NewStatus = false;
					}
					else
					{
						userModel.NewStatus = true;
					}

					onlineFriends.Add(userModel);
				}
			}

			grdData.DataSource = onlineFriends.Distinct().Where(x => x.UserId != LoggedUser.ID);
			grdData.DataBind();
		}
	}
}