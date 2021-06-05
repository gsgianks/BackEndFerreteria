USE Ferreteria
GO

DROP TABLE IF EXISTS Rol

CREATE TABLE Rol(
	Codigo CHAR(3) PRIMARY KEY,
	Descripcion VARCHAR(120) NOT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
)



INSERT INTO Rol(Codigo, Descripcion, Usuario_Creacion) VALUES('ADM', 'Administrador', 'PriIn')
INSERT INTO Rol(Codigo, Descripcion, Usuario_Creacion) VALUES('CRE' ,'Credito', 'PriIn')
