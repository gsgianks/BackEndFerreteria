/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Obtener_Credito_Usuario
GO

CREATE PROCEDURE [dbo].[PA_Obtener_Credito_Usuario]  
	@Estado_Pendiente CHAR(3),
	@Rol VARCHAR(120),
	@Id_Usuario SMALLINT = NULL
AS 
BEGIN  
 
	SELECT USU.Id AS Id_Usuario	
		  ,USU.Nombre AS Nombre_Usuario
		  ,COALESCE(EST.Descripcion, 'Sin saldo') AS Descripcion_Estado
		  ,dbo.FV_ObtenerSaldoCredito(@Estado_Pendiente, @Rol, USU.Id) AS Saldo
	FROM Usuario USU
	LEFT JOIN Credito CRE ON CRE.Id_Usuario = USU.Id AND CRE.Estado =  @Estado_Pendiente
	LEFT JOIN Estado EST ON CRE.Estado = EST.Codigo
	WHERE USU.Rol = @Rol
	AND USU.Id =  COALESCE(@Id_Usuario, USU.Id)
	GROUP BY USU.Id, USU.Nombre,EST.Descripcion,CRE.Estado
	ORDER BY USU.Nombre
 
END
