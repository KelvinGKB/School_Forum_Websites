<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Forum.Master" AutoEventWireup="true" CodeBehind="Comment-Post.aspx.cs" Inherits="Assignment_Web_Application_.Main.Comment_Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


           <div class="col-md-12 gedf-main">
               

                <!--- \\\\\\\Post-->
               <asp:Literal ID="litPost" runat="server"></asp:Literal>
               <!--- \\\\\\\Post-->



               <!--- \\\\\\\Post-->

               
                <div  style="margin-top:40px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                       <div style='text-align:left; padding-left:20px;border-bottom:solid #C0C0C0;'>
                           <div style="display:inline-block;position:relative;top:-15px">
                                    <img width="50" style="border-radius:50%" src="https://picsum.photos/50/50" alt="">
                            </div>
                            <div class="ml-2"  style="display:inline-block;">
                                    <div class="h5 m-0">
                                        <a href="#">@Kengboon09</a>
                                    </div>
                                    <div class="h7 text-muted">Goh Keng Boon</div>
                                </div>
                            
                            
                                <div class="dropdown" style="display:inline-block;float:right">
                                    <button class="btn btn-link dropdown-toggle" type="button" id="gedf-drop1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fa fa-ellipsis-h"></i>
                                    </button>
                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="gedf-drop1">
                                        <div class="h6 dropdown-header">Option</div>
                                        <hr />
                                        <a class="dropdown-item btn" href="#"><span class="glyphicon glyphicon-flag"></span> Bookmark</a>
                                        <a class="dropdown-item btn" href="#"><span class="glyphicon glyphicon-remove"></span> Hide</a>
                                        <a class="dropdown-item btn" href="#"><span class="glyphicon glyphicon-bullhorn"></span> Report</a>
                                     </div>
                                    </div>
                                 </div>

                    <div  style="text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                        <a class="card-link btn" style="margin-left:-13px" href="#">
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
                        <div class="card-footer" style="text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;">
                        <button type="button" class="btn btn-primary col-sm-5" style="text-align:center;margin-right:100px"><span class="glyphicon glyphicon-thumbs-up"></span> Like</button>
                        <button type="button" class="btn btn-primary col-sm-5" style="text-align:center"><span class="glyphicon glyphicon-comment"></span> Comment</button>      
                    </div>
                </div>
                <!-- Post /////-->



               
                <div  style="margin-top:50px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                    
                   
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
                            
                            
                           </div>

                    
                
                    <div  style="text-align:left;padding-left:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                        
                        <asp:TextBox ID="txtcomment" style="margin-top:10px;margin-bottom:10px;width:800px;height:100px"  runat="server"  TextMode="MultiLine">Comment here....</asp:TextBox>

                     


                        </div>
                    <div class="card-footer" style="text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;">
                     
                   
                        <button type="button" class="btn btn-primary col-sm-5" style="text-align:center;float:right"><span class="glyphicon glyphicon-comment"></span> Comment</button>
                    
                        

                         
                    </div>
                </div>
                <!-- Post /////-->

               </div>

</asp:Content>
