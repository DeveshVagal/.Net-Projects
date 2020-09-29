<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span class="auto-style1"><strong>FORGOT PASSWORD</strong></span><br />
        <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Re Enter Password"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt;-- Back To Login</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Exception"></asp:Label>
    </div>
    </form>
</body>
</html>
