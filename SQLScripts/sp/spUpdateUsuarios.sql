 -- =============================================      
-- Author:  Ing. Jose Roman     
-- Create date: 06/02/2015      
-- Description: Actualiza datos de Usuarios en TblUsuarios  
-- =============================================   
alter PROCEDURE DBO.spUpdateUsuarios  
   @IDUsuario INT  
   ,@IDEmpresa INT  
   ,@IDClienteEmpresa INT  
   ,@Nombre VARCHAR(150)  
   ,@NombreCuenta   VARCHAR(100)  
   ,@Clave VARCHAR(200)  
AS  
BEGIN  
 UPDATE DBO.TblUsuarios  
  SET IDEmpresa = @IDEmpresa  
  ,IDClienteEmpresa = @IDClienteEmpresa  
  ,Nombre = @Nombre  
  ,NombreCuenta = @NombreCuenta  
  ,Clave = @Clave   
 WHERE IDUsuario = @IDUsuario  
   
END  