using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace Assignment_Web_Application_.User
{
    public partial class changePic : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
                {
                    string Uid = Session["userId"].ToString();

                    string sql = "SELECT image FROM UserProfile WHERE UserID = @UserID";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@UserID", Uid);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        prePhoto.ImageUrl = dr["image"].ToString();

                    }

                    dr.Close();
                    con.Close();

                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }
            }
            
        }

        protected void uploadID_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                /*
                string path = MapPath("~/ProfilePicture/");
                string filename = fileID.FileName;

                fileID.SaveAs(path + filename);


                image = "~/ProfilePicture/" + filename;


                imageID.AlternateText = filename;
                imageID.ImageUrl = "~/ProfilePicture/" + filename;
                */

            }

            
            
        }

        /*
        if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
        {
            string Uid = Session["userId"].ToString();
            string pics = "";
            if (fileID.FileName!=null)
            {
                pics  = "~/ProfilePicture/" + fileID.FileName;
            }else if (image != null)
            {
                 pics = image;
            }
            else
            {
                pics = "";
            }

            string sql = @"UPDATE UserProfile SET image = @image WHERE UserID = @UserID";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@image", pics);
            cmd.Parameters.AddWithValue("@UserID", Uid);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Session["image"] = pics;
            Response.Redirect("Setting.aspx");
        }
        else
        {
            Response.Redirect("~/Main/index.aspx");
        }
        */
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserProfile u = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString());

                if(u != null)
                {
                    
                    
                        string path = MapPath("../Uploads/");
                    string filename = fileID.FileName;
                    fileID.SaveAs(path + filename);

                    

                        u.image = "../Uploads/" + filename;



                    db.SubmitChanges();
                }

                Response.Redirect("changePic.aspx");
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Setting.aspx");
        }
    }
}