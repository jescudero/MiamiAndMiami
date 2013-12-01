<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link rel="stylesheet" type="text/css" href="css/styleLogin.css"  media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="height:15px;"></div>
 <div class="page-title1" ><h2>Login</h2></div>
  
   <div style="margin-top :10px;text-align:left;padding-left:10px;min-height:300px;" >
    

   		<div id="login">
			
			<div class="inner">

				
				<div class="form">
					<!-- fields -->
					<div class="fields">
						<div class="field">
							<div class="label">
								<label for="username">Email Id:</label>
							</div>

							<div class="input">
                                <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
							
							</div>
						</div>
						<div class="field">
							<div class="label">
								<label for="password">Password:</label>
							</div>

							<div class="input">
							<asp:TextBox ID="TxtPassword" TextMode ="Password" runat="server"></asp:TextBox>
								</div>
						</div>
						
						
					    <div class="field" >
						   
							<div class="checkbox">
                                <asp:CheckBox ID="ChkRememberMe" runat="server" Text =" Remember me" />
								 
                                                                                 
                               
					        </div> 
					    </div>
					     <div class="field" >
						   
							<div class="buttons" >
                                <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="btn-blue"
                                    onclick="Button1_Click" />
                                                       
                               
					        </div> 
					    </div>
					    
					 <div class="field" style="height:40px;">
					 	<ul style="margin-left :130px;color:#129DC6; ">
	                    <li style="padding-bottom:5px;"><a href="ForgotPassword.aspx">Forgot your password ?</a> </li>
                        <li><a href="Register.aspx">Create an account</a></li>
			                    </ul>
							

							
						</div>
						<div class="field"  style="padding-left:132px; ">
					     
						    <asp:Label ID="lblError0"  runat="server" ForeColor="Red" Text =""></asp:Label>
								   
					    </div>
					    					    
					<div>
					
				</div>
								
			</div>
			
		</div>
               
       
</div>
</div> 
					
</div>
</asp:Content>

