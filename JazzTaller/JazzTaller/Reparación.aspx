<%@ Page Title="Reparación" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Reparación.aspx.cs" Inherits="JazzTaller.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Reparación
    </h2>
    <table style="width: 100%;">
        <tr>
            <td width="25%" class="style2">
                Cliente
            </td>
            <td width="25%">
                <asp:TextBox ID="TBClienteID" runat="server" Enabled="False" BorderColor="Silver"
                    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
            <td style="text-align: right" width="25%">
                Placa
            </td>
            <td width="25%">
                <asp:TextBox ID="TBPlaca" runat="server" Enabled="False" BorderColor="Silver" BorderStyle="Solid"
                    BorderWidth="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="25%" class="style2">
                Fecha
            </td>
            <td colspan="3">
                <asp:Label ID="LFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="25%" class="style3" colspan="4">
                Notas
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="TBNotas" runat="server" Rows="2" TextMode="MultiLine" Width="100%"
                    BorderColor="#184F67" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial"
                    CssClass="BigText"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="25%" colspan="4" style="text-align: center">
                <asp:CheckBox ID="CBConfirmarAutomático" runat="server" Text="Confirmar labores automáticamente"
                    Enabled="False" />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;
    <h3>
        Diagnóstico</h3>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TBDiagnóstico" runat="server" Rows="2" TextMode="MultiLine" Width="100%"
                    BorderColor="#184F67" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial"
                    CssClass="BigText"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                Código mecánico
            </td>
            <td>
                <asp:TextBox ID="TBDiagnostica" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                Diagnostica
            </td>
            <td>
                <asp:HyperLink ID="HLDiagnostica" runat="server">Diagnostica</asp:HyperLink>
            </td>
        </tr>
    </table>
    <h3>
        Evaluación</h3>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TBEvaluación" runat="server" Rows="2" TextMode="MultiLine" Width="100%"
                    BorderColor="#184F67" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial"
                    CssClass="BigText"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                Código mecánico
            </td>
            <td>
                <asp:TextBox ID="TBEvalúa" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 25%;">
                Evalúa
            </td>
            <td>
                <asp:HyperLink ID="HLEvalúa" runat="server">Evalúa</asp:HyperLink>
            </td>
        </tr>
    </table>
    <h3>
        Repuestos</h3>
    <asp:GridView ID="GVRepuestos" runat="server" Width="100%">
    </asp:GridView>
    <div>
        <strong>Agregar repuesto </strong>
        <table style="width: 100%;">
            <tr>
                <td class="style2" width="50%">
                    Descripción del repuesto
                </td>
                <td width="50%">
                    <asp:TextBox ID="TBRepuestoDescripción" runat="server" Width="338px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    Precio
                </td>
                <td width="50%">
                    <asp:TextBox ID="TBRepuestoPrecio" runat="server" Width="338px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    &nbsp;
                </td>
                <td align="center" width="50%">
                    <asp:Button ID="BAgregarRepuesto" runat="server" Text="Agregar" Width="100px" OnClick="BAgregarRepuesto_Click" />
                </td>
            </tr>
        </table>
    </div>
    <h3>
        Mecánicos participantes</h3>
    <asp:GridView ID="GVMecánicosParticipantes" runat="server" Width="100%">
    </asp:GridView>
    <div>
        <strong>Agregar mecánico participante </strong>
        <table style="width: 100%;">
            <tr>
                <td class="style2" width="50%">
                    Código de mecánico
                </td>
                <td width="50%">
                    <asp:TextBox ID="TBCódigoMecánico" runat="server" Width="337px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    Rol
                </td>
                <td width="50%">
                    <asp:DropDownList ID="DDLRol" runat="server" Height="17px" Width="333px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    Total de horas
                </td>
                <td align="center" width="50%" style="text-align: left">
                    <asp:TextBox ID="TBHoras" runat="server" Width="337px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    &nbsp;
                </td>
                <td align="center" width="50%">
                    <asp:Button ID="BAgregarMecánico" runat="server" Text="Agregar" Width="100px" OnClick="BAgregarMecánico_Click" />
                </td>
            </tr>
        </table>
    </div>
    <h3>
        Labores</h3>
    <strong>Aprobar Labor</strong>
    <table>
        <tbody>
            <tr>
                <th>
                    ID de labor
                </th>
                <th>
                    Aprobar
                </th>
                <th>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TBIDLabor" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CBAprobarLabor" runat="server" />
                </td>
                <td>
                    <asp:Button ID="BModificarLabor" runat="server" onclick="BModificarLabor_Click" 
                        Text="Modificar" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="GVLaboresRequeridas" runat="server" Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id_labor_requerida" HeaderText="ID">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="aprobada" HeaderText="Aprobada">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
            <asp:BoundField DataField="descripcion" HeaderText="Descripción" ReadOnly="True" />
            <asp:BoundField DataField="nombre" HeaderText="Mecánico Asignado" ReadOnly="True" />
        </Columns>
    </asp:GridView>
    <div>
        <strong>Agregar labor requerida </strong>
        <table style="width: 100%;">
            <tr>
                <td class="style2" width="50%">
                    Labor
                </td>
                <td width="50%">
                    <asp:DropDownList ID="DDLLabores" runat="server" Height="17px" Width="333px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    Código de mecánico
                </td>
                <td width="50%">
                    <asp:TextBox ID="TBCódigoMecánicoLabor" runat="server" Width="338px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" width="50%">
                    &nbsp;
                </td>
                <td align="center" width="50%">
                    <asp:Button ID="BAgregarLabor" runat="server" Text="Agregar" Width="100px" OnClick="BAgregarLabor_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="padding: 20px 20px 20px 20px; margin: 20px 0px 0px 0px; text-align: right;
        background-color: #9A9046;">
        <asp:Button ID="BCompletar" runat="server" Text="Completar" Height="30px" Width="150px"
            OnClick="BCompletar_Click" />
        &nbsp;<asp:Button ID="BGuardar" runat="server" Text="Guardar" Height="30px" Width="150px"
            OnClick="BGuardar_Click" />
    </div>
</asp:Content>
