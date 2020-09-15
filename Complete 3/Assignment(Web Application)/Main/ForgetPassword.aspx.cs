using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


namespace Assignment_Web_Application_.Main
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["Id"] ?? "";
                string username = Request.QueryString["username"];
                string password = Request.QueryString["password"];

                if (id.Length > 10)
                {
                    Session["token"] = 1;
                    id = id.Substring(0, 10);
                }

                UserProfile u = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (u != null)
                {


                    pnlEmailVerification.Visible = true;
                    pnlRemember.Visible = false;
                    litEmail.Text = u.email;
                }
                else if (username != null && password != null)
                {

                    Session["token"] = 1;



                    var query = from s in db.UserProfiles
                                where s.username == username && s.password == password && s.socialId == null
                                select new
                                {

                                    s.username,
                                    s.name,
                                    email = s.email.Substring(0, 2) + "******" + s.email.Substring(s.email.IndexOf('@')),
                                    s.gender,
                                    s.UserID,
                                    s.image


                                };

                    gvWho.DataSource = query;
                    gvWho.DataBind();

                    pnlRemember.Visible = false;
                    pnlWho.Visible = true;
                }
                else
                {
                    Session.Clear();
                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlOption.Visible = false;
                string option = rblRemember.Text;

                if (option == "u")
                {
                    pnlUsername.Visible = true;

                }
                else if (option == "e")
                {
                    pnlEmail.Visible = true;

                }
                else if (option == "ue")
                {
                    pnlUserEmail.Visible = true;
                }
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }

        protected void btnUsername_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txtUsername1.Text;



                var query = from s in db.UserProfiles
                            where s.username == username && s.socialId == null
                            select new
                            {

                                s.username,
                                s.name,
                                email = s.email.Substring(0, 2) + "******" + s.email.Substring(s.email.IndexOf('@')),
                                s.gender,
                                s.UserID,
                                s.image


                            };

                gvWho.DataSource = query;
                gvWho.DataBind();


                pnlWho.Visible = true;
                pnlRemember.Visible = false;
            }


        }

        protected void cvUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = txtUsername1.Text;
            int count = (from s in db.UserProfiles
                         where s.username == username && s.socialId == null
                         select s).Count();

            if (count <= 0)
            {
                args.IsValid = false;
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = txtEmail1.Text;
            int count = (from s in db.UserProfiles
                         where s.email == email && s.socialId == null
                         select s).Count();

            if (count <= 0)
            {
                args.IsValid = false;
            }

        }

        protected void cvBoth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = txtEmail2.Text;
            string username = txtUsername2.Text;

            int count = (from s in db.UserProfiles
                         where s.email == email && s.username == username && s.socialId == null
                         select s).Count();

            if (count <= 0)
            {
                args.IsValid = false;
            }

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail1.Text;



                var query = from s in db.UserProfiles
                            where s.email == email && s.socialId == null
                            select new
                            {

                                s.username,
                                s.name,
                                s.email,
                                s.gender,
                                s.UserID,
                                s.image
                            };

                gvWho.DataSource = query;
                gvWho.DataBind();


                pnlWho.Visible = true;
                pnlRemember.Visible = false;
            }
        }

        protected void btnUserEmail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail2.Text;
                string username = txtUsername2.Text;


                var query = from s in db.UserProfiles
                            where s.email == email && s.username == username && s.socialId == null
                            select new
                            {

                                s.username,
                                s.name,
                                s.email,
                                s.gender,
                                s.UserID,
                                s.image


                            };

                gvWho.DataSource = query;
                gvWho.DataBind();


                pnlWho.Visible = true;
                pnlRemember.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            btnSend.Enabled = false;
            btnSend.Text = "Wait 30 sec";

            Random r = new Random();
            string code = "";
            for (int i = 0; i < 6; i++)
            {
                code += Convert.ToString(r.Next(0, 9));
            }

            HttpCookie coo = new HttpCookie("Vcode");
            coo.Value = code;
            coo.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Add(coo);





            string email = litEmail.Text;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("schoolforumAssignment@gmail.com");
            mail.Subject = "Email Verification Code";

            string body = "This is the code " + code;

            mail.Body = body;

            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("schoolforumAssignment@gmail.com", "#ABCabc123456#");

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(mail);

            ScriptManager.RegisterStartupScript(this, GetType(), "sendSubmit", "sendSubmit();", true);
        }

        protected void cvVerification_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = args.Value;
            HttpCookie coo = Request.Cookies["Vcode"];
            if (coo == null || code != coo.Value)
            {
                args.IsValid = false;
            }

        }

        protected void btnSubmitCode_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Session["token"] != null)
                {
                    string id = Request.QueryString["Id"];

                    if (id.Length > 10)
                    {
                        id = id.Substring(0, 10);
                    }

                    HttpCookie coo = new HttpCookie("id");
                    coo.Value = id;
                    coo.Expires = DateTime.Now.AddDays(14);
                    Response.Cookies.Add(coo);


                    UserProfile u = db.UserProfiles.SingleOrDefault(x => x.UserID == id);

                    if (u != null)
                    {
                        Session.Clear();
                        Session["name"] = u.name;
                        Session["userId"] = u.UserID;
                        Session["username"] = u.username;
                        if (u.position != "Admin")
                        {
                            Response.Redirect("~/User/Index_User.aspx");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }

                }
                else
                {
                    pnlPassword.Visible = true;
                    pnlEmailVerification.Visible = false;
                }
            }
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string password = txtNewPass.Text;
                string realPassword;

                string id = Request.QueryString["Id"];

                UserProfile u = db.UserProfiles.SingleOrDefault(x => x.UserID == id);
                if (u != null)
                {
                    string username = u.username;
                    realPassword = Security.Encrypt(username, password);
                    u.password = realPassword;

                    db.SubmitChanges();

                    Response.Redirect("login.aspx");

                }
                else
                {
                    Response.Redirect("ForgetPassword.aspx");
                }
            }
        }
    }
}