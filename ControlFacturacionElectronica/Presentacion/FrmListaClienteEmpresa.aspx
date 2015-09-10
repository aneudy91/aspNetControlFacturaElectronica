﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmListaClienteEmpresa.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmListaClienteEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1> Catálogo de Clientes</h1>
   <br />
    <asp:Button ID="BtNuevo" class="btn btn-default" runat="server" Text="Agregar Nuevo Cliente" OnClick="BtNuevo_Click" />
    <br />
    <br />
     <asp:GridView ID="GvDatosClienteEmpresa" runat="server" AutoGenerateColumns="False" DataKeyNames="IDClienteEmpresa"
         CssClass="table table-hover table-striped" GridLines="None"
        AutoGenerateEditButton="True" Width="697px" OnRowEditing="GvDatosClienteEmpresa_RowEditing" AutoGenerateDeleteButton="True" OnRowDeleting="GvDatosClienteEmpresa_RowDeleting">
        <Columns>
            <asp:BoundField DataField="IDClienteEmpresa" HeaderText="ID" />
            <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
            <asp:BoundField DataField="NombreComercial" HeaderText="Nombre Comercial" />
            <asp:BoundField DataField="NombreContacto" HeaderText="Nombre de Contacto" />
            <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
            <asp:BoundField DataField="RFC" HeaderText="RFC" />
        </Columns>
    </asp:GridView>
    
    </asp:Content>
