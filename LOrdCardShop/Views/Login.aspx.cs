using LOrdCardShop.Models;
using LOrdCardShop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Database1Entities db = dbSingleton.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["password"] = "";

                if (Session["User"] != null || Request.Cookies["user_cookie"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = uNameTb.Text;
            string password = pwTb.Text;

            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                errLbl.Text = "Username and Password must be filled!";
                errLbl.Visible = true;
            }
            else
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
                if (user != null)
                {
                    Session["User"] = user.UserName;

                    if (rememberMe.Checked)
                    {
                        HttpCookie userCookie = new HttpCookie("user_cookie", user.UserName);

                        userCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(userCookie);
                    }
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    errLbl.Text = "Username or Password invalid!";
                    errLbl.Visible = true;
                }
            }
        }
    }
}