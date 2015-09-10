<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmClienteEmpresa.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmClienteEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
          <br />
          <br />
          <br />
     
        <h1>Mantenimiento de Clientes</h1>
        <table  class="table table-striped">
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Nombre Comercial: </td>
                <td style="width: 426px"><asp:TextBox ID="txtNombreComercial" TabIndex="1" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                 <td style="font-weight: bold; color: rgb(119, 119, 119);">Municipio: </td>
                <td><asp:TextBox ID="txtMunicipio" TabIndex="9" CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Nombre Contacto: </td>
                <td style="width: 426px"><asp:TextBox ID="txtNombreContacto" TabIndex="2" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Estado: </td>
                <td><asp:TextBox ID="txtEstado" TabIndex="10"  CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Razón Social: </td>
                <td style="width: 426px"><asp:TextBox ID="txtRazonSocial" TabIndex="3" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Pais: </td>
                <td><asp:TextBox ID="txtPais" TabIndex="11"  CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">RFC: </td>
                <td style="width: 426px"><asp:TextBox ID="txtRFC" TabIndex="4" CssClass="form-control" runat="server"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Código Postal: </td>
                <td><asp:TextBox ID="txtCodigoPostal" TabIndex="12" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Calle: </td>
                <td style="width: 426px"><asp:TextBox ID="txtCalle" TabIndex="5"  CssClass="form-control" runat="server" Width="249px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Correo Eletrónico: </td>
                <td><asp:TextBox ID="txtCorreoEletronico" TabIndex="13" CssClass="form-control" runat="server" Width="301px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">No. Exterior: </td>
                <td style="width: 426px"><asp:TextBox ID="txtNoExterior" TabIndex="6"  CssClass="form-control" runat="server"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Teléfono de Contacto: </td>
                <td><asp:TextBox ID="txtTelefonoContacto" TabIndex="14"  CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Colonia: </td>
                <td style="width: 426px"><asp:TextBox ID="txtColonia" TabIndex="7" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Celular Contacto: </td>
                <td><asp:TextBox ID="txtCelularContacto" TabIndex="15"  CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Localidad: </td>
                <td style="width: 426px"><asp:TextBox ID="txtLocalidad"  TabIndex="8" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                <td style="font-weight: bold; color: rgb(119, 119, 119);">Tipo de Persona: </td>
                <td>
                    <asp:DropDownList ID="DDLTipoPersona" TabIndex="16" CssClass="form-control" runat="server" Height="50px" Width="254px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Empresa: </td>
                <td style="width: 426px">
                    <asp:DropDownList ID="DDLEmpresa" TabIndex="17"  CssClass="form-control" runat="server" Height="50px" Width="254px"></asp:DropDownList>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="BtGuardar" ImageUrl="~/Img/Guardar.png"  runat="server" OnClick="BtGuardar_Click" />
                </td>
                <td style="width: 426px">
                    <asp:ImageButton ID="BtCancelar" ImageUrl="~/Img/Cancelar.png" runat="server" OnClick="BtCancelar_Click" />
                </td>
            </tr>
        </table> 
                   
        <h1 > 
            <asp:Label ID="LError" runat="server" Text="..."  ></asp:Label> 
        </h1>             
   
    <br />
    <br />
    </asp:Content>
