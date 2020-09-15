<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="delete_subcategory.aspx.cs" Inherits="Assignment_Web_Application_.Admin.delete_subcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <h1 align="center">Delete Subcategory</h1>

    <br />
    <br />
    <table class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <th>SubCategory ID</th>
            <th>Title</th>
        </thead>

        <tbody>
       <td>
           <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label></td>
       <td>
           <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label></td>
        </tbody>
        <tfoot>
             <th>SubCategory ID</th>
            <th>Title</th>
        </tfoot>
    </table>

    <br />
    <br />
   <div style="margin-left:40px;display:inline-block">
    <button type='button' style="width:450px;height:50px;display:inline-block" class="btn btn-danger navbar-btn btn-block" data-toggle='modal' data-target='#myModal'>Delete</button>
    <asp:Button ID="btnReturn"  style="width:450px;height:50px;margin-left:50px;display:inline-block"  class="btn btn-Danger" runat="server" Text="Cancel" OnClick="btnReturn_Click"  />
    </div>


  <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Are you sure want to delete?</h4>
      </div>
      <div class="modal-body">
        <p>Once Confirmed, Subcategory will be deleted Permanently.</p>
      </div>
      <div class="modal-footer">
        <asp:Button ID='btnDeleteSubcategory' style="width:80px;display:inline-block" class="btn btn-danger navbar-btn btn-block" runat='server' Text='Confirm' OnClick="btnDeleteSubcategory_Click"   />
        <button type="button" style="display:inline-block" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

</asp:Content>
