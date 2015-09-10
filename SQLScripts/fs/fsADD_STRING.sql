-- =============================================
-- Author.....:	Ing. Aneudy Abreu
-- Create date: 15/10/2012
-- Description:	Agrega el Valor recivido en @Agregar a @Value a su izquierda hasta que 
-- el Lengh sea igual a @Tamano.
-- 
-- Versión....: 2.0
-- =============================================
alter FUNCTION ADD_STRING(@Value varchar(225)
						  ,@Tamano int
						  ,@Agregar varchar(10)
						  )RETURNS VARCHAR(255)AS
BEGIN
	declare @i int
	/*
	set @Tamano = 2;
	set @Value = 3
	set @Agregar = '0'
	*/
	set @i = LEN(@Value);
IF (LEN(@Value) < @Tamano)
BEGIN
	while (@i < @Tamano )
	begin
		set	@Value = @Agregar+@Value;
		set @i = @i+1;
	end
END
	RETURN @value
END