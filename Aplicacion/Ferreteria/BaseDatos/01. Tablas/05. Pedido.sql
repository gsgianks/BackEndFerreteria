USE Ferreteria
GO

DROP TABLE IF EXISTS Pedido

CREATE TABLE Pedido(
	Id INT PRIMARY KEY IDENTITY,
	Id_Usuario SMALLINT,
	Nombre_Usuario VARCHAR(120),
	Direccion VARCHAR(500),
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
	CONSTRAINT Usuario_Producto_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
)