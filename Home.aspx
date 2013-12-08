<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


      



        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
    
      



        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btlogin" runat="server" OnClick="btlogin_Click" Text="LogIn" />
    
        <p>
    
      



        <asp:TextBox ID="lblError" runat="server" Enabled="False" Visible="False"></asp:TextBox>
    



        </p>
    



    </form>
</body>
</html>
