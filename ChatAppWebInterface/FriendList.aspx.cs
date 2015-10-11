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
    public partial class FriendList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (UserService service = new UserService())
                    {
                        grdData.DataSource = service.GetMyFriends(LoggedUser.ID);
                        grdData.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}