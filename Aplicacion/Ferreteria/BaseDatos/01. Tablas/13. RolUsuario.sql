USE Ferreteria
GO

DROP TABLE IF EXISTS RolUsuario

CREATE TABLE RolUsuario(
	Id_Usuario INT NOT NULL,
	Codigo_Rol CHAR(3) NOT NULL,
	Fecha_Creacion DATETIME NOT NULL DEFAULT GETDATE(),
	Usuario_Creacion VARCHAR(35) NOT NULL,
	CONSTRAINT Usuario_RolUsuario_FK FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
	CONSTRAINT Rol_RolUsuario_FK FOREIGN KEY (Codigo_Rol) REFERENCES Rol(Codigo),
	PRIMARY KEY(Id_Usuario, Codigo_Rol)
)


INSERT INTO RolUsuario(Id_Usuario, Codigo_Rol, Usuario_Creacion) VALUES(1, 'ADM', 'PriIn')
INSERT INTO RolUsuario(Id_Usuario, Codigo_Rol, Usuario_Creacion) VALUES(2, 'CRE', 'PriIn')
