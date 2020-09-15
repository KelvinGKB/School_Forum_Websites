using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Assignment_Web_Application_;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_EditPass : System.Web.UI.Page
    {
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null && Session["username"] == null && Session["name"] == null)
                Response.Redirect("~/Main/index.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
            {
                string Uid = Session["userId"].ToString();
                string pass = txtEpass.Text;
                string username = Session["username"].ToString();

                string realPassword = Security.Encrypt(username, pass);

                string sql = "SELECT password  FROM UserProfile WHERE UserID = @UserID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID", Uid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    if (realPassword != (string)dr["password"])
                        args.IsValid = false;

                }

                dr.Close();
                con.Close();

            }
            else
            {
                Response.Redirect("~/Main/index.aspx");
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string pass1 = txtNpass.Text;
            string pass2 = txtCpass.Text;

            if (pass1 != pass2)
            {
                args.IsValid = false;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                
                    string Uid = Session["userId"].ToString();
                    string pass = txtNpass.Text;
                    string username = Session["username"].ToString();

                    string realPassword = Security.Encrypt(username, pass);

                string sql = @"UPDATE UserProfile SET password = @password WHERE UserID = @UserID";

                SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@UserID", Uid);
                    cmd.Parameters.AddWithValue("@password", realPassword);

                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                Session.Clear();

                Response.Redirect("~/Main/login.aspx");



            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Setting.aspx");
        }
    }
}