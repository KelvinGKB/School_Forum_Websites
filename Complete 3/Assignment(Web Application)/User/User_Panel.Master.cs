using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Assignment_Web_Application_.User
{
    public partial class User_Panel : System.Web.UI.MasterPage 
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if (Session["userId"] != null && Session["username"] != null && Session["position"].ToString() == "Member")
                {

                    litName.Text = Session["username"].ToString();


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

        protected void Logout1(object sender, EventArgs e)
        {



            Session.Clear();
                
                Response.Redirect("~/Main/index.aspx");
           

        }

        protected void Logout2(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Main/index.aspx");
        }
    }
}