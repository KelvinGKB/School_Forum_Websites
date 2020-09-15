using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class Admin_User_Comment_Post : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null && Session["username"] != null && Session["name"] != null)
            {
                litName.Text = Session["name"].ToString();
                litUsername.Text = "@" + Session["username"].ToString();

                UserProfile s = db.UserProfiles.SingleOrDefault(x => x.UserID == Session["userId"].ToString());
                if (s != null)
                {
                    imgProfile.ImageUrl = s.image;


                }

            }
            else
            {
                Response.Redirect("~/Main/index.aspx");
            }


            if (!IsPostBack)
            {
                string post = Request.QueryString["PID"] ?? "";

                string likeStatus;

                Post p = db.Posts.SingleOrDefault(x => x.postID == post);

                Like l = db.Likes.SingleOrDefault(x => x.postId == post && x.userId == Session["userId"].ToString());

                if (l != null)
                {
                    likeStatus = "Liked";
                }
                else
                {
                    likeStatus = "Like";
                }






                int countL;
                int countC;
                string cmd = "SELECT * FROM UserProfile U, Post P WHERE U.UserId=P.userId AND P.postID=@Post";
                string s = "";
                string c = "";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(cmd, con1);
                cmd3.Parameters.AddWithValue("@Post", post);
                con1.Open();
                SqlDataReader dr = cmd3.ExecuteReader();



                string sql1 = "SELECT COUNT(C.PostId) FROM Comment C WHERE C.postID=@Post";



                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.Parameters.AddWithValue("@Post", post);

                    con.Open();
                    countC = (int)cmd1.ExecuteScalar();
                    con.Close();

                string sql2 = "SELECT COUNT(L.PostId) FROM Likes L WHERE L.postID=@Post";


                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.AddWithValue("@Post", post);
                    con.Open();
                    countL = (int)cmd2.ExecuteScalar();
                    con.Close();



                

                while (dr.Read())
                {
                    s += string.Format("<div  style='margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                       "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                           "<div style='display:inline-block;position:relative;top:-15px'>" +
                                   " <img width='50' width='50' style='border-radius:50%' src='{8}' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a href='Admin_Other_Profile.aspx?UID={9}'>@{0}</a>" +
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
                                       " <a class='dropdown-item btn' href='Admin_Add_bookmark.aspx?PID={7}' rel='modal:open'><span class='glyphicon glyphicon-flag'></span> Bookmark</a>" +
                                       " <a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-remove'></span> Hide</a>" +
                                        "<a class='dropdown-item btn' href='Admin_report_post.aspx?PID={7}' rel='modal:open'><span class='glyphicon glyphicon-bullhorn'></span> Report</a>" +
                                   "  </div>" +
                                   " </div>" +
                                 "</div>" +
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
                       " <div class='card-footer' style='text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;'>" +
                        "<a type='button' href='Admin_like.aspx?PID={7}'class='btn btn-primary col-sm-5' style='text-align:center;margin-right:100px' ><span class='glyphicon glyphicon-thumbs-up'></span>{10}</a>" +
                  "</div>" +
                "</div>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], countC, countL, dr["postID"],dr["image"],dr["UserID"],likeStatus);

                }


                

                dr.Close();
                con1.Close();


                litPost.Text = s;


                string sql3 = "SELECT* FROM UserProfile U, Comment C WHERE U.UserId = C.userId AND C.postID = @Post order by date";
                SqlCommand cmd4 = new SqlCommand(sql3, con);
                cmd4.Parameters.AddWithValue("@Post", post);
                con.Open();
                SqlDataReader dr2 = cmd4.ExecuteReader();

                int countD = 0;
                while (dr2.Read())
                {
                    countD = countD + 1;


                    Comment com1 = db.Comments.SingleOrDefault(x => x.comentId == dr2["comentId"].ToString() && x.userId == Session["userId"].ToString());


                    if (com1 != null)
                    {

                        c += string.Format("<tr><td><div  style='margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                      "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                      " <p style='float:right;padding-right:5px'>#{5}</p>" +
                      "<a class='btn' style='float:right' href='Admin_delete_comment.aspx?CID={8}' rel='modal:open'><span class='glyphicon glyphicon-remove-sign'></span></a>" +
                          "<div style='display:inline-block;position:relative;top:-15px'>" +
                                  " <img width='50' height='50' style='border-radius:50%' src='{6}' alt=''>" +
                          " </div>" +
                          " <div class='ml-2'  style='display:inline-block;'>" +
                                  " <div class='h5 m-0'>" +
                                       "<a href='Admin_Other_Profile.aspx?UID={7}'>@{0}</a>" +
                                  " </div>" +
                                   "<div class='h7 text-muted'>{3}</div>" +
                              " </div></div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                      "<br> <p class='card-text'>{1}</p>" +
                      " <div>" +
                           "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {2}</div><br>" +
                       "</div>" +
                         "</div>" +
               "</div></td></tr>", dr2["username"], dr2["content"], dr2["date"], dr2["name"], dr2["UserID"], countD, dr2["image"], dr2["UserID"], dr2["comentId"]);


                    }
                    else
                    {

                        c += string.Format("<tr><td><div  style='margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                       "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                       " <p style='float:right;padding-right:5px'>#{5}</p>" +
                           "<div style='display:inline-block;position:relative;top:-15px'>" +
                                   " <img width='50' height='50' style='border-radius:50%' src='{6}' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a href='Admin_Other_Profile.aspx?UID={7}'>@{0}</a>" +
                                   " </div>" +
                                    "<div class='h7 text-muted'>{3}</div>" +
                               " </div></div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                       "<br> <p class='card-text'>{1}</p>" +
                       " <div>" +
                            "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {2}</div><br>" +
                        "</div>" +
                          "</div>" +
                "</div></td></tr>", dr2["username"], dr2["content"], dr2["date"], dr2["name"], dr2["UserID"], countD, dr2["image"], dr2["UserID"]);
                    }
                }

                dr2.Close();
                con.Close();

                litComment.Text = c;
            }


        }


        protected void btnComment_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {

                Random rnd = new Random();
                string comment = txtcomment.Text;
                string cid = "COM" + (Convert.ToString(rnd.Next(00001, 99999)));
                string uid = Session["userId"].ToString();
                string pid = Request.QueryString["PID"] ?? "";
                DateTime datenow = DateTime.Now;

                Comment s = new Comment
                {
                    userId = uid,
                    comentId = cid,
                    postId = pid,
                    date = datenow,
                    content = comment
                    
                };

                db.Comments.InsertOnSubmit(s);
                db.SubmitChanges();

                string link = "Admin_User-Comment-Post.aspx?PID=" + pid;
                Response.Redirect(link);



            }


        }
    }
}