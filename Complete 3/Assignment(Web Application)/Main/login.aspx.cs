using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;

namespace Assignment_Web_Application_.Main
{
    public partial class login : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            FaceBookConnect.API_Key = "2841309615918912";
            FaceBookConnect.API_Secret = "a1a580e39756ec4e3f91440c6d0669b1";

            if (!IsPostBack)
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                    return;
                }

                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me?fields=name,email,gender");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);


                    string id = faceBookUser.Id;
                    string name = faceBookUser.Name;
                    string username;
                    string email = faceBookUser.Email;
                    string image = faceBookUser.PictureUrl;
                    string gender = faceBookUser.Gender;

                    UserProfile u = db.UserProfiles.SingleOrDefault(
                        x => x.socialId == id);

                    if (u != null)
                    {
                        Session["name"] = u.name;
                        Session["userId"] = u.UserID;
                        Session["username"] = u.username;
                        Session["recaptcha"] = u.recaptcha;
                        Session["position"] = u.position;
                        if (u.position != "Admin")
                        {
                            Response.Redirect("~/User/Index_User.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Admin/Admin_Index_User.aspx");
                        }
                    }
                    else
                    {
                        Random r = new Random();
                        bool repeat = true;
                        string userId;
                        string userTname;
                        do
                        {
                            userId = "U";
                            userTname = "";
                            for (int i = 0; i < 9; i++)
                            {
                                userId += Convert.ToString(r.Next(0, 9));
                                if (i > 5)
                                {
                                    userTname += Convert.ToString(r.Next(0, 9));
                                }
                            }

                            if (db.UserProfiles.Any(m => m.UserID == userId))
                            {
                                repeat = true;
                            }
                            else
                            {
                                repeat = false;
                            }

                        } while (repeat);

                        username = name + userTname;

                        UserProfile user = new UserProfile
                        {
                            UserID = userId,
                            username = username,
                            socialId = id,
                            name = name,
                            email = email,
                            image = image,
                            gender = gender == "male" ? "M" : "F",
                            position = "Member",
                            recaptcha = "None"


                        };
                        db.UserProfiles.InsertOnSubmit(user);
                        db.SubmitChanges();

                        Session["name"] = name;
                        Session["userId"] = userId;
                        Session["username"] = username;
                        Session["recaptcha"] = "Member";
                        Session["position"] = "None";
                        Response.Redirect("~/User/Index_User.aspx");
                    }
                }
            }


        }

        protected void Facebook_Login(object sender, EventArgs e)
        {
            FaceBookConnect.Authorize("email", Request.Url.AbsoluteUri.Split('?')[0]);
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string realPassword = Security.Encrypt(username, password);


            int count = (from s in db.UserProfiles
                         where s.password == realPassword && s.username == username && s.socialId == null
                         select s).Count();

            if (count > 1)
            {

                Response.Redirect("ForgetPassword.aspx?username=" + username + "&password=" + realPassword);

            }
            else
            {

                UserProfile u = db.UserProfiles.SingleOrDefault(
                    x => x.username == username &&
                         x.password == realPassword
                    );

                if (u != null)
                {
                    Session["name"] = u.name;
                    Session["userId"] = u.UserID;
                    Session["username"] = u.username;
                    Session["position"] = u.position;
                    Session["recaptcha"] = u.recaptcha;
                    Session["position"] = u.position;
                    HttpCookie coo = Request.Cookies["id"];

                    if (coo == null || coo.Value == u.UserID)
                    {
                        if (u.position != "Admin")
                        {
                            Response.Redirect("~/User/Index_User.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Admin/Admin_Index_User.aspx");
                        }
                    }
                    else
                    {

                        Response.Redirect("ForgetPassword.aspx?Id=" + u.UserID + "F");

                    }



                }
                else
                {
                    cvNotMatched.IsValid = false;
                }
            }
        }
    }

    public class FaceBookUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
