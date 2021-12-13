CREATE PROCEDURE [dbo].[createCurso]
	@Nombre varchar(500),
	@Descripcion varchar (1000),
	@Profesor varchar(500),
	@Email varchar(100),
	@Precio int,
	@Fecha_Ingreso datetime,
	@Fecha_Update datetime

AS
BEGIN
	INSERT INTO [dbo].[cursos]
           ([nombre]
           ,[descripcion]
           ,[profesor]
           ,[email]
           ,[precio]
           ,[fecha_ingreso]
           ,[fecha_update])
     VALUES
           (@Nombre,
		   @Descripcion,
		   @Profesor,
		   @Email,
		   @Precio,
		   @Fecha_Ingreso,
		   @Fecha_Update
		   )

END
GO