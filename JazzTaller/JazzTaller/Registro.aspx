<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro.aspx.cs" Inherits="JazzTaller.WebForm1" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Registro de reparaciones
    </h2>
    <div>
        <h3>
            Vehículo
        </h3>
        <table width="90%" style="margin: 0px 20px 0px 20px">
            <tbody>
                <tr style="height: 35px">
                    <td width="25%" align="right">
                        <b>Placa</b>
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="TBPlaca" runat="server" Width="100%" AutoPostBack="True" ></asp:TextBox>
                    </td>
                    <td width="25%" align="right">
                        Número de VIN
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="TBNúmeroVIN" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 35px">
                    <td width="25%" align="right">
                        Marca
                    </td>
                    <td width="25%">
                        <asp:DropDownList ID="DDMarcas" runat="server" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td width="25%" align="right">
                        Año
                    </td>
                    <td width="25%">
                        <asp:DropDownList ID="DDAño" runat="server" Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 35px">
                    <td width="25%" align="right">
                        Modelo
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="TBModelo" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td width="25%" align="right">
                        Color
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="TBColor" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="right"">
                        Notas adicionales
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TBNotas" runat="server" Width="100%" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="CBConfirmarTodo" runat="server" Text="Confirmar Todo" />
                </td>
            </tr>
        </table>
    </div>
    <h3>
        Cliente
    </h3>
    <table width="90%" style="margin: 0px 20px 0px 20px">
        <tbody>
            <tr style="height: 35px">
                <td width="25%" align="right">
                    <b>Identificación</b>
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBIdentificación" runat="server" Width="100%" AutoPostBack="True"></asp:TextBox>
                </td>
                <td width="50%" align="center" colspan="2">
                    <asp:CheckBox ID="CBDueño" runat="server" Width="100%" Text="Es dueño del auto."></asp:CheckBox>
                </td>
            </tr>
            <tr style="height: 35px">
                <td width="25%" align="right">
                    Nombre
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td width="25%" align="right">
                    Apellidos
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBApellidos" runat="server" Width="100%"></asp:TextBox>
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
                <td width="25%" align="right" valign="top">
                    Correos electrónicos
                    <br /><i>(Separados por coma)</i>
                </td>
                <td width="25%">
                    <asp:TextBox ID="TBEmails" runat="server" Width="100%" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tr>
            <td>
                <asp:RegularExpressionValidator ID="RETelefono" runat="server" 
                    ErrorMessage="Formato de Telefono Incorrecto" 
                    ControlToValidate="TBTeléfonos" 
                    ValidationExpression="(\d{4}\-\d{4})(,(\d{4}\-\d{4}))*"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="REEmail" runat="server" 
                    ErrorMessage="Formato de Email Incorrecto" ControlToValidate="TBEmails" 
                    ValidationExpression="([a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z])(,([a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]))*"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <div align="right" 
        style="margin: 20px 0px 0px 0px; padding: 20px 20px 20px 20px; background-color: #9A9046">
        <asp:Button ID="BRegistrarReparación" runat="server" 
            Text="Registrar Reparación" Height="30px" 
            onclick="BRegistrarReparación_Click" />
    </div>
</asp:Content>
