<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JazzTaller._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Autos en reparación</h2>
    <asp:Label ID="LTipoLista" runat="server" Text="Lista de autos"></asp:Label>
    <asp:GridView ID="GVListaReparacion" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="id_cita" DataNavigateUrlFormatString="Reparación.aspx?id={0}"
                DataTextField="id_cita" DataTextFormatString="Ver reparación" HeaderText="Reparación"
                Text="Reparación" />
            <asp:HyperLinkField DataNavigateUrlFields="placa" DataNavigateUrlFormatString="Auto.aspx?placa={0}"
                DataTextField="placa" HeaderText="Placa" Text="Placa" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha Ingreso" />
            <asp:BoundField DataField="notas" HeaderText="Notas" />
        </Columns>
    </asp:GridView>
</asp:Content>
