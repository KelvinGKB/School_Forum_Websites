﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete_post.aspx.cs" Inherits="Assignment_Web_Application_.User.delete_post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">Delete Post</h1>

            <br />
            <h3>Comfirm want to Delete this Post ?</h3>
            <br />
            <asp:Button ID="btnDelete" class="btn btn-success navbar-btn btn-block" runat="server" Text="Delete Post" OnClick="btnDelete_Click" />

        </div>
    </form>
</body>
</html>
