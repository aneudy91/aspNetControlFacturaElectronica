<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRepFacturas.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmRepFacturas" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1>Reporte de Facturas por Fecha</h1>
    <br />    
    
    <table>
        <tr>
            <td>
                <h5>Selecione un Cliente:</h5>
            </td>
            <td>
                <asp:DropDownList ID="DDLClientes" class="btn btn-default" runat="server" Height="50px" Width="326px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Desde:<br />
                <asp:DropDownList ID="cbMesInicio" runat="server" Height="40px" Width="187px" class="btn btn-default">
                    <asp:ListItem Value="01">ENERO</asp:ListItem>
                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                    <asp:ListItem Value="07">JUNIO</asp:ListItem>
                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                    <asp:ListItem Value="07">AGOSTO</asp:ListItem>
                    <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                </asp:DropDownList>
               <%-- <asp:Calendar ID="CalendarDesde" class="btn btn-default" runat="server"></asp:Calendar>--%>
            </td>
             <td>
                 Hasta:<br />
                 <asp:DropDownList ID="cbMesFin" runat="server" Height="40px" Width="187px" class="btn btn-default">
                      <asp:ListItem Value="01">ENERO</asp:ListItem>
                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                    <asp:ListItem Value="07">JUNIO</asp:ListItem>
                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                    <asp:ListItem Value="07">AGOSTO</asp:ListItem>
                    <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                 </asp:DropDownList>
              <%--  <asp:Calendar ID="CalendarHasta" class="btn btn-default"  runat="server"></asp:Calendar>--%>
            </td>
            <td>
                Ejercicio:<br />
                <asp:TextBox ID="edEjercico" runat="server" Width="77px" class="btn btn-default"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RBList" runat="server" Height="98px" Width="195px">
                    <asp:ListItem Selected="True" Value="1">General</asp:ListItem>
                    <asp:ListItem Value="2">Emitidas</asp:ListItem>
                    <asp:ListItem Value="3">Recibidas</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    

     <asp:Button ID="BtBuscar" class="btn btn-default" runat="server" Text="Buscar" OnClick="BtBuscar_Click" Width="201px" />
    <asp:Label ID ="Message" runat="server" />
    <br />
   
    </asp:Content>
