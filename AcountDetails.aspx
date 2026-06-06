<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcountDetails.aspx.cs" Inherits="AcountDetails" MasterPageFile="~/MasterPage1.master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Account Details</h1>
    Username: <asp:Label ID="lblUsername" runat="server" /><br />
    First Name: <asp:Label ID="lblFirstName" runat="server" /><br />
    Last Name: <asp:Label ID="lblLastName" runat="server" /><br />
    Email: <asp:Label ID="lblEmail" runat="server" /><br />
    Phone: <asp:Label ID="lblPhone" runat="server" /><br />
    Gender: <asp:Label ID="lblGender" runat="server" /><br />
    Hobbies: <asp:Label ID="lblHobbies" runat="server" /><br />
    Age: <asp:Label ID="lblAge" runat="server" /><br />
    Team Name: <asp:Label ID="lblTeamName" runat="server" /><br />
    Team Number: <asp:Label ID="lblTeamNumber" runat="server" /><br />
    admin: <asp:Label ID="lbladmin" runat="server" /><br />
    <br />
    <br />
    <asp:button ID="logoutbtn" Text="logout" OnClick="logout" runat="server"/>
</asp:Content>