USE Ferreteria
GO

DROP TABLE IF EXISTS ParametrosGenerales

CREATE TABLE ParametrosGenerales(
	Codigo VARCHAR(12) PRIMARY KEY,
	Valor_Texto VARCHAR(120) NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
)