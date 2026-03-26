<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btn-base {
            margin: 5px;
            color: white;
            cursor: pointer;
        }

        .btn-azul { background-color: #007bff; }  
        .btn-rojo { background-color: #dc3545; } 
        .btn-verde { background-color: #28a745; } 

        .caja-espaciada {
            margin-bottom: 15px; 
            padding: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2> Products management </h2>

    Code &nbsp;&nbsp; <asp:TextBox ID="TextBoxCode" runat="server" MaxLength="16" CssClass="caja-espaciada"></asp:TextBox> <br />
    Name &nbsp;&nbsp; <asp:TextBox ID="TextBoxName" runat="server"  MaxLength="32" CssClass="caja-espaciada"></asp:TextBox> <br />
    Amount &nbsp;&nbsp; <asp:TextBox ID="TextBoxAmount" runat="server" CssClass="caja-espaciada"></asp:TextBox> <br />
    Category &nbsp;&nbsp; <asp:DropDownList ID="DropDownListCategory" runat="server" CssClass="caja-espaciada"></asp:DropDownList> <br />
    Price &nbsp;&nbsp; <asp:TextBox ID="TextBoxPrice" runat="server" CssClass="caja-espaciada"></asp:TextBox> <br />
    Creation Date &nbsp;&nbsp; <asp:TextBox ID="TextBoxCDate" runat="server" CssClass="caja-espaciada"></asp:TextBox> <br />

    <asp:Button ID="ButtonCreate" runat="server" Text="Create" OnClick="ButtonCreate_Click" CssClass="btn-base btn-azul"/>
    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" CssClass="btn-base btn-azul"/>
    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" CssClass="btn-base btn-rojo"/>
    <asp:Button ID="ButtonRead" runat="server" Text="Read" OnClick="ButtonRead_Click" CssClass="btn-base btn-verde"/>
    <asp:Button ID="ButtonReadFirst" runat="server" Text="Read First" OnClick="ButtonReadFirst_Click" CssClass="btn-base btn-verde"/>
    <asp:Button ID="ButtonReadPrev" runat="server" Text="Read Prev" OnClick="ButtonReadPrev_Click" CssClass="btn-base btn-verde"/>
    <asp:Button ID="ButtonReadNext" runat="server" Text="Read Next" OnClick="ButtonReadNext_Click" CssClass="btn-base btn-verde"/> <br />

    <asp:Label ID="LabelMessage" runat="server"> </asp:Label>

</asp:Content>
