using LOrdCardShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsernameLabel.Text = Session["user"] != null ? $"Welcome {Session["user"]}" : "Welcome Guest";
            }
            if (Session["User"] == null)
            {
                GuestNavbar.Visible = true;
                DefaultNavbar.Visible = false;
            }
            else
            {
                GuestNavbar.Visible = false;
                DefaultNavbar.Visible = true;
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Redirect("~/Views/Login.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}