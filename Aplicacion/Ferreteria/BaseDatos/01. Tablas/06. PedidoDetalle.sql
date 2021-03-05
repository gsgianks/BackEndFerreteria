USE Ferreteria
GO

DROP TABLE IF EXISTS PedidoDetalle

CREATE TABLE PedidoDetalle(
	Id INT PRIMARY KEY,
	Id_Pedido INT,
	Id_Producto INT,
	Nombre_Producto VARCHAR(240),
	Precio_Venta_Producto DECIMAL(18,2),
	Cantidad SMALLINT,
    Fecha_Creacion DATETIME DEFAULT GETDATE() NOT NULL,
	Usuario_Creacion VARCHAR(35) NOT NULL,
	Fecha_Modificacion DATETIME NULL,
    Usuario_Modificacion DATETIME NULL,
	CONSTRAINT Pedido_PedidoDetalle_FK FOREIGN KEY (Id_Pedido) REFERENCES Pedido(Id),
	CONSTRAINT Producto_PedidoDetalle_FK FOREIGN KEY (Id_Producto) REFERENCES Producto(Id)
)