<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="TimesheetSystem.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Login Required</h2>
    <div style="margin:0 auto; width: 250px">
        <asp:Login ID="_login" runat="server" OnAuthenticate="_login_Authenticate" BackColor="#F7F6F3"
            BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" ForeColor="#333333" Width="100%" >
            <TextBoxStyle Width="150px" CssClass="login-textbox" />
            
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LabelStyle Font-Size="0.9em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="1.2em" Height="25px"/>
        </asp:Login>
    </div>
</asp:Content>
