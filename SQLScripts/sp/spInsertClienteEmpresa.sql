 -- =============================================      
-- Author:  Ing. Jose Roman     
-- Create date: 06/02/2015      
-- Description: Inserta datos de empresa en TblClienteEmpresa  
-- =============================================   
alter PROCEDURE DBO.spInsertClienteEmpresa  
  @IDEmpresa   INT  
  ,@NombreComercial VARCHAR(300)  
  ,@NombreContacto  VARCHAR(200)  
  ,@RazonSocial  VARCHAR(300)  
  ,@RFC    VARCHAR(50)  
  ,@DomicilioFiscal_calle   VARCHAR(500)  
  ,@DomicilioFiscal_noExterior  VARCHAR(100)  
  ,@DomicilioFiscal_colonia  VARCHAR(500)  
  ,@DomicilioFiscal_localidad  VARCHAR(500)  
  ,@DomicilioFiscal_municipio  VARCHAR(500)  
  ,@DomicilioFiscal_estado   VARCHAR(500)  
  ,@DomicilioFiscal_pais   VARCHAR(500)  
  ,@DomicilioFiscal_codigoPostal  VARCHAR(100)  
  ,@CorreoEletronico    VARCHAR(255)  
  ,@ContactoTelefono    VARCHAR(50)  
  ,@ContactoCelular    VARCHAR(50)  
  ,@TipoPersona     VARCHAR(20)  
AS  
BEGIN  
 INSERT INTO TblClienteEmpresa(IDEmpresa,NombreComercial,NombreContacto,RazonSocial,RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia,
		DomicilioFiscal_localidad,DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal,CorreoEletronico,
		ContactoTelefono,ContactoCelular,TipoPersona)
 VALUES(  
   @IDEmpresa  
   ,@NombreComercial  
   ,@NombreContacto  
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
   ,@CorreoEletronico  
   ,@ContactoTelefono  
   ,@ContactoCelular  
   ,@TipoPersona  
 )  
END  