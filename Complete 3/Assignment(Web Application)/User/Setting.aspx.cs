using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_Web_Application_.User
{
    public partial class Setting : System.Web.UI.Page
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


                 string id = Session["userId"].ToString();

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (s != null)
                {
                   
                    litUsername.Text = s.username;
                    txtName.Text = s.name;
                    rblGender.Text = s.gender;
                    txtDescription.Text = s.description;
                    ddlPrivacy.DataValueField = s.privacy;

                    if (s.socialId != null)
                    {
                        trPassword.Visible = false;
                    }


                }
                else
                {
                    Response.Redirect("index_User.aspx");
                }
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                
                string name = txtName.Text;
                string description = txtDescription.Text;
                string gender = rblGender.Text;
                string privacy = ddlPrivacy.Text;

               

                
                string id = Session["userId"].ToString();

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (s != null)
                {
                  
                    s.name = name;
                    s.description = description;
                    s.gender = gender;
                    s.privacy = privacy;
                   
                    db.SubmitChanges();
                    

                }

                
                Response.Redirect("Setting.aspx");
            }


        }
    }
}