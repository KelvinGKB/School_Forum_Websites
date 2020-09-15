using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment_Web_Application_.Admin
{
    public partial class mange_report : System.Web.UI.Page
    {

        string cs = Global.CS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["userId"] != null && Session["username"] != null && Session["position"].ToString() == "Admin")
                {
                    pnlSelection.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Main/index.aspx");
                }

            }
        }

        protected void btnSubmitSelection_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string selection = rblSelection.Text;


                if(selection == "Summary")
                {
                    pnlSelection.Visible = false;
                    pnlSummary.Visible = true;
                }else if(selection == "Detail")
                {
                    pnlSelection.Visible = false;
                    pnlDetail.Visible = true;
                }


            }

        }

        protected void cvStart_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(cldstart.SelectedDate == null || cldstart.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvEnd_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (cldEnd.SelectedDate == null || cldEnd.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        protected void cvDate_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (cldDate.SelectedDate == null || cldDate.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        protected void btnCalender_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string dateS = cldstart.SelectedDate.ToString();



                string dateE = cldEnd.SelectedDate.ToString();


                var sql1 = "SELECT COUNT(postID) FROM Post WHERE date BETWEEN '@SDate' AND '@EDATE'";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con);

                cmd1.Parameters.AddWithValue("@SDate", dateS);
                cmd1.Parameters.AddWithValue("@EDATE", dateE);

                con.Open();
             int   countP = (int)cmd1.ExecuteScalar();
                con.Close();

                Response.Write(countP);


            }
        }
    }
}