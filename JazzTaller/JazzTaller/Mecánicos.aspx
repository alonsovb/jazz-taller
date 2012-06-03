<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mecánicos.aspx.cs" Inherits="JazzTaller.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        MECÁNICOS</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GVMecanicos" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <div align="right" 
        style="margin: 20px 0px 0px 0px; padding: 20px 20px 20px 20px; background-color: #9A9046">
        <asp:Button ID="BRegistrarMecanico" runat="server" 
            Text="Registrar Mecánico" Height="30px" 
            onclick="BRegistrarMecanico_Click"/>
    </div>
    </asp:Content>
