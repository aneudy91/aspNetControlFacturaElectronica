-- Author:		Ing. Aneudy Abreu
-- Create date: 18/02/2015
-- Description:	Consulta [TblUsuarios] por IDUsuarios
-- =============================================
alter PROCEDURE spBuscarUsuarios(
	@IDUsuario int
)as
	if (@IDUsuario <> 0)
	begin
		select s.IDUsuario,ISNULL(s.IDEmpresa,0) as IDEmpresa,e.NombreComercial as Empresa ,ISNULL(s.IDClienteEmpresa,0) as IDClienteEmpresa,ce.NombreComercial as Cliente,
			s.Nombre,s.NombreCuenta,s.Clave
		from TblUsuarios s with (nolock)
			left join TblEmpresa e with (nolock) on s.IDEmpresa = e.IDEmpresa
			left join TblClienteEmpresa ce with (nolock) on s.IDClienteEmpresa = ce.IDClienteEmpresa
		where s.IDUsuario = @IDUsuario
	end else
	begin
		select s.IDUsuario,ISNULL(s.IDEmpresa,0) as IDEmpresa,e.NombreComercial as Empresa ,ISNULL(s.IDClienteEmpresa,0) as IDClienteEmpresa,ce.NombreComercial as Cliente,
			s.Nombre,s.NombreCuenta,s.Clave
		from TblUsuarios s with (nolock)
			left join TblEmpresa e with (nolock) on s.IDEmpresa = e.IDEmpresa
			left join TblClienteEmpresa ce with (nolock) on s.IDClienteEmpresa = ce.IDClienteEmpresa
	end;