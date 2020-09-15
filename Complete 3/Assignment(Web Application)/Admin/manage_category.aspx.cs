using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class manage_category : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string s = "";

                string sql = "SELECT * FROM Category";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s += string.Format("<tr><td>{0}</td><td>{1}</td>" +
                                       "<td><a href='manage_subcategory.aspx?catID={0}'><span class='glyphicon glyphicon-th-list'></span> Subcategory</a>   | <a href='delete_category.aspx?catID={0}'><span class='glyphicon glyphicon-trash'></span> Delete</a></td></tr>",
                                          dr["catID"], dr["title"]);

                }
                dr.Close();

                con.Close();

                litCategory.Text = s;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Random rnd = new Random();
                string title1 = txtCategory.Text;
                string id = "CID" + (Convert.ToString(rnd.Next(00001, 99999)));



                Category s = new Category
                {
                    catID = id,
                    title = title1

                };

                db.Categories.InsertOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("manage_category.aspx");

            }
        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            string title = args.Value;
            if (db.Categories.Any(s => s.title == title))
            {
                args.IsValid = false;
            }
        }
    }
}