<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Forum.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Assignment_Web_Application_.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   



           <div class="col-md-12 gedf-main">
             

               <!-- Modal -->
<div class="modal fade" id="login" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
  aria-hidden="true">
  <div class="modal-dialog" role="document">
    <!--Content-->
    <div class="modal-content form-elegant">
      <!--Header-->
      <div class="modal-header text-center">
        <h3 class="modal-title w-100 dark-grey-text font-weight-bold my-3" id="myModalLabel"><strong>Sign In</strong></h3>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <!--Body-->
      <div class="modal-body mx-4">
        <!--Body-->
        <div class="md-form mb-5">
            <table style="margin-left:30px">
                <asp:CustomValidator ID="cvNotMatched" runat="server" ErrorMessage="[Username] or [Password] not matched" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
           <tr><td><h4>Username:</h4></td><td><asp:TextBox ID="txtUser"  class="form-control" style="width:350px" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[Username] cannot be empty" ControlToValidate="txtUser" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
           <tr><td><h4>Password:</h4></td><td><asp:TextBox ID="txtPassword" class="form-control" style="width:350px"  runat="server" TextMode="Password"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[Password] cannot be empty" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td></tr>

           
            
           </table>
        </div>

        <div>
          <p style="text-align:right"><a href="ForgetPassword.aspx" class="btn">Forgot Password?</a></p>
        </div>

        <div class="text-center mb-3">
            <asp:Button ID="btnLogin" class="btn btn-info" style="width:500px;font-size:20px;" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        <h3 style="text-align:center;margin-top:20px"> or Sign in with:</h3>

        <div class="row my-3 d-flex justify-content-center">
          <div class="col" >
        <a class="btn btn-block btn-social btn-facebook" runat="server" onserverclick="btnFacebookLogin_Click" CausesValidation="false" style="width:500px;margin-left:50px;font-size:20px;padding-top:5px">
         <span class="fa fa-facebook"></span> Sign in with Facebook </a>
        
      </div>
        </div>
      </div>
      <!--Footer-->
      <div class="modal-footer mx-5 pt-3 mb-1">
        <p class="font-small grey-text d-flex justify-content-end">Not a member? <a href="Register.aspx" class="blue-text ml-1">
            Sign Up</a></p>
      </div>
    </div>
    <!--/.Content-->
  </div>
</div>
<!-- Modal -->
               
                   
                            <asp:Literal ID="litPost" runat="server"></asp:Literal>
                     
             

              


         </div>

</asp:Content>


