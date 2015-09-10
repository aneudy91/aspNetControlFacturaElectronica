-- =============================================      
-- Author:  Ing. Jose Roman     
-- Create date: 05/02/2015      
-- Description: Inserta datos de empresa en TblEmpresa  
-- =============================================   
alter PROCEDURE DBO.spInsertEmpresa  
 @NombreComercial VARCHAR(300)  
 ,@RazonSocial  VARCHAR(300)  
 ,@RFC    VARCHAR(50)  
 ,@DomicilioFiscal_calle   VARCHAR(500)  
 ,@DomicilioFiscal_noExterior VARCHAR(100)  
 ,@DomicilioFiscal_colonia  VARCHAR(500)  
 ,@DomicilioFiscal_localidad  VARCHAR(500)  
 ,@DomicilioFiscal_municipio  VARCHAR(500)  
 ,@DomicilioFiscal_estado  VARCHAR(500)  
 ,@DomicilioFiscal_pais   VARCHAR(500)  
 ,@DomicilioFiscal_codigoPostal   VARCHAR(100)  
AS  
BEGIN  
 INSERT INTO DBO.TblEmpresa  
 VALUES(  
  @NombreComercial  
  ,@RazonSocial  
  ,@RFC  
  ,@DomicilioFiscal_calle  
  ,@DomicilioFiscal_noExterior  
  ,@DomicilioFiscal_colonia  
  ,@DomicilioFiscal_localidad  
  ,@DomicilioFiscal_municipio  
  ,@DomicilioFiscal_estado  
  ,@DomicilioFiscal_pais  
  ,@DomicilioFiscal_codigoPostal  
 )  
END 