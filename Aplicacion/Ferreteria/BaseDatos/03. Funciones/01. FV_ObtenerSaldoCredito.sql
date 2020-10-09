USE [Ferreteria]
GO

IF object_id(N'FV_ObtenerSaldoCredito', N'FN') IS NOT NULL
    DROP FUNCTION FV_ObtenerSaldoCredito
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Giancarlos Gamboa S.
-- Create date: 30/08/2020
-- Description:	Obtener el monto pendiente de un usuario
-- =============================================
CREATE FUNCTION FV_ObtenerSaldoCredito 
(
	@Estado_Pendiente CHAR(3),
	@Rol VARCHAR(120),
	@Id_Usuario SMALLINT
)
RETURNS DECIMAL
AS
BEGIN
	-- Variable de retorno
	DECLARE @Result DECIMAL = 0

	-- 
	SELECT @Result = (COALESCE(SUM(CRE.Cantidad*CRE.Precio_Venta_Producto), 0))
	FROM Usuario USU
	LEFT JOIN Credito CRE ON CRE.Id_Usuario = USU.Id AND CRE.Estado = @Estado_Pendiente
	WHERE USU.Rol = @Rol
	AND USU.Id =  @Id_Usuario
	GROUP BY USU.Id

	-- Retornar el valor
	RETURN @Result

END
GO

