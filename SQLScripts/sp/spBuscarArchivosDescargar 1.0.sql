-- ===============================================================  
-- Author...............: Ing. Aneudy Abreu  
-- Create date..........: 25/02/2015  
-- Last Date Modified...: 25/02/2015  
-- Description..........: Buscar la ruta de archivos PDF y XML para descargar de una factura  
--  
-- Versión..............: 1  
-- ===============================================================  
CREATE PROCEDURE spBuscarArchivosDescargar(  
   @IDFactura int  
) as  


DECLARE @tipo varchar(20), @IDClienteEmpresa int,@RFC varchar(20)

  select @IDClienteEmpresa=IDClienteEmpresa
  from tblfacturas
  where idfactura = @IDFactura
  
  select @RFC = RFC
  from TblClienteEmpresa
  where IDClienteEmpresa = @IDClienteEmpresa


select Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+
		dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/XML/'+
		case when TipoFactura = 0  then 'egreso' else 'ingreso' end+'/'+isnull(ArchivoXML,'XML') as XML,  
       Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+
       dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/PDF/'+
       case when TipoFactura = 0  then 'egreso' else 'ingreso' end+'/'+isnull(ArchivoPDF,'PDF') as PDF  
from TblFacturas  
where IDFactura = @IDFactura  
  
  
  
  select *
  from tblfacturas
  where idfactura = 2716
  go
  select *
  from tblClienteEmpresa
  where idClienteEmpresa = 23