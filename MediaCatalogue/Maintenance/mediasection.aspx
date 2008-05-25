<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="mediasection.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grdMediaSection" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="SectionID"
        DataSourceID="dsMediaSection" GridLines="Vertical" ShowFooter="True">
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                        Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SectionID" HeaderText="SectionID" ReadOnly="True" SortExpression="SectionID"
                Visible="False" />
            <asp:BoundField DataField="PresenterID" HeaderText="PresenterID" SortExpression="PresenterID"
                Visible="False" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="PresenterName" HeaderText="Presenter" SortExpression="PresenterName" />
            <asp:BoundField DataField="TimeOffset" HeaderText="TimeOffset" SortExpression="TimeOffset"
                Visible="False" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" Visible="False" />
            <asp:BoundField DataField="PageNumber" HeaderText="PageNumber" SortExpression="PageNumber"
                Visible="False" />
            <asp:BoundField DataField="Title" HeaderText="Source" SortExpression="Title" />
        </Columns>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView>
    <br />
    <asp:FormView ID="frmSectionDetail" runat="server" DataKeyNames="SectionID"
        DataSourceID="dsMediaSectionDetail" DefaultMode="Edit">
        <EditItemTemplate>
            <table width="100%">
                <tr>
                    <td valign="top">
                        Description:</td>
                    <td valign="top" style="width: 248px">
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' Width="264px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Time Offset:</td>
                    <td valign="top" style="width: 248px">
            <asp:TextBox ID="TimeOffsetTextBox" runat="server" Text='<%# Bind("TimeOffset") %>' Width="80px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Notes:</td>
                    <td valign="top" style="width: 248px">
            <asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' Height="80px" TextMode="MultiLine" Font-Names="Arial" Width="264px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Presenter:</td>
                    <td valign="top" style="width: 248px">
            <asp:DropDownList ID="ddlPresenter" runat="server" DataSourceID="dsPresenter" DataTextField="Name"
                DataValueField="PresenterID" SelectedValue='<%# Bind("PresenterID") %>'>
            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update"></asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="New">New</asp:LinkButton></td>
                </tr>
            </table>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <asp:LinkButton ID="lnkNew" runat="server" CommandName="New">New</asp:LinkButton>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <table>
                <tr>
                    <td valign="top">
                        Description:</td>
                    <td valign="top">
            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' Width="97%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Time Offset:</td>
                    <td valign="top">
            <asp:TextBox ID="TimeOffsetTextBox" runat="server" Text='<%# Bind("TimeOffset") %>' Width="88px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Notes:</td>
                    <td valign="top">
            <asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' Height="80px" TextMode="MultiLine" Font-Names="Arial" Width="272px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td valign="top">
                        Presenter:</td>
                    <td valign="top">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsPresenter" DataTextField="Name"
                DataValueField="PresenterID" SelectedValue='<%# Bind("PresenterID") %>'>
            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert"></asp:LinkButton>
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel"></asp:LinkButton></td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            <table width="100%">
                <tr>
                    <td style="width: 100px" valign="top">
                        Description:
                    </td>
                    <td valign="top">
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        Presenter:
                    </td>
                    <td valign="top">
            <asp:Label ID="PresenterNameLabel" runat="server" Text='<%# Bind("PresenterName") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        Time Offset:</td>
                    <td valign="top">
            <asp:Label ID="TimeOffsetLabel" runat="server" Text='<%# Bind("TimeOffset") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        Notes:</td>
                    <td valign="top">
            <asp:Label ID="NotesLabel" runat="server" Text='<%# Bind("Notes") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px" valign="top">
                        Source:</td>
                    <td valign="top">
            <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit"></asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete"></asp:LinkButton>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New"></asp:LinkButton></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <asp:HiddenField ID="hdnMediaSourceID" runat="server" />
    <br />
    <asp:ObjectDataSource ID="dsMediaSection" runat="server"
        InsertMethod="InsertSection" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSections"
        TypeName="MediaSourceTableAdapters.MediaSectionTableAdapter">
        <InsertParameters>
            <asp:ControlParameter ControlID="hdnMediaSourceID" Name="MediaSourceID" PropertyName="Value" />
            <asp:Parameter Name="PresenterID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="TimeOffset" Type="Int32" />
            <asp:Parameter Name="PageNumber" Type="Int32" />
            <asp:Parameter Name="Notes" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="hdnMediaSourceID" Name="MediaSourceID" PropertyName="Value" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsPresenter" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetPresenters" TypeName="MediaSourceTableAdapters.PresenterTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsMediaSource" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="MediaSourceTableAdapters.MediaSourceTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsMediaSectionDetail" runat="server"
        DeleteMethod="DeleteSection" InsertMethod="InsertSection" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetSectionByID" TypeName="MediaSourceTableAdapters.MediaSectionTableAdapter"
        UpdateMethod="UpdateSection">
        <UpdateParameters>
            <asp:Parameter Name="PresenterID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="TimeOffset" Type="Int32" />
            <asp:Parameter Name="PageNumber" Type="Int32" />
            <asp:Parameter Name="Notes" Type="String" />
            <asp:Parameter Name="original_SectionID" Type="Object" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="MediaSourceID" Type="Object" />
            <asp:Parameter Name="PresenterID" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="TimeOffset" Type="Int32" />
            <asp:Parameter Name="PageNumber" Type="Int32" />
            <asp:Parameter Name="Notes" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="grdMediaSection" Name="SectionID" PropertyName="SelectedValue"
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

