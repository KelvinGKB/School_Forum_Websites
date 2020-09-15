<%@ Page Title="" Language="C#" MasterPageFile="~/Main/ForumWS.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Assignment_Web_Application_.Main.ForgetPassword" %>
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
  width: 62%;
  padding: 0 50px;
  margin-top: 6px;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: auto;
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
                document.getElementById("<%=btnSend.ClientID%>").setAttribute('disabled', true);
                document.getElementById("<%=btnSend.ClientID%>").value = 'Wait 30 sec';
            }, 0);

            setTimeout(function () {
                document.getElementById("<%=btnSend.ClientID%>").value = 'Send the Code Again';
                document.getElementById("<%=btnSend.ClientID%>").removeAttribute('disabled');
            }, 30000);
        }
    </script>

    <div class="container col-sm-12" style="margin-top:30px;margin-left:40px;background-color:#f8f8f8;border:solid #C0C0C0">
        <div class="row">
            <asp:Panel ID="pnlRemember" runat="server">
            <h2 style="text-align:center">What You remember ? </h2>
            <div class="col">
                <br />
                <asp:Panel ID="pnlOption" runat="server">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblRemember" ErrorMessage="Please Select One" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RadioButtonList ID="rblRemember" runat="server" RepeatLayout="Flow">
                        <asp:ListItem Value="u">Username</asp:ListItem>
                        <asp:ListItem Value="e">Email</asp:ListItem>
                        <asp:ListItem Value="ue">Username and Email</asp:ListItem>
                    </asp:RadioButtonList>
                    <br /><br />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                </asp:Panel>
                <asp:Panel ID="pnlUsername" runat="server" Visible="False">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsername1" ErrorMessage="[Username] cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="cvUsername" runat="server" ControlToValidate="txtUsername1" ErrorMessage="Cannot find the [Username]" Display="Dynamic" ForeColor="Red" OnServerValidate="cvUsername_ServerValidate"></asp:CustomValidator>
                    <asp:TextBox ID="txtUsername1" runat="server" style="margin: 5px 0;" placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnUsername" runat="server" Text="Submit" OnClick="btnUsername_Click" />
                    <br />
                    <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" CausesValidation="False" />
                </asp:Panel>
                <asp:Panel ID="pnlEmail" runat="server" Visible="False">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail1" ErrorMessage="[Email] cannot be empty" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="cvEmail" runat="server" ControlToValidate="txtEmail1" ErrorMessage="Cannot find the [Email]" Display="Dynamic" ForeColor="Red" OnServerValidate="cvEmail_ServerValidate"></asp:CustomValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail1" Display="Dynamic" ErrorMessage="Invalid [Email] format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail1" runat="server" style="margin: 5px 0;" placeholder="Email"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnEmail" runat="server" Text="Submit" OnClick="btnEmail_Click" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btnback_Click" CausesValidation="False" />
                </asp:Panel>
                <asp:Panel ID="pnlUserEmail" runat="server" Visible="False">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUsername2" ErrorMessage="[Username] cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="cvBoth" runat="server" ControlToValidate="txtUsername2" Display="Dynamic" ErrorMessage="Cannot find the [username] and [Email]" ForeColor="Red" OnServerValidate="cvBoth_ServerValidate"></asp:CustomValidator>
                    <asp:TextBox ID="txtUsername2" runat="server" style="margin: 5px 0;" placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail2" ErrorMessage="[Email] cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail2" Display="Dynamic" ErrorMessage="Invalid [Email] format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtEmail2" runat="server" style="margin: 5px 0;" placeholder="Email"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnUserEmail" runat="server" Text="Submit" OnClick="btnUserEmail_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Back" OnClick="btnback_Click" CausesValidation="False" />
                </asp:Panel>
            </div>
                </asp:Panel>
            <asp:Panel ID="pnlWho" runat="server" Visible="false">
            <div class="col">
                <h2 style="text-align:center">Who are you ? </h2>
                <div style="align-self:center">
                <asp:GridView ID="gvWho" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="493px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Username" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="gender" HeaderText="Gender" />
                        <asp:HyperLinkField DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="ForgetPassword.aspx?Id={0}" Text="This is Me" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                    </div>
                <br />
                <asp:Button ID="Button3" runat="server" Text="Back" OnClick="btnback_Click" CausesValidation="False" />
            </div>
                </asp:Panel>
            <asp:Panel ID="pnlEmailVerification" runat="server" Visible="false">
             <div class="col">
                <h2 style="text-align:center">Email Verification</h2>
                <div style="align-self:center">
                    <table>
                    <tr><td>Email :</td><td><h4><asp:Literal ID="litEmail" runat="server"></asp:Literal></h4></td></tr>
                    </table>
                    <br />
                    <asp:CustomValidator ID="cvVerification" runat="server" ControlToValidate="txtCode" ErrorMessage="[Code] Invalid" ForeColor="Red" OnServerValidate="cvVerification_ServerValidate"></asp:CustomValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCode" Display="Dynamic" ErrorMessage="[Code] Cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtCode" runat="server" style="margin: 5px 0;" placeholder="Email Verification Code"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSend" runat="server" Text="Send" CausesValidation="False" OnClick="btnSend_Click" />
                    <br />
                    <asp:Button ID="btnSubmitCode" runat="server" Text="Submit" OnClick="btnSubmitCode_Click" />
                    </div>
                 
                 </div>
                </asp:Panel>
            <asp:Panel ID="pnlPassword" runat="server" Visible="false">
                <div class="col">
                <h2 style="text-align:center">Set a New Password</h2>
                <div style="align-self:center">
                     <br />
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="[Confirm Password] is not match" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                     <br />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNewPass" Display="Dynamic" ErrorMessage="At least 8 characters, and to be a mix of letters and numbers" ForeColor="Red" ValidationExpression="(?=.{8,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+"></asp:RegularExpressionValidator>
                     <br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNewPass" ErrorMessage="[New Password] cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:TextBox ID="txtNewPass" runat="server" style="margin: 5px 0;" placeholder="New Password [Minimum length = 8] && [Must Mix of number and letter]" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="[Confirm Password] cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:TextBox ID="txtConfirmPass" runat="server" style="margin: 5px 0;" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                     <asp:Button ID="btnPassword" runat="server" Text="Submit" OnClick="btnPassword_Click" />
                    </div>
                    </div>
            </asp:Panel>
            </div>
        </div>
    
</asp:Content>
