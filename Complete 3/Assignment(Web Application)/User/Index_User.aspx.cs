using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.User
{
    public partial class Index_User : System.Web.UI.Page
    {
        string cs = Global.CS;

        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                if (Session["userId"] != null && Session["username"] != null && Session["name"] != null && Session["recaptcha"] != null)
                {
                   



                    string pID = Request.QueryString["PID"];

                    if (pID != null)
                    {
                        Like_Method(pID);
                    }




                    int countLikeStatus = 0;

                    string[] postID = new string[0];

                    SqlConnection con2 = new SqlConnection(cs);
                    string sql3 = "SELECT COUNT(L.userId) FROM Likes L WHERE L.userId='" + Session["userId"].ToString() + "'";

                    SqlCommand cmd4 = new SqlCommand(sql3, con2);

                    con2.Open();
                    countLikeStatus = (int)cmd4.ExecuteScalar();
                    con2.Close();

                    if (countLikeStatus > 0)
                    {
                        postID = new string[countLikeStatus];

                        string sql4 = "SELECT * FROM Likes L WHERE L.userId='" + Session["userId"].ToString() + "'";


                        SqlCommand cmd5 = new SqlCommand(sql4, con2);
                        con2.Open();
                        SqlDataReader lr = cmd5.ExecuteReader();
                        int i = 0;
                        while (lr.Read())
                        {
                            postID[i] = (string)lr["postId"];
                            i++;
                        }
                        lr.Close();
                        con2.Close();
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

                        string likeStatus = "Like";


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





                        if (countLikeStatus > 0)
                        {

                            for (int i = 0; i < postID.Length; i++)
                            {
                                if (postID[i] == (string)dr["postId"])
                                {

                                    likeStatus = "Liked";

                                }


                            }
                        }
                        else
                        {
                            likeStatus = "Like";
                        }







                        s += string.Format("<div  style='margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                           "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                               "<div style='display:inline-block;position:relative;top:-15px'>" +
                                       " <img width='50' height='50' style='border-radius:50%' src='{8}' alt=''>" +
                               " </div>" +
                               " <div class='ml-2'  style='display:inline-block;'>" +
                                       " <div class='h5 m-0'>" +
                                            "<a href='Other_Profile.aspx?UID={9}'>@{0}</a>" +
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
                                           " <a type='button' class='Idinfo dropdown-item btn' href='add_bookmark.aspx?PID={7}' rel='modal:open'><span class='glyphicon glyphicon-flag'></span> Bookmark</a>" +
                                           " <a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-remove'></span> Hide</a>" +
                                            "<a type='button' class='Idinfo dropdown-item btn' href='report_post.aspx?PID={7}' rel='modal:open' ><span class='glyphicon glyphicon-bullhorn'></span> Report</a>" +
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
                            "<a href='Index_User.aspx?PID={7}' class='btn btn-primary col-sm-5' style='text-align:center;margin-right:100px'><span class='glyphicon glyphicon-thumbs-up'></span>{10}</a>" +
                               " <a href='User-Comment-Post.aspx?PID={7}' class='btn btn-primary col-sm-5' style='text-align:center'><span class='glyphicon glyphicon-comment'></span> Comment</a>" +
                      "</div>" +
                    "</div>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], countC, countL, dr["postID"], dr["image"], dr["UserID"],likeStatus);


                    }

                    dr.Close();
                    con1.Close();


                    litPost.Text = s;



                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }
            }


        }


        void Like_Method(string pid)
        {
            Like l = db.Likes.SingleOrDefault(x => x.userId == Session["userId"].ToString() && x.postId == pid);

            if (l != null)
            {

                db.Likes.DeleteOnSubmit(l);
                db.SubmitChanges();
                Response.Redirect("Index_User.aspx");

            }
            else
            {
                Like like = new Like
                {
                    userId = Session["userId"].ToString(),
                    postId = pid
                };

                db.Likes.InsertOnSubmit(like);
                db.SubmitChanges();
                Response.Redirect("Index_User.aspx");
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {

        }
    }
}