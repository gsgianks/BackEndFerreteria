/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Insertar_Pago_Credito
GO

CREATE PROCEDURE [dbo].[PA_Insertar_Pago_Credito]  
	@Estado_Pendiente CHAR(3),
	@Rol VARCHAR(120),
	@Id_Usuario SMALLINT,
	@Abono DECIMAL,
	@Usuario VARCHAR(15),
	@Estado_Pagado CHAR(3),
	@Codigo_Parametro CHAR(6),
	@pCodigoError SMALLINT OUTPUT,
	@pError VARCHAR(4000) OUTPUT
AS 
BEGIN  
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @lMonto DECIMAL = 0,
					@lId INT,
					@lDescripcion_Parametro VARCHAR(240)

			-- Obtener el saldo de 
			SET @lMonto = dbo.FV_ObtenerSaldoCredito(@Estado_Pendiente, @Rol, @Id_Usuario)

			-- Insertar el registro del pago
			INSERT INTO dbo.PagoCredito
					(Monto
					,Abono
					,Saldo
					,Fecha_Creacion
					,Usuario_Creacion
					,Estado
					,Id_Usuario)
				VALUES
					(@lMonto
					,@Abono
					,(@lMonto - @Abono)
					,GETDATE()
					,@Usuario
					,@Estado_Pagado
					,@Id_Usuario)

			-- Recuperar el id del registro de pago
			SET @lId = @@IDENTITY

			-- Actualización los créditos asociados al pago
			UPDATE Credito
				SET Id_Pago = @lId,
				Estado = @Estado_Pagado
				WHERE Id_Usuario = @Id_Usuario
				AND Estado = @Estado_Pendiente	
	 
			-- Insertar nuevo crédito si es pago parcial
			IF @lMonto > @Abono
				BEGIN

					SET @lDescripcion_Parametro = (SELECT Valor_Texto FROM ParametrosGenerales WHERE Codigo = @Codigo_Parametro)

					INSERT INTO dbo.Credito
							(Id_Usuario
							,Id_Producto
							,Nombre_Producto
							,Precio_Venta_Producto
							,Cantidad
							,Fecha_Creacion
							,Usuario_Creacion
							,Estado
							,Id_Pago_Parcial)
			
					SELECT TOP 1 @Id_Usuario
							,Id
							,@lDescripcion_Parametro
							,(@lMonto - @Abono)
							,1
							,GETDATE()
							,@Usuario
							,@Estado_Pendiente
							,@lId
					FROM Producto	
				END

		IF @@TRANCOUNT > 0
			COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION

		SET @pCodigoError = ERROR_NUMBER()  
		SET @pError = ERROR_MESSAGE() 
	END CATCH
END