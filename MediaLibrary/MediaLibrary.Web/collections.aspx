<%@ Page Title="" Language="C#" MasterPageFile="~/MediaLibrary.Master" AutoEventWireup="true" CodeBehind="collections.aspx.cs" Inherits="MediaLibrary.Web.collections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Edit Collections</h4>
    
    <asp:GridView ID="uxCollectionsGrid" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="CollectionID" DataSourceID="CollectionDataSource" 
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="CollectionID" HeaderText="CollectionID" 
                ReadOnly="True" SortExpression="CollectionID" Visible="False" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:LinqDataSource ID="CollectionDataSource" runat="server" 
        ContextTypeName="MediaLibrary.Web.Data.MediaLibraryDataContext" 
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" 
        OrderBy="Description" TableName="Collections">
    </asp:LinqDataSource>
    <asp:TextBox ID="uxNewCollectionTextBox" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="uxAddButton" runat="server" onclick="uxAddButton_Click" 
        Text="Add" />
</asp:Content>
