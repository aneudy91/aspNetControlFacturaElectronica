-- ===============================================================    
-- Author...............: Ing. Aneudy Abreu    
-- Create date..........: 21/02/2015    
-- Last Date Modified...: 21/02/2015    
-- Description..........: Reporte de facturas por cliente    
--    
-- Versión..............: 2  
-- ===============================================================    
alter PROCEDURE [dbo].[spBuscarFacturasPorCliente](    
  @IDClienteEmpresa int    
 ,@FI Date    
 ,@FF Date     
 ,@Tipo int /*1: General 2: Emitidas 3:Recibidas /Compras*/    
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
      TIPO_FACTURA = case when f.TipoFactura = 0 then 'E' else 'R' end,    
      convert(varchar,f.Fecha,103) as FECHA,    
      f.Emisor_RFC as EMISOR_RFC,    
      f.Emisor_Nombre as EMISOR_NOMBRE,    
       case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            else cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            end as SUB_TOTAL,    
      case     
     when f.TipoFactura = 0 then cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     else cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     end AS IVA    
      ,    
      case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     else cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     end as TOTAL,    
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
      convert(varchar(10),@FI,105) as FechaDesde,    
      convert(varchar(10),@FF,105) as FechaHasta,       
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
      TIPO_FACTURA = case when f.TipoFactura = 0 then 'E' else 'R' end,    
      convert(varchar,f.Fecha,103) as FECHA,    
      f.Emisor_RFC as EMISOR_RFC,    
    case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            else cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            end as SUB_TOTAL,    
      case     
     when f.TipoFactura = 0 then cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     else cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     end AS IVA    
      ,    
      case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     else cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     end as TOTAL,    
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
      convert(varchar(10),@FI,105) as FechaDesde,    
      convert(varchar(10),@FF,105) as FechaHasta,       
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
      TIPO_FACTURA = case when f.TipoFactura = 0 then 'E' else 'R' end,    
      convert(varchar,f.Fecha,103) as FECHA,    
      f.Emisor_RFC as EMISOR_RFC,    
      f.Emisor_Nombre as EMISOR_NOMBRE,    
     case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            else cast(CAST(f.Comprobante_subTotal as decimal(18,5)) as float)    
            end as SUB_TOTAL,    
      case     
     when f.TipoFactura = 0 then cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     else cast(CAST(f.Traslado_importe as decimal(18,5)) as float)    
     end AS IVA    
      ,    
      case when f.TipoFactura = 0 then cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     else cast(CAST(f.Comprobante_total as decimal(18,5)) as float)    
     end as TOTAL,    
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
      convert(varchar(10),@FI,105) as FechaDesde,    
      convert(varchar(10),@FF,105) as FechaHasta,       
   --   @IvaEmitido as IVA_EMITIDO,    
    --  @IvaRecibido as IVA_RECIBIDO,     
         @IvaAfavor as IVA_A_FAVOR,    
         @IvaEncontra as IVA_EN_CONTRA,    
         @Diferencia as Diferencia    
  from TblFacturas f with (nolock)    
    left join TblClienteEmpresa c on f.IDClienteEmpresa = c.IDClienteEmpresa    
  where (f.IDClienteEmpresa = @IDClienteEmpresa) and (Fecha between @FI and @FF) and (TipoFactura = 1)     
        
    end    