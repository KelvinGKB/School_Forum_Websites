using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{

    public partial class manage_post : System.Web.UI.Page
    {
        string cs = Global.CS;
        ForumDBDataContext db = new ForumDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string s = "";

                string sql = "Select * From UserProfile U, Post P Where P.userID = U.userID Order By P.date";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    s += string.Format("<tr><td><div  style='border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;'>" +
                      "<div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>" +
                          "<div style='display:inline-block;position:relative;top:-15px'>" +
                                  " <img width='50' height='50' style='border-radius:50%' src='{6}' alt='' />" +
                          " </div>" +
                          " <div class='ml-2'  style='display:inline-block;'>" +
                                  " <div class='h5 m-0'>" +
                                       "<a href='Admin_Other_Profile.aspx?UID={7}'>@{0}</a>" +
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
                                      " <a class='dropdown-item btn' href='bookmark.aspx?{5}'><span class='glyphicon glyphicon-flag'></span> Bookmark</a>" +
                                      " <a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-remove'></span> Hide</a>" +
                                       "<a class='dropdown-item btn' href='#'><span class='glyphicon glyphicon-bullhorn'></span> Report</a>" +
                                  "  </div>" +
                                  " </div>" +
                                "</div>" +
"  <div  style='text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 '>" +
                      " <a class='card-link btn' style='margin-left:-13px' href='Admin_User-Comment-Post.aspx?PID={5}'>" +
                           "<h5 class='card-title'>{1}</h5>" +
                      " </a>" +
                      " <p class='card-text'>{2}</p>" +
                      " <div>" +

                           "<div class='text-muted h7 mb-2' style='float:right;margin-bottom:5px;margin-right:10px;display:inline-block'> <i class='fa fa-clock-o'></i> {3}</div><br>" +
                       "</div>" +
                         "</div>" +

               "</div></td><td><a type='button' href='admin_delete_posts.aspx?PID={5}' class='btn btn-Danger'>Delete</a></td></tr>", dr["username"], dr["title"], dr["content"], dr["date"], dr["name"], dr["postID"], dr["image"],dr["UserID"]);

                }
                dr.Close();

                con.Close();

                litPosts.Text = s;
            }
        }

        protected void btnDeletePosts_Click(object sender, EventArgs e)
        {


        }
    }
}