<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table><tr><td><asp:Label ID="Label1" runat="server" Text="enter user name"></asp:Label></td><td>  <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="Label2" runat="server" Text="password"></asp:Label></td><td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="l3" runat="server" Text="User Type"></asp:Label></td><td><asp:DropDownList ID="ddlUser" runat="server"><asp:ListItem>Admin</asp:ListItem>
        <asp:ListItem>User</asp:ListItem>
    </asp:DropDownList></td></tr>
        <tr><td colspan="2"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td></tr>
    </table>
    

    
    
    
   
       
    


    </div>
    </form>
</body>
</html>