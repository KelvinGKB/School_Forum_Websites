<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Main.Master" AutoEventWireup="true" CodeBehind="Admin_NewPost_Recaptcha.aspx.cs" Inherits="Assignment_Web_Application_.Admin.Admin_NewPost_Recaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     <script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>

    <div  style="margin-top:50px;margin-bottom:30px;margin-left:40px;border:solid #C0C0C0 ;border-radius:5px; background-color:#f8f8f8;">
                    
                   
        <div style="text-align: left; padding-left: 20px; border-bottom: solid #C0C0C0;">



            <div style="display: inline-block; position: relative; top: -15px">
                  <asp:Image ID="imgProfile" Height="50"  width="50" style="border-radius:50%" runat="server" />
            </div>

            <div class="ml-2" style="display: inline-block;">
                <div class="h5 m-0">
                    <a href="#">
                        <asp:Literal ID="litUsername" runat="server"></asp:Literal></a>
                </div>
                <div class="h7 text-muted">
                    <asp:Literal ID="litName" runat="server"></asp:Literal></div>
            </div>


        </div>

                    
                
                    <div  style="text-align:left;padding-left:20px;padding-right:20px;background-color:white;border-bottom:solid #C0C0C0 ">
                        
                        <asp:TextBox ID="txtTitle" style="margin-top:10px;margin-bottom:10px;width:100%;height:30px;border-radius:3px"  runat="server" placeholder="Title..." ></asp:TextBox>
                        
                        <div style="display:inline-block">

                        <asp:DropDownList ID="ddlCategory" style="width:400px;margin-right:100px;margin-left:50px;height:30px;display:inline-block" runat="server" DataSourceID="dsCategory" DataTextField="title" DataValueField="catID" AutoPostBack="True">
                            <asp:ListItem Value="0">Category</asp:ListItem>
                           
                        </asp:DropDownList>
                            <asp:LinqDataSource ID="dsCategory" runat="server" ContextTypeName="Assignment_Web_Application_.ForumDBDataContext" EntityTypeName="" TableName="Categories"></asp:LinqDataSource>
                        <asp:DropDownList ID="ddlSubCategory" style="width:400px;height:30px;text-align:center;display:inline-block" runat="server" DataSourceID="dsSubcategory" DataTextField="title" DataValueField="subID" >
                            <asp:ListItem Text="SubCategory" Value="0"></asp:ListItem>
                       
                        </asp:DropDownList>
                            <asp:LinqDataSource ID="dsSubCategory" runat="server" ContextTypeName="Assignment_Web_Application_.ForumDBDataContext" EntityTypeName="" TableName="SubCategories" Where="catID == @catID">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="ddlCategory" Name="catID" PropertyName="SelectedValue" Type="String" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                            </div>

                      


                        <asp:TextBox ID="txtcomment" style="margin-top:10px;margin-bottom:10px;width:100%;height:100px;border-radius:3px"  runat="server"  placeholder="Description..." TextMode="MultiLine"></asp:TextBox>


                        </div>
                    <div class="card-footer" style="text-align:left;background-color:#f8f8f8;padding-left:60px;padding-top:10px;padding-bottom:50px;padding-right:20px;">
                     
                        
                        <div>
                    <div id="dvCaptcha">
                          </div>
                        <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                         <asp:RequiredFieldValidator ID = "rfvCaptcha" ErrorMessage="Captcha validation is required." ControlToValidate="txtCaptcha" runat="server" ForeColor = "Red" Display = "Dynamic" />
                         <br />
                         <br />

                        <asp:LinkButton ID="btnPost" class="btn btn-primary col-sm-5" style="text-align:center;float:right"  runat="server" OnClick="btnPost_Click"  ><span class="glyphicon glyphicon-comment"></span> Post</asp:LinkButton>
                       </div>
                    
                        <script type="text/javascript">
                            var onloadCallback = function () {
                                grecaptcha.render('dvCaptcha', {
                                    'sitekey': '6LfuBsIUAAAAAJ8D1QnGRdkfyEitAISZuebBwdtT',
                                    'callback': function (response) {
                                        $.ajax({
                                            type: "POST",
                                            url: "Admin_NewPost_Recaptcha.aspx/VerifyCaptcha",
                                            data: "{response: '" + response + "'}",
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function (r) {
                                                var captchaResponse = jQuery.parseJSON(r.d);
                                                if (captchaResponse.success) {
                                                    $("[id*=txtCaptcha]").val(captchaResponse.success);
                                                    $("[id*=rfvCaptcha]").hide();
                                                } else {
                                                    $("[id*=txtCaptcha]").val("");
                                                    $("[id*=rfvCaptcha]").show();
                                                    var error = captchaResponse["error-codes"][0];
                                                    $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);
                                                }
                                            }
                                        });
                                    }
                                });
                            };
                        </script>
                        
                       
                         
                    </div>

         
                </div>




</asp:Content>
