<%@ Page Title="Login" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JUHIMS.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="login">
            <h1><%: Title %></h1>
       
        <asp:TextBox ID="username" runat="server" class="input" placeholder="Username"></asp:TextBox> <br />
        <asp:TextBox ID="password" TextMode="Password" runat="server" class="input" placeholder="Password"></asp:TextBox> <br />
        <asp:Label ID="WrongPassword" runat="server" Text="" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="loginbtn" UseSubmitBehavior="true" class="button" runat="server" Text="Login" OnClick="loginbtn_Click" OnClientClick="loginbtn_Click"/>
        <asp:Label ID="Feedback" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>