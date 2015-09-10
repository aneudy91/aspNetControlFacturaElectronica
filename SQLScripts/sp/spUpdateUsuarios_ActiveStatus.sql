-- =============================================          
-- Author:  Ing. Jose Roman         
-- Create date: 06/02/2015          
-- Description: Cambia Status Active de clienteEmpresa en TblClienteEmpresa      
-- =============================================       
CREATE PROCEDURE DBO.spUpdateUsuarios_ActiveStatus  
 @IDUsuario INT  
 ,@Active BIT  
AS      
BEGIN      
  UPDATE TblUsuarios  
  SET Active = @Active  
 WHERE IDUsuario = @IDUsuario  
END      
  