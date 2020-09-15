using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Assignment_Web_Application_.Admin
{
    public partial class edit_Ads : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
                {

                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }


                string id = Request.QueryString["AID"] ?? "";

                Advertisment s = db.Advertisments.SingleOrDefault(x => x.AdID == id);

                if (s != null)
                {

                    
                    txtName.Text = s.Name;
                    txtLink.Text = s.link;
                    imgAds.ImageUrl = s.image;




                }
                else
                {
                    Response.Redirect("manage_advertisment.aspx");
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string name = txtName.Text;
                string link = txtLink.Text;

                string path = MapPath("../Uploads/");
                string filename = imageAD.FileName;
                imageAD.SaveAs(path + filename);

                string image = "../Uploads/" + filename;

                string id = Request.QueryString["AID"] ?? "";

                Advertisment s = db.Advertisments.SingleOrDefault(x => x.AdID == id);
                if (s != null)
                {

                    s.Name = name;
                    s.link = link;
                    s.image = image;

                    db.SubmitChanges();


                }


                Response.Redirect("manage_advertisment.aspx");
            }


        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_advertisment.aspx");
        }
    }
}