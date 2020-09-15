using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.User
{
    public partial class delete_bookmark : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = Session["userId"].ToString();
            string post = Request.QueryString["PID"] ?? "";

            Bookmark s = db.Bookmarks.SingleOrDefault(x => x.userID == id && x.postID == post);
            if (s != null)
            {
                db.Bookmarks.DeleteOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("User_Profile.aspx");
            }

        }
    }
}