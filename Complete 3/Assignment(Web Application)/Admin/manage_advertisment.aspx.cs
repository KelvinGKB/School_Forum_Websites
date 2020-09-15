using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class manage_advertisment : System.Web.UI.Page
    {
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string s = "";

                string sql = "SELECT * FROM Advertisment";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td><img width=100px height=100px src='{3}'></td>" +
                                       "<td><a type='button' href='edit_Ads.aspx?AID={0}' ><span class='glyphicon glyphicon-pencil'></span> Edit |</a>" +
                                       "<a type='button' href='delete_Ads.aspx?AID={0}' rel='modal:open' ><span class='glyphicon glyphicon-trash'></span> Delete</a></td></tr>",
                                          dr["AdID"],dr["Name"],dr["Link"],dr["image"]);

                }
                dr.Close();

                con.Close();

                litAds.Text = s;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_Advertisment.aspx");
        }
    }
}