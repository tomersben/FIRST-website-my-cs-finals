<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password_changer.aspx.cs" Inherits="password_changer" MasterPageFile="~/MasterPage1.master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script src="checker.js"></script>
    <h1>Change Password</h1>
    <asp:Label ID="lblMessage" runat="server" /><br /><br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ClientIDMode="Static" /><span id="passwordError" class="error"></span><br /><br />
    new Password:<br />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" ClientIDMode="Static" /><span id="newPasswordError" class="error"></span><br /><br />
    <asp:Button ID="btnReset" runat="server" Text="Reset Form" OnClick="reset" CausesValidation="false" />
    <asp:Button ID="confirm" runat="server" Text="confirm" OnClick="submit" OnClientClick="return valNewPassword()" />
</asp:Content>