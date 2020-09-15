<%@ Page Title="" Language="C#" MasterPageFile="~/Main/ForumWS.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Assignment_Web_Application_.Main.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
body {
  font-family: Arial, Helvetica, sans-serif;
}

* {
  box-sizing: border-box;
}

/* style the container */
.container {
  position: relative;
  border-radius: 5px;
  background-color: #f8f8f8;
  padding: 20px 0 30px 0;
} 

/* style inputs and link buttons */
input,
.Sbtn {
  width: 100%;
  padding: 12px ;

  border: none;
  border-radius: 4px;
  opacity: 0.85;
  display: inline-block;
  font-size: 17px;
  line-height: 20px;
  text-decoration: none; /* remove underline from anchors */
}

input:hover,
.btn:hover {
  opacity: 1;
}

/* add appropriate colors to fb, twitter and google buttons */
.fb {
  background-color: #3B5998;
  color: white;
}

.twitter {
  background-color: #55ACEE;
  color: white;
}

.google {
  background-color: #dd4b39;
  color: white;
}

/* style the submit button */
input[type=submit] {
  background-image: linear-gradient(120deg, #a6c0fe 0%, #f68084 100%);
 /*  background-image: linear-gradient(-225deg, #5D9FFF 0%, #B8DCFF 48%, #6BBBFF 100%);*/
  color: black;
  cursor: pointer;
}

input[type=submit]:hover {
 background-image: linear-gradient(120deg, #a6c0fe 0%, #f68084 100%);
}

/* Two-column layout */
.col {
  float: left;
  width: 50%;
  margin: auto;
  padding: 0 50px;
  margin-top: 6px;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

/* vertical line */
.vl {
  position: absolute;
  left: 50%;
  transform: translate(-50%);
  border: 2px solid #ddd;
  height: 175px;
}

/* text inside the vertical line */
.vl-innertext {
  position: absolute;
  top: 50%;
  transform: translate(-50%, -50%);
  background-color: #f1f1f1;
  border: 1px solid #ccc;
  border-radius: 50%;
  padding: 8px 10px;
}

/* hide some text on medium and large screens */
.hide-md-lg {
  display: none;
}

/* bottom container */
.bottom-container {
  text-align: center;
background-image: linear-gradient(to right, #868f96 0%, #596164 100%);
  border-radius: 0px 0px 4px 4px;
}

/* Responsive layout - when the screen is less than 650px wide, make the two columns stack on top of each other instead of next to each other */
@media screen and (max-width: 650px) {
  .col {
    width: 100%;
    margin-top: 0;
  }
  /* hide the vertical line */
  .vl {
    display: none;
  }
  /* show the hidden text on small screens */
  .hide-md-lg {
    display: block;
    text-align: center;
  }
}
</style>

      <div class="container col-sm-6" style="margin-top:100px;margin-left:550px;background-color:#f8f8f8;border:solid #C0C0C0;">
  
    <div class="row">
      <h2 style="text-align:center">Sign In School Board With Facebook</h2>
      <div class="vl">
        <span class="vl-innertext">or</span>
      </div>

      <div class="col" style="margin-top:60px">
        <a class="btn btn-block btn-social btn-facebook" runat="server" onserverclick="Facebook_Login" CausesValidation="false">
    <span class="fa fa-facebook"></span> Sign in with Facebook
  </a>
        
      </div>

      <div class="col">
        <div class="hide-md-lg">
          <p>Or sign in manually:</p>
        </div>
          <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
          <asp:CustomValidator ID="cvNotMatched" runat="server" ErrorMessage="[Username] or [Password] not matched" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
          <asp:TextBox ID="txtUsername" runat="server" style="margin: 5px 0;" placeholder="Username"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[Username] cannot be empty" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:TextBox ID="txtPassword" runat="server" style="margin: 5px 0;" placeholder="Password" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[Password] cannot be empty" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:Button ID="btnLogin" runat="server" Text="Sign In" style="margin: 5px 0;" OnClick="btnLogin_Click" />
      <!-- <input type="text" name="username" placeholder="Username" style="margin: 5px 0;" required>
        <input type="password" name="password" placeholder="Password" style="margin: 5px 0;" required>
        <input type="submit" value="Sign In" style="margin: 5px 0;"> -->
              </asp:Panel>
      </div>
      
    </div>
</div>

<div class="bottom-container col-sm-6" style="margin-left:550px">
  <div class="row">
    <div class="col">
      <a href="Register.aspx" style="color:white" class="Sbtn" >Sign up</a>
    </div>
    <div class="col">
      <a href="ForgetPassword.aspx" style="color:white" class="Sbtn">Forgot password?</a>
    </div>
  </div>
</div>
    </asp:Content>
