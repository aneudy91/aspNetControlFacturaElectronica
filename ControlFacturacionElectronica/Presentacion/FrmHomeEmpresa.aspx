<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeEmpresa.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmHomeEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <table style="text-align:center">
       <tr>
            <td>
                <asp:Button ID="BtEmpresas" runat="server" class="btn btn-primary btn-lg" Text="Empresas" Height="108px" Width="246px" OnClick="BtEmpresas_Click" />
            </td>
            <td>
                <asp:Button ID="BtClientes" runat="server" class="btn btn-primary btn-lg" Text="Clientes" Height="108px" Width="246px" OnClick="BtClientes_Click" />
            </td>
           <td>
                <asp:Button ID="BtUsuario" runat="server" class="btn btn-primary btn-lg" Text="Usuarios" Height="108px" Width="246px" OnClick="BtUsuario_Click"/>
            </td>
       </tr>
        <tr>
        
            
       </tr>
    </table>

</asp:Content>
