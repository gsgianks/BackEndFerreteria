/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Obtener_Credito_Usuario
GO

CREATE PROCEDURE [dbo].[PA_Obtener_Credito_Usuario]  
	@Estado_Pendiente CHAR(3),
	@Rol VARCHAR(120)
AS 
BEGIN  
 
	SELECT USU.Id AS Id_Usuario	
		  ,USU.Nombre AS Nombre_Usuario
		  ,COALESCE(EST.Descripcion, 'Sin saldo') AS Descripcion_Estado
		  ,COALESCE(SUM(CRE.Cantidad*CRE.Precio_Venta_Producto), 0) AS Saldo
	FROM Usuario USU
	LEFT JOIN Credito CRE ON CRE.Id_Usuario = USU.Id
	LEFT JOIN Estado EST ON CRE.Estado = EST.Codigo
	WHERE COALESCE(CRE.Estado,@Estado_Pendiente) = @Estado_Pendiente
	AND USU.Rol = @Rol
	GROUP BY USU.Id, USU.Nombre,EST.Descripcion
	ORDER BY USU.Nombre
 
END
