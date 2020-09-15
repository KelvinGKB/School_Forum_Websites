using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class manage_member : System.Web.UI.Page
    {
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string s = "";

                string sql = "SELECT * FROM UserProfile";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td>" +
                                       "<td><a href='edit_member.aspx?UID={0}'><span class='glyphicon glyphicon-pencil'></span> Edit</a> | <a href='delete_member.aspx?UID={0}'><span class='glyphicon glyphicon-trash'></span> Delete</a></td></tr>",
                                          dr["UserID"], dr["name"], dr["username"], dr["gender"], dr["email"], dr["position"], dr["recaptcha"]);

                }
                dr.Close();

                con.Close();

                litMember.Text = s;
            }
        }
    }
}