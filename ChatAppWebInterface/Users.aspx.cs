using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatAppService;

namespace ChatAppWebInterface
{
	public partial class Users : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			using(UserService service = new UserService())
			{
				grdData.DataSource =  service.GetUsers();
				grdData.DataBind();
			}
		}
	}
}