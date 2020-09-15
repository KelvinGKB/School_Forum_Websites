<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="delete_group.aspx.cs" Inherits="Assignment_Web_Application_.Admin.delete_group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1 align="center">Delete Group</h1>

    <table class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <th>Group ID</th>
            <th>Title</th>
        </thead>

        <tbody>
    <asp:Literal ID="litGroup" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
             <th>Group ID</th>
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
        <p>Once Confirmed, Group will be deleted Permanently.</p>
      </div>
      <div class="modal-footer">
        <asp:Button ID='btnDeleteGroup' style="width:80px;display:inline-block" class="btn btn-danger navbar-btn btn-block" runat='server' Text='Confirm' OnClick="btnDeleteGroup_Click"  />
        <button type="button" style="display:inline-block" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

</asp:Content>
