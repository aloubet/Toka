USE [master]
GO
/****** Object:  Database [TakaSat]    Script Date: 22/02/2021 06:20:13 a. m. ******/
CREATE DATABASE [TakaSat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TakaSat', FILENAME = N'C:\Users\ALOPEZ\TakaSat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TakaSat_log', FILENAME = N'C:\Users\ALOPEZ\TakaSat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TakaSat] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TakaSat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TakaSat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TakaSat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TakaSat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TakaSat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TakaSat] SET ARITHABORT OFF 
GO
ALTER DATABASE [TakaSat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TakaSat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TakaSat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TakaSat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TakaSat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TakaSat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TakaSat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TakaSat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TakaSat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TakaSat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TakaSat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TakaSat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TakaSat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TakaSat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TakaSat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TakaSat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TakaSat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TakaSat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TakaSat] SET  MULTI_USER 
GO
ALTER DATABASE [TakaSat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TakaSat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TakaSat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TakaSat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TakaSat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TakaSat] SET QUERY_STORE = OFF
GO
USE [TakaSat]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TakaSat]
GO
/****** Object:  Table [dbo].[PersonasFisicas]    Script Date: 22/02/2021 06:20:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonasFisicas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPat] [varchar](50) NULL,
	[ApellidoMat] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Nacionalidad] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCreador] [int] NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModifica] [int] NOT NULL,
 CONSTRAINT [PK_PersonasFisicas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 22/02/2021 06:20:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ApellidoPaterno] [varchar](50) NOT NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreador] [int] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModifica] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PersonasFisicas] ON 

INSERT [dbo].[PersonasFisicas] ([Id], [Nombre], [ApellidoPat], [ApellidoMat], [Direccion], [Nacionalidad], [FechaCreacion], [UsuarioCreador], [FechaModificacion], [UsuarioModifica]) VALUES (9, N'Carlos', N'Marin', N'Zapata', N'Valle de los Molinos', N'Canadiense', CAST(N'2021-02-22T01:20:35.000' AS DateTime), 1, CAST(N'2021-02-22T06:12:19.537' AS DateTime), 1)
INSERT [dbo].[PersonasFisicas] ([Id], [Nombre], [ApellidoPat], [ApellidoMat], [Direccion], [Nacionalidad], [FechaCreacion], [UsuarioCreador], [FechaModificacion], [UsuarioModifica]) VALUES (11, N'Sara', N'Gutierrez', N'Ruiz', N'Plaza del Sol', N'Mexicana', CAST(N'2021-02-22T01:26:17.863' AS DateTime), 1, CAST(N'2021-02-22T01:26:17.863' AS DateTime), 1)
INSERT [dbo].[PersonasFisicas] ([Id], [Nombre], [ApellidoPat], [ApellidoMat], [Direccion], [Nacionalidad], [FechaCreacion], [UsuarioCreador], [FechaModificacion], [UsuarioModifica]) VALUES (12, N'Luis', N'Castillo', N'Zepeda', N'Valle de los Molinos', N'Mexicana', CAST(N'2021-02-22T06:13:16.807' AS DateTime), 1, CAST(N'2021-02-22T06:13:16.807' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PersonasFisicas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Usuario], [Password], [FechaCreacion], [UsuarioCreador], [FechaModificacion], [UsuarioModifica]) VALUES (1, N'Abraham', N'Lopez', N'Loubet', N'ALoubet', N'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAm3Yj93FPRkGiFHrZgxAiOQAAAAACAAAAAAADZgAAwAAAABAAAADOCd9d0caGD1uoZWhK9SkMAAAAAASAAACgAAAAEAAAAL+Qc/BCOxYSavzOoAAR8dcQAAAAA35lvYpz4Uz5pyX5xghB3BQAAAD2G4nPqfvqk0grx751Af48VI9zZQ==', CAST(N'2021-02-21T00:00:00.000' AS DateTime), 1, CAST(N'2021-02-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Usuarios] ([Id], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Usuario], [Password], [FechaCreacion], [UsuarioCreador], [FechaModificacion], [UsuarioModifica]) VALUES (3, N'Jose', N'Hernandez', N'Murguia', N'JHernandez', N'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAm3Yj93FPRkGiFHrZgxAiOQAAAAACAAAAAAADZgAAwAAAABAAAADOCd9d0caGD1uoZWhK9SkMAAAAAASAAACgAAAAEAAAAL+Qc/BCOxYSavzOoAAR8dcQAAAAA35lvYpz4Uz5pyX5xghB3BQAAAD2G4nPqfvqk0grx751Af48VI9zZQ==', CAST(N'2021-02-21T00:00:00.000' AS DateTime), 1, CAST(N'2021-02-21T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[PersonasFisicas]  WITH CHECK ADD  CONSTRAINT [FK_PersonasFisicas_Usuarios] FOREIGN KEY([UsuarioCreador])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[PersonasFisicas] CHECK CONSTRAINT [FK_PersonasFisicas_Usuarios]
GO
ALTER TABLE [dbo].[PersonasFisicas]  WITH CHECK ADD  CONSTRAINT [FK_PersonasFisicas_Usuarios1] FOREIGN KEY([UsuarioModifica])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[PersonasFisicas] CHECK CONSTRAINT [FK_PersonasFisicas_Usuarios1]
GO
USE [master]
GO
ALTER DATABASE [TakaSat] SET  READ_WRITE 
GO
