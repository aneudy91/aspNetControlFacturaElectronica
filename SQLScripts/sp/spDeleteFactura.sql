 -- =============================================        
-- Author:  Ing. Jose Roman       
-- Create date: 06/02/2015        
-- Description: Borra facturas en TBLFacturas   
-- =============================================        
CREATE PROCEDURE DBO.spDeleteFactura        
 (@IDFactura INT  
  ,@IDClienteEmpresa INT      
  ,@Comprobante_TipoDeComprobante VARCHAR(50)  
 )        
AS         
BEGIN        
 DELETE TBLFACTURAS        
 WHERE IDFactura = @IDFactura  
  AND IDClienteEmpresa = @IDClienteEmpresa  
  AND Comprobante_TipoDeComprobante = @Comprobante_TipoDeComprobante  
        
END  