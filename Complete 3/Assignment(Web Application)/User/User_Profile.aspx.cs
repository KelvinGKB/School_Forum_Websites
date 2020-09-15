using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.User
{
    public partial class User_Profile : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
                {
                    litName.Text = Session["name"].ToString();
                    litUsername.Text = "@" + Session["username"].ToString();
                    litName2.Text = Session["name"].ToString();

                    UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString() );
                    if (s != null)
                    {
                        imgProfile.ImageUrl = s.image;
                        litGender.Text = s.gender;
                        litDescription.Text = s.description;

                    }

                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }



                int countL;
                int countC;

                string id = Session["userId"].ToString();
                string cmd = "SELECT * FROM UserProfile U, Post P WHERE U.UserId=P.userId AND P.userId = @ID";
                string p = "";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(cmd, con1);
                cmd3.Parameters.AddWithValue("@ID", id);
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


                    p += string.Format("<div  style=border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                       "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                           "<div style='display:inline-block;position:relative;top:-15px'>" +
                                   " <img width='50' height='50' style='border-radius:50%' src='{8}' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a href='User_Profile.aspx?{7}'>@{0}</a>" +
                                   " </div>" +
                                    "<div class='h7 text-muted'>{4}</div>" +                        
                                " </div>" +
                                 "<a class='btn' style='float:right' href='delete_post.aspx?PID={7}' rel='modal:open'><span class='glyphicon glyphicon-remove-sign'></span></a>" +
                                  " </div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                       " <a class='card-link btn' style='margin-left:-13px' href='User-Comment-Post.aspx?PID={7}'>" +
                            "<h5 class='card-title'>{1}</h5>" +
                       " </a>" +
                       " <p class='card-text'>{2}</p>" +
                       " <div>" +
                           " <div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-thumbs-up'></span> {6}</div>" +
                            "<div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-comment'></span> {5}</div>" +
                            "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {3}</div>" +
                        "</div>" +
                          "</div>" + 
                
                "</div>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], countC, countL, dr["postID"],dr["image"]);


                }

                dr.Close();
                con1.Close();


                litUserpost.Text = p;




                int countL2;
                int countC2;

               
                string cmd22 = "SELECT * FROM UserProfile U, Post P, Bookmark B WHERE U.UserID = P.userID AND P.postID=B.postId AND B.userID= @ID";
                string p2 = "";

                SqlConnection con12 = new SqlConnection(cs);
                SqlCommand cmd32 = new SqlCommand(cmd22, con12);
                cmd32.Parameters.AddWithValue("@ID", id);
                con12.Open();
                SqlDataReader dr2 = cmd32.ExecuteReader();

                while (dr2.Read())
                {




                    string sql12 = "SELECT COUNT(C.PostId) FROM Comment C WHERE C.postID='" + dr2["postId"] + "'";



                    SqlConnection con7 = new SqlConnection(cs);
                    SqlCommand cmd12 = new SqlCommand(sql12, con7);

                    con7.Open();
                    countC2 = (int)cmd12.ExecuteScalar();
                    con7.Close();

                    string sql2 = "SELECT COUNT(L.PostId) FROM Likes L WHERE L.postID='" + dr2["postId"] + "'";


                    SqlCommand cmd24 = new SqlCommand(sql2, con7);

                    con7.Open();
                    countL2 = (int)cmd24.ExecuteScalar();
                    con7.Close();


                    p2 += string.Format("<div  style=border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                       "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                           "<div style='display:inline-block;position:relative;top:-15px'>" +
                                   " <img width='50' height='50' style='border-radius:50%' src='{8}' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a href='User_Profile.aspx?{7}'>@{0}</a>" +
                                   " </div>" +
                                    "<div class='h7 text-muted'>{4}</div>" +
                                " </div>" +
                                 "<a class='btn' style='float:right' href='delete_bookmark.aspx?PID={7}' rel='modal:open'><span class='glyphicon glyphicon-remove-sign'></span></a>" +
                                  " </div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                       " <a class='card-link btn' style='margin-left:-13px' href='User-Comment-Post.aspx?PID={7}'>" +
                            "<h5 class='card-title'>{1}</h5>" +
                       " </a>" +
                       " <p class='card-text'>{2}</p>" +
                       " <div>" +
                           " <div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-thumbs-up'></span> {6}</div>" +
                            "<div class='text-muted h7 mb-2' style='margin-bottom:5px;margin-right:10px;display:inline-block'><span class='glyphicon glyphicon-comment'></span> {5}</div>" +
                            "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {3}</div>" +
                        "</div>" +
                          "</div>" +

                "</div>", dr2["username"], dr2["title"], dr2["content"], dr2["date"], dr2["name"], countC2, countL2, dr2["postID"], dr2["image"]);


                }

                dr2.Close();
                con12.Close();


                litBookmark.Text = p2;


            }

        }
    }
}