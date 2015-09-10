using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace ControlFacturacionElectronica.Comun
{
    class mEmpresa
    {
        string connString;
        public int idEmpresa { set; get; }
        public string NombreComercial { set; get; }
        public string RazonSocial { set; get; }
        public string RFC { set; get; }
        public string DomicilioFiscal_calle { set; get; }
        public string DomicilioFiscal_noExterior { set; get; }
        public string DomicilioFiscal_colonia { set; get; }
        public string DomicilioFiscal_localidad { set; get; }
        public string DomicilioFiscal_municipio { set; get; }
        public string DomicilioFiscal_estado { set; get; }
        public string DomicilioFiscal_pais { set; get; }
        public string DomicilioFiscal_codigoPostal { set; get; }

        public mEmpresa(string connString) 
        {
            this.connString = connString;

        }

        public mEmpresa(string connString,int idEmpresa)
        {
            this.connString = connString;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idEmpresa", idEmpresa);
            DataTable dt = SqlHelper.ExecuteDataset(this.connString, CommandType.StoredProcedure, "spBuscarEmpresa", param).Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.idEmpresa = Convert.ToInt32(dt.Rows[0]["idEmpresa"].ToString());
                this.NombreComercial = dt.Rows[0]["NombreComercial"].ToString();
                this.RazonSocial = dt.Rows[0]["RazonSocial"].ToString();
                this.RFC = dt.Rows[0]["RFC"].ToString();
                this.DomicilioFiscal_calle = dt.Rows[0]["DomicilioFiscal_calle"].ToString();
                this.DomicilioFiscal_noExterior = dt.Rows[0]["DomicilioFiscal_noExterior"].ToString();
                this.DomicilioFiscal_colonia = dt.Rows[0]["DomicilioFiscal_colonia"].ToString();
                this.DomicilioFiscal_localidad = dt.Rows[0]["DomicilioFiscal_localidad"].ToString();
                this.DomicilioFiscal_municipio = dt.Rows[0]["DomicilioFiscal_municipio"].ToString();
                this.DomicilioFiscal_estado = dt.Rows[0]["DomicilioFiscal_estado"].ToString();
                this.DomicilioFiscal_pais = dt.Rows[0]["DomicilioFiscal_pais"].ToString();
                this.DomicilioFiscal_codigoPostal = dt.Rows[0]["DomicilioFiscal_codigoPostal"].ToString();
            }
        }

     
        public int insertEmpresa() 
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@NombreComercial", this.NombreComercial);
                param[1] = new SqlParameter("@RazonSocial", this.RazonSocial);
                param[2] = new SqlParameter("@RFC", this.RFC);
                param[3] = new SqlParameter("@DomicilioFiscal_calle", this.DomicilioFiscal_calle);
                param[4] = new SqlParameter("@DomicilioFiscal_noExterior", this.DomicilioFiscal_noExterior);
                param[5] = new SqlParameter("@DomicilioFiscal_colonia", this.DomicilioFiscal_colonia);
                param[6] = new SqlParameter("@DomicilioFiscal_localidad", this.DomicilioFiscal_localidad);
                param[7] = new SqlParameter("@DomicilioFiscal_municipio", this.DomicilioFiscal_municipio);
                param[8] = new SqlParameter("@DomicilioFiscal_estado", this.DomicilioFiscal_estado);
                param[9] = new SqlParameter("@DomicilioFiscal_pais", this.DomicilioFiscal_pais);
                param[10] = new SqlParameter("@DomicilioFiscal_codigoPostal", this.DomicilioFiscal_codigoPostal);

                return SqlHelper.ExecuteNonQuery(connString, CommandType.StoredProcedure, "spInsertEmpresa", param);
            }
            catch (Exception e) 
            {
                return 0;
            }
        }

        public DataTable getEmpresabyID(int idEmpresa) 
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idEmpresa", idEmpresa);
            return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "", param).Tables[0];
        }


        public DataTable getEmpresabyRFC(string rfc)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RFC", rfc);
            return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "", param).Tables[0];
        }


        public int updateEmpresa()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@NombreComercial", this.NombreComercial);
                param[1] = new SqlParameter("@RazonSocial", this.RazonSocial);
                param[2] = new SqlParameter("@RFC", this.RFC);
                param[3] = new SqlParameter("@DomicilioFiscal_calle", this.DomicilioFiscal_calle);
                param[4] = new SqlParameter("@DomicilioFiscal_noExterior", this.DomicilioFiscal_noExterior);
                param[5] = new SqlParameter("@DomicilioFiscal_colonia", this.DomicilioFiscal_colonia);
                param[6] = new SqlParameter("@DomicilioFiscal_localidad", this.DomicilioFiscal_localidad);
                param[7] = new SqlParameter("@DomicilioFiscal_municipio", this.DomicilioFiscal_municipio);
                param[8] = new SqlParameter("@DomicilioFiscal_estado", this.DomicilioFiscal_estado);
                param[9] = new SqlParameter("@DomicilioFiscal_pais", this.DomicilioFiscal_pais);
                param[10] = new SqlParameter("@DomicilioFiscal_codigoPostal", this.DomicilioFiscal_codigoPostal);
                param[11] = new SqlParameter("@idEmpresa", this.idEmpresa);


                return SqlHelper.ExecuteNonQuery(connString, CommandType.StoredProcedure, "spUpdateEmpresa", param);
            }
            catch (Exception e)
            {
                return 0;
            }
        }



    }
}
