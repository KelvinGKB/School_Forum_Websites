using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Main
{
    public partial class Comment_Post : System.Web.UI.Page
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
                 //   s += string.Format(,
                      //                    dr["UserID"], dr["name"], dr["username"], dr["gender"], dr["email"], dr["position"]);

                }
                dr.Close();

                con.Close();

                litPost.Text = s;
            }
        }
    }
}