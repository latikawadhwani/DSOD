<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="btnDownload" runat="server" Text="Download stock quotes" OnClick="btnDownload_Click"/>
    <br /><br />
    <asp:Label ID="ll1" runat="server" Text="enter path of the file"></asp:Label><asp:TextBox ID="txtFilePath" runat="server"></asp:TextBox><br /><br />

    <asp:Button ID="btnUplaod" runat="server" Text="Daily Upload to server" OnClick="btnUplaod_Click" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnSend" runat="server" Text="Send Subscription Mails" OnClick="btnSend_Click" />
</asp:Content>

