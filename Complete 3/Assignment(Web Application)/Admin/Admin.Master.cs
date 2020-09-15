using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null && Session["position"].ToString() =="Admin" )
                {
                    litName.Text = Session["username"].ToString() + " ";
                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString());
                if (s != null)
                {
                    ImgProfile.ImageUrl = s.image;
                    ImgProfile2.ImageUrl = s.image;


                }

            }

        }


        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Main/index.aspx");
        }

   

    }
}