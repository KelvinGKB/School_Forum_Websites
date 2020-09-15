using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.User
{
    public partial class add_bookmark : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Session["userId"].ToString();
                string pid = Request.QueryString["PID"];
                Random rnd = new Random();
                string uid = id;
                DateTime datenow = DateTime.Now;


                Bookmark b = db.Bookmarks.SingleOrDefault(x => x.postID == pid && x.userID == id);

                if (b != null)
                {
                    Response.Redirect("Index_User.aspx");
                }
                else
                {


                    Bookmark s = new Bookmark
                    {
                        userID = uid,
                        postID = pid,
                        date = datenow

                    };

                    db.Bookmarks.InsertOnSubmit(s);
                    db.SubmitChanges();

                    Response.Redirect("Index_User.aspx");

                }

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}