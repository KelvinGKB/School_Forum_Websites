using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_NewPost : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               


                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null && Session["recaptcha"]!=null)
                {
                    litName.Text = Session["name"].ToString();
                    litUsername.Text = "@" + Session["username"].ToString();

                    if(Session["recaptcha"].ToString()=="Activated")
                    {
                        Response.Redirect("Admin_NewPost_Recaptcha.aspx");
                    }


                    UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString());
                    if (s != null)
                    {
                        imgProfile.ImageUrl = s.image;
                        

                    }

                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }



            }


        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                string id = Session["userId"].ToString();

                Random rnd = new Random();
                string pid = "PID" + (Convert.ToString(rnd.Next(00001, 99999)));
                string title1 = txtTitle.Text;
                string comment = txtcomment.Text;
                string uid = id;
                string cid = ddlCategory.SelectedValue;
                string sid = ddlSubCategory.SelectedValue;
                DateTime datenow = DateTime.Now;

                Post s = new Post
                {
                    userID = uid,
                    title = title1,
                    content = comment,
                    subID = sid,
                    postID = pid,
                    date = datenow
                };

                db.Posts.InsertOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("Admin_NewPost.aspx");

            }


        }
    }
}