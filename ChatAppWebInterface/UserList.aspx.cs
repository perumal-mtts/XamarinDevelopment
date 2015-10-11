using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatAppService;
using ChatAppService.Models;

namespace ChatAppWebInterface
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (UserService service = new UserService())
            {
                grdData.DataSource = service.GetUsers().Where(x=>x.ID != LoggedUser.ID);
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

                    if (button.CommandName == "AddFriend")
                    {
                        FriendRequest request = new FriendRequest();
                        request.FromUserId = LoggedUser.ID;
                        request.ToUserId = button.CommandArgument;
                        service.SendFriendRequest(request);

                        button.Text = "Request Sent";
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}