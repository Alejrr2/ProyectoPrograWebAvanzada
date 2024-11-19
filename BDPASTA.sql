USE [master]
GO

CREATE DATABASE [AlaPastaDatabase]
GO

USE [AlaPastaDatabase]
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

CREATE TABLE [dbo].[tCategorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCat] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tDetalles](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[ConsecutivoPed] [int] NOT NULL,
	[ConsecutivoProd] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_tDetalles] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
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

CREATE TABLE [dbo].[tPedidos](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[FechaPedido] [date] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[ConsecutivoCli] [int] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tPedidos] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

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
SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tUsuario] ADD  CONSTRAINT [UK_Identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tUsuario_tRol] FOREIGN KEY([ConsecutivoRol])
REFERENCES [dbo].[tRoles] ([IdRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [FK_tUsuario_tRol]
GO
ALTER TABLE [dbo].[tDetalles]  WITH CHECK ADD  CONSTRAINT [FK_tDetalles_tPedidos] FOREIGN KEY([ConsecutivoPed])
REFERENCES [dbo].[tPedidos] ([IdPedido])
GO
ALTER TABLE [dbo].[tDetalles] CHECK CONSTRAINT [FK_tDetalles_tPedidos]
GO
ALTER TABLE [dbo].[tDetalles]  WITH CHECK ADD  CONSTRAINT [FK_tDetalles_tProductos] FOREIGN KEY([ConsecutivoProd])
REFERENCES [dbo].[tProductos] ([IdProducto])
GO
ALTER TABLE [dbo].[tDetalles] CHECK CONSTRAINT [FK_tDetalles_tProductos]
GO
ALTER TABLE [dbo].[tPagos]  WITH CHECK ADD  CONSTRAINT [FK_tPagos_tMetodos] FOREIGN KEY([ConsecutivoMet])
REFERENCES [dbo].[tMetodos] ([IdMetodo])
GO
ALTER TABLE [dbo].[tPagos] CHECK CONSTRAINT [FK_tPagos_tMetodos]
GO
ALTER TABLE [dbo].[tPagos]  WITH CHECK ADD  CONSTRAINT [FK_tPagos_tPedidos] FOREIGN KEY([ConsecutivoPed])
REFERENCES [dbo].[tPedidos] ([IdPedido])
GO
ALTER TABLE [dbo].[tPagos] CHECK CONSTRAINT [FK_tPagos_tPedidos]
GO
ALTER TABLE [dbo].[tPedidos]  WITH CHECK ADD  CONSTRAINT [FK_tPedidos_tClientes] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[tUsuario] ([Consecutivo])
GO
ALTER TABLE [dbo].[tPedidos] CHECK CONSTRAINT [FK_tPedidos_tClientes]
GO
ALTER TABLE [dbo].[tProductos]  WITH CHECK ADD  CONSTRAINT [FK_tProductos_tCategorias] FOREIGN KEY([ConsecutivoCat])
REFERENCES [dbo].[tCategorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tProductos] CHECK CONSTRAINT [FK_tProductos_tCategorias]
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

CREATE PROCEDURE ObtenerDatosUsuario
    @Identificacion varchar(255)
AS
BEGIN
    SELECT Consecutivo, Identificacion, Nombre, Apellido, CorreoElectronico, Telefono
    FROM tUsuario
    WHERE Identificacion = @Identificacion
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

INSERT INTO [dbo].[tRoles]
           ([NombreRol])
     VALUES
           ('Administrador')
GO

INSERT INTO [dbo].[tRoles]
           ([NombreRol])
     VALUES
           ('Empleado')
GO

INSERT INTO [dbo].[tRoles]
           ([NombreRol])
     VALUES
           ('Cliente')
GO


USE [AlaPastaDatabase]
GO

INSERT INTO [dbo].[tUsuario]
           ([Identificacion]
           ,[Nombre]
           ,[Apellido]
           ,[CorreoElectronico]
           ,[Telefono]
           ,[Contrasenna]
           ,[ConsecutivoRol]
           ,[Activo]
           ,[TieneContrasennaTemp]
           ,[FechaVencimientoTemp])
     VALUES
           ('1234567890'
           ,'Juan'
           ,'Perez'
           ,'juan.perez@ejemplo.com'
           ,'123456789'
           ,'password12'
           ,1
           ,1
           ,0
           ,'2024-12-31')
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

CREATE PROCEDURE [dbo].[EliminarProducto]
	@IdProducto int
AS
BEGIN
     DELETE FROM dbo.tProductos
    WHERE IdProducto = @IdProducto;

END
GO
USE [AlaPastaDatabase]
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


GO

INSERT INTO [dbo].[tCategorias]
           ([NombreCat])
     VALUES
           ('Pasta Italiana')
GO
USE [AlaPastaDatabase]
GO

INSERT INTO [dbo].[tCategorias]
           ([NombreCat])
     VALUES
           ('Entradas')
GO



