<%@ Page Title="Mecánicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarMecánicos.aspx.cs" Inherits="JazzTaller.WebForm2" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 27%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Registro de Mecánicos</h2>
    <h3>
        MECáNICOS</h3>
    <table width="90%" style="margin: 0px 20px 0px 20px">
        <tbody>
            <tr style="height: 35px">
                <td width="25%" align="right">
                    <b>Identificación</b>
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBIdentificación" runat="server" Width="100%" AutoPostBack="True"></asp:TextBox>
                </td>
                <td width="25%" align="right">
                    Código
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBCódigo" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td width="25%" align="right">
                    Nombre
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right" class="style1">
                    Apellidos
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBApellidos" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td align="right">Título</td>
                <td>
                    <asp:TextBox ID="TBTítulo" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">Experiencia</td>
                <td>
                    <asp:TextBox ID="TBExperiencia" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td width="25%" align="right" valign="top">
                    Números de teléfono
                    <br /><i>(Separados por coma)</i>
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBTeléfonos" runat="server" Width="100%" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </td>
                <td align="right" valign="top" class="style1">
                    Correos electrónicos
                    <br /><i>(Separados por coma)</i>
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBEmails" runat="server" Width="100%" TextMode="MultiLine" Rows="2"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr style="height: 35px">
                <td width="25%" align="right" valign="top">
                <asp:RegularExpressionValidator ID="RETelefono" runat="server" 
                    ErrorMessage="Formato de Telefono Incorrecto" 
                    ControlToValidate="TBTeléfonos" 
                    ValidationExpression="(\d{4}\-\d{4})(,(\d{4}\-\d{4}))*"></asp:RegularExpressionValidator>
                </td>
                <td width="25%">
                    &nbsp;</td>
                <td align="right" valign="top" class="style1">
                <asp:RegularExpressionValidator ID="REEmail" runat="server" 
                    ErrorMessage="Formato de Email Incorrecto" ControlToValidate="TBEmails" 
                    ValidationExpression="([a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z])(,([a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]))*"></asp:RegularExpressionValidator>
                </td>
                <td width="25%">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
    <div align="right" 
        
        style="margin: 20px 0px 0px 0px; padding: 20px 20px 20px 20px; background-color: #9A9046">
        <asp:Button ID="BRegistrarMecánico" runat="server" 
            Text="Registrar Mecánico" Height="30px" 
            onclick="BRegistrarMecánico_Click" Enabled="False" />
    </div>
</asp:Content>
