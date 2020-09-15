using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_report_post : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Session["userId"].ToString();
                string pid = Request.QueryString["PID"];
                Random rnd = new Random();
                string rid = "RID" + (Convert.ToString(rnd.Next(00001, 99999)));
                string uid = id;
                string reason1 = rblReport.SelectedValue;


                Report s = new Report
                {
                    userID = uid,
                    reason = reason1,
                    postID = pid,
                    reportID = rid
                   
                };

                db.Reports.InsertOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("Admin_Index_User.aspx");
               

            }


        }
    }
}