USE Ferreteria
GO

DROP TABLE IF EXISTS Estado

CREATE TABLE Estado(
	Codigo CHAR(3) PRIMARY KEY,
	Descripcion VARCHAR(30),
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
)

INSERT INTO Estado(Codigo, Descripcion, Usuario_Creacion) VALUES('PEN', 'Pendiente', 'PriIn')
INSERT INTO Estado(Codigo, Descripcion, Usuario_Creacion) VALUES('ACT', 'Activo', 'PriIn')
INSERT INTO Estado(Codigo, Descripcion, Usuario_Creacion) VALUES('INA', 'Inactivo', 'PriIn')
INSERT INTO Estado(Codigo, Descripcion, Usuario_Creacion) VALUES('PAG', 'Pagado', 'PriIn')
