﻿/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Obtener_Credito
GO

CREATE PROCEDURE [dbo].[PA_Obtener_Credito]  
	@Id SMALLINT = NULL,
	@Id_Pago INT = NULL,
	@Id_Usuario SMALLINT = NULL,
	@Estado CHAR(3) = NULL
AS 
BEGIN  
 
	SELECT CRE.id
		  ,CRE.Id_Usuario
		  ,CRE.Id_Producto
		  ,CRE.Nombre_Producto
		  ,CRE.Precio_Venta_Producto
		  ,CRE.Cantidad
		  ,CRE.Id_Pago
		  ,CRE.Fecha_Creacion
		  ,CRE.Usuario_Creacion
		  ,CRE.Fecha_Modificacion
		  ,CRE.Usuario_Modificacion
		  ,CRE.Estado
		  ,EST.Descripcion AS Descripcion_Estado
		  ,CRE.Cantidad*CRE.Precio_Venta_Producto AS Precio_Total
		  ,CRE.Id_Pago_Parcial
	FROM Credito CRE
	INNER JOIN Estado EST ON CRE.Estado = EST.Codigo
	WHERE CRE.Id= COALESCE(@Id, CRE.Id)
	AND CRE.Id_Usuario = COALESCE(@Id_Usuario, CRE.Id_Usuario)
	AND COALESCE(CRE.Id_Pago, 0) = COALESCE(@Id_Pago, COALESCE(CRE.Id_Pago, 0))
	AND CRE.Estado = COALESCE(@Estado, CRE.Estado)
	ORDER BY CRE.id DESC
 
END
