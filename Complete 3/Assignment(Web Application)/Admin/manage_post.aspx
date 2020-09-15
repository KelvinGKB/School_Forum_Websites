<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="manage_post.aspx.cs" Inherits="Assignment_Web_Application_.Admin.manage_post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Manage Posts</h1>
    <div style="margin-top:40px;margin-left:30px">
         <table id="posts" class="table table-striped table-bordered" style="width:100%;">
         <script>
        $(document).ready(function () {
$('#posts').DataTable();
$('.dataTables_length').addClass('bs-select');
});
    </script>
        <thead>
            <tr>
                 <th>Post</th>
                 <th>Action</th>
            </tr>
          
           
        </thead>
        <tbody>
          <asp:Literal ID="litPosts" runat="server"></asp:Literal>
        </tbody>
        <tfoot>
           <tr>
                 <th>Post</th>
                 <th>Action</th>
            </tr>
        </tfoot>

        </table>
         
     </div>

  
   

</asp:Content>
