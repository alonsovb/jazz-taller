<%@ Page Title="Historial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="JazzTaller.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Historial de Reparaciones</h2>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GVHistorial" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
