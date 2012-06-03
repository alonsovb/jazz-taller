<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Costo.aspx.cs" Inherits="JazzTaller.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 89%;
        }
        .style2
        {
            width: 392px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        COSTO DE REPARACIONES</h2>
    <p>
        &nbsp;</p>
    <table class="style1">
        <tr>
            <td class="style2" width="40%">
                COSTO MANO DE OBRA</td>
            <td>
                COSTO REPUESTOS UTILIZADOS</td>
        </tr>
        <tr>
            <td align="center" class="style2" width="50%">
        <asp:GridView ID="GVCostosReparacion" runat="server">
        </asp:GridView>
                <br />
            </td>
            <td align="center" width="50%">
        <asp:GridView ID="GVCostosRepuestos" runat="server">
        </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" class="style2" width="50%">
                Costo total:
                <asp:Label ID="LTotal" runat="server" Enabled="False" Visible="False"></asp:Label>
            </td>
            <td align="center" width="50%">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <div align="right" 
        style="margin: 20px 0px 0px 0px; padding: 20px 20px 20px 20px; background-color: #9A9046">
        <asp:Button ID="BCancelar" runat="server" 
            Text="Cancelar" Height="30px" onclick="BCancelar_Click" />
    </div>
    <p>
        &nbsp;</p>
    </asp:Content>
