USE Ferreteria
GO

DROP TABLE IF EXISTS Pedido

CREATE TABLE Pedido(
	Id INT PRIMARY KEY IDENTITY,
	Id_Usuario INT NOT NULL,
	Nombre_Usuario VARCHAR(120) NOT NULL,
	Direccion VARCHAR(500) NOT NULL,
	Estado CHAR(3) NOT NULL,
	Fecha_Entrega DATE NOT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
	CONSTRAINT Usuario_Pedido_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
)