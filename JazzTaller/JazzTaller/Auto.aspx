<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Auto.aspx.cs" Inherits="JazzTaller.AutoWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Placa <asp:Label ID="LPlaca" runat="server" Text=""></asp:Label></h1>
    <table width="100%">
        <tbody>
            <tr>
                <td align="right" width="50%">
                    Marca
                </td>
                <td>
                    <asp:Label ID="LMarca" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    Modelo
                </td>
                <td>
                    <asp:Label ID="LModelo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    Año
                </td>
                <td>
                    <asp:Label ID="LAño" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    Número de VIN
                </td>
                <td>
                    <asp:Label ID="LVIN" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    Color
                </td>
                <td>
                    <asp:Label ID="LColor" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    
    <br />
    <asp:GridView ID="GVAuto" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    
</asp:Content>
