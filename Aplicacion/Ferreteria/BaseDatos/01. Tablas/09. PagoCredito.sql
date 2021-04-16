USE Ferreteria
GO

DROP TABLE IF EXISTS PagoCredito

CREATE TABLE PagoCredito(
	Id INT PRIMARY KEY IDENTITY,
	Id_Usuario INT NOT NULL,
	Monto DECIMAL(18,2) NOT NULL,
	Abono DECIMAL(18,2) NOT NULL,
	Saldo DECIMAL(18,2) NOT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
	CONSTRAINT Usuario_PagoCreditos_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
)


  