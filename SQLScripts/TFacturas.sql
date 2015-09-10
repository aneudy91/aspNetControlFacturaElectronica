
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblFacturas]') AND type in (N'U'))
    DROP TABLE [dbo].[TblFacturas]
GO
CREATE TABLE TblFacturas(
	 IDFactura int identity(1,1)
	,IDClienteEmpresa int CONSTRAINT fk_TblFacturas_IDClienteEmpresa FOREIGN KEY REFERENCES TblClienteEmpresa(IDClienteEmpresa) on delete cascade 
	,Comprobante_version varchar(100)
	,Comprobante_folio varchar(500)
	,Comprobante_fecha varchar(100)
	,Comprobante_sello nvarchar(max)
	,Comprobante_formaDePago varchar(100)
	,Comprobante_noCertificado nvarchar(max)
	,Comprobante_certificado nvarchar(max)
	,Comprobante_subTotal varchar(100)
	,Comprobante_TipoCambio varchar(100)
	,Comprobante_Moneda varchar(100)
	,Comprobante_total varchar(100)
	,Comprobante_tipoDeComprobante varchar(100) /* Ingreso o Egreso */
	,Comprobante_metodoDePago varchar(100)
	,Comprobante_LugarExpedicion varchar(100)
	,Emisor_Nombre varchar(max)
	,Emisor_RFC varchar(100)
	,DomicilioFiscal_calle varchar(500)  /* Emisor */
	,DomicilioFiscal_noExterior varchar(100)  /* Emisor */
	,DomicilioFiscal_colonia varchar(500) /* Emisor */
	,DomicilioFiscal_localidad varchar(500) /* Emisor */
	,DomicilioFiscal_municipio varchar(500) /* Emisor */
	,DomicilioFiscal_estado varchar(500) /* Emisor */
	,DomicilioFiscal_pais varchar(500) /* Emisor */
	,DomicilioFiscal_codigoPostal varchar(100) /* Emisor */
	,ExpedidoEn_calle varchar(500)
	,ExpedidoEn_noExterior varchar(100)
	,ExpedidoEn_colonia varchar(500)
	,ExpedidoEn_localidad varchar(500)
	,ExpedidoEn_municipio varchar(500)
	,ExpedidoEn_estado varchar(500)
	,ExpedidoEn_pais varchar(500)
	,ExpedidoEn_codigoPostal varchar(100)
	,RegimenFiscal_Regimen varchar(500)
	,Receptor_Nombre varchar(max)
	,Receptor_RFC varchar(100)
	,Domicilio_calle varchar(500) /* Receptor */
	,Domicilio_noExterior varchar(100) /* Receptor */
	,Domicilio_colonia varchar(500) /* Receptor */
	,Domicilio_localidad varchar(500) /* Receptor */
	,Domicilio_municipio varchar(500) /* Receptor */
	,Domicilio_estado varchar(500) /* Receptor */
	,Domicilio_pais varchar(500) /* Receptor */
	,Domicilio_codigoPostal varchar(100) /* Receptor */
	,Concepto_cantidad varchar(100)
	,Concepto_unidad varchar(100)
	,Concepto_noIdentificacion varchar(100)
	,Concepto_descripcion varchar(500)
	,Concepto_valorUnitario varchar(100)
	,Concepto_importe varchar(100)
	,Traslado_impuesto varchar(100)
	,Traslado_tasa varchar(100)
	,Traslado_importe varchar(100)
	,TimbreFiscalDigital_tfd varchar(max)
	,TimbreFiscalDigital_xsi varchar(max)
	,TimbreFiscalDigital_schemaLocation varchar(max)
	,TimbreFiscalDigital_selloCFD nvarchar(max)
	,TimbreFiscalDigital_FechaTimbrado nvarchar(100)
	,TimbreFiscalDigital_UUID nvarchar(max)
	,TimbreFiscalDigital_noCertificadoSAT nvarchar(max)
	,TimbreFiscalDigital_version varchar(100)
	,TimbreFiscalDigital_selloSAT nvarchar(max)
	--,TipoFactura int not null /*1: Ingreso 2: Egreso*/
	,FechaReg Datetime default getdate()
	,Fecha as CONVERT(date,( substring(Comprobante_fecha,1,10)))
	,TipoFactura int /* 0 : Emitida 1: Recibida*/ not null
	,ArchivoXML varchar(255) not null
	,ArchivoPDF varchar(255) 
	,Primary key (Receptor_RFC,Comprobante_folio)
);