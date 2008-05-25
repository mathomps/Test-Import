<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        Search Media Library</h3>
    <p>
        <table border="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 100px">
                    Keywords:</td>
                <td>
                    <asp:TextBox ID="txtKeywords" runat="server" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Series/Source:</td>
                <td>
                    <asp:DropDownList ID="ddlSource" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        DataSourceID="SeriesDataSource" DataTextField="Description" DataValueField="CollectionID">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">(all)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    Presenter:</td>
                <td>
                    <asp:DropDownList ID="ddlPresenter" runat="server" AppendDataBoundItems="True" DataSourceID="PresenterDataSource"
                        DataTextField="Name" DataValueField="PresenterID">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">(all)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    Media Type:</td>
                <td>
                    <asp:DropDownList ID="ddlMediaType" runat="server" AppendDataBoundItems="True" DataSourceID="MediaTypeDataSource"
                        DataTextField="Description" DataValueField="MediaTypeID">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">(all)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
            </tr>
        </table>
    </p>
    <asp:SqlDataSource ID="SeriesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
        SelectCommand="SELECT CollectionID, Description FROM Collection ORDER BY Description">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="PresenterDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
        SelectCommand="SELECT PresenterID, Name FROM Presenter&#13;&#10;WHERE (CollectionID = @CollectionID) OR (@CollectionID = '00000000-0000-0000-0000-000000000000') ORDER BY Name">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSource" DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="CollectionID" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="MediaTypeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
        SelectCommand="SELECT [MediaTypeID], [Description] FROM [MediaType] ORDER BY [Description]">
    </asp:SqlDataSource>
    <br />
    <h5>Results</h5>
    <asp:GridView ID="grdResults" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="SectionID"
            DataSourceID="SearchResultsDataSource" GridLines="Vertical">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="SectionID" HeaderText="SectionID" ReadOnly="True" SortExpression="SectionID"
                    Visible="False" />
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="hlDescription" runat="server" NavigateUrl='<%# Eval("SectionID", "playmedia.aspx?sectionId={0}") %>'
                            Text='<%# Eval("Description") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Collection" HeaderText="Collection" SortExpression="Collection" />
                <asp:BoundField DataField="Name" HeaderText="Presenter" SortExpression="Name" />
                <asp:BoundField DataField="MediaType" HeaderText="MediaType" SortExpression="MediaType" />
            </Columns>
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView>
    <asp:SqlDataSource ID="SearchResultsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MediaCatalogue %>"
        SelectCommand="SELECT MediaSection.SectionID, MediaSection.Description, MediaSource.Title, Collection.Description AS Collection, Presenter.Name, MediaType.Description AS MediaType FROM Collection INNER JOIN MediaSource ON Collection.CollectionID = MediaSource.CollectionID INNER JOIN MediaSection ON MediaSource.MediaSourceID = MediaSection.MediaSourceID INNER JOIN MediaType ON MediaSource.MediaTypeID = MediaType.MediaTypeID INNER JOIN Presenter ON Collection.CollectionID = Presenter.CollectionID AND MediaSection.PresenterID = Presenter.PresenterID WHERE (@CollectionID = Collection.CollectionID OR @CollectionID = '00000000-0000-0000-0000-000000000000') AND (@PresenterID = Presenter.PresenterID OR @PresenterID = '00000000-0000-0000-0000-000000000000') AND (@MediaTypeID = MediaType.MediaTypeID OR @MediaTypeID = '00000000-0000-0000-0000-000000000000') AND (MediaSection.Description LIKE @Keywords) OR (@CollectionID = Collection.CollectionID OR @CollectionID = '00000000-0000-0000-0000-000000000000') AND (@PresenterID = Presenter.PresenterID OR @PresenterID = '00000000-0000-0000-0000-000000000000') AND (@MediaTypeID = MediaType.MediaTypeID OR @MediaTypeID = '00000000-0000-0000-0000-000000000000') AND (MediaSection.Notes LIKE @Keywords) OR (@CollectionID = Collection.CollectionID OR @CollectionID = '00000000-0000-0000-0000-000000000000') AND (@PresenterID = Presenter.PresenterID OR @PresenterID = '00000000-0000-0000-0000-000000000000') AND (@MediaTypeID = MediaType.MediaTypeID OR @MediaTypeID = '00000000-0000-0000-0000-000000000000') AND (@Keywords IS NULL) OR (@CollectionID = Collection.CollectionID OR @CollectionID = '00000000-0000-0000-0000-000000000000') AND (@PresenterID = Presenter.PresenterID OR @PresenterID = '00000000-0000-0000-0000-000000000000') AND (@MediaTypeID = MediaType.MediaTypeID OR @MediaTypeID = '00000000-0000-0000-0000-000000000000') AND (MediaSection.Description LIKE @Keywords) OR (@CollectionID = Collection.CollectionID OR @CollectionID = '00000000-0000-0000-0000-000000000000') AND (@PresenterID = Presenter.PresenterID OR @PresenterID = '00000000-0000-0000-0000-000000000000') AND (@MediaTypeID = MediaType.MediaTypeID OR @MediaTypeID = '00000000-0000-0000-0000-000000000000') AND (MediaSection.Notes LIKE @Keywords) ORDER BY Collection, MediaSource.Title">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSource" DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="CollectionID" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlPresenter" DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="PresenterID" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlMediaType" DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="MediaTypeID" PropertyName="SelectedValue" />
            <asp:Parameter Name="Keywords" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

