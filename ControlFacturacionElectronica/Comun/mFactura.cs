using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using System.Xml;

using ControlFacturacionElectronica.ConsultaCFDI;

namespace ControlFacturacionElectronica.Comun
{
    class mFactura
    {
        //dataGridView1.DataSource = GetInversedDataTable(extracXMLtoDatatable(filename), "Nodo_Atributo", null);
        public ConsultaCFDI.ConsultaCFDIServiceClient wsConsulta = new ConsultaCFDI.ConsultaCFDIServiceClient();
        public ConsultaCFDI.Acuse oacuse;

        public string connString { get; set; }
        public string Comprobante_version { get; set; }
        public string Comprobante_folio { get; set; }
        public string Comprobante_fecha { get; set; }
        public string Comprobante_sello { get; set; }
        public string Comprobante_formaDePago { get; set; }
        public string Comprobante_noCertificado { get; set; }
        public string Comprobante_certificado { get; set; }
        public string Comprobante_subTotal { get; set; }
        public string Comprobante_TipoCambio { get; set; }
        public string Comprobante_Moneda { get; set; }
        public string Comprobante_total { get; set; }
        public string Comprobante_tipoDeComprobante { get; set; }
        public string Comprobante_metodoDePago { get; set; }
        public string Comprobante_LugarExpedicion { get; set; }
        public string DomicilioFiscal_calle { get; set; }
        public string DomicilioFiscal_noExterior { get; set; }
        public string DomicilioFiscal_colonia { get; set; }
        public string DomicilioFiscal_localidad { get; set; }
        public string DomicilioFiscal_municipio { get; set; }
        public string DomicilioFiscal_estado { get; set; }
        public string DomicilioFiscal_pais { get; set; }
        public string DomicilioFiscal_codigoPostal { get; set; }
        public string ExpedidoEn_calle { get; set; }
        public string ExpedidoEn_noExterior { get; set; }
        public string ExpedidoEn_colonia { get; set; }
        public string ExpedidoEn_localidad { get; set; }
        public string ExpedidoEn_municipio { get; set; }
        public string ExpedidoEn_estado { get; set; }
        public string ExpedidoEn_pais { get; set; }
        public string ExpedidoEn_codigoPostal { get; set; }
        public string RegimenFiscal_Regimen { get; set; }
        public string Domicilio_calle { get; set; }
        public string Domicilio_noExterior { get; set; }
        public string Domicilio_colonia { get; set; }
        public string Domicilio_localidad { get; set; }
        public string Domicilio_municipio { get; set; }
        public string Domicilio_estado { get; set; }
        public string Domicilio_pais { get; set; }
        public string Domicilio_codigoPostal { get; set; }
        public string Concepto_cantidad { get; set; }
        public string Concepto_unidad { get; set; }
        public string Concepto_noIdentificacion { get; set; }
        public string Concepto_descripcion { get; set; }
        public string Concepto_valorUnitario { get; set; }
        public string Concepto_importe { get; set; }
        public string Traslado_impuesto { get; set; }
        public string Traslado_tasa { get; set; }
        public string Traslado_importe { get; set; }
        public string TimbreFiscalDigital_tfd { get; set; }
        public string TimbreFiscalDigital_xsi { get; set; }
        public string TimbreFiscalDigital_schemaLocation { get; set; }
        public string TimbreFiscalDigital_selloCFD { get; set; }
        public string TimbreFiscalDigital_FechaTimbrado { get; set; }
        public string TimbreFiscalDigital_UUID { get; set; }
        public string TimbreFiscalDigital_noCertificadoSAT { get; set; }
        public string TimbreFiscalDigital_version { get; set; }
        public string TimbreFiscalDigital_selloSAT { get; set; }
        public string Emisor_rfc { get; set; }
        public string Emisor_nombre { get; set; }
        public string Receptor_RFC { get; set; }
        public string Receptor_Nombre { get; set; }
        public int TipoFactura { get; set; }
        public string ArchivoXML { get; set; }
        public string ArchivoPDF { get; set; }


        public mFactura(string conn)
        {
            connString = conn.ToString();

        }

        public bool ValidaCFDI()
        {
            /*
            try
            {
                oacuse = wsConsulta.Consulta("?re=" + Emisor_rfc + "&rr=" + Receptor_RFC + "&tt=" + Comprobante_total + "&id=" + TimbreFiscalDigital_UUID);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (oacuse.CodigoEstatus == "S - Comprobante Obtenido satisfactoriamente." && oacuse.Estado == "Vigente")
            {
                return true;
            }
            else
            {
                return false;
            }
             */

            return true;
        }

        public void importDataTableToObj(DataTable dtExtract)
        {
            if (dtExtract.Columns.Contains("Comprobante_version"))
            {
                Comprobante_version = dtExtract.Rows[0]["Comprobante_version"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_folio"))
            {
                Comprobante_folio = dtExtract.Rows[0]["Comprobante_folio"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_fecha"))
            {
                Comprobante_fecha = dtExtract.Rows[0]["Comprobante_fecha"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_sello"))
            {
                Comprobante_sello = dtExtract.Rows[0]["Comprobante_sello"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_formaDePago"))
            {
                Comprobante_formaDePago = dtExtract.Rows[0]["Comprobante_formaDePago"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_noCertificado"))
            {
                Comprobante_noCertificado = dtExtract.Rows[0]["Comprobante_noCertificado"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_certificado"))
            {
                Comprobante_certificado = dtExtract.Rows[0]["Comprobante_certificado"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_subTotal"))
            {
                Comprobante_subTotal = dtExtract.Rows[0]["Comprobante_subTotal"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_TipoCambio"))
            {
                Comprobante_TipoCambio = dtExtract.Rows[0]["Comprobante_TipoCambio"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_Moneda"))
            {
                Comprobante_Moneda = dtExtract.Rows[0]["Comprobante_Moneda"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_total"))
            {
                Comprobante_total = dtExtract.Rows[0]["Comprobante_total"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_tipoDeComprobante"))
            {
                Comprobante_tipoDeComprobante = dtExtract.Rows[0]["Comprobante_tipoDeComprobante"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_metodoDePago"))
            {
                Comprobante_metodoDePago = dtExtract.Rows[0]["Comprobante_metodoDePago"].ToString();
            }
            if (dtExtract.Columns.Contains("Comprobante_LugarExpedicion"))
            {
                Comprobante_LugarExpedicion = dtExtract.Rows[0]["Comprobante_LugarExpedicion"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_calle"))
            {
                DomicilioFiscal_calle = dtExtract.Rows[0]["DomicilioFiscal_calle"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_noExterior"))
            {
                DomicilioFiscal_noExterior = dtExtract.Rows[0]["DomicilioFiscal_noExterior"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_colonia"))
            {
                DomicilioFiscal_colonia = dtExtract.Rows[0]["DomicilioFiscal_colonia"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_localidad"))
            {
                DomicilioFiscal_localidad = dtExtract.Rows[0]["DomicilioFiscal_localidad"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_municipio"))
            {
                DomicilioFiscal_municipio = dtExtract.Rows[0]["DomicilioFiscal_municipio"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_estado"))
            {
                DomicilioFiscal_estado = dtExtract.Rows[0]["DomicilioFiscal_estado"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_pais"))
            {
                DomicilioFiscal_pais = dtExtract.Rows[0]["DomicilioFiscal_pais"].ToString();
            }
            if (dtExtract.Columns.Contains("DomicilioFiscal_codigoPostal"))
            {
                DomicilioFiscal_codigoPostal = dtExtract.Rows[0]["DomicilioFiscal_codigoPostal"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_calle"))
            {
                ExpedidoEn_calle = dtExtract.Rows[0]["ExpedidoEn_calle"].ToString();
            }

            if (dtExtract.Columns.Contains("ExpedidoEn_noExterior"))
            {
                ExpedidoEn_noExterior = dtExtract.Rows[0]["ExpedidoEn_noExterior"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_colonia"))
            {
                ExpedidoEn_colonia = dtExtract.Rows[0]["ExpedidoEn_colonia"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_localidad"))
            {
                ExpedidoEn_localidad = dtExtract.Rows[0]["ExpedidoEn_localidad"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_municipio"))
            {
                ExpedidoEn_municipio = dtExtract.Rows[0]["ExpedidoEn_municipio"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_estado"))
            {
                ExpedidoEn_estado = dtExtract.Rows[0]["ExpedidoEn_estado"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_pais"))
            {
                ExpedidoEn_pais = dtExtract.Rows[0]["ExpedidoEn_pais"].ToString();
            }
            if (dtExtract.Columns.Contains("ExpedidoEn_codigoPostal"))
            {
                ExpedidoEn_codigoPostal = dtExtract.Rows[0]["ExpedidoEn_codigoPostal"].ToString();
            }
            if (dtExtract.Columns.Contains("RegimenFiscal_Regimen"))
            {
                RegimenFiscal_Regimen = dtExtract.Rows[0]["RegimenFiscal_Regimen"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_calle"))
            {
                Domicilio_calle = dtExtract.Rows[0]["Domicilio_calle"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_noExterior"))
            {
                Domicilio_noExterior = dtExtract.Rows[0]["Domicilio_noExterior"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_colonia"))
            {
                Domicilio_colonia = dtExtract.Rows[0]["Domicilio_colonia"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_localidad"))
            {
                Domicilio_localidad = dtExtract.Rows[0]["Domicilio_localidad"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_municipio"))
            {
                Domicilio_municipio = dtExtract.Rows[0]["Domicilio_municipio"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_estado"))
            {
                Domicilio_estado = dtExtract.Rows[0]["Domicilio_estado"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_pais"))
            {
                Domicilio_pais = dtExtract.Rows[0]["Domicilio_pais"].ToString();
            }
            if (dtExtract.Columns.Contains("Domicilio_codigoPostal"))
            {
                Domicilio_codigoPostal = dtExtract.Rows[0]["Domicilio_codigoPostal"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_cantidad"))
            {
                Concepto_cantidad = dtExtract.Rows[0]["Concepto_cantidad"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_unidad"))
            {
                Concepto_unidad = dtExtract.Rows[0]["Concepto_unidad"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_noIdentificacion"))
            {
                Concepto_noIdentificacion = dtExtract.Rows[0]["Concepto_noIdentificacion"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_descripcion"))
            {
                Concepto_descripcion = dtExtract.Rows[0]["Concepto_descripcion"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_valorUnitario"))
            {
                Concepto_valorUnitario = dtExtract.Rows[0]["Concepto_valorUnitario"].ToString();
            }
            if (dtExtract.Columns.Contains("Concepto_importe"))
            {
                Concepto_importe = dtExtract.Rows[0]["Concepto_importe"].ToString();
            }
            if (dtExtract.Columns.Contains("Traslado_impuesto"))
            {
                Traslado_impuesto = dtExtract.Rows[0]["Traslado_impuesto"].ToString();
            }
            if (dtExtract.Columns.Contains("Traslado_tasa"))
            {
                Traslado_tasa = dtExtract.Rows[0]["Traslado_tasa"].ToString();
            }
            if (dtExtract.Columns.Contains("Traslado_importe"))
            {
                Traslado_importe = dtExtract.Rows[0]["Traslado_importe"].ToString();
            }
           
              //  TimbreFiscalDigital_tfd = dtExtract.Rows[0][52].ToString();
          
              //  TimbreFiscalDigital_xsi = dtExtract.Rows[0][53].ToString();
          
              //  TimbreFiscalDigital_schemaLocation = dtExtract.Rows[0][54].ToString();

            if (dtExtract.Columns.Contains("TimbreFiscalDigital_selloCFD"))
            {
                TimbreFiscalDigital_selloCFD = dtExtract.Rows[0]["TimbreFiscalDigital_selloCFD"].ToString();
            }
            if (dtExtract.Columns.Contains("TimbreFiscalDigital_FechaTimbrado"))
            {
                TimbreFiscalDigital_FechaTimbrado = dtExtract.Rows[0]["TimbreFiscalDigital_FechaTimbrado"].ToString();
            }
                if (dtExtract.Columns.Contains("TimbreFiscalDigital_UUID"))
            {
                TimbreFiscalDigital_UUID = dtExtract.Rows[0]["TimbreFiscalDigital_UUID"].ToString();
            }
                if (dtExtract.Columns.Contains("TimbreFiscalDigital_noCertificadoSAT"))
                {
                    TimbreFiscalDigital_noCertificadoSAT = dtExtract.Rows[0]["TimbreFiscalDigital_noCertificadoSAT"].ToString();
                }
                if (dtExtract.Columns.Contains("TimbreFiscalDigital_version"))
                {
                    TimbreFiscalDigital_version = dtExtract.Rows[0]["TimbreFiscalDigital_version"].ToString();
                }
                if (dtExtract.Columns.Contains("TimbreFiscalDigital_selloSAT"))
                {
                    TimbreFiscalDigital_selloSAT = dtExtract.Rows[0]["TimbreFiscalDigital_selloSAT"].ToString();
                }
                if (dtExtract.Columns.Contains("Emisor_rfc"))
            {
                Emisor_rfc = dtExtract.Rows[0]["Emisor_rfc"].ToString();
            }
                if (dtExtract.Columns.Contains("Emisor_nombre"))
            {
                Emisor_nombre = dtExtract.Rows[0]["Emisor_nombre"].ToString();
            }
                if (dtExtract.Columns.Contains("Receptor_RFC"))
            {
                Receptor_RFC = dtExtract.Rows[0]["Receptor_RFC"].ToString();
            }
                if (dtExtract.Columns.Contains("Receptor_Nombre"))
            {
                Receptor_Nombre = dtExtract.Rows[0]["Receptor_Nombre"].ToString();
            }

        }


        public int insertFactura(mFactura obj,Int32 IDClienteEmpresa)
        {
            try
            {
                SqlParameter[] arparms = new SqlParameter[65];

                arparms[0] = new SqlParameter("@Comprobante_version", obj.Comprobante_version);
                arparms[1] = new SqlParameter("@Comprobante_folio", obj.Comprobante_folio);
                arparms[2] = new SqlParameter("@Comprobante_fecha", obj.Comprobante_fecha);
                arparms[3] = new SqlParameter("@Comprobante_sello", obj.Comprobante_sello);
                arparms[4] = new SqlParameter("@Comprobante_formaDePago", obj.Comprobante_formaDePago);
                arparms[5] = new SqlParameter("@Comprobante_noCertificado", obj.Comprobante_noCertificado);
                arparms[6] = new SqlParameter("@Comprobante_certificado", obj.Comprobante_certificado);
                arparms[7] = new SqlParameter("@Comprobante_subTotal", obj.Comprobante_subTotal);
                arparms[8] = new SqlParameter("@Comprobante_TipoCambio", obj.Comprobante_TipoCambio);
                arparms[9] = new SqlParameter("@Comprobante_Moneda", obj.Comprobante_Moneda);
                arparms[10] = new SqlParameter("@Comprobante_total", obj.Comprobante_total);
                arparms[11] = new SqlParameter("@Comprobante_tipoDeComprobante", obj.Comprobante_tipoDeComprobante);
                arparms[12] = new SqlParameter("@Comprobante_metodoDePago", obj.Comprobante_metodoDePago);
                arparms[13] = new SqlParameter("@Comprobante_LugarExpedicion", obj.Comprobante_LugarExpedicion);
                arparms[14] = new SqlParameter("@DomicilioFiscal_calle", obj.DomicilioFiscal_calle);
                arparms[15] = new SqlParameter("@DomicilioFiscal_noExterior", obj.DomicilioFiscal_noExterior);
                arparms[16] = new SqlParameter("@DomicilioFiscal_colonia", obj.DomicilioFiscal_colonia);
                arparms[17] = new SqlParameter("@DomicilioFiscal_localidad", obj.DomicilioFiscal_localidad);
                arparms[18] = new SqlParameter("@DomicilioFiscal_municipio", obj.DomicilioFiscal_municipio);
                arparms[19] = new SqlParameter("@DomicilioFiscal_estado", obj.DomicilioFiscal_estado);
                arparms[20] = new SqlParameter("@DomicilioFiscal_pais", obj.DomicilioFiscal_pais);
                arparms[21] = new SqlParameter("@DomicilioFiscal_codigoPostal", obj.DomicilioFiscal_codigoPostal);
                arparms[22] = new SqlParameter("@ExpedidoEn_calle", obj.ExpedidoEn_calle);
                arparms[23] = new SqlParameter("@ExpedidoEn_noExterior", obj.ExpedidoEn_noExterior);
                arparms[24] = new SqlParameter("@ExpedidoEn_colonia", obj.ExpedidoEn_colonia);
                arparms[25] = new SqlParameter("@ExpedidoEn_localidad", obj.ExpedidoEn_localidad);
                arparms[26] = new SqlParameter("@ExpedidoEn_municipio", obj.ExpedidoEn_municipio);
                arparms[27] = new SqlParameter("@ExpedidoEn_estado", obj.ExpedidoEn_estado);
                arparms[28] = new SqlParameter("@ExpedidoEn_pais", obj.ExpedidoEn_pais);
                arparms[29] = new SqlParameter("@ExpedidoEn_codigoPostal", obj.ExpedidoEn_codigoPostal);
                arparms[30] = new SqlParameter("@RegimenFiscal_Regimen", obj.RegimenFiscal_Regimen);
                arparms[31] = new SqlParameter("@Domicilio_calle", obj.Domicilio_calle);
                arparms[32] = new SqlParameter("@Domicilio_noExterior", obj.Domicilio_noExterior);
                arparms[33] = new SqlParameter("@Domicilio_colonia", obj.Domicilio_colonia);
                arparms[34] = new SqlParameter("@Domicilio_localidad", obj.Domicilio_localidad);
                arparms[35] = new SqlParameter("@Domicilio_municipio", obj.Domicilio_municipio);
                arparms[36] = new SqlParameter("@Domicilio_estado", obj.Domicilio_estado);
                arparms[37] = new SqlParameter("@Domicilio_pais", obj.Domicilio_pais);
                arparms[38] = new SqlParameter("@Domicilio_codigoPostal", obj.Domicilio_codigoPostal);
                arparms[39] = new SqlParameter("@Concepto_cantidad", obj.Concepto_cantidad);
                arparms[40] = new SqlParameter("@Concepto_unidad", obj.Concepto_unidad);
                arparms[41] = new SqlParameter("@Concepto_noIdentificacion", obj.Concepto_noIdentificacion);
                arparms[42] = new SqlParameter("@Concepto_descripcion", obj.Concepto_descripcion);
                arparms[43] = new SqlParameter("@Concepto_valorUnitario", obj.Concepto_valorUnitario);
                arparms[44] = new SqlParameter("@Concepto_importe", obj.Concepto_importe);
                arparms[45] = new SqlParameter("@Traslado_impuesto", obj.Traslado_impuesto);
                arparms[46] = new SqlParameter("@Traslado_tasa", obj.Traslado_tasa);
                arparms[47] = new SqlParameter("@Traslado_importe", obj.Traslado_importe);
                arparms[48] = new SqlParameter("@TimbreFiscalDigital_tfd", obj.TimbreFiscalDigital_tfd);
                arparms[49] = new SqlParameter("@TimbreFiscalDigital_xsi", obj.TimbreFiscalDigital_xsi);
                arparms[50] = new SqlParameter("@TimbreFiscalDigital_schemaLocation", obj.TimbreFiscalDigital_schemaLocation);
                arparms[51] = new SqlParameter("@TimbreFiscalDigital_selloCFD", obj.TimbreFiscalDigital_selloCFD);
                arparms[52] = new SqlParameter("@TimbreFiscalDigital_FechaTimbrado", obj.TimbreFiscalDigital_FechaTimbrado);
                arparms[53] = new SqlParameter("@TimbreFiscalDigital_UUID", obj.TimbreFiscalDigital_UUID);
                arparms[54] = new SqlParameter("@TimbreFiscalDigital_noCertificadoSAT", obj.TimbreFiscalDigital_noCertificadoSAT);
                arparms[55] = new SqlParameter("@TimbreFiscalDigital_version", obj.TimbreFiscalDigital_version);
                arparms[56] = new SqlParameter("@TimbreFiscalDigital_selloSAT", obj.TimbreFiscalDigital_selloSAT);
                arparms[57] = new SqlParameter("@Emisor_rfc", obj.Emisor_rfc);
                arparms[58] = new SqlParameter("@Emisor_nombre", obj.Emisor_nombre);
                arparms[59] = new SqlParameter("@Receptor_RFC", obj.Receptor_RFC);
                arparms[60] = new SqlParameter("@Receptor_Nombre", obj.Receptor_Nombre);
                arparms[61] = new SqlParameter("@IDClienteEmpresa", IDClienteEmpresa);
                arparms[62] = new SqlParameter("@TipoFactura", obj.TipoFactura);
                arparms[63] = new SqlParameter("@ArchivoXML", obj.ArchivoXML);
                arparms[64] = new SqlParameter("@ArchivoPDF", obj.ArchivoPDF);
                return SqlHelper.ExecuteNonQuery(obj.connString, CommandType.StoredProcedure, "spInsertarFactura", arparms);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public DataTable extracXMLtoDatatable(string filename, string text)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nodo_Atributo", typeof(string));
            table.Columns.Add("Value", typeof(string));


            string data = "";
                //data = File.ReadAllText(filename);
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filename))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
             data = sb.ToString();
                   
            
            data = data.ToString().Replace("{http://www.w3.org/2000/xmls/}", "");
                

            data = RemoveAllNamespaces(data);


            DataTable dt = new DataTable();
            XElement elem = XElement.Parse(data);


            XDocument xdoc = XDocument.Load(filename);


            var version = xdoc.Root.Attribute("version").Value.ToString();
            var folio = xdoc.Root.Attribute("folio").Value.ToString();
            var fecha = xdoc.Root.Attribute("fecha").Value.ToString();
            var sello = xdoc.Root.Attribute("sello").Value.ToString();
            var formaDePago = xdoc.Root.Attribute("formaDePago").Value.ToString();
            var noCertificado = xdoc.Root.Attribute("noCertificado").Value.ToString();
            var certificado = xdoc.Root.Attribute("certificado").Value.ToString();
            //var condicionesDePago = xdoc.Root.Attribute("condicionesDePago").Value.ToString();
            var subTotal = xdoc.Root.Attribute("subTotal").Value.ToString();
            var TipoCambio = string.Empty;
            try
            {
                if (xdoc.Root.Attribute("TipoCambio").Value != null)
                {
                    TipoCambio = (xdoc.Root.Attribute("TipoCambio").Value).ToString();
                }
                else
                {
                    TipoCambio = "1";
                }
            }
            catch 
            {
                TipoCambio = "1"; 
            }
            var Moneda = string.Empty;
            try
            {
                if (xdoc.Root.Attribute("Moneda").Value != null)
                {
                    Moneda = (xdoc.Root.Attribute("Moneda").Value).ToString();
                }
                else
                {
                    Moneda = "MXN";
                }
            }
            catch 
            {
                Moneda = "MXN";
            }
            var total = xdoc.Root.Attribute("total").Value.ToString();
            var tipoDeComprobante = xdoc.Root.Attribute("tipoDeComprobante").Value.ToString();
            var metodoDePago = xdoc.Root.Attribute("metodoDePago").Value.ToString();
            var LugarExpedicion = xdoc.Root.Attribute("LugarExpedicion").Value.ToString();

            //var NumCtaPago = xdoc.Root.Attribute("NumCtaPago").Value.ToString();



            table.Rows.Add("Comprobante_version", version);
            table.Rows.Add("Comprobante_folio", folio);
            table.Rows.Add("Comprobante_fecha", fecha);
            table.Rows.Add("Comprobante_sello", sello);
            table.Rows.Add("Comprobante_formaDePago", formaDePago);
            table.Rows.Add("Comprobante_noCertificado", noCertificado);
            table.Rows.Add("Comprobante_certificado", certificado);
            //table.Rows.Add("Comprobante", "condicionesDePago", condicionesDePago);
            table.Rows.Add("Comprobante_subTotal", subTotal);
            table.Rows.Add("Comprobante_TipoCambio", TipoCambio);
            table.Rows.Add("Comprobante_Moneda", Moneda);
            table.Rows.Add("Comprobante_total", total);
            table.Rows.Add("Comprobante_tipoDeComprobante", tipoDeComprobante);
            table.Rows.Add("Comprobante_metodoDePago", metodoDePago);
            table.Rows.Add("Comprobante_LugarExpedicion", LugarExpedicion);
            //table.Rows.Add("Comprobante", "NumCtaPago", NumCtaPago);



            XDocument doc = XDocument.Load(filename);

            XNamespace xmlns = "http://www.sat.gob.mx/cfd/3";

            var Emisor = doc.Root
                 .Elements()
                 .First(node => node.Name.LocalName == "Emisor");


            foreach (var emi in Emisor.Attributes())
            {
                table.Rows.Add("Emisor" + "_" + emi.Name.ToString(), emi.Value.ToString());
            }


            var Receptor = doc.Root
                 .Elements()
                 .First(node => node.Name.LocalName == "Receptor");

            foreach (var rec in Receptor.Attributes())
            {
                table.Rows.Add("Receptor" + "_" + rec.Name.ToString(), rec.Value.ToString());
            }


            XElement xmlTree = XElement.Parse(data);

            IEnumerable<XElement> awElements =
                from el in xmlTree.Descendants()
                select el;

            foreach (XElement el in awElements)
            {
                foreach (var attribute in el.Attributes())
                {
                    table.Rows.Add(el.Name + "_" + attribute.Name.ToString(), attribute.Value.ToString());
                }

                if (el.HasElements)
                {
                    foreach (var elm in el.Elements())
                    {
                        foreach (XAttribute pa in elm.Attributes())
                        {
                            table.Rows.Add(elm.Name + "_" + pa.Name.ToString(), pa.Value.ToString());
                        }
                    }
                }
            }

            xdoc.Save(filename);
            DataTable distinctTable = table.DefaultView.ToTable( /*distinct*/ true);
            return distinctTable;
        }

        public DataTable getDataReportFacturas(string conn, int IDclienteEmpresa, DateTime FI, DateTime FF, int Tipo)
        {
            SqlParameter[] arParmsName = new SqlParameter[4];
            arParmsName[0] = new SqlParameter("@IDClienteEmpresa", IDclienteEmpresa);
            arParmsName[1] = new SqlParameter("@FI", FI);
            arParmsName[2] = new SqlParameter("@FF", FF);
            arParmsName[3] = new SqlParameter("@Tipo", Tipo);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spBuscarFacturasPorCliente", true, arParmsName).Tables[0];
            return dt;
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        /// <summary>
        /// Gets a Inverted DataTable
        /// </summary>
        /// <param name="table">DataTable do invert</param>
        /// <param name="columnX">X Axis Column</param>
        /// <param name="nullValue">null Value to Complete the Pivot Table</param>
        /// <param name="columnsToIgnore">Columns that should be ignored in the pivot 
        /// process (X Axis column is ignored by default)</param>
        /// <returns>C# Pivot Table Method  - Felipe Sabino</returns>
        public DataTable GetInversedDataTable(DataTable table, string columnX, params string[] columnsToIgnore)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            //Add a Column at the beginning of the table

            returnTable.Columns.Add(columnX);

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            //Creates list of columns to ignore
            //List<string> listColumnsToIgnore = new List<string>();
            //if (columnsToIgnore.Length > 0)
            //    listColumnsToIgnore.AddRange(columnsToIgnore);

            //if (!listColumnsToIgnore.Contains(columnX))
            //    listColumnsToIgnore.Add(columnX);

            foreach (DataRow dr in table.Rows)
            {
                string columnXTemp = dr[columnX].ToString();
                //Verify if the value was already listed
                if (!columnXValues.Contains(columnXTemp))
                {
                    //if the value id different from others provided, add to the list of 
                    //values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
                else
                {
                    ////Throw exception for a repeated value
                    //throw new Exception("The inversion used must have " +
                    //                    "unique values for column " + columnX);
                    //columnXValues.Add(columnXTemp+"2");
                    //returnTable.Columns.Add(columnXTemp+"2");
                }
            }

            //Add a line for each column of the DataTable

            foreach (DataColumn dc in table.Columns)
            {
                if (!columnXValues.Contains(dc.ColumnName))
                {
                    DataRow dr = returnTable.NewRow();
                    dr[0] = dc.ColumnName;
                    returnTable.Rows.Add(dr);
                }
            }

            foreach (DataColumn dc in returnTable.Columns) 
            {
                DataRow[] rowArray = table.Select("Nodo_Atributo ='"+dc.ColumnName.ToString()+"'");
                if (rowArray.Length <= 0) { }
                else
                {
                    returnTable.Rows[1][dc.ColumnName] = rowArray[0]["Value"].ToString();
                }
            }




           // Complete the datatable with the values
            //for (int i = 0; i < returnTable.Rows.Count; i++)
            //{
            //    for (int j = 1; j < returnTable.Columns.Count; j++)
            //    {
            //        returnTable.Rows[i][j] =
            //          table.Rows[j - 1][returnTable.Rows[i][0].ToString()].ToString();
            //    }
            //}

            returnTable.Rows[0].Delete();
            returnTable.Columns.Remove("Nodo_Atributo");



            string colum = "";
            foreach (var col in returnTable.Columns)
            {
                colum = col.ToString() + ",";
            }

            foreach (DataColumn dc in returnTable.Columns) 
            {
                if(dc.ColumnName.ToString().Contains("{http://www.w3.org/2000/xmls/}"))
               {
                   dc.ColumnName = dc.ColumnName.ToString().Replace("{http://www.w3.org/2000/xmls/}", "");
                }
            }

            return returnTable;
        }

    }
}