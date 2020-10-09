/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Obtener_Pago_Credito
GO

CREATE PROCEDURE [dbo].[PA_Obtener_Pago_Credito]  
	@Id INT = NULL,
	@Id_Usuario SMALLINT = NULL
AS 
BEGIN  
	SELECT PCR.Id
		  ,PCR.Monto
		  ,PCR.Abono
		  ,PCR.Saldo
		  ,PCR.Fecha_Creacion
		  ,PCR.Usuario_Creacion
		  ,PCR.Estado
		  ,PCR.Id_Usuario
		  ,USU.Nombre AS Nombre_Usuario
	FROM dbo.PagoCredito PCR
	INNER JOIN dbo.Usuario USU ON PCR.Id_Usuario = USU.Id
	WHERE PCR.Id= COALESCE(@Id, PCR.Id)
	AND PCR.Id_Usuario = COALESCE(@Id_Usuario, PCR.Id_Usuario)
 
END
