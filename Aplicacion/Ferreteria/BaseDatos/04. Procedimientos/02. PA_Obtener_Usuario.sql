/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Obtener_Usuario
GO

CREATE PROCEDURE [dbo].[PA_Obtener_Usuario]  
	@Id SMALLINT = NULL
AS 
BEGIN  
 
	SELECT USU.Id
      ,USU.Identificacion
      ,USU.Nombre
      ,USU.Celular
      ,USU.Telefono
      ,USU.Correo_Electronico
      ,USU.Direccion
      ,USU.Contrasena
      ,USU.Fecha_Creacion
      ,USU.Usuario_Creacion
      ,USU.Fecha_Modificacion
      ,USU.Usuario_Modificacion
      ,USU.Estado
	FROM Usuario USU
	WHERE USU.Id= COALESCE(@Id, USU.Id)
 
END
