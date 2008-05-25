<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="presenter.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FormView ID="fvPresenter" runat="server" AllowPaging="True" DataKeyNames="PresenterID"
        DataSourceID="dsPresenter">
        <EditItemTemplate>
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox><br />
            Collection:
            <asp:DropDownList ID="ddlCollection" runat="server" DataSourceID="dsCollection" DataTextField="Description"
                DataValueField="CollectionID" SelectedValue='<%# Bind("CollectionID") %>'>
            </asp:DropDownList><br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update"></asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="lnkNew" runat="server" CommandName="New">New</asp:LinkButton>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox><br />
            Collection:
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsCollection" DataTextField="Description"
                DataValueField="CollectionID" SelectedValue='<%# Bind("CollectionID") %>'>
            </asp:DropDownList><br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert"></asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton>
        </InsertItemTemplate>
        <ItemTemplate>
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label><br />
            Collection:
            <asp:Label ID="CollectionLabel" runat="server" Text='<%# Bind("Collection") %>'></asp:Label><br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit"></asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete"></asp:LinkButton>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New"></asp:LinkButton>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <asp:ObjectDataSource ID="dsPresenter" runat="server" DeleteMethod="DeletePresenter"
        InsertMethod="InsertPresenter" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetPresenters" TypeName="MediaSourceTableAdapters.PresenterTableAdapter"
        UpdateMethod="UpdatePresenter">
        <UpdateParameters>
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="PresenterID" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCollection" runat="server" DataObjectTypeName="System.Guid"
        DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="MediaSourceTableAdapters.CollectionTableAdapter"
        UpdateMethod="Update">
        <UpdateParameters>
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Original_CollectionID" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

