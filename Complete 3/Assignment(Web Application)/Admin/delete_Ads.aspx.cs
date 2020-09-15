using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_Ads : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Request.QueryString["AID"];


                Advertisment s = db.Advertisments.SingleOrDefault(x => x.AdID == id);
                if (s != null)
                {
                    db.Advertisments.DeleteOnSubmit(s);
                    db.SubmitChanges();

                }

                Response.Redirect("manage_advertisment.aspx");

            }

        }

    }
}