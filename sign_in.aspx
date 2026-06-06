<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="sign_in.aspx.cs" Inherits="sign_in" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script src="checker.js"></script>
    <h1>Sign in</h1>
    Username:<br />
    <asp:TextBox ID="txtUsername" runat="server" ClientIDMode="Static" /><span id="usernameError" class="error"></span><br /><br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ClientIDMode="Static" /><span id="passwordError" class="error"></span><br /><br />
    <asp:Label ID="lblMessage" runat="server" /><br /><br />
    <asp:Button ID="btnReset" runat="server" Text="Reset Form" OnClick="reset" CausesValidation="false" />
    &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="submit" OnClientClick="return valLogin()" />
</asp:Content>