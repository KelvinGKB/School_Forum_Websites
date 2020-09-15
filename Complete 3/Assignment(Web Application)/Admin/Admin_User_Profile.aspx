<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_User_Profile.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Admin_User_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- jQuery Modal -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />

    
                <div class="panel" style="margin-top:40px;margin-left:40px;border:solid #C0C0C0;background-color:#f8f8f8;">
                    <asp:Image ID="imgProfile"  class="pic img-circle" style="text-align:left;display:inline-block;position:relative;top:-15px;margin-left:10px;height:120px;width:120px" runat="server" />
                    
                    <div class="name" style="display:inline-block;margin-left:10px">
                        <h2> <asp:Literal ID="litUsername" runat="server"></asp:Literal> </h2>
                        <h3><asp:Literal ID="litName" runat="server"></asp:Literal></h3>

                    </div>

                </div>


    <ul class="nav nav-tabs" style="margin-left:40px;" id="myTab">
         <li class="active"><a href="#info" data-toggle="tab"><span class="glyphicon glyphicon-user"></span> Info</a></li>
        <li><a href="#post" data-toggle="tab"><span class="glyphicon glyphicon-list-alt"></span> Post</a></li>
         <li><a href="#bookmark" data-toggle="tab"><span class="glyphicon glyphicon-flag"></span> Bookmark</a></li>
   
      
    </ul>
    



    <div class="tab-content" style="margin-left:40px;">

        <div class="tab-pane active" id="info">
       <div class="media">
                  <table style="font-size:large">
                      <br />
                       <br />
                      <tr><td>Name</td><td>: <asp:Literal ID="litName2" runat="server"></asp:Literal></td></tr>
                      <tr><td>Gender</td><td>: <asp:Literal ID="litGender" runat="server"></asp:Literal></td></tr>
                      <tr><td>Desrciption:</td><td> <pre style="font-size:large"><asp:Literal ID="litDescription" runat="server"></asp:Literal></pre></td></tr>

                  </table>
            </div>
    </div>

      <div class="tab-pane " id="inbox">
        <a type="button" data-toggle="collapse" data-target="#a1">
            <div class="btn-toolbar well well-sm" role="toolbar"  style="margin:0px;">
              <div class="btn-group"><input type="checkbox"></div>
              <div class="btn-group col-md-3">Micheal09</div>
              <div class="btn-group col-md-8"><b>Have you done the Proposal ?</b> <div class="pull-right"><i class="glyphicon glyphicon-time"></i> 12:10 PM <button class="btn btn-primary btn-xs" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="fa fa-share-square-o"> Reply</i></button></div> </div>
            </div>
        </a>
        <div id="a1" class="collapse out well">Have you done the proposal of Web Application?</div>
        <br>
        <button class="btn btn-primary btn-xs"><i class="fa fa-check-square-o"></i> Delete Checked Item's</button>
      </div>

        
     
       

      <div class="tab-pane" id="sent">
            <a type="button" data-toggle="collapse" data-target="#s1">
            <div class="btn-toolbar well well-sm" role="toolbar"  style="margin:0px;">
              <div class="btn-group"><input type="checkbox"></div>
              <div class="btn-group col-md-3">Pikachu</div>
              <div class="btn-group col-md-8"><b>Tomorrow will you attend the OS class?</b> <div class="pull-right"><i class="glyphicon glyphicon-time"></i> 12:30 AM</div> </div>
            </div>
        </a>
        <div id="s1" class="collapse out well">Tomorrow will you attend the OS class?</div>
        <br>
        <button class="btn btn-primary btn-xs"><i class="fa fa-check-square-o"></i> Delete Checked Item's</button>
      </div>
      

       <div class="tab-pane"  id="bookmark">
       
           <div style="border: solid #C0C0C0; border-radius: 5px; background-color: #f8f8f8;">

               <asp:Literal ID="litBookmark" runat="server"></asp:Literal>
           </div>

     </div>


      
     <div class="tab-pane"  id="post">
       <div style="border: solid #C0C0C0; border-radius: 5px; background-color: #f8f8f8;">
          
            
           <asp:Literal ID="litUserpost" runat="server"></asp:Literal>
           </div>

     </div>
     
    

</asp:Content>

