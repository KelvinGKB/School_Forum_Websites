using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class subcategories : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["catID"];

            string s = "";

            string sql = "Select * from SubCategory where catID = @catID ";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@catID", id);




            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                s += string.Format("<tr><td>{0}</td><td>{1}</td><td><a href='delete_subcategory.aspx?subID={0}&catID={2}'>Delete</a></td></tr>", dr["subID"], dr["title"], dr["catID"]);

            }
            dr.Close();

            con.Close();

            litSubCategory.Text = s;

        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            string title = args.Value;
            if (db.SubCategories.Any(s => s.title == title))
            {
                args.IsValid = false;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                string id = Request.QueryString["catID"];

                Random rnd = new Random();
                string title1 = txtSubCategory.Text;
                string id2 = "subID" + (Convert.ToString(rnd.Next(00001, 99999)));



                SubCategory m = new SubCategory
                {
                    catID = id,
                    title = title1,
                    subID = id2

                };

                db.SubCategories.InsertOnSubmit(m);
                db.SubmitChanges();

                string link = "manage_subcategory.aspx?catID=" + id;

                Response.Redirect(link);

            }

        }


    }
}