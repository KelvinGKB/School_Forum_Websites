<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin-profile.aspx.cs" Inherits="Assignment_Web_Application_.Admin.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
                <div class="panel" style="margin-top:40px;margin-left:40px;border:solid #C0C0C0;background-color:#f8f8f8;">
                    <img class="pic img-circle" style="text-align:left;display:inline-block;position:relative;top:-15px;margin-left:10px" src="https://picsum.photos/120/120" alt="...">
                    <div class="name" style="display:inline-block;margin-left:10px">
                        <h2>@Kengboon09</h2>
                        <h3>Goh Keng Boon</h3>

                    </div>

                </div>


    <ul class="nav nav-tabs" style="margin-left:40px;" id="myTab">
         <li class="active"><a href="#info" data-toggle="tab"><span class="glyphicon glyphicon-user"></span> Info</a></li>
        <li><a href="#post" data-toggle="tab"><span class="glyphicon glyphicon-list-alt"></span> Post</a></li>
         <li><a href="#bookmark" data-toggle="tab"><span class="glyphicon glyphicon-flag"></span> Bookmark</a></li>
      <li ><a href="#inbox" data-toggle="tab"><span class="glyphicon glyphicon-inbox"></span> Inbox</a></li>
      <li><a href="#sent" data-toggle="tab"><span class="glyphicon glyphicon-share-alt"></span> Sent</a></li>
      
    </ul>
    



    <div class="tab-content" style="margin-left:40px;">

        <div class="tab-pane active" id="info">
       <div class="media">
                  <a class="pull-left" href="#">
                    <img class="media-object img-thumbnail" width="100" src="https://picsum.photos/50/50" alt="...">
                  </a>
                  <div class="media-body">
                    <h4 class="media-heading">Animation Workshop</h4>
                    2Days animation workshop to be conducted
                  </div>
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
       
          <div  style="border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                    
                     <div  style="border-radius:5px; background-color:#f8f8f8;">
                    
                   
                       <div style="text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;">
                        

                             
                                <div style="display:inline-block;position:relative;top:-15px">
                                    <img width="50" style="border-radius:50%" src="https://picsum.photos/50/50" alt="">
                                </div>
                         
                                <div class="ml-2"  style="display:inline-block;">
                                    <div class="h5 m-0">
                                        <a href="#">@Kengboon09</a>
                                    </div>
                                    <div class="h7 text-muted">Goh Keng Boon</div>
                                </div>
                            
                            
                                <a href="#" class="btn" style="float:right" data-toggle="modal" data-target="#delete-bookmark" ><span class="glyphicon glyphicon-remove-sign"></span></a>

                        <!-- Modal -->
                          <div id="delete-bookmark" class="modal fade" role="dialog">
                              <div class="modal-dialog">

                            <!-- Modal content-->
                              <div class="modal-content">
                               <div class="modal-header">
                                 <button type="button" class="close" data-dismiss="modal">&times;</button>
                                 <h4 class="modal-title">Comfirm delete the Post ?</h4>
                               </div>
      
                               <div class="modal-footer">
                                 <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                 <button type="button" class="btn btn-default" data-dismiss="modal">Delete</button>
                              </div>
                             </div>

                           </div>
                         </div>

                        <!-----modal--->
                                
                           </div>

                        
                    
                
                    <div  style="text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                      
                        

                        <a class="card-link btn" style="margin-left:-13px" href="User-Comment-Post.aspx">
                            <h5 class="card-title">What is The Next Assignment ?</h5>
                        </a>

                        <p class="card-text">
                            Anyone Know tomorrow what assignment will distribute by the Web Application Tutor ? 
                            They say the Assignment have to be passed up on Week 8
                        </p>

                        <div>
  
                           <div class="text-muted h7 mb-2" style="margin-bottom:5px;margin-right:10px;display:inline-block"><span class="glyphicon glyphicon-thumbs-up"></span> 100</div>
                            <div class="text-muted h7 mb-2" style="margin-bottom:5px;margin-right:10px;display:inline-block"><span class="glyphicon glyphicon-comment"></span> 20</div>
                            <div class="text-muted h7 mb-2" style="float:right;margin-bottom:5px;margin-right:10px;display:inline-block"> <i class="fa fa-clock-o"></i> 20:12pm 2 November 2019</div>
                        </div>


                        </div>
                    
                </div>
                <!-- Post /////-->
              </div>

     </div>


      
     <div class="tab-pane"  id="post">
       
          <div  style="border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                    
                   
                    
                
                    <div  style="text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                      
                        <a href="#" class="btn" style="float:right" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-remove-sign"></span></a>

                        <!-- Modal -->
                          <div id="delete" class="modal fade" role="dialog">
                              <div class="modal-dialog">

                            <!-- Modal content-->
                              <div class="modal-content">
                               <div class="modal-header">
                                 <button type="button" class="close" data-dismiss="modal">&times;</button>
                                 <h4 class="modal-title">Comfirm delete the Post ?</h4>
                               </div>
      
                               <div class="modal-footer">
                                 <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                 <button type="button" class="btn btn-default" data-dismiss="modal">Delete</button>
                              </div>
                             </div>

                           </div>
                         </div>

                        <!-----modal--->

                        <br />
                        <a class="card-link btn" style="margin-left:-13px" href="User-Comment-Post.aspx">
                            <h5 class="card-title">What is The Next Assignment ?</h5>
                        </a>

                        <p class="card-text">
                            Anyone Know tomorrow what assignment will distribute by the Web Application Tutor ? 
                            They say the Assignment have to be passed up on Week 8
                        </p>

                        <div>
  
                           <div class="text-muted h7 mb-2" style="margin-bottom:5px;margin-right:10px;display:inline-block"><span class="glyphicon glyphicon-thumbs-up"></span> 100</div>
                            <div class="text-muted h7 mb-2" style="margin-bottom:5px;margin-right:10px;display:inline-block"><span class="glyphicon glyphicon-comment"></span> 20</div>
                            <div class="text-muted h7 mb-2" style="float:right;margin-bottom:5px;margin-right:10px;display:inline-block"> <i class="fa fa-clock-o"></i> 20:12pm 2 November 2019</div>
                        </div>


                        </div>
                    
                </div>
                <!-- Post /////-->


     </div>

</asp:Content>
