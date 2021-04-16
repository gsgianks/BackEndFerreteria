USE Ferreteria
GO

DROP TABLE IF EXISTS Categoria

CREATE TABLE Categoria(
	Id INT PRIMARY KEY IDENTITY,
	Descripcion VARCHAR(120),
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35)
)