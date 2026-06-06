<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin Panel</h1>
    Sort by:
    <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
        <asp:ListItem Value="username">Username</asp:ListItem>
        <asp:ListItem Value="eamil">Email</asp:ListItem>
        <asp:ListItem Value="phone">Phone</asp:ListItem>
        <asp:ListItem Value="age">Age</asp:ListItem>
        <asp:ListItem Value="teamname">Team Name</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
    <asp:GridView ID="gvUsers" runat="server" />
    <br />
    <h3>Delete User</h3>
    Username: <asp:TextBox ID="txtDeleteUsername" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <br /><br />
    <h3>Update User</h3>
    Username: <asp:TextBox ID="txtUpdateUsername" runat="server" /><br />
    Field:
    <asp:DropDownList ID="ddlField" runat="server">
        <asp:ListItem Value="username">Username</asp:ListItem>
        <asp:ListItem Value="password">Password</asp:ListItem>
        <asp:ListItem Value="first name">First Name</asp:ListItem>
        <asp:ListItem Value="last name">Last Name</asp:ListItem>
        <asp:ListItem Value="eamil">Email</asp:ListItem>
        <asp:ListItem Value="phone">Phone</asp:ListItem>
        <asp:ListItem Value="gender">Gender</asp:ListItem>
        <asp:ListItem Value="hobbies">Hobbies</asp:ListItem>
        <asp:ListItem Value="age">Age</asp:ListItem>
        <asp:ListItem Value="teamname">Team Name</asp:ListItem>
        <asp:ListItem Value="teamnumber">Team Number</asp:ListItem>
    </asp:DropDownList><br />
    New Value: <asp:TextBox ID="txtNewValue" runat="server" /><br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <br /><br />
    <asp:Button ID="btnsort" runat="server" Text="sort by abc" OnClick="btnsortABC_Click" />
    <br /><br />
    <asp:Button ID="btnsort2" runat="server" Text="sort by number" OnClick="btnsortint" />
</asp:Content>