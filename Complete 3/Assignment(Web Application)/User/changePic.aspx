<%@ Page Title="" Language="C#" MasterPageFile="~/User/User_Panel.Master" AutoEventWireup="true" CodeBehind="changePic.aspx.cs" Inherits="Assignment_Web_Application_.User.changePic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div align="center" style="margin-top:40px;margin-left:40px;border:solid #C0C0C0;background-color:#f8f8f8;">
        <h1 align="center">Upload Your Picture</h1>

        <h3>Previous Picture</h3>
        <br />
        <br />
        <asp:Image ID="prePhoto" Width="300px" Height="300px" runat="server" />

        <br />
        <br />

               
        <h2><asp:FileUpload ID="fileID" style="text-align:center" runat="server" /></h2>



        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileID" Display="Dynamic" ErrorMessage="Only Allow JPG/PNG File" ForeColor="Red" ValidationExpression=".+\.(jpg|png)"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fileID" Display="Dynamic" ErrorMessage="Cannot be Empty" ForeColor="Red"></asp:RequiredFieldValidator>

        <br />
        <br />
        <div align="center">
            <asp:Button ID="btnUpload" class="btn btn-success navbar-btn btn-block" style="display:inline-block" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="500px" />
            <asp:Button ID="btnCancel" class="btn btn-default navbar-btn btn-block" style="display:inline-block;margin-left:50px" runat="server" Text="Cancel" CausesValidation="False" Width="500px" OnClick="btnCancel_Click"  /></div>
    
    <br />
        <br />
    </div>
    




</asp:Content>
