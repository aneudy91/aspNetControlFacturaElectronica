-- ===============================================================
-- Author...............: Ing. Aneudy Abreu
-- Create date..........: 25/02/2015
-- Last Date Modified...: 25/02/2015
-- Description..........:	Buscar la ruta de archivos PDF y XML para descargar de una factura
--
-- Versión..............: 1
-- ===============================================================
ALTER PROCEDURE spBuscarArchivosDescargar(
   @IDFactura int
) as
select	Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/XML/'+case when TipoFactura = 0  then 'EMITIDAS' else 'RECIBIDA' end+'/'+isnull(ArchivoXML,'XML') as XML,
		Emisor_RFC+'/'+convert(varchar,DATEPART(yy,fecha))+'/'+dbo.ADD_STRING(convert(varchar,DATEPART(MM,Fecha)),2,'0')+'/PDF/'+case when TipoFactura = 0  then 'EMITIDAS' else 'RECIBIDA' end+'/'+isnull(ArchivoPDF,'PDF') as PDF
from TblFacturas
where IDFactura = @IDFactura


go


exec spBuscarArchivosDescargar 426


select *
from tblfacturas