using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_member : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string id = Request.QueryString["UID"];

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (s != null)
                {
                    lblID.Text = s.UserID;
                    lblUsername.Text = s.username;
                    lblName.Text = s.name;
                    lblGender.Text = s.gender;
                    lblPosition.Text = s.position;
                    lblRecaptcha.Text = s.recaptcha;

                }
                else
                {
                    Response.Redirect("manage_member.aspx");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = lblID.Text;


                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (s != null)
                {
                    db.UserProfiles.DeleteOnSubmit(s);
                    db.SubmitChanges();

                }

                Response.Redirect("manage_member.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_member.aspx");
        }
    }
}
