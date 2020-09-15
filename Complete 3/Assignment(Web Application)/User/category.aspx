<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="Assignment_Web_Application_.User.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 172px
        }
        .auto-style2 {
            width: 304px
        }
        .auto-style3 {
            width: 122px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Category :  <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label></h1>

      <div class="col-md-12 gedf-main">

          <table style='margin-top:20px;margin-bottom:10px;margin-left:40px;'><tr><td class="auto-style1"><h3>Subcategory :  </h3></td>
        <td class="auto-style2"><h3><asp:DropDownList ID="ddlSubcategory" runat="server" DataSourceID="LinqDataSource1" DataTextField="title" DataValueField="subID"></asp:DropDownList>
        </h3></td><td class="auto-style3"><h3><asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" /></h3></td></tr>
    </table>
          <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Assignment_Web_Application_.ForumDBDataContext" EntityTypeName="" TableName="SubCategories" Where="catID == @catID">
            <WhereParameters>
                <asp:QueryStringParameter Name="catID" QueryStringField="cat" Type="String" />
            </WhereParameters>
            </asp:LinqDataSource>
        

               <!-- Modal -->
<div class="modal fade" id="login" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
  aria-hidden="true">
  <div class="modal-dialog" role="document">
    <!--Content-->
    <div class="modal-content form-elegant">
      <!--Header-->
      <div class="modal-header text-center">
        <h3 class="modal-title w-100 dark-grey-text font-weight-bold my-3" id="myModalLabel"><strong>Sign In</strong></h3>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <!--Body-->
      <div class="modal-body mx-4">
        <!--Body-->
        <div class="md-form mb-5">
            <table style="margin-left:30px">
           <tr><td><h4>Username/Email:</h4></td><td><asp:TextBox ID="txtUser"  class="form-control" style="width:350px" runat="server"></asp:TextBox></td></tr>
           <tr><td><h4>Password:</h4></td><td><asp:TextBox ID="txtPassword" class="form-control" style="width:350px"  runat="server"></asp:TextBox></td></tr>

           
            
           </table>
        </div>

        <div>
          <p style="text-align:right"><a href="#" class="btn">Forgot Password?</a></p>
        </div>

        <div class="text-center mb-3">
            <asp:Button ID="btnLogin" class="btn btn-info" style="width:500px;font-size:20px;" runat="server" Text="Login" />
        </div>
        <h3 style="text-align:center;margin-top:20px"> or Sign in with:</h3>

        <div class="row my-3 d-flex justify-content-center">
          <div class="col" >
        <a class="btn btn-block btn-social btn-facebook" style="width:500px;margin-left:50px;font-size:20px;padding-top:5px">
         <span class="fa fa-facebook"></span> Sign in with Facebook </a>
        
      </div>
        </div>
      </div>
      <!--Footer-->
      <div class="modal-footer mx-5 pt-3 mb-1">
        <p class="font-small grey-text d-flex justify-content-end">Not a member? <a href="#" class="blue-text ml-1">
            Sign Up</a></p>
      </div>
    </div>
    <!--/.Content-->
  </div>
</div>
<!-- Modal -->
         

          <div id="report" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Report Post</h4>
      </div>
      <div class="modal-body">
<asp:RadioButtonList ID="rblReport"  runat="server">
    <asp:ListItem Value="Spam Post">This is a Spam Post</asp:ListItem>
    <asp:ListItem Value="Abusive or Harassing Post">This is a Abusive or Harassing Post</asp:ListItem>
    <asp:ListItem Value="Pornographic Content">Pornographic Content</asp:ListItem>
    <asp:ListItem>Violance Content</asp:ListItem>
    <asp:ListItem Value="infringes copyright">It infringes my copyright</asp:ListItem>
               </asp:RadioButtonList>
          
          <br />
      <div class="modal-footer">
        <asp:Button ID='btnReport' style="width:80px;display:inline-block" class="btn btn-success navbar-btn btn-block" runat='server' Text='Report' OnClick="btnReport_Click"  />
        <button type="button" style="display:inline-block" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
</div>

          <asp:Literal ID="litPost" runat="server"></asp:Literal>

    
           
         
          

         </div>




</asp:Content>
