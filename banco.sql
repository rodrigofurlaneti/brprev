USE [master]
GO

/****** Object:  Database [BRASILPREV]    Script Date: 16/03/2020 21:19:18 ******/
CREATE DATABASE [BRASILPREV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BRASILPREV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BRASILPREV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BRASILPREV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BRASILPREV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BRASILPREV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BRASILPREV] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BRASILPREV] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BRASILPREV] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BRASILPREV] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BRASILPREV] SET ARITHABORT OFF 
GO

ALTER DATABASE [BRASILPREV] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BRASILPREV] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BRASILPREV] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BRASILPREV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BRASILPREV] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BRASILPREV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BRASILPREV] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BRASILPREV] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BRASILPREV] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BRASILPREV] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BRASILPREV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BRASILPREV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BRASILPREV] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BRASILPREV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BRASILPREV] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BRASILPREV] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BRASILPREV] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BRASILPREV] SET RECOVERY FULL 
GO

ALTER DATABASE [BRASILPREV] SET  MULTI_USER 
GO

ALTER DATABASE [BRASILPREV] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BRASILPREV] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BRASILPREV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BRASILPREV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BRASILPREV] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BRASILPREV] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BRASILPREV] SET  READ_WRITE 
GO


USE [BRASILPREV]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 16/03/2020 21:19:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Logradouro] [varchar](90) NOT NULL,
	[Numero] [varchar](30) NOT NULL,
	[Complemento] [varchar](20) NOT NULL,
	[Bairro] [varchar](40) NOT NULL,
	[Cidade] [varchar](30) NOT NULL,
	[Estado] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BRASILPREV]
GO

/****** Object:  Table [dbo].[Pessoa]    Script Date: 16/03/2020 21:20:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](90) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [BRASILPREV]
GO

/****** Object:  Table [dbo].[Telefone]    Script Date: 16/03/2020 21:20:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Telefone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ddd] [varchar](2) NOT NULL,
	[Numero] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Telefone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


