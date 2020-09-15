<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="Add_Advertisment.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Add_Advertisment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1 align="center">Create New Advertisment</h1>


<table>
     <tr><td><h2>Advertisment Name:</h2></td><td><h2><asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Must Enter the Advertisment Name !" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></h2>
       </td></tr>
    <tr><td><h2>Advertisment Link:</h2></td><td><h2><asp:TextBox ID="txtLink" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Must Enter the Advertisment Link !" Display="Dynamic" ForeColor="Red" ControlToValidate="txtLink"></asp:RequiredFieldValidator></h2></td></tr>
     <tr><td><h2>Advertisment Image:</h2></td><td><h2><asp:FileUpload ID="imageAD" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Must Upload a Image !" ControlToValidate="imageAD" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Only JPG and PNG format is Available !" Display="Dynamic" ControlToValidate="imageAD" ForeColor="Red" ValidationExpression=".+\.(jpg|png)"></asp:RegularExpressionValidator></h2></td></tr>

</table>
    

    <br />
    <br />
    <div>
    <asp:Button ID="btnCreate" runat="server" style="display:inline-block" class="btn btn-success navbar-btn btn-block" Text="Create" Width="438px" OnClick="btnCreate_Click" /><asp:Button ID="BtnCancel"  style="display:inline-block;margin-left:50px"  class="btn btn-default navbar-btn btn-block" runat="server" Text="Cancel" Width="440px" OnClick="BtnCancel_Click" />
    </div>
</asp:Content>
