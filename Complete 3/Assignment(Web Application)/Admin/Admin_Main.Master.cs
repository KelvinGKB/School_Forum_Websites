using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_Main : System.Web.UI.MasterPage
    {
        ForumDBDataContext db = new ForumDBDataContext();
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null && Session["position"].ToString() == "Admin")
                {
                    litName.Text = Session["username"].ToString() + " ";
                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString());
                if (s != null)
                {
                    ImgProfile.ImageUrl = s.image;
                    ImgProfile2.ImageUrl = s.image;


                }


                string d = "";

                string sql = "SELECT * FROM Category";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    d += string.Format("<tr><td style='width:150px' ><h3><span class='glyphicon glyphicon-asterisk'></span></h3></td>" +
                          "<td><h3><a href='Admin_category.aspx?cat={0}'>{1}</a></h3></td></tr>", dr["catID"], dr["title"]);

                }
                dr.Close();

                con.Close();


                litCategory.Text = d;

                string p = "";

                string sql2 = "SELECT * FROM Advertisment";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql2, con1);

                con1.Open();

                SqlDataReader dr2 = cmd1.ExecuteReader();
                while (dr2.Read())
                {
                    p += string.Format("<div class='item'><a href='{0}'><img style='height:500px;width:500px' src= '{1}' /></a></div > ",
                                          dr2["link"], dr2["image"]);

                }

                litAD.Text = p;



                lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");


            }





        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Main/index.aspx");
        }

        protected void btnNewPost_Click(object sender, EventArgs e)
        {


            Response.Redirect("Admin_NewPost.aspx");


        }
        protected void GetTime(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        
    }
}