<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="playmedia.aspx.vb" Inherits="Default2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<object id="Player" height="276" width="360" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
    <param name="URL" value = "" />
    <param name="CurrentPosition" value = "0" />
</object>
    <br />
    <asp:DetailsView ID="sectionDetails" runat="server" AutoGenerateRows="False"
        DataKeyNames="SectionID" DataSourceID="mediaSectionDataSource" Height="50px"
        Width="360px" BackColor="LightSteelBlue">
        <Fields>
            <asp:BoundField DataField="SectionID" HeaderText="SectionID" ReadOnly="True" SortExpression="SectionID" Visible="False" />
            <asp:BoundField DataField="PresenterID" HeaderText="PresenterID" SortExpression="PresenterID" Visible="False" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="TimeOffset" HeaderText="TimeOffset" SortExpression="TimeOffset" Visible="False" />
            <asp:BoundField DataField="PageNumber" HeaderText="PageNumber" SortExpression="PageNumber" Visible="False" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
            <asp:BoundField DataField="PresenterName" HeaderText="Presenter" SortExpression="PresenterName" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        </Fields>
    </asp:DetailsView>
    &nbsp;
    <br />
    <asp:ObjectDataSource ID="mediaSectionDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetSectionByID" TypeName="MediaSourceTableAdapters.MediaSectionTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="SectionID" QueryStringField="sectionId" />
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>

