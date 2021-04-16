USE Ferreteria
GO

DROP TABLE IF EXISTS Usuario

CREATE TABLE Usuario(
	Id INT PRIMARY KEY IDENTITY,
	Identificacion VARCHAR(15) NOT NULL UNIQUE,-- REVISAR EL TAMA�O DE PASAPORTE
	Nombre VARCHAR(120) NOT NULL,
	Celular VARCHAR(10) NOT NULL,
	Telefono VARCHAR(10),
	Correo_Electronico VARCHAR(120) NOT NULL,
	Direccion VARCHAR(500) NULL,
	Rol VARCHAR(200),
	Contrasena VARCHAR(20) NOT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
	Usuario_Modificacion VARCHAR(35),
	Estado CHAR(3)
	
)

INSERT INTO Usuario(Identificacion, Nombre, Celular, Telefono, Correo_Electronico, Direccion, Rol, Contrasena, Estado, Usuario_Creacion)
VALUES('702380702', 'Giancarlos Gamboa Salazar', '89355180', '27631067', 'gsgiank@gmail.com', 'Roxana, Limon, Costa Rica', 'Administrator', '1234', 'ACT', 'Inicio')