using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.Admin
{
    public partial class Add_Advertisment : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_advertisment.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {



                     Random rnd = new Random();
                     string Name = txtName.Text;
                     string Link = txtLink.Text;

                     string id = "AdID" + (Convert.ToString(rnd.Next(0001, 9999)));


                    string path = MapPath("../Uploads/");
                    string filename = imageAD.FileName;
                    imageAD.SaveAs(path + filename);



                    string image = "../Uploads/" + filename;

                Advertisment s = new Advertisment
                {
                    AdID = id,
                    link = Link,
                    Name = Name,
                    image = image

                };


                db.Advertisments.InsertOnSubmit(s);
                db.SubmitChanges();

                Response.Redirect("manage_advertisment.aspx");
            }


        }
    }


}