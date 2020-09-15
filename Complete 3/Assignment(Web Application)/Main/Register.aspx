<%@ Page Title="" Language="C#" MasterPageFile="~/Main/ForumWS.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Assignment_Web_Application_.Main.Register" %>
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
  ;
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

    <script type="text/javascript">
        function sendSubmit() {
            

            setTimeout(function () {
                document.getElementById("<%=btnEmail.ClientID%>").setAttribute('disabled', true);
                document.getElementById("<%=btnEmail.ClientID%>").value = 'Wait 30 sec';
            }, 0);

            setTimeout(function () {
                document.getElementById("<%=btnEmail.ClientID%>").value = 'Send the Code Again';
                document.getElementById("<%=btnEmail.ClientID%>").removeAttribute('disabled');
            }, 30000);
        }
    </script>
    
    <div class="container col-sm-12" style="margin-top:30px;margin-left:40px;background-color:#f8f8f8;border:solid #C0C0C0">
        <div class="row">
            <h2 style="text-align:center">Register School Board </h2>
            <div class="col">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[UserName] cannot be empty" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtUsername" runat="server" style="margin: 5px 0;" placeholder="Username"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[Password] cannot be empty" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="At least 8 characters, and to be a mix of letters and numbers" ForeColor="Red" ValidationExpression="(?=.{8,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPassword" runat="server" style="margin: 5px 0;" placeholder="Password [Minimum length = 8] && [Must Mix of number and letter]" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConPassword" ErrorMessage="[Confirm Password] cannot be empty" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConPassword" ErrorMessage="[Confirm Password] is not as same as [Password]" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                <asp:TextBox ID="txtConPassword" runat="server" style="margin: 5px 0;" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName" ErrorMessage="[Name] cannot be empty" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtName" runat="server" style="margin: 5px 0;" placeholder="Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="[Email] cannot be empty" ValidationGroup="email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="[Email] format incorrect" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="email" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtEmail" runat="server" style="margin: 5px 0;" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCode" ErrorMessage="[Code] cannot be empty" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="[Code] invalid" OnServerValidate="CustomValidator1_ServerValidate" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                <asp:TextBox ID="txtCode" runat="server" style="margin: 5px 0;" placeholder="Code"></asp:TextBox>
                <br />
                <asp:Button ID="btnEmail" runat="server" Text="Send Code" OnClick="btnEmail_Click" ValidationGroup="email" />
                <br />
                <br />
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
