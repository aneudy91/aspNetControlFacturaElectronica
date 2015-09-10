-- =============================================      
-- Author:  Ing. Jose Roman     
-- Create date: 06/02/2015      
-- Description: Inserta datos de Usuarios en TblUsuarios  
-- =============================================   
alter PROCEDURE spInsertUsuarios  
    @IDUsuario int
   ,@IDEmpresa INT  
   ,@IDClienteEmpresa INT  
   ,@Nombre VARCHAR(150)  
   ,@NombreCuenta   VARCHAR(100)  
   ,@Clave VARCHAR(200)  
   ,@Actualizar int
AS  
BEGIN
	if (@IDEmpresa = 0) set @IDEmpresa = null;
	if (@IDClienteEmpresa = 0) set @IDClienteEmpresa = null;
  
  if (@Actualizar = 1)
  begin
	update TblUsuarios
		set Nombre = @Nombre
		,NombreCuenta = @NombreCuenta
		,Clave = @Clave
		,IDClienteEmpresa = @IDClienteEmpresa
		,IDEmpresa = @IDEmpresa
	where IDUsuario = @IDUsuario
  end else
  begin
	 INSERT INTO TblUsuarios(IDEmpresa,IDClienteEmpresa,Nombre,NombreCuenta,Clave,Active)
	 VALUES (@IDEmpresa,@IDClienteEmpresa,@Nombre,@NombreCuenta,@Clave,0)  
  end
END  

