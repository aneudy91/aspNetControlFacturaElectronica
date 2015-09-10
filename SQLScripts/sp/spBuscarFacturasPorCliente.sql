-- ===============================================================
-- Author...............: Ing. Aneudy Abreu
-- Create date..........: 21/02/2015
-- Last Date Modified...: 21/02/2015
-- Description..........:	Reporte de facturas por cliente
--
-- Versión..............: 1
-- ===============================================================
alter PROCEDURE spBuscarFacturasPorCliente(
	 @IDClienteEmpresa int
	,@FI Date
	,@FF Date	
	,@Tipo int /*1: General 2: Emitidas 3:Recibidas/Compras*/
) as
	DECLARE @IvaAfavor money, @IvaEncontra money, 
			@IvaEmitido money, @IvaRecibido money,@Diferencia money
	
	if @Tipo = 1
	begin
		
		select @IvaEmitido= SUM(cast(Traslado_importe as money))
		from TblFacturas with (nolock)
		where (IDClienteEmpresa = @IDClienteEmpresa) and (Fecha between @FI and @FF) and (TipoFactura = 0)
		
		select @IvaRecibido= SUM(cast(Traslado_importe as money))
		from TblFacturas with (nolock)
		where (IDClienteEmpresa = @IDClienteEmpresa) and (Fecha between @FI and @FF) and (TipoFactura = 1)
		
		
		set @Diferencia=(@IvaEmitido - @IvaRecibido)
		
		if (@Diferencia > 0)
		begin
		 select @IvaAfavor = @Diferencia,@IvaEncontra=0;
		end else
		begin
			select @IvaEncontra=@Diferencia,@IvaAfavor=0;
		end
		
		select XML = case when f.ArchivoXML <> '' then 'SI' else 'NO' end,
			   PDF = case when f.ArchivoPDF <> '' then 'SI' else 'NO' end,
			   '' as VALIDACION,
			   TIPO_FACTURA = case when f.TipoFactura = 0 then 'EMITIDA' else 'RECIBIDA' end,
			   convert(varchar,f.Fecha,103) as FECHA,
			   f.Emisor_RFC as EMISOR_RFC,
			   f.Emisor_Nombre as EMISOR_NOMBRE,
			   f.Comprobante_subTotal as SUB_TOTAL,
			   f.Traslado_importe as IVA,
			   f.Comprobante_total as TOTAL,
			   f.IDFactura,
			   c.NombreComercial as CLIENTE,
			   c.RazonSocial as RazonSocialCliente,
			   c.DomicilioFiscal_calle as ClienteCalle,
			   c.DomicilioFiscal_colonia as ColoniaCliente,
			   c.DomicilioFiscal_estado as EstadoCliente,
			   c.DomicilioFiscal_localidad as LocalidadCliente,
			   c.DomicilioFiscal_municipio as MunicipioCliente,
			   c.DomicilioFiscal_pais as PaisCliente,
			   c.DomicilioFiscal_noExterior as NoExteriorCliente,
			   c.DomicilioFiscal_codigoPostal as CodigoPostalCliente,
			   @FI as FechaDesde,
			   @FF as FechaHasta,   
			--   @IvaEmitido as IVA_EMITIDO,
			 --  @IvaRecibido as IVA_RECIBIDO, 
		       @IvaAfavor as IVA_A_FAVOR,
		       @IvaEncontra as IVA_EN_CONTRA,
		       @Diferencia as Diferencia
		from TblFacturas f with (nolock)
				left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
		where f.IDClienteEmpresa = @IDClienteEmpresa and Fecha between @FI and @FF
	
    end;
    
    
    
    if (@Tipo = 2)
    begin
		select @IvaAfavor=0,@IvaEncontra=0,@Diferencia=0
		
		select XML = case when f.ArchivoXML <> '' then 'SI' else 'NO' end,
			   PDF = case when f.ArchivoPDF <> '' then 'SI' else 'NO' end,
			   '' as VALIDACION,
			   TIPO_FACTURA = case when f.TipoFactura = 0 then 'EMITIDA' else 'RECIBIDA' end,
			   convert(varchar,f.Fecha,103) as FECHA,
			   f.Emisor_RFC as EMISOR_RFC,
			   f.Emisor_Nombre as EMISOR_NOMBRE,
			   f.Comprobante_subTotal as SUB_TOTAL,
			   f.Traslado_importe as IVA,
			   f.Comprobante_total as TOTAL,
			   f.IDFactura,
			   c.NombreComercial as CLIENTE,
			   c.RazonSocial as RazonSocialCliente,
			   c.DomicilioFiscal_calle as ClienteCalle,
			   c.DomicilioFiscal_colonia as ColoniaCliente,
			   c.DomicilioFiscal_estado as EstadoCliente,
			   c.DomicilioFiscal_localidad as LocalidadCliente,
			   c.DomicilioFiscal_municipio as MunicipioCliente,
			   c.DomicilioFiscal_pais as PaisCliente,
			   c.DomicilioFiscal_noExterior as NoExteriorCliente,
			   c.DomicilioFiscal_codigoPostal as CodigoPostalCliente,
			   @FI as FechaDesde,
			   @FF as FechaHasta,   
			--   @IvaEmitido as IVA_EMITIDO,
			 --  @IvaRecibido as IVA_RECIBIDO, 
		       @IvaAfavor as IVA_A_FAVOR,
		       @IvaEncontra as IVA_EN_CONTRA,
		       @Diferencia as Diferencia
		from TblFacturas f with (nolock)
				left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
		where (f.IDClienteEmpresa = @IDClienteEmpresa) and (Fecha between @FI and @FF) and (TipoFactura = 0) 
    
    end
	
    if (@Tipo = 3)
    begin
		select @IvaAfavor=0,@IvaEncontra=0,@Diferencia=0
    
		select XML = case when f.ArchivoXML <> '' then 'SI' else 'NO' end,
			   PDF = case when f.ArchivoPDF <> '' then 'SI' else 'NO' end,
			   '' as VALIDACION,
			   TIPO_FACTURA = case when f.TipoFactura = 0 then 'EMITIDA' else 'RECIBIDA' end,
			   convert(varchar,f.Fecha,103) as FECHA,
			   f.Emisor_RFC as EMISOR_RFC,
			   f.Emisor_Nombre as EMISOR_NOMBRE,
			   f.Comprobante_subTotal as SUB_TOTAL,
			   f.Traslado_importe as IVA,
			   f.Comprobante_total as TOTAL,
			   f.IDFactura,
			   c.NombreComercial as CLIENTE,
			   c.RazonSocial as RazonSocialCliente,
			   c.DomicilioFiscal_calle as ClienteCalle,
			   c.DomicilioFiscal_colonia as ColoniaCliente,
			   c.DomicilioFiscal_estado as EstadoCliente,
			   c.DomicilioFiscal_localidad as LocalidadCliente,
			   c.DomicilioFiscal_municipio as MunicipioCliente,
			   c.DomicilioFiscal_pais as PaisCliente,
			   c.DomicilioFiscal_noExterior as NoExteriorCliente,
			   c.DomicilioFiscal_codigoPostal as CodigoPostalCliente,
			   @FI as FechaDesde,
			   @FF as FechaHasta,   
			--   @IvaEmitido as IVA_EMITIDO,
			 --  @IvaRecibido as IVA_RECIBIDO, 
		       @IvaAfavor as IVA_A_FAVOR,
		       @IvaEncontra as IVA_EN_CONTRA,
		       @Diferencia as Diferencia
		from TblFacturas f with (nolock)
				left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa
		where (f.IDClienteEmpresa = @IDClienteEmpresa) and (Fecha between @FI and @FF) and (TipoFactura = 1) 
    
    end

go
--exec spBuscarFacturasPorCliente 1,'2014-02-15','2014-03-15',3
	
