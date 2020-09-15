<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="manage_reported_post.aspx.cs" Inherits="Assignment_Web_Application_.Admin.manage_security" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- jQuery Modal -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />

    <h1 align="center">Manage Reported Posts</h1>

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
                <th>Report ID</th>
                <th>Reason</th>
               <th>Reported By</th>
                <th>Posted By</th>
                <th>Post ID</th>
                <th>Action</th>
                
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="litReported" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
            <tr>
                <th>Report ID</th>
                <th>Reason</th>
                <th>Reported By</th>
                <th>Posted By</th>
                <th>Post ID</th>
                <th>Action</th>
               
            </tr>
        </tfoot>

        </table>
        </div>

</asp:Content>
