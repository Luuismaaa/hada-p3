<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2> Products management </h2>

    Code <asp:TextBox ID="TextBoxCode" runat="server"></asp:TextBox> <br />
    Name <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox> <br />
    Amount <asp:TextBox ID="TextBoxAmount" runat="server"></asp:TextBox> <br />
    Category <asp:DropDownList ID="DropDownListCategory" runat="server"></asp:DropDownList> <br />
    Price <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox> <br />
    Creation Date <asp:TextBox ID="TextBoxCDate" runat="server"></asp:TextBox> <br />

    <asp:Button ID="ButtonCreate" runat="server" Text="Create"/>
    <asp:Button ID="ButtonUpdate" runat="server" Text="Update"/>
    <asp:Button ID="ButtonDelete" runat="server" Text="Delete"/>
    <asp:Button ID="ButtonRead" runat="server" Text="Read"/>
    <asp:Button ID="ButtonReadFirst" runat="server" Text="Read First"/>
    <asp:Button ID="ButtonReadPrev" runat="server" Text="Read Prev"/>
    <asp:Button ID="ButtonReadNext" runat="server" Text="Read Next"/>

</asp:Content>
