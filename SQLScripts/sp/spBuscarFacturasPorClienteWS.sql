USE [DB_9BB153_ControlFacturas]
GO
/****** Object:  StoredProcedure [dbo].[spBuscarFacturasPorClienteWS]    Script Date: 05/14/2015 09:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author...............: Ing. Jose Roman
-- Create date..........: 21/04/2015
-- Last Date Modified...: 21/04/2015
-- Description..........: Rastreo de archivos XML
--
-- Versión..............: 1
-- ===============================================================
ALTER PROCEDURE [dbo].[spBuscarFacturasPorClienteWS]--'ICT940906K57','05/02/2010','05/02/2015','E'
(
	 @RFC VARCHAR(50)
	,@FI Datetime
	,@FF Datetime	
	,@Tipo Varchar(10) /*1: General 2: Emitidas 3:Recibidas/Compras*/
) as

	--	RAISERROR ('Hola Hola', 15,1)
	--7	RETURN -100
	
	if EXISTS(SELECT IDFactura FROM TblFacturas where Emisor_RFC = @RFC or  Receptor_RFC = @RFC)
	begin
		if(@Tipo = 'R')
		begin
			select '/ctrlfacturaselectr/Documentos/'+ f.Emisor_RFC +'/'+Cast(Year(f.Fecha)as varchar)+'/'+RIGHT(REPLICATE('0',1)+Cast(Month(F.Fecha)As Varchar),2)+'/XML/RECIBIDA/'+f.ArchivoXML AS [File]
			,f.ArchivoXML [FileName]
			,F.Receptor_RFC
			from TblFacturas f with (nolock)
					left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
			where (f.Emisor_RFC = @RFC or  f.Receptor_RFC = @RFC)   and Cast(Fecha as Datetime) between @FI and @FF
				 And f.Comprobante_TipodeComprobante = 'ingreso'
		end
		else if (@tipo = 'E')
		begin		
			select '/ctrlfacturaselectr/Documentos/'+ f.Emisor_RFC +'/'+Cast(Year(f.Fecha)as varchar)+'/'+RIGHT(REPLICATE('0',1)+Cast(Month(F.Fecha)As Varchar),2)+'/XML/EMITIDAS/'+f.ArchivoXML AS [File]			
			,f.ArchivoXML [FileName]
			,f.Emisor_RFC
			from TblFacturas f with (nolock)
					left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
			where(f.Emisor_RFC = @RFC or  f.Receptor_RFC = @RFC)   and Cast(Fecha as Datetime) between @FI and @FF
			and f.Comprobante_TipodeComprobante = 'egreso'
		end 
		else  if (@tipo = 'T')
		begin
			select '/ctrlfacturaselectr/Documentos/'+ f.Emisor_RFC +'/'+Cast(Year(f.Fecha)as varchar)+'/'+RIGHT(REPLICATE('0',1)+Cast(Month(F.Fecha)As Varchar),2)+'/XML/EMITIDAS/'+f.ArchivoXML AS [File]			
			,f.ArchivoXML [FileName]
			,f.Emisor_RFC
			from TblFacturas f with (nolock)
					left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
			where (f.Emisor_RFC = @RFC or  f.Receptor_RFC = @RFC)   and Cast(Fecha as Datetime) between @FI and @FF
		end;
	end else
	begin
		RAISERROR ('El RFC no existe', 15,1)
		RETURN -100
	end