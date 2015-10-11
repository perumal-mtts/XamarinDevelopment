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
    public partial class MyRequests : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (UserService service = new UserService())
                    {
                        grdData.DataSource = service.GetMyRequests(LoggedUser.ID);
                        grdData.DataBind();
                    }
                }
                catch (Exception ex)
                {
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

                    if (button.CommandName == "Approve")
                    {
                        FriendRequest request = new FriendRequest();
                        request.FromUserId = button.CommandArgument;
                        request.ToUserId = LoggedUser.ID;
                        service.ApproveFriendRequest(request);
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