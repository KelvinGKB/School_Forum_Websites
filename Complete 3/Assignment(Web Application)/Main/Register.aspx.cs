using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Assignment_Web_Application_.Main
{
    public partial class Register : System.Web.UI.Page
    {
        ForumDBDataContext db = new ForumDBDataContext();



        protected void Page_Load(object sender, EventArgs e)
        {



            if (Page.IsPostBack)
            {
                txtPassword.Attributes.Add("value", txtPassword.Text);
                txtConPassword.Attributes.Add("value", txtConPassword.Text);
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Random r = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    code += Convert.ToString(r.Next(0, 9));
                }

                HttpCookie coo = new HttpCookie("code");
                coo.Value = code;
                coo.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(coo);





                string email = txtEmail.Text;
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("schoolforumAssignment@gmail.com");
                mail.Subject = "Registration Code";

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
        }



        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = args.Value;
            HttpCookie coo = Request.Cookies["code"];
            if (coo == null || code != coo.Value)
            {
                args.IsValid = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HttpCookie coo = new HttpCookie("code");
                coo.Expires = DateTime.Now.AddYears(-100);
                Response.Cookies.Add(coo);

                Random r = new Random();
                bool repeat = true;
                string userId;
                do
                {
                    userId = "U";

                    for (int i = 0; i < 9; i++)
                    {
                        userId += Convert.ToString(r.Next(0, 9));
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


                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;
                string name = txtName.Text;
                string position = "Member";
                string recaptcha = "None";
                string image = "~/Uploads/default_Pic.png";

                UserProfile u = new UserProfile
                {
                    UserID = userId,
                    username = username,
                    password = Security.Encrypt(username, password),
                    email = email,
                    name = name,
                    position = position,
                    recaptcha = recaptcha,
                    image = image
                };
                db.UserProfiles.InsertOnSubmit(u);
                db.SubmitChanges();

                Response.Redirect("login.aspx");

            }
        }
    }
}