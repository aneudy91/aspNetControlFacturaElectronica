using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace ControlFacturacionElectronica.Comun
{
    class mClienteEmpresa
    {
            string connString;
    	    public  int IDClienteEmpresa {get; set;}
            public int IDEmpresa { get; set; }
            public string NombreComercial { get; set; }
            public string NombreContacto { get; set; }
            public string RazonSocial { get; set; }
            public string RFC { get; set; }
	        public string DomicilioFiscal_calle {get; set;}
	        public string DomicilioFiscal_noExterior {get; set;}
	        public string DomicilioFiscal_colonia {get; set;}
	        public string DomicilioFiscal_localidad {get; set;}
	        public string DomicilioFiscal_municipio {get; set;}
	        public string DomicilioFiscal_estado {get; set;}
	        public string DomicilioFiscal_pais {get; set;}
	        public string DomicilioFiscal_codigoPostal {get; set;}
	        public string CorreoEletronico {get; set;}
	        public string ContactoTelefono {get; set;}
	        public string ContactoCelular {get; set;}
             public string TipoPersona { get; set; }
            public int Active { get; set; }

            public mEmpresa objEmpresa;

     

        public mClienteEmpresa(string connString) 
        {
            this.connString = connString;
            this.IDClienteEmpresa = 0;

        }

        public mClienteEmpresa(string connString, int idClienteEmpresa) 
        {
            this.connString = connString;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDClienteEmpresa", idClienteEmpresa);
            DataTable dt = SqlHelper.ExecuteDataset(this.connString, CommandType.StoredProcedure, "spBuscarClienteEmpresa", param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.IDClienteEmpresa = Convert.ToInt32(dt.Rows[0]["IDClienteEmpresa"].ToString());
                this.IDEmpresa = Convert.ToInt32(dt.Rows[0]["IDEmpresa"].ToString());
                this.NombreComercial = dt.Rows[0]["NombreComercial"].ToString();
                this.NombreContacto = dt.Rows[0]["NombreContacto"].ToString();
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
                this.CorreoEletronico = dt.Rows[0]["CorreoEletronico"].ToString();
                this.ContactoTelefono = dt.Rows[0]["ContactoTelefono"].ToString();
                this.ContactoCelular = dt.Rows[0]["ContactoCelular"].ToString();
                this.TipoPersona = dt.Rows[0]["TipoPersona"].ToString();
                this.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
                this.objEmpresa = new mEmpresa(connString, idClienteEmpresa);
            }
        }


        public int insertClienteEmpresa() 
        {
            try
            {
                SqlParameter[] param = new SqlParameter[17];
                param[0] = new SqlParameter("@NombreComercial", this.NombreComercial);
                param[1] = new SqlParameter("@NombreContacto", this.NombreContacto);
                param[2] = new SqlParameter("@RazonSocial", this.RazonSocial);
                param[3] = new SqlParameter("@RFC", this.RFC);
                param[4] = new SqlParameter("@DomicilioFiscal_calle", this.DomicilioFiscal_calle);
                param[5] = new SqlParameter("@DomicilioFiscal_noExterior", this.DomicilioFiscal_noExterior);
                param[6] = new SqlParameter("@DomicilioFiscal_colonia", this.DomicilioFiscal_colonia);
                param[7] = new SqlParameter("@DomicilioFiscal_localidad", this.DomicilioFiscal_localidad);
                param[8] = new SqlParameter("@DomicilioFiscal_municipio", this.DomicilioFiscal_municipio);
                param[9] = new SqlParameter("@DomicilioFiscal_estado", this.DomicilioFiscal_estado);
                param[10] = new SqlParameter("@DomicilioFiscal_pais", this.DomicilioFiscal_pais);
                param[11] = new SqlParameter("@DomicilioFiscal_codigoPostal", this.DomicilioFiscal_codigoPostal);
                param[12] = new SqlParameter("@CorreoEletronico", this.CorreoEletronico);
                param[13] = new SqlParameter("@ContactoTelefono", this.ContactoTelefono);
                param[14] = new SqlParameter("@ContactoCelular", this.ContactoCelular);
                param[15] = new SqlParameter("@TipoPersona", this.TipoPersona);
                param[16] = new SqlParameter("@IDEmpresa", this.IDEmpresa);

                return SqlHelper.ExecuteNonQuery(connString, CommandType.StoredProcedure, "spInsertClienteEmpresa", param);
            }
            catch (Exception e) 
            {
                return 0;
            }
        }

        public DataTable getClienteEmpresabyID(int id) 
        {
            try
            {      
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IDClienteEmpresa", id);
                return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "spBuscarClienteEmpresa", param).Tables[0];
            }
            catch (Exception e) 
            {
                throw e;
            }
        }


        public DataTable getClienteEmpresabyID(string rfc)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RFC", rfc);
                return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "spBuscarClienteEmpresa_ByRFC", param).Tables[0];
            }
            catch (Exception e) 
            {
                throw e;
            }
        }


        public int updateClienteEmpresa()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@NombreComercial", this.NombreComercial);
                param[1] = new SqlParameter("@NombreContacto", this.NombreContacto);
                param[2] = new SqlParameter("@RazonSocial", this.RazonSocial);
                param[3] = new SqlParameter("@RFC", this.RFC);
                param[4] = new SqlParameter("@DomicilioFiscal_calle", this.DomicilioFiscal_calle);
                param[5] = new SqlParameter("@DomicilioFiscal_noExterior", this.DomicilioFiscal_noExterior);
                param[6] = new SqlParameter("@DomicilioFiscal_colonia", this.DomicilioFiscal_colonia);
                param[7] = new SqlParameter("@DomicilioFiscal_localidad", this.DomicilioFiscal_localidad);
                param[8] = new SqlParameter("@DomicilioFiscal_municipio", this.DomicilioFiscal_municipio);
                param[9] = new SqlParameter("@DomicilioFiscal_estado", this.DomicilioFiscal_estado);
                param[10] = new SqlParameter("@DomicilioFiscal_pais", this.DomicilioFiscal_pais);
                param[11] = new SqlParameter("@DomicilioFiscal_codigoPostal", this.DomicilioFiscal_codigoPostal);
                param[12] = new SqlParameter("@CorreoEletronico", this.CorreoEletronico);
                param[13] = new SqlParameter("@ContactoTelefono", this.ContactoTelefono);
                param[14] = new SqlParameter("@ContactoCelular", this.ContactoCelular);
                param[15] = new SqlParameter("@TipoPersona", this.TipoPersona);
                param[16] = new SqlParameter("@IDClienteEmpresa", this.IDClienteEmpresa);
                param[17] = new SqlParameter("@IDEmpresa", this.IDEmpresa);

                return SqlHelper.ExecuteNonQuery(connString, CommandType.StoredProcedure, "spUpdateClienteEmpresa", param);
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public bool UpdateClienteEmpresa_ActiveStatus()
        {
            int result;
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@IDClienteEmpresa", this.IDEmpresa);
                param[1] = new SqlParameter("@Active", this.Active);

                result = SqlHelper.ExecuteNonQuery(this.connString, CommandType.StoredProcedure, "spUpdateClienteEmpresa_ActiveStatus", param);
            }
            catch (Exception e)
            {
                throw e;
            }

            return Convert.ToBoolean(result);

        }

        public bool DeleteClienteEmpresa()
        {
                int result;
                try
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IDClienteEmpresa", this.IDEmpresa);


                    result = SqlHelper.ExecuteNonQuery(this.connString, CommandType.StoredProcedure, "spDeleteClienteEmpresa", param);
                }
                catch (Exception e)
                {
                    throw e;
                }

                return Convert.ToBoolean(result);  
        }

    }
}
