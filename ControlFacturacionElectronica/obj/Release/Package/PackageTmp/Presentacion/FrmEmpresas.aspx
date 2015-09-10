<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmEmpresas.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
          <br />
          <br />
          <br />
     
        <h1>Mantenimiento de Empresas</h1>
    <table  class="table table-striped">
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Nombre Comercial: </td>
                <td><asp:TextBox ID="txtNombreComercial" TabIndex="1" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Localidad: </td>
                <td><asp:TextBox ID="txtLocalidad" TabIndex="7" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td> 
            </tr>
            <tr>
                
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Razón Social: </td>
                <td><asp:TextBox ID="txtRazonSocial" TabIndex="2" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                 <td style="font-weight: bold; color: rgb(119, 119, 119);">Colonia: </td>
                <td><asp:TextBox ID="txtColonia" TabIndex="8" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>
            </tr>
            <tr>
                
                <td style="font-weight: bold; color: rgb(119, 119, 119);">RFC: </td>
                <td><asp:TextBox ID="txtRFC" TabIndex="3" CssClass="form-control" runat="server"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Municipio: </td>
                <td><asp:TextBox ID="txtMunicipio" TabIndex="9" CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Estado: </td>
                <td><asp:TextBox ID="txtEstado" TabIndex="4" CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Pais: </td>
                <td><asp:TextBox ID="txtPais" TabIndex="10" CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Calle: </td>
                <td><asp:TextBox ID="txtCalle" TabIndex="5" CssClass="form-control" runat="server" Width="249px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Código Postal: </td>
                <td><asp:TextBox ID="txtCodigoPostal" TabIndex="11" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">No. Exterior: </td>
                <td><asp:TextBox ID="txtNoExterior" TabIndex="6" CssClass="form-control" runat="server"></asp:TextBox></td>

            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="BtGuardar" ImageUrl="~/Img/Guardar.png" runat="server" OnClick="BtGuardar_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="BtCancelar"  ImageUrl="~/Img/Cancelar.png"  runat="server" OnClick="BtCancelar_Click" />
                </td>
            </tr>
        </table> 
        <h1 > 
            <asp:Label ID="LError" runat="server" Text="..."  ></asp:Label> 
        </h1> 
</asp:Content>
