<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alertas.aspx.cs" Inherits="JazzTaller.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 138px;
            margin-bottom: 0px;
        }
        .style3
        {
            width: 557px;
            height: 200px;
        }
        .style4
        {
            width: 364px;
            height: 200px;
        }
        .style7
        {
            width: 364px;
            height: 34px;
        }
        .style8
        {
            width: 557px;
            height: 34px;
        }
        .style5
        {
            width: 100%;
        }
        .style6
        {
            width: 319px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <table class="style5">
        <tr>
            <td align="center" class="style6">
                &nbsp;RECORDATORIO</td>
            <td align="center">
                REGISTRAR RECORDATORIO</td>
        </tr>
        <tr>
            <td align="center" class="style6">
                <asp:GridView ID="GVRecordatorio" runat="server" Visible="False">
                </asp:GridView>
            </td>
            <td align="center">
        <table class="style1">
            <tr>
                <td align="right" class="style4" dir="ltr">
                    PLACA:
                    <br />
&nbsp;<asp:TextBox ID="TBPlacaReg" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <br />
                    Descripcion Alerta:<br />
                        <asp:TextBox ID="TBAlertaReg" runat="server" Width="100%" 
                        TextMode="MultiLine" Rows="3"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td align="center" class="style3">
                    <asp:Calendar ID="CAlertaReg" runat="server" Height="100px" Width="200px">
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" dir="ltr">
                </td>
                <td align="center" class="style8">
                    <asp:Button ID="BRegistrarAlerta" runat="server" 
                        onclick="BRegistrarAlerta_Click" Text="Registrar Recordatorio" />
                </td>
            </tr>
        </table>
            </td>
        </tr>
    </table>
    <p align="left">
        &nbsp;</p>
    <p align="left">
        &nbsp;</p>
    <p align="left">
        <br />
    </p>
    <br />
</asp:Content>
