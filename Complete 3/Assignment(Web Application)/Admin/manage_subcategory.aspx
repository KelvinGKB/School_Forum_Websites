﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="manage_subcategory.aspx.cs" Inherits="Assignment_Web_Application_.Admin.subcategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Sub-Category</h1>
    <br />

    <button type="button"  style="width:150px;float:right" class="btn btn-success navbar-btn btn-block"  data-toggle='modal' data-target='#myModal'>Create Subcategory</button>
    <br />
    <br />
     <div style="margin-top:40px;margin-left:30px">
    <table id="subcategory" class="table table-striped table-bordered" style="width:100%;">
         <script>
        $(document).ready(function () {
$('#subcategory').DataTable();
$('.dataTables_length').addClass('bs-select');
});
    </script>
        <thead>
            <tr>
                <th>SubCategory ID</th>
                <th>Title</th>
                 <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="litSubCategory" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
            <tr>
               <th>SubCategory ID</th>
                <th>Title</th>
                <th>Action</th>
            </tr>
        </tfoot>

        </table>
        </div>

     <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Create SubCategory</h4>
      </div>
      <div class="modal-body">

       <table>
      <td><span class="input-group-text"><h4>Title: </h4></span></td>
    
   <td><asp:TextBox ID="txtSubCategory"  style="display:inline-block" runat="server" class="form-control" placeholder="Category Title"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtSubCategory" ErrorMessage="* Please Enter The Title" ForeColor="Red"></asp:RequiredFieldValidator>
 <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtSubCategory" Display="Dynamic" ErrorMessage="* SubCategory Already Exists" OnServerValidate="CustomValidator1_ServerValidate1" ForeColor="Red"></asp:CustomValidator>     
   </td>
 </table>
          <br />
      <div class="modal-footer">
       <asp:Button ID='btnCreate' style="width:80px;display:inline-block" class="btn btn-success navbar-btn btn-block" runat='server' Text='Create' OnClick="btnCreate_Click"  />
        <button type="button" style="display:inline-block" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
</div>
     
</asp:Content>