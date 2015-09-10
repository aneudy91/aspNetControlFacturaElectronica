<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRepFacturasPorFecha.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmRepFacturasPorFecha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" />
<script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>  
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
                <br />
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
              <%--  <asp:Calendar ID="CalendarDesde" class="btn btn-default" runat="server" OnSelectionChanged="CalendarDesde_SelectionChanged"></asp:Calendar>--%>
            </td>
             <td>
                 <br />
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
                 <br />
                Ejercicio:<br />
                <asp:TextBox ID="edEjercico" runat="server" Width="77px" class="btn btn-default"></asp:TextBox>
            </td>
        </tr>
    </table>
    

     <asp:Button ID="BtBuscar" class="btn btn-default" runat="server" Text="Buscar" OnClick="BtBuscar_Click" Width="183px" BorderWidth="5px" />
    <br /><%--  table table-striped--%>
    <h3>Lista de Facturas</h3>
    <asp:GridView ID="GridViewFacturas"  class="table table-striped" DataKeyNames="IDFactura"  runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewFacturas_SelectedIndexChanged" OnPageIndexChanging="GridViewFacturas_PageIndexChanging" Font-Size="Small">
        <Columns>
            <asp:TemplateField HeaderText="Descargar Archivos">
                 <ItemTemplate>
                        <asp:ImageButton id="imgSeleccionar" runat="server" CommandName="Select"  ImageUrl="~/img/Descargar.jpg">
                            
                        </asp:ImageButton>
                    </ItemTemplate>

                    <HeaderStyle Width="20px" />

                   <ItemStyle HorizontalAlign="Center"></ItemStyle>

            </asp:TemplateField>
            <asp:BoundField DataField="XML" HeaderText="XML" />
            <asp:BoundField DataField="PDF" HeaderText="PDF" />
            <asp:BoundField DataField="VALIDACION" HeaderText="VALIDACION" />
            <asp:BoundField DataField="TIPO_FACTURA" HeaderText="TIPO_FACTURA" />
            <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
            <asp:BoundField DataField="EMISOR_RFC" HeaderText="EMISOR_RFC" />
            <asp:BoundField DataField="EMISOR_NOMBRE" HeaderText="EMISOR_NOMBRE" />
            <asp:BoundField DataField="SUB_TOTAL" HeaderText="SUB_TOTAL" />
            <asp:BoundField DataField="IVA" HeaderText="IVA" />
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
        </Columns>
    </asp:GridView>
</asp:Content>



