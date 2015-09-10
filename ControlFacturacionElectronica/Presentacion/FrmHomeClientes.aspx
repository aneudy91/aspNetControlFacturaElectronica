<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeClientes.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmHomeClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <table style="text-align:center">
       <tr>
           <td></td>
            <td>
                <asp:Button ID="BtUploadFile" runat="server" class="btn btn-primary btn-lg" Text="Subir Factura" OnClick="BtUploadFile_Click" Height="108px" Width="246px" />
            </td>
      <%--      <td>
                <asp:Button ID="BtConsultas" runat="server" class="btn btn-primary btn-lg" Text="Consultar Facturaa"  Height="108px" Width="246px" OnClick="BtConsultas_Click" />
            </td>--%>
           <td></td>
       </tr>
    </table>
</asp:Content>
