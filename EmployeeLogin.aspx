<%@ Page Title="Employee Login" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="EmployeeLogin.aspx.cs" Inherits="JUHIMSemployee.EmployeeLogin" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="login">
            <h1><%: Title %></h1>
       
        <asp:TextBox ID="eusername" runat="server" class="input" placeholder="Username"></asp:TextBox> <br />
        <asp:TextBox ID="epassword" TextMode="Password" runat="server" class="input" placeholder="Password"></asp:TextBox> <br />
        <asp:Label ID="eWrongPassword" runat="server" Text="" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="eloginbtn" UseSubmitBehavior="true" class="button" runat="server" Text="Login" OnClick="eloginbtn_Click" OnClientClick="eloginbtn_Click"/>

    </div>
</asp:Content>