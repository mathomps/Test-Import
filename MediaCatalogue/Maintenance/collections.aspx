<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="collections.aspx.vb" Inherits="Maintenance_collections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div>
        <strong>
        Manage Collections<br />
        </strong>
        <br />
        <asp:GridView ID="grdCollection" runat="server" AutoGenerateColumns="False" DataKeyNames="CollectionID"
            DataSourceID="ds" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="CollectionID" HeaderText="CollectionID" ReadOnly="True"
                    SortExpression="CollectionID" Visible="False" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
    </div>
        <asp:SqlDataSource ID="ds" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
            ProviderName="<%$ ConnectionStrings:MediaCatalogue.ProviderName %>" SelectCommand="SELECT [CollectionID], [Description] FROM [Collection]" DeleteCommand="DELETE FROM Collection WHERE CollectionID = @CollectionID" InsertCommand="Collection_Insert" InsertCommandType="StoredProcedure" UpdateCommand="Collection_Update" UpdateCommandType="StoredProcedure">
            <UpdateParameters>
                <asp:Parameter Name="CollectionID" Type="Object" />
                <asp:Parameter Name="Description" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Button ID="btnAddCollection" runat="server" Text="Add" /><br />
    <br />
    <asp:FormView ID="frmCollectionDetail" runat="server" DataKeyNames="CollectionID"
        DataSourceID="collectionDetailDS">
        <EditItemTemplate>
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox><br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update"></asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton>
        </EditItemTemplate>
        <InsertItemTemplate>
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox><br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert"></asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton>
        </InsertItemTemplate>
        <ItemTemplate>
            Description:
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label><br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit"></asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete"></asp:LinkButton>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New"></asp:LinkButton>
        </ItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="lnkNew" runat="server" CommandName="New">New</asp:LinkButton>
        </EmptyDataTemplate>
    </asp:FormView>
    <br />
    <br />
    <asp:ObjectDataSource ID="collectionDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
        TypeName="MediaSourceTableAdapters.CollectionTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="collectionDetailDS" runat="server" DeleteMethod="DeleteCollection"
        InsertMethod="InsertCollection" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCollectionByID" TypeName="MediaSourceTableAdapters.CollectionTableAdapter"
        UpdateMethod="UpdateCollection">
        <UpdateParameters>
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Original_CollectionID" Type="Object" />
            <asp:Parameter Name="Original_Description" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="grdCollection" Name="CollectionID" PropertyName="SelectedValue"
                Type="Object" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>

</asp:Content>
