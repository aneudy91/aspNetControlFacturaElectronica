 -- =============================================        
-- Author:  Ing. Jose Roman       
-- Create date: 06/02/2015        
-- Description: Busca Listado clienteEmpresa en TblClienteEmpresa que sean Activos   
-- =============================================     
CREATE PROCEDURE DBO.spSelectListClienteEmpresa_Active     
AS    
BEGIN    
 SELECT *   
 FROM DBO.TblClienteEmpresa  
 WHERE Active = 1  
END 