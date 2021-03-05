USE Ferreteria
GO

DROP TABLE IF EXISTS Proveedor

CREATE TABLE Proveedor(
	Id INT PRIMARY KEY,
	Nombre_Proveedor VARCHAR(240) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Correo_Electronico VARCHAR(120) NOT NULL,
    Fecha_Creacion DATETIME DEFAULT GETDATE() NOT NULL,
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
    Usuario_Modificacion DATETIME NULL
)