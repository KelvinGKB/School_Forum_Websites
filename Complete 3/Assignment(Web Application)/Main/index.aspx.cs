using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace Assignment_Web_Application_
{
    public partial class index : System.Web.UI.Page
    {
        string cs = Global.CS;

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
                            position = "Member"

                        };
                        db.UserProfiles.InsertOnSubmit(user);
                        db.SubmitChanges();

                        Session["name"] = name;
                        Session["userId"] = userId;
                        Session["username"] = username;
                        Response.Redirect("~/User/Index_User.aspx");
                    }
                }


                int countL;
                int countC;
                string cmd = "SELECT * FROM UserProfile U, Post P WHERE U.UserId=P.userId order by date desc";
                string s = "";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(cmd, con1);
                con1.Open();
                SqlDataReader dr = cmd3.ExecuteReader();

                while (dr.Read())
                {




                    string sql1 = "SELECT COUNT(C.PostId) FROM Comment C WHERE C.postID='" + dr["postId"] + "'";



                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con);

                    con.Open();
                    countC = (int)cmd1.ExecuteScalar();
                    con.Close();

                    string sql2 = "SELECT COUNT(L.PostId) FROM Likes L WHERE L.postID='" + dr["postId"] + "'";


                    SqlCommand cmd2 = new SqlCommand(sql2, con);

                    con.Open();
                    countL = (int)cmd2.ExecuteScalar();
                    con.Close();


                    s += string.Format("<div  style='margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                       "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                           "<div style='display:inline-block;position:relative;top:-15px'>" +
                                   " <img width='50' height='50' style='border-radius:50%' src='{8}' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a data-toggle='modal' data-target='#login' >@{0}</a>" +
                                   " </div>" +
                                    "<div class='h7 text-muted'>{4}</div>" +
                               " </div>" +
                                "<div class='dropdown' style='display:inline-block;float:right'>" +
                                   " <button class='btn btn-link dropdown-toggle' type='button' id='gedf-drop1' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' > " +
                                      "  <i class='fa fa - ellipsis - h'></i>" +
                                    "</button>" +
                                    "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='gedf-drop1'>" +
                                       " <div class='h6 dropdown-header'>Option</div>" +
                                       " <hr />" +
                                       " <a type='button' class='Idinfo dropdown-item btn' data-toggle='modal' data-target='#login' ><span class='glyphicon glyphicon-flag'></span> Bookmark</a>" +
                                       " <a class='dropdown-item btn' data-toggle='modal' data-target='#login' ><span class='glyphicon glyphicon-remove'></span> Hide</a>" +
                                        "<a type='button' class='Idinfo dropdown-item btn' data-toggle='modal' data-target='#login' ><span class='glyphicon glyphicon-bullhorn'></span> Report</a>" +
                                   "  </div>" +
                                   " </div>" +
                                 "</div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                       " <a class='card-link btn' style='margin-left:-13px' data-toggle='modal' data-target='#login' '>" +
                            "<h5 class='card-title'>{1}</h5>" +
                       " </a>" +
                       " <p class='card-text'>{2}</p>" +
                       " <div>" +
                           " <div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-thumbs-up'></span> {6}</div>" +
                            "<div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-comment'></span> {5}</div>" +
                            "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {3}</div>" +
                        "</div>" +
                          "</div>" +
                       " <div class='card-footer' style='text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;'>" +
                        "<button type='button' class='btn btn-primary col-sm-5' style='text-align:center;margin-right:100px' data-toggle='modal' data-target='#login'><span class='glyphicon glyphicon-thumbs-up'></span>Like</button>" +
                       " <button type='button' class='btn btn-primary col-sm-5' style='text-align:center' data-toggle='modal' data-target='#login'><span class='glyphicon glyphicon-comment'></span> Comment</button>" +
                  "</div>" +
                "</div>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], countC, countL, dr["postID"], dr["image"]);


                }

                dr.Close();
                con1.Close();


                litPost.Text = s;

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string username = txtUser.Text;
                string password = txtPassword.Text;
                string realPassword = Security.Encrypt(username, password);

                int count = (from s in db.UserProfiles
                             where s.password == realPassword && s.username == username && s.socialId == null
                             select s).Count();

                if (count > 1)
                {
                    Session["username"] = username;
                    Session["password"] = realPassword;
                    Response.Redirect("ForgetPassword.aspx");

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

        protected void btnFacebookLogin_Click(object sender, EventArgs e)
        {
            FaceBookConnect.Authorize("email", Request.Url.AbsoluteUri.Split('?')[0]);
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