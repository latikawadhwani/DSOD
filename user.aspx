<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table><tr><td><asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label></td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="Label2" runat="server" Text="enter last name"></asp:Label></td><td><asp:TextBox ID="txtLastNAme" runat="server"></asp:TextBox></td></tr>
        <tr><td><asp:Label ID="l2" runat="server" Text="enter email"></asp:Label></td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
      <tr><td><asp:Label ID="Label3" runat="server" Text="enter symbol you wish to subscribe to"></asp:Label></td><td><asp:TextBox ID="txtSymbol" runat="server"></asp:TextBox></td></tr>
          <tr><td colspan="2"><asp:Button ID="btnSubscribe" runat="server" Text="Subscribe" OnClick="btnSubscribe_Click" /><asp:TextBox ID="txtShow" runat="server"></asp:TextBox></td></tr>
        <tr><td colspan="2"><br /><asp:Button ID="btnDownload" runat="server" Text="Download stock quotes" OnClick="btnDownload_Click" /></td></tr>
    </table>

    <table><tr><td> <h2>
        View Stock History</h2>
    <p>
        Symbol:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtsymbolBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Start Date:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtstartBox" runat="server"></asp:TextBox>
    </p>
    <p>
        End Date:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtendBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSsubmit" runat="server" Text="Submit" 
            Width="98px" OnClick="btnSsubmit_Click" />
    </p>
    <p>
        <asp:TextBox ID="txtoutputBox" runat="server" Height="253px" TextMode="MultiLine" 
            Width="907px"></asp:TextBox>
    </p></td></tr></table>
</asp:Content>

