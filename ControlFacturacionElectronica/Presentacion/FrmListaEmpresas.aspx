<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmListaEmpresas.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmListaEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1> Catálogo de Empresas</h1>
   <br />
   <br />

    <asp:Button ID="BtNuevo" class="btn btn-default" runat="server" Text="Agregar Nueva Empresa" OnClick="BtNuevo_Click" />
    <br />
    <br />
     <asp:GridView ID="GvDatosEmpresa" runat="server" AutoGenerateColumns="False" DataKeyNames="IDEmpresa"
        CssClass="table table-hover table-striped"  AutoGenerateEditButton="True" Width="697px" OnRowEditing="GvDatosEmpresa_RowEditing" >
        <Columns>
            <asp:BoundField DataField="IDEmpresa" HeaderText="ID" />
            <asp:BoundField DataField="NombreComercial" HeaderText="Nombre Comercial" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
            <asp:BoundField DataField="RFC" HeaderText="RFC" />
        </Columns>
    </asp:GridView>

</asp:Content>
