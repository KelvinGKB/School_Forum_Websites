<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="manage_advertisment.aspx.cs" Inherits="Assignment_Web_Application_.Admin.manage_advertisment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- jQuery Modal -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />

    <h1 align="center">Manage Advertisment</h1>

    <asp:LinkButton ID="btnCreate" runat="server" style="width:150px;float:right" class="btn btn-success navbar-btn btn-block" OnClick="btnCreate_Click">Create Advertisment</asp:LinkButton>
   
    <br />
      <div style="margin-top:40px;margin-left:30px">
    <table id="group" class="table table-striped table-bordered" style="width:100%;">
         <script>
        $(document).ready(function () {
$('#group').DataTable();
$('.dataTables_length').addClass('bs-select');
});
    </script>
        <thead>
            <tr>
                <th>Advertisment ID</th>
                <th>Name</th>
                 <th>Link</th>
                <th>Image</th>
                 <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="litAds" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
            <tr>
                <th>Advertisment ID</th>
                <th>Name</th>
                 <th>Link</th>
                <th>Image</th>
                 <th>Action</th>
            </tr>
        </tfoot>

        </table>
        </div>



</asp:Content>
