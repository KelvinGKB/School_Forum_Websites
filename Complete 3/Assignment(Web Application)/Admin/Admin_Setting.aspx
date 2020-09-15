<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Setting.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Admin_Setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            width: 650px;
        }
        .auto-style2 {
            width: 764px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Profile Setting</h1>
    <div style="margin-top:40px;margin-left:40px;border:solid #C0C0C0;background-color:#f8f8f8;">
    <table style="margin-left:50px;margin-right:50px;margin-top:30px">
        <tr>
            <td class="auto-style1">
                <h3>Name:<h3>
            </td>
            <td class="auto-style2">
              <h3> <asp:TextBox ID="txtName" runat="server" Height="47px" Width="284px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Must Have a Name !" Display="Dynamic" ControlToValidate="txtName" ForeColor="Red" ></asp:RequiredFieldValidator></td></h3> 
              
        </tr>

        <tr><td><h3>Username:</h3></td><td><h3>@<asp:Literal ID="litUsername" runat="server"></asp:Literal></h3></td></tr>
        <tr>
            <td class="auto-style1">
                <h3>Description:</h3>

            </td>
            <td class="auto-style2">
              <h3>  <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="148px" Width="756px"></asp:TextBox></h3> 
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                <h3>Gender:</h3>

            </td>
            <td class="auto-style2">
              <h3>  <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" Width="224px">
                  <asp:ListItem>Male</asp:ListItem>
                  <asp:ListItem>Female</asp:ListItem>
                  </asp:RadioButtonList>  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Must Choose a Gender" Display="Dynamic" ControlToValidate="rblGender" ForeColor="Red" ></asp:RequiredFieldValidator></h3> </td>
           
        </tr>

        <tr>
            <td class="auto-style1">
                <h3>Profile Picture
                    :</h3>

            </td>
            <td class="auto-style2">
              <h3><asp:HyperLink ID="editPic" runat="server" NavigateUrl="~/Admin/Admin_changePic.aspx"><span class="glyphicon glyphicon-picture"></span> Change Profile Picture</asp:HyperLink></h3></td>
        </tr>

         <tr runat="server" id="trPassword">
            <td class="auto-style1">
                <h3>Password:</h3>

            </td>
            <td class="auto-style2">
              <h3>  <asp:HyperLink ID="editPass" runat="server" NavigateUrl="~/Admin/Admin_EditPass.aspx"><span class="glyphicon glyphicon-lock"></span> Change Pasword</asp:HyperLink> </h3></td>
        </tr>

        <tr>
            <td class="auto-style1">
                <h3>Privacy Setting:</h3>

            </td>
            <td class="auto-style2">
                <h3>
                    <asp:DropDownList ID="ddlPrivacy" runat="server">
                        <asp:ListItem Value="pb">Public</asp:ListItem>
                        <asp:ListItem Value="pv">Private</asp:ListItem>
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Must Select Your Privacy Setting !" Display="Dynamic" ControlToValidate="ddlPrivacy" ForeColor="Red"></asp:RequiredFieldValidator></h3>
            </td>
        </tr>

    </table>
        <br />
        <br />
    <asp:Button ID="btnUpdate" class="btn btn-success navbar-btn btn-block" style="margin-left:100px;margin-bottom:30px" runat="server" Text="Update" Width="800px" OnClick="btnUpdate_Click" />
        </div>
</asp:Content>
