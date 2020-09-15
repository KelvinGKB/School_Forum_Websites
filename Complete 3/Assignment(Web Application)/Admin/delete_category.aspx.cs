using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_category : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string id = Request.QueryString["catID"];

                Category s = db.Categories.SingleOrDefault(x => x.catID == id);
                if (s != null)
                {
                    lblID.Text = s.catID;
                    lblTitle.Text = s.title;

                }
                else
                {
                    Response.Redirect("manage_category.aspx");
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {

            Response.Redirect("manage_category.aspx");



        }


        protected void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = lblID.Text;


                Category s = db.Categories.SingleOrDefault(x => x.catID == id);
                if (s != null)
                {
                    db.Categories.DeleteOnSubmit(s);
                    db.SubmitChanges();

                }

                Response.Redirect("manage_category.aspx");

            }
        }
    }
}