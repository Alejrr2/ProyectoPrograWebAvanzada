USE [master]
GO

CREATE DATABASE [AlaPastaDatabase]
GO

USE [AlaPastaDatabase]
GO

CREATE TABLE [dbo].[tCarrito](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [int] NOT NULL,
	[ConsecutivoProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_tCarrito] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tCategorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCat] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tDirecciones](
	[IdDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Canton] [varchar](50) NOT NULL,
	[Distrito] [varchar](50) NOT NULL,
	[O_Senales] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tDirecciones] PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tMetodos](
	[IdMetodo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tMetodo] PRIMARY KEY CLUSTERED 
(
	[IdMetodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tPagos](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[FechaPago] [date] NOT NULL,
	[ConsecutivoPed] [int] NOT NULL,
	[ConsecutivoMet] [int] NOT NULL,
 CONSTRAINT [PK_tPagos] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE tPedidos (
    Consecutivo INT PRIMARY KEY IDENTITY(1,1),
    ConsecutivoUsuario INT NOT NULL,
    NombreUsuario NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200) NOT NULL,
    FechaPedido DATETIME NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente'
);

CREATE TABLE tDetallePedidos (
    ConsecutivoDetalle INT PRIMARY KEY IDENTITY(1,1),
    ConsecutivoPedido INT FOREIGN KEY REFERENCES tPedidos(Consecutivo),
    ConsecutivoProducto INT NOT NULL,
    NombreProducto NVARCHAR(100) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Total DECIMAL(10, 2) NOT NULL
);

CREATE TABLE [dbo].[tProductos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](255) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[ConsecutivoCat] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[ImagenProd] [varchar](255) NOT NULL,
	[ActivoProd] [bit] NOT NULL,
 CONSTRAINT [PK_tProductos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tPuestos](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[NombrePuesto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tPuestos] PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tRoles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tRoles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tUsuario](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[CorreoElectronico] [varchar](80) NOT NULL,
	[Telefono] [varchar](255) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[ConsecutivoRol] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[TieneContrasennaTemp] [bit] NOT NULL,
	[FechaVencimientoTemp] [datetime] NOT NULL,
 CONSTRAINT [PK_tUsuario] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tCarrito] ON 
GO
INSERT [dbo].[tCarrito] ([Consecutivo], [ConsecutivoUsuario], [ConsecutivoProducto], [Cantidad], [Fecha]) VALUES (2, 5, 1, 9, CAST(N'2024-12-16T17:55:32.857' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tCarrito] OFF
GO
SET IDENTITY_INSERT [dbo].[tCategorias] ON 
GO
INSERT [dbo].[tCategorias] ([IdCategoria], [NombreCat]) VALUES (1, N'Pasta Italiana')
GO
INSERT [dbo].[tCategorias] ([IdCategoria], [NombreCat]) VALUES (2, N'Entradas')
GO
SET IDENTITY_INSERT [dbo].[tCategorias] OFF
GO
SET IDENTITY_INSERT [dbo].[tProductos] ON 
GO
INSERT [dbo].[tProductos] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ConsecutivoCat], [Stock], [ImagenProd], [ActivoProd]) VALUES (1, N'Pasta Ravioli', N'Pasta rellena realizada con diferentes ingredientes y generalmente replegada en forma cuadrada, t?pico de la cocina italiana. Se acompa?an de alg?n tipo de salsa, en especial de tomate (similar al rag?), tucos, pesto (salsa a base de albahaca) o crema.', CAST(6500.00 AS Decimal(10, 2)), 1, 10, N'/ImagenProd/1.png', 1)
GO
SET IDENTITY_INSERT [dbo].[tProductos] OFF
GO
SET IDENTITY_INSERT [dbo].[tRoles] ON 
GO
INSERT [dbo].[tRoles] ([IdRol], [NombreRol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[tRoles] ([IdRol], [NombreRol]) VALUES (2, N'Empleado')
GO
INSERT [dbo].[tRoles] ([IdRol], [NombreRol]) VALUES (3, N'Cliente')
GO
SET IDENTITY_INSERT [dbo].[tRoles] OFF

SET IDENTITY_INSERT [dbo].[tUsuario] ON
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Nombre], [Apellido], [CorreoElectronico], [Telefono], [Contrasenna], [ConsecutivoRol], [Activo], [TieneContrasennaTemp], [FechaVencimientoTemp]) VALUES (1, N'1234567890', N'JuanCho', N'Perez', N'juan.perez@ejemplo.com', N'123456789', N'1', 1, 1, 0, CAST(N'2024-11-19T17:12:18.627' AS DateTime))
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Nombre], [Apellido], [CorreoElectronico], [Telefono], [Contrasenna], [ConsecutivoRol], [Activo], [TieneContrasennaTemp], [FechaVencimientoTemp]) VALUES (2, N'1', N'1', N'1', N'1@gmail.com', N'1', N'1', 2, 1, 0, CAST(N'2024-11-19T17:11:07.407' AS DateTime))
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Nombre], [Apellido], [CorreoElectronico], [Telefono], [Contrasenna], [ConsecutivoRol], [Activo], [TieneContrasennaTemp], [FechaVencimientoTemp]) VALUES (3, N'132332', N'1', N'1', N'1adawd@gmail.com', N'1', N'1', 3, 1, 0, CAST(N'2024-11-19T17:13:02.510' AS DateTime))
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Nombre], [Apellido], [CorreoElectronico], [Telefono], [Contrasenna], [ConsecutivoRol], [Activo], [TieneContrasennaTemp], [FechaVencimientoTemp]) VALUES (4, N'123', N'Bego', N'Giner', N'1wd@gmail.com', N'1221', N'123', 2, 1, 0, CAST(N'2024-11-19T17:49:48.070' AS DateTime))
GO
INSERT [dbo].[tUsuario] ([Consecutivo], [Identificacion], [Nombre], [Apellido], [CorreoElectronico], [Telefono], [Contrasenna], [ConsecutivoRol], [Activo], [TieneContrasennaTemp], [FechaVencimientoTemp]) VALUES (5, N'118490588', N'raquel', N'arias', N'raquelarias3102@gmail.com', N'70761941', N'123', 3, 1, 0, CAST(N'2024-12-13T15:47:10.053' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_CorreoElectronico]    Script Date: 16/12/2024 18:06:56 ******/
ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Identificacion]    Script Date: 16/12/2024 18:06:56 ******/
ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_Identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tCarrito_tProductos] FOREIGN KEY([ConsecutivoProducto])
REFERENCES [dbo].[tProductos] ([IdProducto])
GO
ALTER TABLE [dbo].[tCarrito] CHECK CONSTRAINT [FK_tCarrito_tProductos]
GO
ALTER TABLE [dbo].[tCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tCarrito_tUsuario] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[tUsuario] ([Consecutivo])
GO
ALTER TABLE [dbo].[tCarrito] CHECK CONSTRAINT [FK_tCarrito_tUsuario]
GO
GO
ALTER TABLE [dbo].[tProductos]  WITH CHECK ADD  CONSTRAINT [FK_tProductos_tCategorias] FOREIGN KEY([ConsecutivoCat])
REFERENCES [dbo].[tCategorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tProductos] CHECK CONSTRAINT [FK_tProductos_tCategorias]
GO
ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tUsuario_tRol] FOREIGN KEY([ConsecutivoRol])
REFERENCES [dbo].[tRoles] ([IdRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [FK_tUsuario_tRol]
GO

CREATE PROCEDURE [dbo].[ActualizarContrasenna]
	@ContrasennaTemp		VARCHAR(80),
	@TieneContrasennaTemp	BIT,
	@FechaVencimientoTemp	DATETIME,
	@Consecutivo			BIGINT
AS
BEGIN
	
	UPDATE	dbo.tUsuario
	   SET	Contrasenna = @ContrasennaTemp,
			TieneContrasennaTemp = @TieneContrasennaTemp,
			FechaVencimientoTemp = @FechaVencimientoTemp
	 WHERE	Consecutivo = @Consecutivo
	
END
GO

CREATE PROCEDURE [dbo].[ActualizarPerfil]
    @Identificacion     varchar(20),
    @Nombre                varchar(255),
    @Apellido                varchar(255),
    @CorreoElectronico                varchar(255),
    @Telefono                varchar(255)
AS
BEGIN
    UPDATE    dbo.tUsuario
       SET   Nombre = @Nombre,
            Apellido = @Apellido,
            CorreoElectronico = @CorreoElectronico,
            Telefono = @Telefono
     WHERE    Identificacion = @Identificacion

END
GO

CREATE PROCEDURE [dbo].[ActualizarProducto]
	@IdProducto int,
	@NombreProducto		varchar(255),
	@Descripcion		varchar(255),
	@Precio				decimal(10,2),
	@ConsecutivoCat		int,
	@Stock				int,
	@ImagenProd			varchar(255),
	@ActivoProd			bit
AS
BEGIN
    UPDATE    dbo.tProductos
       SET  NombreProducto = @NombreProducto,
            Descripcion = @Descripcion,
            Precio = @Precio,
            ConsecutivoCat = @ConsecutivoCat,
			Stock = @Stock,
			ImagenProd = @ImagenProd,
			ActivoProd = @ActivoProd
     WHERE    IdProducto = IdProducto

END
GO

CREATE PROCEDURE [dbo].[CambiarContrasenna]
	@Identificacion varchar(20),
	@Contrasenna		varchar(255),
	@TieneContrasennaTemp	bit,
	@FechaVencimientoTemp	DATETIME
AS
BEGIN
	UPDATE	dbo.tUsuario
	   SET	Contrasenna = @Contrasenna,
			TieneContrasennaTemp = @TieneContrasennaTemp,
			FechaVencimientoTemp = @FechaVencimientoTemp
	 WHERE	Identificacion = @Identificacion

END
GO

CREATE PROCEDURE [dbo].[EliminarProducto]
	@IdProducto int
AS
BEGIN
     DELETE FROM dbo.tProductos
    WHERE IdProducto = @IdProducto;

END
GO

CREATE PROCEDURE [dbo].[InicioSesion]
	@Identificacion		varchar(20),
	@Contrasenna		varchar(10)
AS
BEGIN

	SELECT	U.Consecutivo,
			Identificacion,
			Nombre,
			Apellido,
			CorreoElectronico,
			Telefono,
			Contrasenna,
			ConsecutivoRol,
			Activo,
			R.NombreRol,
			TieneContrasennaTemp,
			FechaVencimientoTemp
	  FROM	dbo.tUsuario U 
	  INNER JOIN dbo.tRoles R ON U.ConsecutivoRol = R.IdRol
	  WHERE Identificacion = @Identificacion
		AND	Contrasenna	= @Contrasenna
		AND Activo = 1

END
GO

CREATE PROCEDURE [dbo].[ObtenerDatosUsuario]
    @Identificacion varchar(255)
AS
BEGIN
    SELECT Consecutivo, Identificacion, Nombre, Apellido, CorreoElectronico, Telefono
    FROM tUsuario
    WHERE Identificacion = @Identificacion
END
GO

CREATE PROCEDURE [dbo].[RegistroEmpleado]
    @Identificacion        varchar(20),
    @Nombre                varchar(255),
    @Apellido            varchar(255),
    @CorreoElectronico    varchar(80),
    @Telefono                varchar(255),
    @Contrasenna        varchar(10)
AS
BEGIN

    IF NOT EXISTS(    SELECT    1 
                    FROM    dbo.tUsuario 
                    WHERE    Identificacion = @Identificacion
                        AND    CorreoElectronico = @CorreoElectronico)
    BEGIN
        INSERT INTO dbo.tUsuario (Identificacion,Nombre,Apellido,CorreoElectronico,Telefono,Contrasenna, ConsecutivoRol,Activo,TieneContrasennaTemp,FechaVencimientoTemp)
        VALUES (@Identificacion,@Nombre,@Apellido,@CorreoElectronico,@Telefono,@Contrasenna,2,1,0,GETDATE())
    END

END
GO


CREATE PROCEDURE [dbo].[RegistroProducto]
	@NombreProducto		varchar(255),
	@Descripcion		varchar(255),
	@Precio				decimal(10,2),
	@ConsecutivoCat		int,
	@Stock				int,
	@ImagenProd			varchar(255),
	@ActivoProd			bit
AS
BEGIN
	INSERT INTO dbo.tProductos(NombreProducto,Descripcion,Precio,ConsecutivoCat,Stock,ImagenProd, ActivoProd)
	VALUES (@NombreProducto,@Descripcion,@Precio,@ConsecutivoCat,@Stock,@ImagenProd,1)

END
GO


CREATE PROCEDURE [dbo].[RegistroUsuario]
	@Identificacion		varchar(20),
	@Nombre				varchar(255),
	@Apellido			varchar(255),
	@CorreoElectronico	varchar(80),
	@Telefono				varchar(255),
	@Contrasenna		varchar(10)
AS
BEGIN

	IF NOT EXISTS(	SELECT	1 
					FROM	dbo.tUsuario 
					WHERE	Identificacion = @Identificacion
						AND	CorreoElectronico = @CorreoElectronico)
	BEGIN
		INSERT INTO dbo.tUsuario (Identificacion,Nombre,Apellido,CorreoElectronico,Telefono,Contrasenna, ConsecutivoRol,Activo,TieneContrasennaTemp,FechaVencimientoTemp)
		VALUES (@Identificacion,@Nombre,@Apellido,@CorreoElectronico,@Telefono,@Contrasenna,3,1,0,GETDATE())
	END

END
GO

ALTER TABLE tCarrito
DROP CONSTRAINT FK_tCarrito_tProductos;

ALTER TABLE tCarrito
ADD CONSTRAINT FK_tCarrito_tProductos
FOREIGN KEY (ConsecutivoProducto) REFERENCES tProductos(IdProducto)
ON DELETE CASCADE;



CREATE TABLE tContactos (
    Id_Contacto INT PRIMARY KEY IDENTITY(1,1),
	NombreContacto NVARCHAR(100) NOT NULL,
    NumeroTel INT NOT NULL,
    Comentario NVARCHAR(100) NOT NULL,
);