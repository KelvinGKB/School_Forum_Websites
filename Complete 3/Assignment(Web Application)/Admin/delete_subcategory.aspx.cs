using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_subcategory : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string id = Request.QueryString["subID"];

                SubCategory s = db.SubCategories.SingleOrDefault(x => x.subID == id);
                if (s != null)
                {
                    lblID.Text = s.subID;
                    lblTitle.Text = s.title;

                }
                else
                {
                    Response.Redirect("manage_subcategory.aspx");
                }

            }
        }

        protected void btnDeleteSubcategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = lblID.Text;


                SubCategory s = db.SubCategories.SingleOrDefault(x => x.subID == id);
                if (s != null)
                {
                    db.SubCategories.DeleteOnSubmit(s);
                    db.SubmitChanges();

                }

                string id2 = Request.QueryString["catID"];

                string link = "manage_subcategory.aspx?catID=" + id2;

                Response.Redirect(link);

            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {

            string id2 = Request.QueryString["catID"];

            string link = "manage_subcategory.aspx?catID=" + id2;

            Response.Redirect(link);

        }
    }
}