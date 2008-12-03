<%@ Page Title="" Language="C#" MasterPageFile="~/MediaLibrary.Master" AutoEventWireup="true" CodeBehind="addmedia.aspx.cs" Inherits="MediaLibrary.Web.addmedia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add Media</h3>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>Filename:</td>
            <td>
                <asp:TextBox ID="uxFilenameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox ID="uxDescriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="uxAddButton" runat="server" Text="Add" />
        </tr>
    </table>
</asp:Content>
