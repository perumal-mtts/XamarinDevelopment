using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatAppService.Models;

namespace ChatAppWebInterface
{
    public class BasePage : System.Web.UI.Page
    {

        public User LoggedUser
        {
            get
            {
                if (Session["LoggedUser"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                return Session["LoggedUser"] as User;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}