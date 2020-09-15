using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_delete_comment : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {


            string id = Session["userId"].ToString();
            string comment = Request.QueryString["CID"] ?? "";




            Comment c = db.Comments.SingleOrDefault(x => x.userId == id && x.comentId == comment);
            if (c != null)
            {
                string pid = c.postId;
                db.Comments.DeleteOnSubmit(c);
                db.SubmitChanges();

                Response.Redirect("Admin_User-Comment-Post.aspx?PID=" + pid);
            }
            else
            {
                Response.Redirect("~/Main/index.aspx");
            }



        }
    }
}