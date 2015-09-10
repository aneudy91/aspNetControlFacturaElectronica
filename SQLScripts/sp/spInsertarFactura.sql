-- =============================================      
-- Author:  Ing. Jose Roman     
-- Create date: 05/02/2015      
-- Description: Inserta datos de facturas con cliente empresa    
-- =============================================      
ALTER PROCEDURE spInsertarFactura      
 (@IDClienteEmpresa int       
 ,@Comprobante_version varchar(100)      
 ,@Comprobante_folio varchar(500)      
 ,@Comprobante_fecha varchar(100)      
 ,@Comprobante_sello nvarchar(max)      
 ,@Comprobante_formaDePago varchar(100)      
 ,@Comprobante_noCertificado nvarchar(max)      
 ,@Comprobante_certificado nvarchar(max)      
 ,@Comprobante_subTotal varchar(100)      
 ,@Comprobante_TipoCambio varchar(100)      
 ,@Comprobante_Moneda varchar(100)      
 ,@Comprobante_total varchar(100)      
 ,@Comprobante_tipoDeComprobante varchar(100) /* Ingreso o Egreso */      
 ,@Comprobante_metodoDePago varchar(100)      
 ,@Comprobante_LugarExpedicion varchar(100)      
 ,@Emisor_Nombre varchar(max)      
 ,@Emisor_RFC varchar(100)      
 ,@DomicilioFiscal_calle varchar(500)  /* Emisor */      
 ,@DomicilioFiscal_noExterior varchar(100)  /* Emisor */      
 ,@DomicilioFiscal_colonia varchar(500) /* Emisor */      
 ,@DomicilioFiscal_localidad varchar(500) /* Emisor */      
 ,@DomicilioFiscal_municipio varchar(500) /* Emisor */      
 ,@DomicilioFiscal_estado varchar(500) /* Emisor */      
 ,@DomicilioFiscal_pais varchar(500) /* Emisor */      
 ,@DomicilioFiscal_codigoPostal varchar(100) /* Emisor */      
 ,@ExpedidoEn_calle varchar(500)      
 ,@ExpedidoEn_noExterior varchar(100)      
 ,@ExpedidoEn_colonia varchar(500)      
 ,@ExpedidoEn_localidad varchar(500)      
 ,@ExpedidoEn_municipio varchar(500)      
 ,@ExpedidoEn_estado varchar(500)      
 ,@ExpedidoEn_pais varchar(500)      
 ,@ExpedidoEn_codigoPostal varchar(100)      
 ,@RegimenFiscal_Regimen varchar(500)      
 ,@Receptor_Nombre varchar(max)      
 ,@Receptor_RFC varchar(100)      
 ,@Domicilio_calle varchar(500) /* Receptor */      
 ,@Domicilio_noExterior varchar(100) /* Receptor */      
 ,@Domicilio_colonia varchar(500) /* Receptor */      
 ,@Domicilio_localidad varchar(500) /* Receptor */      
 ,@Domicilio_municipio varchar(500) /* Receptor */      
 ,@Domicilio_estado varchar(500) /* Receptor */      
 ,@Domicilio_pais varchar(500) /* Receptor */      
 ,@Domicilio_codigoPostal varchar(100) /* Receptor */      
 ,@Concepto_cantidad varchar(100)      
 ,@Concepto_unidad varchar(100)      
 ,@Concepto_noIdentificacion varchar(100)      
 ,@Concepto_descripcion varchar(500)      
 ,@Concepto_valorUnitario varchar(100)      
 ,@Concepto_importe varchar(100)      
 ,@Traslado_impuesto varchar(100)      
 ,@Traslado_tasa varchar(100)      
 ,@Traslado_importe varchar(100)      
 ,@TimbreFiscalDigital_tfd varchar(max)      
 ,@TimbreFiscalDigital_xsi varchar(max)      
 ,@TimbreFiscalDigital_schemaLocation varchar(max)      
 ,@TimbreFiscalDigital_selloCFD nvarchar(max)      
 ,@TimbreFiscalDigital_FechaTimbrado nvarchar(100)      
 ,@TimbreFiscalDigital_UUID nvarchar(max)      
 ,@TimbreFiscalDigital_noCertificadoSAT nvarchar(max)      
 ,@TimbreFiscalDigital_version varchar(100)      
 ,@TimbreFiscalDigital_selloSAT nvarchar(max) 
 ,@TipoFactura int /* 0 : Emitida 1: Recibida*/
 ,@ArchivoXML varchar(255)
 ,@ArchivoPDF varchar(255)      
 --,@TipoFactura int not null /*1: Ingreso 2: Egreso*/      
 --,@FechaReg Datetime default getdate()      
 --,@Primary key (Receptor_RFC,@Comprobante_folio)      
 )      
AS       
BEGIN      
 INSERT INTO TblFacturas(IDClienteEmpresa,Comprobante_version,Comprobante_folio,Comprobante_fecha ,Comprobante_sello,Comprobante_formaDePago,Comprobante_noCertificado 
,Comprobante_certificado,Comprobante_subTotal,Comprobante_TipoCambio,Comprobante_Moneda,Comprobante_total,Comprobante_tipoDeComprobante 
,Comprobante_metodoDePago,Comprobante_LugarExpedicion,Emisor_Nombre,Emisor_RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia 
,DomicilioFiscal_localidad,DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal,ExpedidoEn_calle,ExpedidoEn_noExterior  
,ExpedidoEn_colonia,ExpedidoEn_localidad,ExpedidoEn_municipio,ExpedidoEn_estado,ExpedidoEn_pais,ExpedidoEn_codigoPostal,RegimenFiscal_Regimen,Receptor_Nombre 
,Receptor_RFC,Domicilio_calle,Domicilio_noExterior,Domicilio_colonia,Domicilio_localidad,Domicilio_municipio,Domicilio_estado,Domicilio_pais,Domicilio_codigoPostal  
,Concepto_cantidad,Concepto_unidad,Concepto_noIdentificacion,Concepto_descripcion,Concepto_valorUnitario,Concepto_importe,Traslado_impuesto,Traslado_tasa 
,Traslado_importe,TimbreFiscalDigital_tfd,TimbreFiscalDigital_xsi,TimbreFiscalDigital_schemaLocation,TimbreFiscalDigital_selloCFD,TimbreFiscalDigital_FechaTimbrado 
,TimbreFiscalDigital_UUID,TimbreFiscalDigital_noCertificadoSAT,TimbreFiscalDigital_version,TimbreFiscalDigital_selloSAT,TipoFactura,ArchivoXML,ArchivoPDF)      
 VALUES(      
 @IDClienteEmpresa,@Comprobante_version 
 ,@Comprobante_folio      
 ,@Comprobante_fecha,@Comprobante_sello,@Comprobante_formaDePago,@Comprobante_noCertificado,@Comprobante_certificado       
 ,@Comprobante_subTotal,@Comprobante_TipoCambio,@Comprobante_Moneda,@Comprobante_total       
 ,@Comprobante_tipoDeComprobante  /* Ingreso o Egreso */      
 ,@Comprobante_metodoDePago,@Comprobante_LugarExpedicion,@Emisor_Nombre,@Emisor_RFC       
 ,@DomicilioFiscal_calle   /* Emisor */      
 ,@DomicilioFiscal_noExterior   /* Emisor */      
 ,@DomicilioFiscal_colonia  /* Emisor */      
 ,@DomicilioFiscal_localidad  /* Emisor */      
 ,@DomicilioFiscal_municipio  /* Emisor */      
 ,@DomicilioFiscal_estado  /* Emisor */      
 ,@DomicilioFiscal_pais  /* Emisor */      
 ,@DomicilioFiscal_codigoPostal  /* Emisor */      
 ,@ExpedidoEn_calle,@ExpedidoEn_noExterior,@ExpedidoEn_colonia,@ExpedidoEn_localidad,@ExpedidoEn_municipio       
 ,@ExpedidoEn_estado,@ExpedidoEn_pais,@ExpedidoEn_codigoPostal,@RegimenFiscal_Regimen,@Receptor_Nombre,@Receptor_RFC       
 ,@Domicilio_calle  /* Receptor */      
 ,@Domicilio_noExterior  /* Receptor */      
 ,@Domicilio_colonia  /* Receptor */      
 ,@Domicilio_localidad  /* Receptor */      
 ,@Domicilio_municipio  /* Receptor */      
 ,@Domicilio_estado  /* Receptor */      
 ,@Domicilio_pais  /* Receptor */      
 ,@Domicilio_codigoPostal  /* Receptor */      
 ,@Concepto_cantidad,@Concepto_unidad,@Concepto_noIdentificacion,@Concepto_descripcion,@Concepto_valorUnitario,@Concepto_importe       
 ,@Traslado_impuesto,@Traslado_tasa,@Traslado_importe,@TimbreFiscalDigital_tfd,@TimbreFiscalDigital_xsi,@TimbreFiscalDigital_schemaLocation       
 ,@TimbreFiscalDigital_selloCFD,@TimbreFiscalDigital_FechaTimbrado,@TimbreFiscalDigital_UUID,@TimbreFiscalDigital_noCertificadoSAT       
 ,@TimbreFiscalDigital_version,@TimbreFiscalDigital_selloSAT      
 ,@TipoFactura 
 ,@ArchivoXML
 ,@ArchivoPDF     
       
 )      
END
