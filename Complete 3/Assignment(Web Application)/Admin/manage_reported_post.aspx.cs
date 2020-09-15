using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class manage_security : System.Web.UI.Page
    {
        //dsForumDataContext db = new dsForumDataContext();
        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // string post = Request.QueryString["PID"];

                // var q = from s in db.Posts
                //      where post == s.postID
                //     select new
                //   {
                //     s.postID,s.title,s.subID,s.content,s.date,s.
                //};

                if (!Page.IsPostBack)
                {

                    string s = "";

                    string sql = "SELECT r.reportID,r.reason,r.userID,r.postID,p.userID AS Poster FROM Report r ,Post p where r.postID = p.postID";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        s += string.Format("<tr><td>{0}</td><td>{1}</td><td><a href='Admin_Other_Profile.aspx?UID={2}'>{2}</a></td><td><a href='Admin_Other_Profile.aspx?UID={3}'>{3}</a></td><td><a href='delete_reported_post.aspx?PID={4}'>{4}</a></td><td><a href='delete_report.aspx?RID={0}' rel='modal:open'>Delete</a></td>" +
                                           "</tr>",
                                              dr["reportID"], dr["reason"], dr["userID"], dr["Poster"], dr["postID"]);

                    }
                    dr.Close();

                    con.Close();

                    litReported.Text = s;
                }





            }

        }
    }
}