<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebApplication1.Contacts.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Create a new contact</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Name" runat="server" CssClass="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="Telephone" CssClass="col-md-2 control-label">Telephone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Telephone" CssClass="form-control" TextMode="Phone" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="Mobile" CssClass="col-md-2 control-label">Mobile</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Mobile" runat="server" CssClass="form-control" TextMode="Phone">
                </asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" AssociatedControlID="DateOfBirth" CssClass="col-md-2 control-label">Date of Birth</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="DateOfBirth" runat="server" CssClass="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Submit" runat="server" Text="Create" CssClass="btn btn-default" OnClick="Submit_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
