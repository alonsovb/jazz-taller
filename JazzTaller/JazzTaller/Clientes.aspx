<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="JazzTaller.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .style1
        {
            width: 19%;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>
 
    Personas Registradas</h2>
    <p>
 
&nbsp;<table width="90%" style="margin: 0px 20px 0px 20px">
        <tbody>
            <tr style="height: 35px">
                <td width="25%" rowspan="3">
                    <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="False" 
                        onselectedindexchanged="GVClientes_SelectedIndexChanged">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="identificacion" 
                                DataNavigateUrlFormatString="Clientes.aspx?id={0}" 
                                DataTextField="identificacion" HeaderText="Identificacion" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellidos" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="right" class="style1">
                    Números de teléfono</td>
                <td width="25%">
                    <asp:TextBox ID="TBTeléfonos" runat="server" Width="100%" TextMode="MultiLine" 
                        Rows="2" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td align="right" class="style1">
                    Correos electrónicos
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBEmails" runat="server" Width="100%" TextMode="MultiLine" 
                        Rows="2" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td align="right" class="style1">
                    &nbsp;Auto(s)
        &nbsp;&nbsp;</td>
                <td width="25%">
                    <asp:DropDownList ID="DDLAutos" runat="server" 
                        onSelectedIndexChanged="DDLAutos_SelectedIndexChanged" AutoPostBack="True" 
                        EnableTheming="True" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
</p>
    <p>
 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>

</asp:Content>
