using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.User
{
    public partial class delete_post : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string id = Session["userId"].ToString();
            string post = Request.QueryString["PID"] ?? "";





            var queryL = from l in db.Likes
                         where l.postId == post
                         select l;

            var queryC = from c in db.Comments
                         where c.postId == post
                         select c;

            var queryB = from b in db.Bookmarks
                         where b.postID == post
                         select b;

            var queryR = from r in db.Reports
                         where r.postID == post
                         select r;




            if (queryL.Any() && queryC.Any() && queryB.Any() && queryR.Any())
            {
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Comments.DeleteAllOnSubmit(queryC);
                db.SubmitChanges();
            }
            else if (queryL.Any() && !queryC.Any() && !queryB.Any() && !queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && queryC.Any() && !queryB.Any() && !queryR.Any())
            {
                db.Comments.DeleteAllOnSubmit(queryC);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && !queryC.Any() && queryB.Any() && !queryR.Any())
            {
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && !queryC.Any() && !queryB.Any() && queryR.Any())
            {
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (queryL.Any() && queryC.Any() && !queryB.Any() && !queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Comments.DeleteAllOnSubmit(queryC);
                db.SubmitChanges();
            }
            else if (queryL.Any() && !queryC.Any() && queryB.Any() && !queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.SubmitChanges();

            }
            else if (queryL.Any() && !queryC.Any() && !queryB.Any() && queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && queryC.Any() && queryB.Any() && !queryR.Any())
            {
                db.Comments.DeleteAllOnSubmit(queryC);
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && queryC.Any() && !queryB.Any() && queryR.Any())
            {
                db.Comments.DeleteAllOnSubmit(queryC);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && !queryC.Any() && queryB.Any() && queryR.Any())
            {
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (queryL.Any() && queryC.Any() && queryB.Any() && !queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Comments.DeleteAllOnSubmit(queryC);
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.SubmitChanges();
            }
            else if (queryL.Any() && queryC.Any() && !queryB.Any() && queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Comments.DeleteAllOnSubmit(queryC);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (queryL.Any() && !queryC.Any() && queryB.Any() && queryR.Any())
            {
                db.Likes.DeleteAllOnSubmit(queryL);
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }
            else if (!queryL.Any() && queryC.Any() && queryB.Any() && queryR.Any())
            {
                db.Comments.DeleteAllOnSubmit(queryC);
                db.Bookmarks.DeleteAllOnSubmit(queryB);
                db.Reports.DeleteAllOnSubmit(queryR);
                db.SubmitChanges();
            }



            Post s = db.Posts.SingleOrDefault(x => x.userID == id && x.postID == post);
            if (s != null)
            {
                db.Posts.DeleteOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("User_Profile.aspx");
            }


        }
    }
}