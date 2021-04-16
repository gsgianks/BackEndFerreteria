USE Ferreteria
GO

DROP TABLE IF EXISTS Credito

CREATE TABLE Credito(
	Id BIGINT PRIMARY KEY IDENTITY,
	Id_Usuario INT NOT NULL,
	Id_Producto INT NULL,
	Nombre_Producto VARCHAR(250) NOT NULL,
	Precio_Venta_Producto DECIMAL(18,2) NOT NULL,
	Cantidad SMALLINT,
	Id_Pago INT NULL,
	Id_Pago_Parcial INT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
	CONSTRAINT Usuario_Credito_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
	CONSTRAINT Pago_Credito_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
	CONSTRAINT Pago_Credito_2_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
)

