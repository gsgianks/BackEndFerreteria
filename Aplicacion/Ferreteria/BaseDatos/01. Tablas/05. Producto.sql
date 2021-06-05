USE Ferreteria
GO

IF OBJECT_ID('dbo.Producto', 'U') IS NOT NULL 
  DROP TABLE dbo.Producto; 

CREATE TABLE dbo.Producto(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Id_Proveedor] INT NOT NULL,
	[Id_Categoria] INT NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Precio_Costo] [decimal](18, 2) NOT NULL,
	[Precio_Venta] [decimal](18, 2) NOT NULL,
	[Utilidad] [decimal](18, 2) NOT NULL,
	[Impuesto] [decimal](18, 2) NOT NULL,
	[Stock] [smallint] NOT NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[Codigo_Barra] [varchar](250) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Usuario_Creacion] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modificacion] [varchar](50) NULL,
	[Estado] VARCHAR(3) NOT NULL,
	CONSTRAINT Proveedor_Producto_FK FOREIGN KEY (Id_Proveedor) REFERENCES Proveedor(Id),
	CONSTRAINT Categoria_Producto_FK FOREIGN KEY (Id_Categoria) REFERENCES Categoria(Id),
)