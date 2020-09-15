<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="manage_member.aspx.cs" Inherits="Assignment_Web_Application_.Admin.manage_member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1 align="center">Manage Member</h1>
    <div style="margin-top:40px;margin-left:30px">
    <table id="member" class="table table-striped table-bordered" style="width:100%;">
         <script>
        $(document).ready(function () {
$('#member').DataTable();
$('.dataTables_length').addClass('bs-select');
});
    </script>
        <thead>
            <tr>
                <th>User ID</th>
                <th>Name</th>
                <th>User Name</th>
                <th>Gender</th>
                <th>Email</th>
                <th>Position</th>
                <th>Recaptcha</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="litMember" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
            <tr>
                <th>User ID</th>
                <th>Name</th>
                <th>User Name</th>
                <th>Gender</th>
                <th>Email</th>
                <th>Position</th>
                <th>Recaptcha</th>
                <th>Action</th>
            </tr>
        </tfoot>

        </table>
        </div>

</asp:Content>
