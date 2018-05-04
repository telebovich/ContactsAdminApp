<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="Test.aspx?test=10">Click Me!</a>
    <h2>Index</h2>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        TypeName="WebApplication1.DataAccessLayer"
        SelectMethod="SelectData">

    </asp:ObjectDataSource>
    <asp:HyperLink ID="create" runat="server" Text="Create New" CssClass="btn btn-link" 
        NavigateUrl="~/Contacts/Create.aspx"></asp:HyperLink>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" 
        AllowPaging="True" CssClass="table" GridLines="None" AutoGenerateColumns="false" 
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" 
                DataFormatString="<a href='mailto:{0}'>{0}</a>" HtmlEncodeFormatString="false" />
            <asp:BoundField DataField="LandlinePhone" HeaderText="Telephone" />
            <asp:BoundField DataField="CellPhone" HeaderText="Mobile" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:d}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
