using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Services;

namespace Assignment_Web_Application_.Admin
{


    public partial class Admin_NewPost_Recaptcha : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected static string ReCaptcha_Key = "6LfuBsIUAAAAAJ8D1QnGRdkfyEitAISZuebBwdtT";
        protected static string ReCaptcha_Secret = "6LfuBsIUAAAAAHvv5-Afy9vEdZ12EPTmChPysXG1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null && Session["recaptcha"] != null)
                {
                    litName.Text = Session["name"].ToString();
                    litUsername.Text = "@" + Session["username"].ToString();
                    if (Session["recaptcha"].ToString() == "None")
                    {
                        Response.Redirect("Admin_NewPost.aspx");
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

        [WebMethod]
        public static string VerifyCaptcha(string response)
        {
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            return (new WebClient()).DownloadString(url);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin/manage_member.aspx");
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

                Response.Redirect("Admin_NewPost_Recaptcha.aspx");

            }


        }
    }
}