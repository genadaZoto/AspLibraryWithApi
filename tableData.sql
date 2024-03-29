USE [master]
GO
/****** Object:  Database [Library]    Script Date: 09-02-20 22:27:24 ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [Library] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[Book]    Script Date: 09-02-20 22:27:25 ******/
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
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Livre] PRIMARY KEY CLUSTERED 
(
	[IdBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCopy]    Script Date: 09-02-20 22:27:25 ******/
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
/****** Object:  Table [dbo].[BookReservation]    Script Date: 09-02-20 22:27:25 ******/
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
	[IdReader] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 09-02-20 22:27:25 ******/
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
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (1, N'Mark Twain', N'Huckleberry Finn (Fictitious character),Male friendship,Adventure and adventures,Spanish language books,Readers,Runaway children,Fiction,Child witnesses,Relatos de aventura,Juvenile literature,Adventure stories,Race relations,American Adventure stories,Specimens,Facsimiles,Boys,Tom Sawyer (Fictitious character),Historical fiction,Dummies (Bookselling),Manuscripts,Readers for new literates,Mississippi River,Children''s stories, American,Adventure and adventurers,High interest-low vocabulary books,Ficciu00f3n juvenil,open_syllabus_project,Children''s stories,Missouri,Sawyer, Tom (Personaje literario),Muchachos,Cartoons and comics,History,Social life and customs,Niu00f1os,Translations into Russian,Translations into Polish,Juvenile fiction,History and criticism,Spanish language,Translations into Czech,Fugitive slaves,American Manuscripts,Boys -- Missouri -- Fiction,Novels, other prose & writers: 19th century,Mississippi River -- Fiction,', N'Includes bibliographical references (p. 213-216).', N'https://covers.openlibrary.org/b/id/295577-L.jpg', 1997, N'The adventures of Tom Sawyer', 1)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (7, N'Lucy Gordon', N'In library', N'Harlequin Romance', N'https://covers.openlibrary.org/b/id/214291-L.jpg', 0, N'Her Italian Boss''s Agenda', 2)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (8, N'Barbara Hill Rigney', N'Internet Archive Wishlist,Criticism and interpretation,Women and literature,History,Critique et interpru00e9tation,Femmes et littu00e9rature,Histoire,', N'Bibliography: p. 139-141.nnIncludes index.', N'https://covers.openlibrary.org/b/id/9256068-L.jpg', 1987, N'Margaret Atwood', 3)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (9, N'David M. Collopy', N'C (Computer program language),C++ (Computer program language),', N'Includes index.nnAccompanied by a CD-ROM disk.', N'https://covers.openlibrary.org/b/id/9261012-L.jpg', 2003, N'Introduction to C programming', 4)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (13, N'Ernest Ropiequet Hilgard', N'In library,Psychology,Psicologia,Accessible book,Einfu00fchrung,Textbooks,Psychology textbooks,Psychologie,Humanities textbooks,Protected DAISY,', N'Bibliography: p. [619]-639.nIncludes index.', N'https://covers.openlibrary.org/b/id/6618073-L.jpg', 1975, N'Introduction to psychology', 5)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (14, N'Cecie Starr Ralph , Taggart Starr ', N'Biology,Textbooks,Biology textbooks,Accessible book,In library,Human biology,Biologie,Protected DAISY,Science textbooks,Physiology,Science/Mathematics,', N'Includes bibliographical references and index.', N'https://covers.openlibrary.org/b/id/6642203-L.jpg', 1991, N'Biology', 6)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (16, N'Sarah Schulman ', N'Difference (Psychology),Social psychology,Conflict management,Social conflict,', N'Includes bibliographical references (pages 287-290).', N'https://covers.openlibrary.org/b/id/9255836-L.jpg', 2016, N'Conflict is not abuse', 7)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (17, N'Antonia Zehler ', N'Bears,Fiction,Friendship,Tea,Protected DAISY,Juvenile fiction,Conflict management,', N'Preschool-grade 1.', N'https://covers.openlibrary.org/b/id/233716-L.jpg', 2002, N'Two fine ladies', 8)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (19, N'Denys Cazet ', N'Fiction,Juvenile fiction,Humorous stories,Tractors,Cows,Farm life,Friendship,', N'Reprint. Originally published by DK, Inc., c1998.', N'https://covers.openlibrary.org/b/id/8667824-L.jpg', 1999, N'Minnie and Moo go to the moon', 9)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (23, N'Morgan, Robin. Robin Morgan ', N'Terrorism,Women terrorists,Government policy,Feminism,Accessible book,Protected DAISY,Femmes terroristes,Terrorisme,Politique gouvernementale,Fu00e9minisme,In library,Terroristin,Terrorismus,', N'Includes bibliographical references (p. 371-373) and index.', N'https://covers.openlibrary.org/b/id/477530-L.jpg', 2001, N'The demon lover', 10)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (25, N'Angela Barron McBride ', N'Social conditions,Internet Archive Wishlist,Psychology,Feminism,Women,Social Conditions,', N'Includes bibliographical references.', N'https://covers.openlibrary.org/b/id/8143812-L.jpg', 1976, N'A married feminist', 11)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (28, N'Benjamin Hulme-Cross ', N'Horror tales', N'7+.', N'https://covers.openlibrary.org/b/id/8274253-L.jpg', 2013, N'House of memories', 12)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (29, N'Jane Austen ', N'Correspondence,English Novelists,', N'Bibliography: p. 213-214.rnIncludes indexes.', N'https://covers.openlibrary.org/b/id/8229954-L.jpg', 1985, N'Selected letters, 1796-1817', 13)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (31, N'John Martin Robinson ', N'Manors,Country homes,', N'Includes bibliographies and index.', N'https://covers.openlibrary.org/b/id/8407934-L.jpg', 1984, N'The latest country houses', 14)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (32, N'Marcus Binney ', N'In library,Manors,Gardens,Country homes,', N'Includes bibliographical references (p. 222) and index.', N'https://covers.openlibrary.org/b/id/643588-L.jpg', 1998, N'Houses and gardens of Portugal', 15)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (36, N'Genevieve Davis Ginsburg ', N'In library,Widows,Life skills guides,Protected DAISY,', N'Originally published: To live again : Los Angeles : T.P. Tarcher, 1987.nIncludes index.', N'https://covers.openlibrary.org/b/id/8364976-L.jpg', 1997, N'Widow to widow', 16)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (40, N'J. R. Block ', N'Optical illusions,Visual perception,Accessible book,Protected DAISY,In library,', N'Includes bibliographical references (p. 241-244).', N'https://covers.openlibrary.org/b/id/8042515-L.jpg', 1989, N'Can you believe your eyes?', 17)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (41, N'James Q. Wilson,  John J. DiIulio, Jr. ', N'Accessible book,Constitution,Local government,Politics and government,Politique et gouvernement,Protected DAISY,Pru00e9sidents,State governments,Study and teaching (Secondary),Textbooks,Offentlig meningsdannelse,Pru00e6sidenter,USA,Interesseorganisationer,Valg,Politiske systemer,Frihedsrettigheder,Politiske partier,Politiske forhold,Forfatninger,Parlamenter,Regeringer,Retssystemer,In library,', N'Includes bibliographical references and index.', N'https://covers.openlibrary.org/b/id/3701725-L.jpg', 2000, N'American government', 18)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (42, N'Irving Louis Horowitz ', N'Political sociology,Politics and government,Ideology,Sociology,Polarity (Philosophy),Soziales System,Sociologie,Sociologie politique,Politische Soziologie,Contraires (Logique),Politique et gouvernement,Ideologie,Politik,Politisches System,', N'Bibliography: p. [303]-321.nIncludes index.', N'https://covers.openlibrary.org/b/id/4231685-L.jpg', 1984, N'Winners and losers', 19)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (43, N'Lewis Joachim Edinger Lewis J. Edinger ', N'Politics and government,Politisches System,Politique et gouvernement,Politik,Politiek,Overheidsbeleid,', N'Bibliography: p. [331]-334.nIncludes index.', N'https://covers.openlibrary.org/b/id/4142447-L.jpg', 1986, N'West German politics', 20)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (44, N'Kellas, James G. ', N'Politics and government,Politisches System,Politique et gouvernement,', N'Bibliography: p. 276-278.nIncludes index.', N'https://covers.openlibrary.org/b/id/8456500-L.jpg', 1984, N'The Scottish political system', 21)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (49, N'George, Charles ', N'Juvenile literature,Protected DAISY,In library,', N'Includes bibliographical references (p. 136-137) and index.', N'https://covers.openlibrary.org/b/id/1262220-L.jpg', 1999, N'Mississippi', 22)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (51, N'Jill Bailey Steve Parker ', N'Birds,Juvenile literature,Identification,Herbivores,Granivores,Food,Protected DAISY,Accessible book,Birds & birdwatching,Children''s Books/Ages 9-12 Nonfiction,Nature/Ecology,Reference - Encyclopedias,Animals - Birds,', N'Includes index.', N'https://covers.openlibrary.org/b/id/800186-L.jpg', 0, N'Birds', 23)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (54, N'Mary Firestone ', N'Internet Archive Wishlist,Endangered species,Juvenile literature,Elephants,', N'Includes bibliographical references and index.', N'https://covers.openlibrary.org/b/id/8207161-L.jpg', 0, N'Top 50 reasons to care about elephants', 24)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (55, N'Michael Herschell ', N'Internet Archive Wishlist,Juvenile literature,Endangered species,', N'Includes index.', N'https://covers.openlibrary.org/b/id/3882740-L.jpg', 0, N'Animals in danger', 25)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (58, N'Kathy Lancaster ', N'Parenting,Adopted children,In library,Protected DAISY,', N'Includes bibliographical references (p. 181-183) and index.', N'https://covers.openlibrary.org/b/id/602194-L.jpg', 0, N'Keys to parenting an adopted child', 26)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (67, N'Cindi McMenamin ', N'Christian women,Health and hygiene,Religious life,RELIGION / Christian Life / General,', N'Includes bibliographical references.', N'https://covers.openlibrary.org/b/id/1368212-L.jpg', 0, N'When you''re running on empty', 27)
INSERT [dbo].[Book] ([IdBook], [Author], [Category], [Description], [Image], [ReleaseYear], [Title], [Position]) VALUES (69, N'Rhonda Rhea ', N'Christian life,Family,Religious life,Families,', N'Includes bibliographical references (p.         ).', N'https://covers.openlibrary.org/b/id/532924-L.jpg', 0, N'Who put the cat in the fridge?', 28)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookCopy] ON 

INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (1, 1, 1)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (2, 1, 1)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (3, 1, 1)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (4, 1, 1)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (5, 1, 1)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (6, 1, 7)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (7, 1, 7)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (8, 1, 7)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (9, 1, 7)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (10, 1, 7)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (12, 1, 8)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (13, 1, 8)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (14, 1, 8)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (15, 1, 8)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (16, 1, 9)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (17, 1, 9)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (18, 1, 9)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (19, 1, 9)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (20, 1, 9)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (21, 1, 13)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (22, 1, 13)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (23, 1, 13)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (24, 1, 13)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (25, 1, 13)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (26, 1, 14)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (27, 1, 14)
INSERT [dbo].[BookCopy] ([IdBookCopy], [Available], [IdBook]) VALUES (28, 1, 14)
SET IDENTITY_INSERT [dbo].[BookCopy] OFF
SET IDENTITY_INSERT [dbo].[Reader] ON 

INSERT [dbo].[Reader] ([IdReader], [Name], [Surname], [Email], [Adress], [Password]) VALUES (1, N'Genada Zoto', N'Zoto', N'genadazoto@hotmail.com', N'rue max roos, 56', N'3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2')
SET IDENTITY_INSERT [dbo].[Reader] OFF
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
/****** Object:  StoredProcedure [dbo].[InsertBookOfReader]    Script Date: 09-02-20 22:27:25 ******/
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
