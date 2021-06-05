/****** Script for SelectTopNRows command from SSMS  ******/
USE [Ferreteria]
GO


DROP PROCEDURE IF EXISTS dbo.PA_Insertar_Pago_Credito
GO

CREATE PROCEDURE [dbo].[PA_Insertar_Pago_Credito]  
	@pEstado_Pendiente CHAR(3),
	@pRol VARCHAR(120),
	@pId_Usuario SMALLINT,
	@pAbono DECIMAL,
	@pUsuario VARCHAR(15),
	@pEstado_Pagado CHAR(3),
	@pCodigo_Parametro CHAR(6),
	@pCodigoError SMALLINT OUTPUT,
	@pError VARCHAR(4000) OUTPUT
AS 
BEGIN  
	BEGIN TRY
		BEGIN TRANSACTION
			-- Se asignan valores a los parámetros de salida
			SET @pCodigoError = 0
			SET @pError = ''
			
			DECLARE @lMonto DECIMAL(18,2) = 0,
					@lMonto_Pagar DECIMAL(18,2),
					@lId INT,
					@lDescripcion_Parametro VARCHAR(240)

			-- Obtener el saldo de 
			SET @lMonto = dbo.FV_ObtenerSaldoCredito(@pEstado_Pendiente, @pRol, @pId_Usuario)
			SET @lMonto_Pagar = @lMonto - @pAbono 

			-- Validar el monto a abonar
			IF @lMonto_Pagar < 0
			BEGIN
				
				SET @pCodigoError = 1
				SET @pError = FORMAT((@lMonto_Pagar*-1), 'N','de-DE')
				SET @pAbono = @lMonto
				
			END

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
					,@pAbono
					,(@lMonto - @pAbono)
					,GETDATE()
					,@pUsuario
					,@pEstado_Pagado
					,@pId_Usuario)

			-- Recuperar el id del registro de pago
			SET @lId = @@IDENTITY

			-- Actualización los créditos asociados al pago
			UPDATE Credito
				SET Id_Pago = @lId,
				Estado = @pEstado_Pagado
				WHERE Id_Usuario = @pId_Usuario
				AND Estado = @pEstado_Pendiente	
	 
			-- Insertar nuevo crédito si es pago parcial
			IF @lMonto > @pAbono
				BEGIN

					SET @lDescripcion_Parametro = (SELECT Valor_Texto FROM ParametrosGenerales WHERE Codigo = @pCodigo_Parametro)

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
			
					SELECT TOP 1 @pId_Usuario
							,Id
							,@lDescripcion_Parametro
							,(@lMonto - @pAbono)
							,1
							,GETDATE()
							,@pUsuario
							,@pEstado_Pendiente
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