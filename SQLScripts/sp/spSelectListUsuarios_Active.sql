-- =============================================        
-- Author:  Ing. Jose Roman       
-- Create date: 06/02/2015        
-- Description: Busca Listado Usuarios en TblUsuarios que sean Activos   
-- =============================================     
CREATE PROCEDURE DBO.spSelectListUsuarios_Active     
AS    
BEGIN    
 SELECT *   
 FROM DBO.TblUsuarios  
 WHERE Active = 1  
END