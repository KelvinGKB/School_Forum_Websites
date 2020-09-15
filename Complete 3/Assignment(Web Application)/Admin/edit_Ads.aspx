<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="edit_Ads.aspx.cs" Inherits="Assignment_Web_Application_.Admin.edit_Ads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<h1 align="center">Update Advertisment</h1>


<table>
     <tr><td><h2>Advertisment Name:</h2></td><td><h2><asp:TextBox ID="txtName" runat="server"></asp:TextBox></h2>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Must Enter a Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
    <tr><td><h2>Advertisment Link:</h2></td><td><h2><asp:TextBox ID="txtLink" runat="server"></asp:TextBox></h2>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Must Have a Link for the ADS"  ControlToValidate="txtLink" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>

     <tr><td><h2>Advertisment Image:</h2></td><td><h2><asp:Image ID="imgAds" runat="server" /><asp:FileUpload ID="imageAD" runat="server" /></h2>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Only JPG OR PNG FORMAT ! " ControlToValidate="imageAD" Display="Dynamic" ForeColor="Red" ValidationExpression=".+\.(jpg|png)"></asp:RegularExpressionValidator> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Must Have a Image" ControlToValidate="imageAD" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>

</table>

    <br />
    <br />
    <div>
    <asp:Button ID="btnUpdate" runat="server" style="display:inline-block" class="btn btn-success navbar-btn btn-block" Text="Update" Width="438px" OnClick="btnUpdate_Click"  /><asp:Button ID="BtnCancel"  style="display:inline-block;margin-left:50px"  class="btn btn-default navbar-btn btn-block" runat="server" Text="Cancel" Width="440px" OnClick="BtnCancel_Click" />
    </div>

</asp:Content>
