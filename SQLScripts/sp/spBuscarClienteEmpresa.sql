-- =============================================
-- Author:		Ing. Aneudy Abreu
-- Create date: 02/02/2015
-- Description:	Consulta [TblClienteEmpresa] por IDClienteEmpresa
-- =============================================
alter PROCEDURE spBuscarClienteEmpresa(
	@IDClienteEmpresa int
) as

	if (@IDClienteEmpresa <> 0)
	begin
		select ce.IDClienteEmpresa,ce.IDEmpresa,e.NombreComercial as Empresa,ce.NombreComercial,ce.NombreContacto,ce.RazonSocial,ce.RFC,ce.DomicilioFiscal_calle,ce.DomicilioFiscal_noExterior
			,ce.DomicilioFiscal_colonia,ce.DomicilioFiscal_localidad,ce.DomicilioFiscal_municipio,ce.DomicilioFiscal_estado,ce.DomicilioFiscal_pais,
			ce.DomicilioFiscal_codigoPostal,ce.CorreoEletronico,ce.ContactoTelefono,ce.ContactoCelular,ce.TipoPersona,Convert(int,ce.Active) as Active
		from TblClienteEmpresa	ce with (nolock)
			left join TblEmpresa e with (nolock) on e.IDEmpresa = ce.IDEmpresa
		where IDClienteEmpresa = @IDClienteEmpresa
	end else
	begin
		select ce.IDClienteEmpresa,ce.IDEmpresa,e.NombreComercial as Empresa,ce.NombreComercial,ce.NombreContacto,ce.RazonSocial,ce.RFC,ce.DomicilioFiscal_calle,ce.DomicilioFiscal_noExterior
			,ce.DomicilioFiscal_colonia,ce.DomicilioFiscal_localidad,ce.DomicilioFiscal_municipio,ce.DomicilioFiscal_estado,ce.DomicilioFiscal_pais,
			ce.DomicilioFiscal_codigoPostal,ce.CorreoEletronico,ce.ContactoTelefono,ce.ContactoCelular,ce.TipoPersona,Convert(int,ce.Active) as Active
		from TblClienteEmpresa	ce with (nolock)
			left join TblEmpresa e with (nolock) on e.IDEmpresa = ce.IDEmpresa
	--	where IDClienteEmpresa = @IDClienteEmpresa
		
	end;