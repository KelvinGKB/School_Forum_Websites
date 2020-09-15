using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_report : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Request.QueryString["RID"];


                Report s = db.Reports.SingleOrDefault(x => x.reportID == id);
                if (s != null)
                {
                    db.Reports.DeleteOnSubmit(s);
                    db.SubmitChanges();

                }

                Response.Redirect("manage_reported_post.aspx");

            }

        }
    }
}