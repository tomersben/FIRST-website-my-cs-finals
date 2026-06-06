<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="sign up page.aspx.cs" Inherits="sign_up_page" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script src="checker.js"></script>
    <style>
        
        
    </style>
    <h1>Sign Up</h1>
    Username:<br />
    <input type="text" id="txtUsername" name="txtUsername" /><span id="usernameError" class="error"></span><br /><br />
    Password:<br />
    <input type="password" id="txtPassword" name="txtPassword" /><span id="passwordError" class="error"></span><br /><br />
    Confirm Password:<br />
    <input type="password" id="txtConfirmPassword" name="txtConfirmPassword" /><span id="confirmPasswordError" class="error"></span><br /><br />
    First Name:<br />
    <input type="text" id="txtFirstName" name="txtFirstName" /><span id="firstnameError" class="error"></span><br /><br />
    Last Name:<br />
    <input type="text" id="txtLastName" name="txtLastName" /><span id="lastnameError" class="error"></span><br /><br />
    Email:<br />
    <input type="text" id="txtEmail" name="txtEmail" /><span id="emailError" class="error"></span><br /><br />
    Phone:<br />
    <input type="text" id="txtPhone" name="txtPhone" /><span id="phoneError" class="error"></span><br /><br />
    Gender:<br />
    <input type="radio" name="rblGender" value="Male" /> Male
    <input type="radio" name="rblGender" value="Female" /> Female
    <input type="radio" name="rblGender" value="Other" /> Other
    <span id="genderError" class="error"></span><br /><br />
    Hobbies:<br />
    <input type="checkbox" name="cblHobbies" value="Gaming" /> Gaming<br />
    <input type="checkbox" name="cblHobbies" value="Coding" /> Coding<br />
    <input type="checkbox" name="cblHobbies" value="Robotics" /> Robotics<br />
    <span id="hobbiesError" class="error"></span><br /><br />
    Age Range:<br />
    <select id="ddlAge" name="ddlAge">
        <option value="">Choose age</option>
        <option value="1-10">1-10</option>
        <option value="11-20">11-20</option>
        <option value="21-30">21-30</option>
        <option value="31+">31+</option>
    </select>
    <span id="ageError" class="error"></span><br /><br />
    Team Name:<br />
    <input type="text" id="txtTeamName" name="txtTeamName" /><span id="teamnameError" class="error"></span><br /><br />
    Team Number:<br />
    <input type="text" id="txtTeamNumber" name="txtTeamNumber" /><span id="teamnumberError" class="error"></span><br /><br />
    <input type="button" value="Reset" onclick="location.reload()" />
    &nbsp;
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="Submit" OnClientClick="return val()" />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Size="Large" /><br />
    <asp:Panel runat="server" ID="pnlVideo" Visible="false">
        <img src="images/ani.gif" width="400" />
    </asp:Panel>
</asp:Content>