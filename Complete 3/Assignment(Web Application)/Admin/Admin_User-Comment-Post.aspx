<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Main.Master" AutoEventWireup="true" CodeBehind="Admin_User-Comment-Post.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Admin_User_Comment_Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     

    
           <div class="col-md-12 gedf-main">
                <!--- \\\\\\\Post-->
                <!--- \\\\\\\Post-->
               
                 <asp:Literal ID="litPost" runat="server"></asp:Literal>
                <!-- Post /////-->



               
                <div  style="margin-top:50px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                    
                   
                       <div style="text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;">
                        

                             
                                <div style="display:inline-block;position:relative;top:-15px">
                                   <asp:Image ID="imgProfile" Height="50" width="50" style="border-radius:50%" runat="server" />
                                </div>
                         
                                <div class="ml-2"  style="display:inline-block;">
                                    <div class="h5 m-0">
                                        <a href="#">
                                            <asp:Literal ID="litUsername" runat="server"></asp:Literal></a>
                                    </div>
                                    <div class="h7 text-muted">
                                        <asp:Literal ID="litName" runat="server"></asp:Literal></div>
                                </div>
                            
                            
                           </div>

                    
                
                    <div  style="text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                        
                        <asp:TextBox ID="txtcomment" style="margin-top:10px;margin-bottom:10px;width:800px;height:100px"  runat="server" Placeholder="Comment here..." TextMode="MultiLine"></asp:TextBox>

                     


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcomment" Display="Dynamic" ErrorMessage="* Comment cannot be blank !" ForeColor="Red"></asp:RequiredFieldValidator>

                     


                        </div>
                    <div class="card-footer" style="text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;">
                     
                   
                        <asp:Linkbutton type="button" runat="server" class="btn btn-primary col-sm-5" style="text-align:center;float:right" ID="btnComment" OnClick="btnComment_Click" ><span class="glyphicon glyphicon-comment"></span> Comment</asp:Linkbutton>
                    
                        

                         
                    </div>
                </div>
                <!-- Post /////-->
               <h1>COMMENTS</h1>
               <!-- Comment //// -->
               <div style="margin-top: 40px; margin-left: 40px">
                    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
                    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
                    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap.min.js"></script>
                    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">

                   <table id="comment" class="table table-striped table-bordered" style="width: 100%;">
                       <script>
                           $(document).ready(function () {
                               $('#comment').DataTable();
                               $('.dataTables_length').addClass('bs-select');
                           });
                       </script>
                       <thead>
                           <tr>
                               <th>LATEST</th>

                           </tr>


                       </thead>
                       <tbody>
                           <asp:Literal ID="litComment" runat="server"></asp:Literal>
                       </tbody>
                       <tfoot>
                           <tr>
                               <th></th>

                           </tr>
                       </tfoot>

                   </table>

               </div>

               </div>


</asp:Content>
