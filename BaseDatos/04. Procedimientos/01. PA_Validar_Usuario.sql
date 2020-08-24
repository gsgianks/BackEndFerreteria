USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Validar_Usuario
GO

CREATE PROCEDURE [dbo].[PA_Validar_Usuario]  
	@pIdentificacion varchar(25),  
	@pContasena varchar(60) 
AS 
BEGIN  
	SELECT Id
      ,Identificacion
      ,Nombre
      ,Celular
      ,Telefono
      ,Correo_Electronico
      ,Direccion
      ,Rol
      ,Contrasena
      ,Fecha_Creacion
      ,Usuario_Creacion
      ,Fecha_Modificacion
      ,Usuario_Modificacion
      ,Estado
	FROM dbo.Usuario
	WHERE Identificacion=@pIdentificacion AND Contrasena=@pContasena
END

