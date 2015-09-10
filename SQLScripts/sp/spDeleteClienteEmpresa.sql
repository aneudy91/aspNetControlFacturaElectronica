 -- =============================================        
-- Author:  Ing. Aneudy Abreu
-- Create date: 03/04/2015        
-- Description: Borra Clientes Empresa
-- ============================================= 
create procedure spDeleteClienteEmpresa(@IDClienteEmpresa int)
as
declare @error varchar(1000)
	BEGIN TRY
        delete from TblClienteEmpresa where IDClienteEmpresa = @IDClienteEmpresa
    END TRY
    BEGIN CATCH
        select @error='Se produjo un error: '+ERROR_MESSAGE();
        
        RAISERROR (@error, 
		16, -- Severidad 
		1   -- Estado
		)
    END CATCH 