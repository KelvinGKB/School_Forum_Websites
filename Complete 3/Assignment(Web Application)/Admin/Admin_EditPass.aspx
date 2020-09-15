<%@ Page Title="" Language="C#"  MasterPageFile="~/Admin/Admin.Master"  AutoEventWireup="true" CodeBehind="Admin_EditPass.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Admin_EditPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 810px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Change Password</h1>
    <div style="margin-top:40px;margin-left:40px;border:solid #C0C0C0;background-color:#f8f8f8;">
    <table style="margin-left:50px;margin-right:50px;margin-top:30px" class="auto-style1">
        <tr>
           <td> <h3>Existing Password : </h3></td>
                 <td> <h3><asp:TextBox ID="txtEpass" runat="server" TextMode="Password"></asp:TextBox></h3></td>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Your Password Not Matched" ForeColor="#FF0066" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEpass" Display="Dynamic" ErrorMessage="Please Enter Your Password" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </h3>
        </tr>
        <tr>
            <td><h3>New Password :</h3></td>
                <td> <h3> <asp:TextBox ID="txtNpass" runat="server" TextMode="Password"></asp:TextBox></h3></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNpass" Display="Dynamic" ErrorMessage="Please Enter Your Password" ForeColor="#FF0066"></asp:RequiredFieldValidator>
            </h3>
        </tr>
        <tr>
            <td>
                <h3>
                Confirm Password :</h3></h3></td>
                <td> <h3><asp:TextBox ID="txtCpass" runat="server" TextMode="Password"></asp:TextBox></h3></td>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtCpass" Display="Dynamic" ErrorMessage="Invalid Password" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCpass" Display="Dynamic" ErrorMessage="Please Enter Your Password" ForeColor="#FF0066"></asp:RequiredFieldValidator>
           
        </tr>

    </table>

<br />
        <br />
    <div style="margin-left:100px;margin-bottom:30px">
    <h4><asp:Button ID="btnChange" style="display:inline-block" class="btn btn-success navbar-btn btn-block" runat="server" Text="Change" OnClick="btnChange_Click" Width="500
        px" /><asp:Button ID="btnCancel"   style="display:inline-block;margin-left:50px" class="btn btn-default navbar-btn btn-block" runat="server" Text="Cancel" CausesValidation="False"  Width="500
        px" OnClick="btnCancel_Click" /></h4>
       </div>

        </div>

</asp:Content>
