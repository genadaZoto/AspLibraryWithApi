USE [master]
GO
/****** Object:  Database [Library]    Script Date: 30-01-20 14:59:06 ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ADMINSQL\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.ADMINSQL\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 30-01-20 14:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[IdBook] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[ReleaseYear] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Livre] PRIMARY KEY CLUSTERED 
(
	[IdBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCopy]    Script Date: 30-01-20 14:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCopy](
	[IdBookCopy] [int] IDENTITY(1,1) NOT NULL,
	[Available] [bit] NOT NULL,
	[IdBook] [int] NOT NULL,
 CONSTRAINT [PK_Copy] PRIMARY KEY CLUSTERED 
(
	[IdBookCopy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookReservation]    Script Date: 30-01-20 14:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReservation](
	[IdBookCopy] [int] NOT NULL,
	[IdReader] [int] NOT NULL,
	[ReservationDate] [date] NOT NULL,
 CONSTRAINT [PK_BookReservation] PRIMARY KEY CLUSTERED 
(
	[IdBookCopy] ASC,
	[IdReader] ASC,
	[ReservationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 30-01-20 14:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reader](
	[IdReader] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Surname] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Adress] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Lecteur] PRIMARY KEY CLUSTERED 
(
	[IdReader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Livre] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Book] ([IdBook])
GO
ALTER TABLE [dbo].[BookCopy] CHECK CONSTRAINT [FK_Copy_Livre]
GO
ALTER TABLE [dbo].[BookReservation]  WITH CHECK ADD  CONSTRAINT [FK_BookReservation_Copy] FOREIGN KEY([IdBookCopy])
REFERENCES [dbo].[BookCopy] ([IdBookCopy])
GO
ALTER TABLE [dbo].[BookReservation] CHECK CONSTRAINT [FK_BookReservation_Copy]
GO
ALTER TABLE [dbo].[BookReservation]  WITH CHECK ADD  CONSTRAINT [FK_BookReservation_Lecteur] FOREIGN KEY([IdReader])
REFERENCES [dbo].[Reader] ([IdReader])
GO
ALTER TABLE [dbo].[BookReservation] CHECK CONSTRAINT [FK_BookReservation_Lecteur]
GO
/****** Object:  StoredProcedure [dbo].[InsertBookOfReader]    Script Date: 30-01-20 14:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBookOfReader]
-- on les passse des parametres
@IdBook int,
@IdReader int,
@ReservationDate date
AS
BEGIN
declare @IdBookCopy int
SELECT TOP 1 @IdBookCopy=IdBookCopy From BookCopy Where BookCopy.IdBook = @IdBook AND available=1
INSERT INTO BookReservation(IdBookCopy,IdReader,ReservationDate)  VALUES (@IdBookCopy,@IdReader,@ReservationDate)
Update BookCopy SET available= 0 WHERE  @IdBookCopy=IdBookCopy 
select @IdBookCopy
END
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
