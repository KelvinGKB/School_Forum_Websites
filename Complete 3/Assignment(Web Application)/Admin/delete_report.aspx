<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete_report.aspx.cs" Inherits="Assignment_Web_Application_.Admin.delete_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">Delete Report</h1>
            <br />
            <h3>Confirm want to delete the Report ? </h3>
            <br />
            <br />
            <asp:Button ID="btnDelete" class="btn btn-success navbar-btn btn-block" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
