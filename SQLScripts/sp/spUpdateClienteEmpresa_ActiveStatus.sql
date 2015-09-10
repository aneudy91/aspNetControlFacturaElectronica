-- =============================================          
-- Author:  Ing. Jose Roman         
-- Create date: 06/02/2015          
-- Description: Cambia Status Active de clienteEmpresa en TblClienteEmpresa      
-- =============================================       
CREATE PROCEDURE DBO.spUpdateClienteEmpresa_ActiveStatus  
 @IDClienteEmpresa INT  
 ,@Active BIT  
AS      
BEGIN      
  UPDATE TblClienteEmpresa  
  SET Active = @Active  
 WHERE IDClienteEmpresa = @IDClienteEmpresa  
END 