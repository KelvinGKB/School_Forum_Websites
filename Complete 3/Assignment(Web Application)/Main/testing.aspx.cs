using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Main
{
    public partial class testing : System.Web.UI.Page
    {
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int countL;
                int countC;
                string cmd = "SELECT * FROM UserProfile U, Post P WHERE U.UserId=P.userId";
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
                                   " <img width='50' style='border-radius:50%' src='https://picsum.photos/50/50' alt=''>" +
                           " </div>" +
                           " <div class='ml-2'  style='display:inline-block;'>" +
                                   " <div class='h5 m-0'>" +
                                        "<a href='post-comment.aspx?{7}'>@{0}</a>" +
                                   " </div>" +
                                    "<div class='h7 text-muted'>{4}</div>" +
                               " </div>" +
                                "<div class='dropdown' style='display:inline-block;float:right'>" +
                                   " <button class='btn btn-link dropdown-toggle' type='button' id='gedf-drop1' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' > "+
                                      "  <i class='fa fa - ellipsis - h'></i>" +
                                    "</button>" +
                                    "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='gedf-drop1'>" +
                                       " <div class='h6 dropdown-header'>Option</div>" +
                                       " <hr />" +
                                       " <a class='dropdown-item btn' href='bookmark.aspx?{7}'><span class='glyphicon glyphicon-flag'></span> Bookmark</a>" +
                                       " <a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-remove'></span> Hide</a>" +
                                        "<a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-bullhorn'></span> Report</a>" +
                                   "  </div>" +
                                   " </div>" +
                                 "</div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                       " <a class='card-link btn' style='margin-left:-13px' href='#'>" +
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
                        "<button type='button' class='btn btn-primary col-sm-5' style='text-align:center;margin-right:100px'><span class='glyphicon glyphicon-thumbs-up'></span>Like</button>" +
                       " <button type='button' class='btn btn-primary col-sm-5' style='text-align:center'><span class='glyphicon glyphicon-comment'></span> Comment</button>" +
                  "</div>" +
                "</div>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], countC, countL, dr["postID"]);

                   
                }

                dr.Close();
                con1.Close();
               

                litPost.Text = s;



            }


        }


    }
        
}