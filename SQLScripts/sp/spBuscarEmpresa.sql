-- =============================================
-- Author:		Ing. Aneudy Abreu
-- Create date: 02/02/2015
-- Description:	Consulta [TblEmpresa] por IDEmpresa
-- =============================================
ALTER PROCEDURE spBuscarEmpresa(
	@IDEmpresa int
) as
	if (@IDEmpresa <> 0)
	begin
		select IDEmpresa,NombreComercial,RazonSocial,RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia,DomicilioFiscal_localidad,
			DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal
		from TblEmpresa	with (nolock)
		where IDEmpresa = @IDEmpresa
	end
	else
	begin
		select IDEmpresa,NombreComercial,RazonSocial,RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia,DomicilioFiscal_localidad,
			DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal
		from TblEmpresa	with (nolock)
	end