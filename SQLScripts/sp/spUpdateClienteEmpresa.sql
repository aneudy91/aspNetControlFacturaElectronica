-- =============================================        
-- Author:  Ing. Jose Roman       
-- Create date: 06/02/2015        
-- Description: Actualiza datos de clienteEmpresa en TblClienteEmpresa    
-- =============================================     
alter PROCEDURE DBO.spUpdateClienteEmpresa    
   @IDClienteEmpresa INT  
  ,@IDEmpresa   INT    
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
 UPDATE TblClienteEmpresa    
 SET IDEmpresa  = @IDEmpresa    
   , NombreComercial  = @NombreComercial    
   , NombreContacto  = @NombreContacto    
   , RazonSocial  = @RazonSocial    
   , RFC  = @RFC    
   , DomicilioFiscal_calle  = @DomicilioFiscal_calle    
   , DomicilioFiscal_noExterior  = @DomicilioFiscal_noExterior    
   , DomicilioFiscal_colonia  = @DomicilioFiscal_colonia    
   , DomicilioFiscal_localidad  = @DomicilioFiscal_localidad    
   , DomicilioFiscal_municipio  = @DomicilioFiscal_municipio    
   , DomicilioFiscal_estado  = @DomicilioFiscal_estado    
   , DomicilioFiscal_pais  = @DomicilioFiscal_pais    
   , DomicilioFiscal_codigoPostal  = @DomicilioFiscal_codigoPostal    
   , CorreoEletronico  = @CorreoEletronico    
   , ContactoTelefono  = @ContactoTelefono    
   , ContactoCelular  = @ContactoCelular    
   , TipoPersona  = @TipoPersona    
 WHERE IDClienteEmpresa = @IDClienteEmpresa  
END 