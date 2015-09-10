-- ===============================================================  
-- Author...............: Ing. Aneudy Abreu  
-- Create date..........: 25/02/2015  
-- Last Date Modified...: 25/02/2015  
-- Description..........: Buscar la ruta de archivos PDF y XML para descargar de una factura  
--  
-- Versión..............: 2 
-- ===============================================================  
alter PROCEDURE spBuscarArchivosDescargar(  
   @IDFactura int  
) as  


DECLARE @tipo varchar(20), @IDClienteEmpresa int,@RFC varchar(20)

  select @IDClienteEmpresa=IDClienteEmpresa
  from tblfacturas with (nolock)
  where idfactura = @IDFactura
  
  select @RFC = RFC
  from TblClienteEmpresa  with (nolock)
  where IDClienteEmpresa = @IDClienteEmpresa


select Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+
		dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/XML/'+
		case when @RFC = Emisor_RFC  then 'egreso' else 'ingreso' end+'/'+isnull(ArchivoXML,'XML') as XML,  
       Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+
       dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/PDF/'+
       case when @RFC = Emisor_RFC  then 'egreso' else 'ingreso' end+'/'+isnull(ArchivoPDF,'PDF') as PDF  
from TblFacturas   with (nolock) 
where IDFactura = @IDFactura  
  
  