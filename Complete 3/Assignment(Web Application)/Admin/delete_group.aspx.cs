using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class delete_group : System.Web.UI.Page
    {
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string group = Request.QueryString["grpID"] ?? "";

                string s = "";

                string sql = "Select * from GroupProfile where grpID = @group ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@group", group);




                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    s += string.Format("<br><td><h2>{0}</h2></td><td><h2>{1}</h2></td>", dr["grpID"], dr["title"]);

                }
                dr.Close();

                con.Close();

                litGroup.Text = s;


            }


        }



        protected void btnReturn_Click(object sender, EventArgs e)
        {

            Response.Redirect("manage_group.aspx");



        }

        protected void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            string group = Request.QueryString["grpID"] ?? "";

            string sql = "Delete from GroupProfile where grpID = @group";
            Response.Write(group);
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@group", group);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            Response.Redirect("manage_group.aspx");
        }
    }
}