<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_bookmark.aspx.cs" Inherits="Assignment_Web_Application_.User.add_bookmark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">Add Bookmark</h1>
            
            <br />
            <h3>Comfirm want to Add this Post to your bookmark?</h3>
            <br />
            
            <asp:Button ID="btnAdd" class="btn btn-success navbar-btn btn-block" runat="server" Text="Add Bookmark" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
