using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_like : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ForumDBDataContext db = new ForumDBDataContext();

            if (!IsPostBack)
            {
                string post = Request.QueryString["PID"] ?? "";
                string id = Session["userId"].ToString();


           

                Like s = db.Likes.SingleOrDefault(x => x.userId == id && x.postId == post );
                if (s == null)
                {
                    
                    Like a = new Like
                    {
                        userId = id,
                        postId = post
                    };

                    db.Likes.InsertOnSubmit(a);
                    db.SubmitChanges();

                    string link2 = "Admin_User-Comment-Post.aspx?PID=" + post;
                    Response.Redirect(link2);


                }
                else
                {
                    //Like k = db.Likes.SingleOrDefault(x => x.userId == id);
                    if (s != null)
                    {
                        db.Likes.DeleteOnSubmit(s);
                        db.SubmitChanges();

                    }


                    string link2 = "Admin_User-Comment-Post.aspx?PID=" + post;
                    Response.Redirect(link2);

                }



                string link = "Admin_User-Comment-Post.aspx?PID=" + post;

                Response.Redirect(link);

            }
        }
    }
}