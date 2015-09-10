<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmConfirmDeleteClienteEmpresa.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmConfirmDeleteClienteEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Eliminar Cliente empresa.
    </h1>
    <br />
    <h2>
        ¿Confirma eliminar este Cliente Empresa?
    </h2>
  
        <h3>Razón Social:</h3><asp:Label ID="LRazonSocial" runat="server" Text="..."></asp:Label> <br />
        <h3>RFC: </h3><asp:Label ID="LRfc" runat="server" Text="...."></asp:Label>     <br />
        <h3>Nombre Comercial: </h3><asp:Label ID="LNombreComercial" runat="server" Text="..."></asp:Label> <br />   
        <h3>Nombre de Contacto: </h3><asp:Label ID="LContacto" runat="server" Text="..."></asp:Label><br />
      
    <asp:Button ID="BtEliminar" runat="server" Text="Eliminar" OnClick="BtEliminar_Click" />
</asp:Content>
