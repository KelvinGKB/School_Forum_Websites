using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class manage_group : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string s = "";

                string sql = "SELECT * FROM GroupProfile";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s += string.Format("<tr><td>{0}</td><td>{1}</td>" +
                                       "<td><a type='button' href='delete_group.aspx?grpID={0}' ><span class='glyphicon glyphicon-trash'></span> Delete</a></td></tr>",
                                          dr["grpID"], dr["title"]);

                }
                dr.Close();

                con.Close();

                litGroup.Text = s;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Random rnd = new Random();
                string title1 = txtGroup.Text;
                string id = "G" + (Convert.ToString(rnd.Next(0001, 9999)));



                GroupProfile s = new GroupProfile
                {
                    grpID = id,
                    title = title1

                };

                db.GroupProfiles.InsertOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("manage_group.aspx");

            }


        }



        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            string title = args.Value;
            if (db.GroupProfiles.Any(s => s.title == title))
            {
                args.IsValid = false;
            }
        }
    }
}