<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="edit_member.aspx.cs" Inherits="Assignment_Web_Application_.Admin.edit_member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
    <h1 align="center">Edit Member</h1>
    <br />
    <br />
    <table class="table table-striped table-bordered" style="width:100%;">

    <tr><td>User ID</td><td><asp:Label ID="lblID" runat="server" Text="lblID"></asp:Label></td></tr>
     <tr><td>Name</td><td><asp:Label ID="lblName" runat="server" Text="lblName"></asp:Label></td></tr>
         <tr><td>Username</td><td><asp:Label ID="lblUsername" runat="server" Text="lbUsername"></asp:Label></td></tr>
     <tr><td>Gender</td><td><asp:Label ID="lblGender" runat="server" Text="lblGender"></asp:Label></td></tr>
        
     <tr><td>Position</td><td><asp:DropDownList ID="ddlPosition" class="btn btn-default dropdown-toggle" runat="server">
        <asp:ListItem>---Select One---</asp:ListItem>
        <asp:ListItem Value="Admin">Admin</asp:ListItem>
        <asp:ListItem Value="Member">Member</asp:ListItem>
        </asp:DropDownList></td></tr>

         <tr><td>Recaptcha</td><td><asp:DropDownList ID="ddlRecaptcha" class="btn btn-default dropdown-toggle" runat="server" DataSourceID="LinqDataSource1" DataTextField="recaptcha" DataValueField="recaptcha">

        </asp:DropDownList>
             <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Assignment_Web_Application_.ForumDBDataContext" EntityTypeName="" GroupBy="recaptcha" Select="new (key as recaptcha, it as UserProfiles)" TableName="UserProfiles">
             </asp:LinqDataSource>
             </td></tr>
    




    </table>
    <br />
    <br />
    <div style="margin-left:40px;display:inline-block">
    <button type='button' style="width:450px;height:50px;display:inline-block" class="btn btn-success navbar-btn btn-block" data-toggle='modal' data-target='#myModal'>Update</button>
    <asp:Button ID="btnReturn"  style="width:450px;height:50px;margin-left:50px;display:inline-block"  class="btn btn-Danger" runat="server" Text="Cancel" OnClick="btnReturn_Click"/>
    </div>



    <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Are you sure want to Update?</h4>
      </div>
      <div class="modal-body">
        <p>Once Confirmed, Post will be Updated Permanently.</p>
      </div>
      <div class="modal-footer">
         <asp:Button ID='btnUpdate' style="width:80px;display:inline-block" class="btn btn-success navbar-btn btn-block" runat='server' Text='Confirm' OnClick="btnUpdate_Click"  />
        <button type="button" style="display:inline-block" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>


</asp:Content>
