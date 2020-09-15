<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report_post.aspx.cs" Inherits="Assignment_Web_Application_.User.report_post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  
 
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">Report Post</h1><br />
            <asp:RadioButtonList ID="rblReport"  runat="server">
    <asp:ListItem Value="Spam Post"> This is a Spam Post</asp:ListItem>
    <asp:ListItem Value="Abusive or Harassing Post"> This is a Abusive or Harassing Post</asp:ListItem>
    <asp:ListItem Value="Pornographic Content"> Pornographic Content</asp:ListItem>
    <asp:ListItem> Violance Content</asp:ListItem>
    <asp:ListItem Value="infringes copyright"> It infringes my copyright</asp:ListItem>
               </asp:RadioButtonList>
            <br />

            <asp:Button ID="btnReport" class="btn btn-success navbar-btn btn-block" runat="server" Text="Report" OnClick="btnReport_Click" />
        </div>
    </form>
</body>
</html>
