<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="mediatype.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MediaTypeID"
        DataSourceID="ds" EnableTheming="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <Columns>
            <asp:BoundField DataField="MediaTypeID" HeaderText="MediaTypeID" ReadOnly="True"
                SortExpression="MediaTypeID" Visible="False" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
    </asp:GridView>
    <asp:SqlDataSource ID="ds" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
        DeleteCommand="DELETE FROM [MediaType] WHERE [MediaTypeID] = @MediaTypeID" InsertCommand="INSERT INTO [MediaType] ([MediaTypeID], [Description]) VALUES (@MediaTypeID, @Description)"
        ProviderName="<%$ ConnectionStrings:MediaCatalogue.ProviderName %>" SelectCommand="SELECT [MediaTypeID], [Description] FROM [MediaType]&#13;&#10;ORDER BY [Description]"
        UpdateCommand="UPDATE [MediaType] SET [Description] = @Description WHERE [MediaTypeID] = @MediaTypeID">
        <DeleteParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="MediaTypeID" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:Button ID="btnAdd" runat="server" Text="Add" />
</asp:Content>

