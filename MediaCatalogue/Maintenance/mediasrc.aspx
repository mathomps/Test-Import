<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="mediasrc.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:GridView ID="grdMediaSource" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="MediaSourceID"
        DataSourceID="mediaSourceDataSource" GridLines="Vertical" ShowFooter="True">
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="MediaSourceID" HeaderText="MediaSourceID" ReadOnly="True"
                SortExpression="MediaSourceID" Visible="False" />
            <asp:BoundField DataField="MediaTypeID" HeaderText="MediaTypeID" SortExpression="MediaTypeID"
                Visible="False" />
            <asp:BoundField DataField="CollectionID" HeaderText="CollectionID" SortExpression="CollectionID"
                Visible="False" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Collection" HeaderText="Collection" SortExpression="Collection" />
            <asp:BoundField DataField="MediaType" HeaderText="MediaType" SortExpression="MediaType" />
            <asp:BoundField DataField="FullPath" HeaderText="FullPath" SortExpression="FullPath"
                Visible="False" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("MediaSourceID", "mediasection.aspx?mediasrc={0}") %>'>Edit Sections</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView>
    <br />
    &nbsp;<br />
    <asp:FormView ID="frmMediaSource" runat="server" DataKeyNames="MediaSourceID" DataSourceID="dsMediaSourceDetails" Width="100%">
        <EditItemTemplate>
            <table>
                <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td>Media Type:</td>
                    <td><asp:DropDownList ID="ddlMediaType" runat="server" DataSourceID="mediaTypeDS" DataTextField="Description"
                DataValueField="MediaTypeID" SelectedValue='<%# Bind("MediaTypeID") %>'>
            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Collection:</td>
                    <td><asp:DropDownList ID="ddlCollection" runat="server" DataSourceID="collectionDS" DataTextField="Description"
                DataValueField="CollectionID" SelectedValue='<%# Bind("CollectionID") %>'>
            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>FullPath:</td>
                    <td><asp:TextBox ID="FullPathTextBox" runat="server" Text='<%# Bind("FullPath") %>'>
            </asp:TextBox></td>
                
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update">
            </asp:LinkButton>
                        <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel">
            </asp:LinkButton></td>
                </tr>
                
            </table>
            &nbsp;
        </EditItemTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td style="width: 100px">
                        Title:</td>
                    <td>
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Collection:</td>
                    <td>
            <asp:Label ID="CollectionLabel" runat="server" Text='<%# Bind("Collection") %>'>
            </asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        FullPath:</td>
                    <td>
            <asp:Label ID="FullPathLabel" runat="server" Text='<%# Bind("FullPath") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        MediaType:</td>
                    <td>
            <asp:Label ID="MediaTypeLabel" runat="server" Text='<%# Bind("MediaType") %>'></asp:Label></td>
                </tr>
            </table>
            &nbsp;<br />
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="New">New</asp:LinkButton>
        </ItemTemplate>
        <InsertItemTemplate>
            <table>
                <tr>
                    <td style="width: 100px">
                        Title:
                    </td>
                    <td>
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Collection:</td>
                    <td>
                        <asp:DropDownList ID="ddlCollection" runat="server" DataSourceID="collectionDS" DataTextField="Description"
                            DataValueField="CollectionID" SelectedValue='<%# Bind("CollectionID") %>'>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        FullPath:</td>
                    <td>
            <asp:TextBox ID="FullPathTextBox" runat="server" Text='<%# Bind("FullPath") %>'>
            </asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        MediaType:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="mediaTypeDS" DataTextField="Description"
                            DataValueField="MediaTypeID" SelectedValue='<%# Bind("MediaTypeID") %>'>
                        </asp:DropDownList></td>
                </tr>
            </table>
            <br />
            &nbsp;<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert">
            </asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel">
            </asp:LinkButton>
        </InsertItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="lnkNew" runat="server" CommandName="New">New</asp:LinkButton>
        </EmptyDataTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="mediaSourceDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="MediaSourceTableAdapters.MediaSourceTableAdapter" DeleteMethod="DeleteQuery" InsertMethod="InsertData" UpdateMethod="UpdateData">
        <UpdateParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="FullPath" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="FullPath" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
            
            
            <asp:ObjectDataSource ID="mediaTypeDS" runat="server" DataObjectTypeName="System.Guid"
                DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetData" TypeName="MediaSourceTableAdapters.MediaTypeTableAdapter"
                UpdateMethod="Update">
                <UpdateParameters>
                    <asp:Parameter Name="MediaTypeID" Type="Object" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Original_MediaTypeID" Type="Object" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="MediaTypeID" Type="Object" />
                    <asp:Parameter Name="Description" Type="String" />
                </InsertParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="collectionDS" runat="server" DataObjectTypeName="System.Guid"
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
    <asp:ObjectDataSource ID="dsMediaSourceDetails" runat="server" DeleteMethod="DeleteQuery"
        InsertMethod="InsertData" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMediaSourceByID"
        TypeName="MediaSourceTableAdapters.MediaSourceTableAdapter" UpdateMethod="UpdateData">
        <UpdateParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="FullPath" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="original_MediaSourceID" Type="Object" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="grdMediaSource" Name="MediaSourceID" PropertyName="SelectedValue"
                Type="Object" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="MediaTypeID" Type="Object" />
            <asp:Parameter Name="CollectionID" Type="Object" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="FullPath" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

