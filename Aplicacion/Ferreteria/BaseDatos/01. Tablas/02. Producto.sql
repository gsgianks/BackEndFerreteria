USE Ferreteria
GO

IF OBJECT_ID('dbo.Producto', 'U') IS NOT NULL 
  DROP TABLE dbo.Producto; 

CREATE TABLE dbo.Producto(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Id_Proveedor] [smallint] NOT NULL,
	[Id_Categoria] [tinyint] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Precio_Costo] [decimal](18, 2) NOT NULL,
	[Precio_Venta] [decimal](18, 2) NOT NULL,
	[Utilidad] [decimal](18, 2) NOT NULL,
	[Impuesto] [decimal](18, 2) NOT NULL,
	[Stock] [smallint] NOT NULL,
	[Existencia] [smallint] NOT NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[Codigo_Barra] [varchar](250) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Usuario_Creacion] [varchar](50) NOT NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modificacion] [varchar](50) NULL,
	[Activo] [bit] NOT NULL,
)