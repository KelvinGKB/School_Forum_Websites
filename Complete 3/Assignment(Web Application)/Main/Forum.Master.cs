using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_
{
    

    public partial class Forum : System.Web.UI.MasterPage
    {
        string cs = Global.CS;

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
                    s += string.Format("<tr><td style='width:150px' ><h3><span class='glyphicon glyphicon-asterisk'></span></h3></td><td><h3><a data-toggle='modal' data-target='#login' >{1}</a></h3></td></tr>",
                                          dr["catID"],dr["title"]);

                }
                dr.Close();

                con.Close();


                litCategory.Text = s;

                string p = "";

                string sql2 = "SELECT * FROM Advertisment";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql2, con1);

                con1.Open();

                SqlDataReader dr2 = cmd1.ExecuteReader();
                while (dr2.Read())
                {
                    p += string.Format("<div class='item'><a href='{0}'><img style='height:500px;width:500px' src= '{1}' /></a></div > ",
                                          dr2["link"],dr2["image"]);

                }

                litAD.Text = p;



                lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            }

        }
        protected void GetTime(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


        protected void btnEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}