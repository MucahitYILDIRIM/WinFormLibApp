USE [LibraryApp]
GO
/****** Object:  UserDefinedFunction [dbo].[GetBookId]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[GetBookId]
(

)
RETURNS int
AS
BEGIN
	DECLARE @bookId int;
	SELECT @bookId=MAX(Book.bookId) FROM dbo.Book;
	RETURN @bookId;

END

GO
/****** Object:  UserDefinedFunction [dbo].[GetBookTypeId]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetBookTypeId]
(
	@P_bookType Varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @bookTypeId int;

	SELECT @bookTypeId = BookType.typeId
	FROM dbo.BookType
	Where BookType.typeName = @P_bookType

	RETURN @bookTypeId;

END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryId]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[GetCategoryId]
(
	@P_category Varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @P_categoryId int;

	SELECT @P_categoryId = Category.categoryId
	FROM dbo.Category
	Where Category.categoryName = @P_category

	RETURN @P_categoryId;

END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetPrinteryId]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetPrinteryId]
(
	@P_printeryName Varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @printeryId int;

	SELECT @printeryId = Printery.printeryId
	FROM dbo.Printery
	Where Printery.printeryName = @P_printeryName

	RETURN @printeryId;

END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetWriterId]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetWriterId]
(
	@P_writerName Varchar(50),
	@P_writerSurname Varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @writerId int;

	SELECT @writerId = Writer.personId
	FROM dbo.Writer 
	INNER JOIN Person on Writer.personId = Person.personId
	WHERE Person.Name = @P_writerName AND Person.Surname = @P_writerSurname AND Person.isWriter = 1;

	RETURN @writerId;

END;

GO
/****** Object:  UserDefinedFunction [dbo].[isExistsWriter]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[isExistsWriter]
(
	@P_writerName Varchar(50),
	@P_writerSurname Varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @isExists int;

	SELECT @isExists = Count(*) 
	FROM dbo.Writer 
	INNER JOIN Person on Writer.personId = Person.personId
	WHERE Person.Name = @P_writerName AND Person.Surname = @P_writerSurname AND Person.isWriter = 1;

	RETURN @isExists;

END;

GO
/****** Object:  Table [dbo].[Adress]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[adressId] [int] IDENTITY(1,1) NOT NULL,
	[townId] [int] NOT NULL,
	[adres] [varchar](150) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[adressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[bookId] [int] IDENTITY(1,1) NOT NULL,
	[bookName] [nvarchar](50) NOT NULL,
	[printeryDate] [date] NOT NULL,
	[writerId] [int] NOT NULL,
	[printeryId] [int] NOT NULL,
	[bookTypeId] [int] NOT NULL,
	[hirePrice] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[bookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[bookCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NOT NULL,
	[bookId] [int] NOT NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[bookCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookType]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookType](
	[typeId] [int] IDENTITY(1,1) NOT NULL,
	[typeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BookType] PRIMARY KEY CLUSTERED 
(
	[typeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[cityId] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hire]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hire](
	[hireId] [int] IDENTITY(1,1) NOT NULL,
	[responseTime] [date] NOT NULL,
	[price] [int] NOT NULL,
	[isBack] [tinyint] NOT NULL,
	[bookId] [int] NOT NULL,
	[personId] [int] NOT NULL,
 CONSTRAINT [PK_Hire] PRIMARY KEY CLUSTERED 
(
	[hireId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[personId] [int] NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[bookNumber] [int] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[personId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[isMember] [tinyint] NOT NULL,
	[isWriter] [tinyint] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Printery]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Printery](
	[printeryId] [int] IDENTITY(1,1) NOT NULL,
	[printeryName] [nvarchar](50) NOT NULL,
	[adressId] [int] NULL,
 CONSTRAINT [PK_Printery] PRIMARY KEY CLUSTERED 
(
	[printeryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Town]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[townId] [int] IDENTITY(1,1) NOT NULL,
	[townName] [nvarchar](50) NOT NULL,
	[cityId] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[townId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Writer]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Writer](
	[personId] [int] NOT NULL,
	[bookNumber] [int] NOT NULL,
 CONSTRAINT [PK_Writer] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Adress] ON 

INSERT [dbo].[Adress] ([adressId], [townId], [adres]) VALUES (1, 1, N'Fevzi Çakmak Mh., 756. Sk No:4, 34250 ')
INSERT [dbo].[Adress] ([adressId], [townId], [adres]) VALUES (2, 2, N'Kemalpasa Mah. 191.Sk No:9 D:4')
INSERT [dbo].[Adress] ([adressId], [townId], [adres]) VALUES (3, 5, N'Kemalpasa Mah. No:252')
INSERT [dbo].[Adress] ([adressId], [townId], [adres]) VALUES (4, 6, N'Selam Sok. No:3')
INSERT [dbo].[Adress] ([adressId], [townId], [adres]) VALUES (5, 5, N'Deli Sokak. No: 48')
SET IDENTITY_INSERT [dbo].[Adress] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (2, N'Beyaz Dis', CAST(N'1998-07-29' AS Date), 19, 2, 1, 3)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (3, N'Kara Dis', CAST(N'1998-07-29' AS Date), 19, 2, 1, 3)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (4, N'Sari Dis', CAST(N'2018-11-27' AS Date), 19, 1, 1, 7)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (5, N'How to code in C', CAST(N'2008-09-09' AS Date), 20, 1, 3, 2)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (6, N'How to code in C#', CAST(N'2008-09-09' AS Date), 20, 1, 3, 2)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (7, N'Kalem', CAST(N'2018-12-16' AS Date), 21, 5, 3, 3)
INSERT [dbo].[Book] ([bookId], [bookName], [printeryDate], [writerId], [printeryId], [bookTypeId], [hirePrice]) VALUES (8, N'xcvsdv', CAST(N'2018-12-16' AS Date), 22, 3, 3, 13)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (1, 1, 3)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (2, 2, 3)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (3, 1, 4)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (4, 2, 4)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (5, 4, 4)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (6, 2, 5)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (7, 4, 5)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (8, 2, 6)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (9, 4, 6)
INSERT [dbo].[BookCategory] ([bookCategoryId], [categoryId], [bookId]) VALUES (11, 3, 8)
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
SET IDENTITY_INSERT [dbo].[BookType] ON 

INSERT [dbo].[BookType] ([typeId], [typeName]) VALUES (1, N'Roman')
INSERT [dbo].[BookType] ([typeId], [typeName]) VALUES (2, N'Şiir')
INSERT [dbo].[BookType] ([typeId], [typeName]) VALUES (3, N'Boyama')
INSERT [dbo].[BookType] ([typeId], [typeName]) VALUES (4, N'Masal')
INSERT [dbo].[BookType] ([typeId], [typeName]) VALUES (5, N'Deneme')
SET IDENTITY_INSERT [dbo].[BookType] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([categoryId], [categoryName]) VALUES (1, N'Polisiye')
INSERT [dbo].[Category] ([categoryId], [categoryName]) VALUES (2, N'Dram')
INSERT [dbo].[Category] ([categoryId], [categoryName]) VALUES (3, N'Komedi')
INSERT [dbo].[Category] ([categoryId], [categoryName]) VALUES (4, N'Korku')
INSERT [dbo].[Category] ([categoryId], [categoryName]) VALUES (5, N'Eğlence')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([cityId], [cityName]) VALUES (1, N'İstanbul')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (2, N'Sakarya')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (3, N'Ankara')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (4, N'Adıyaman')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (5, N'Adana')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (6, N'Erzurum')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (7, N'Çankırı')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (8, N'Sinop')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (9, N'Mersin')
INSERT [dbo].[City] ([cityId], [cityName]) VALUES (10, N'Zonguldak')
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Hire] ON 

INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (1, CAST(N'2018-12-23' AS Date), 3, 1, 7, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (2, CAST(N'2018-12-23' AS Date), 2, 1, 5, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (3, CAST(N'2018-12-23' AS Date), 2, 1, 5, 2)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (4, CAST(N'2018-12-23' AS Date), 2, 1, 6, 2)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (5, CAST(N'2018-12-23' AS Date), 2, 1, 5, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (6, CAST(N'2018-12-23' AS Date), 2, 1, 6, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (7, CAST(N'2018-12-23' AS Date), 2, 1, 5, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (8, CAST(N'2018-12-23' AS Date), 3, 1, 3, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (9, CAST(N'2018-12-23' AS Date), 2, 1, 5, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (10, CAST(N'2018-12-23' AS Date), 3, 0, 2, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (11, CAST(N'2018-12-23' AS Date), 2, 1, 5, 17)
INSERT [dbo].[Hire] ([hireId], [responseTime], [price], [isBack], [bookId], [personId]) VALUES (12, CAST(N'2018-12-23' AS Date), 13, 0, 8, 17)
SET IDENTITY_INSERT [dbo].[Hire] OFF
INSERT [dbo].[Member] ([personId], [userName], [password], [bookNumber]) VALUES (2, N'myildi65', N'123456', 0)
INSERT [dbo].[Member] ([personId], [userName], [password], [bookNumber]) VALUES (12, N'myazicio', N'654321', 0)
INSERT [dbo].[Member] ([personId], [userName], [password], [bookNumber]) VALUES (17, N'admin', N'admin', 3)
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (2, N'Mücahit', N'YILDIRIM', 1, 0)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (12, N'Musa Can', N'YAZICIOGLU', 1, 0)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (17, N'admin', N'admin', 1, 0)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (18, N'Stefan', N'Zweig', 0, 1)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (19, N'Jack', N'London', 0, 1)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (20, N'Harun Resit', N'Heybet', 0, 1)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (21, N'Onur', N'Bolukbas', 0, 1)
INSERT [dbo].[Person] ([personId], [Name], [Surname], [isMember], [isWriter]) VALUES (22, N'svd', N'dsv', 0, 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Printery] ON 

INSERT [dbo].[Printery] ([printeryId], [printeryName], [adressId]) VALUES (1, N'Can', 1)
INSERT [dbo].[Printery] ([printeryId], [printeryName], [adressId]) VALUES (2, N'Ekinezya', 2)
INSERT [dbo].[Printery] ([printeryId], [printeryName], [adressId]) VALUES (3, N'Hilal', 3)
INSERT [dbo].[Printery] ([printeryId], [printeryName], [adressId]) VALUES (4, N'Onur', 4)
INSERT [dbo].[Printery] ([printeryId], [printeryName], [adressId]) VALUES (5, N'Bardak', 5)
SET IDENTITY_INSERT [dbo].[Printery] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (1, N'Gaziosmanpaşa', 1)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (2, N'Serdivan', 2)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (3, N'Başakşehir', 1)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (4, N'Orta', 7)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (5, N'Erfelek', 8)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (6, N'Yenimahalle', 3)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (8, N'Bahçelievler', 3)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (9, N'Bahçelievler', 1)
INSERT [dbo].[Town] ([townId], [townName], [cityId]) VALUES (10, N'Salihli', 4)
SET IDENTITY_INSERT [dbo].[Town] OFF
INSERT [dbo].[Writer] ([personId], [bookNumber]) VALUES (18, 0)
INSERT [dbo].[Writer] ([personId], [bookNumber]) VALUES (19, 3)
INSERT [dbo].[Writer] ([personId], [bookNumber]) VALUES (20, 2)
INSERT [dbo].[Writer] ([personId], [bookNumber]) VALUES (21, 1)
INSERT [dbo].[Writer] ([personId], [bookNumber]) VALUES (22, 1)
ALTER TABLE [dbo].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_Town] FOREIGN KEY([townId])
REFERENCES [dbo].[Town] ([townId])
GO
ALTER TABLE [dbo].[Adress] CHECK CONSTRAINT [FK_Adress_Town]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookType] FOREIGN KEY([bookTypeId])
REFERENCES [dbo].[BookType] ([typeId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookType]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Printery] FOREIGN KEY([printeryId])
REFERENCES [dbo].[Printery] ([printeryId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Printery]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Writer] FOREIGN KEY([writerId])
REFERENCES [dbo].[Writer] ([personId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Writer]
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookCategory_Book] FOREIGN KEY([bookId])
REFERENCES [dbo].[Book] ([bookId])
GO
ALTER TABLE [dbo].[BookCategory] CHECK CONSTRAINT [FK_BookCategory_Book]
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookCategory_Category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([categoryId])
GO
ALTER TABLE [dbo].[BookCategory] CHECK CONSTRAINT [FK_BookCategory_Category]
GO
ALTER TABLE [dbo].[Hire]  WITH CHECK ADD  CONSTRAINT [FK_Hire_Book] FOREIGN KEY([bookId])
REFERENCES [dbo].[Book] ([bookId])
GO
ALTER TABLE [dbo].[Hire] CHECK CONSTRAINT [FK_Hire_Book]
GO
ALTER TABLE [dbo].[Hire]  WITH CHECK ADD  CONSTRAINT [FK_Hire_Person] FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([personId])
GO
ALTER TABLE [dbo].[Hire] CHECK CONSTRAINT [FK_Hire_Person]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Person] FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([personId])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Person]
GO
ALTER TABLE [dbo].[Printery]  WITH CHECK ADD  CONSTRAINT [FK_Printery_Adress] FOREIGN KEY([adressId])
REFERENCES [dbo].[Adress] ([adressId])
GO
ALTER TABLE [dbo].[Printery] CHECK CONSTRAINT [FK_Printery_Adress]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_City] FOREIGN KEY([cityId])
REFERENCES [dbo].[City] ([cityId])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_City]
GO
ALTER TABLE [dbo].[Writer]  WITH CHECK ADD  CONSTRAINT [FK_Writer_Person] FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([personId])
GO
ALTER TABLE [dbo].[Writer] CHECK CONSTRAINT [FK_Writer_Person]
GO
/****** Object:  StoredProcedure [dbo].[PRC_DML_BOOK]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PRC_DML_BOOK] 
	@P_dmlType varchar(1),
	@P_bookName varchar(50),
	@P_printeryDate date,
	@P_writerName varchar(50),
	@P_writerSurname varchar(50),
	@P_printery varchar(50),
	@P_category varchar(250),
	@P_typeName varchar(50),
	@P_hirePrice int
AS
BEGIN

	IF(@P_dmlType = 'I')
		IF((SELECT dbo.isExistsWriter(@P_writerName,@P_writerSurname)) = 0)

			INSERT INTO [dbo].[Person]
				   ([Name]
				   ,[Surname]
				   ,[isMember]
				   ,[isWriter])
			 VALUES
				   (@P_writerName,@P_writerSurname,0,1);


		INSERT INTO [dbo].[Book]
				([bookName]
				,[printeryDate]
				,[writerId]
				,[printeryId]
				,[bookTypeId]
				,[hirePrice])
			VALUES
				( @P_bookName
				,@P_printeryDate
				,(SELECT dbo.GetWriterId(@P_writerName,@P_writerSurname))
				,(SELECT dbo.GetPrinteryId(@P_printery))
				,(SELECT dbo.GetBookTypeId(@P_typeName))
				,@P_hirePrice);



				
		DECLARE @Category varchar(50);
		DECLARE @CategoryId int;
		DECLARE @BookId int;

		DECLARE MY_CURSOR CURSOR 
		  LOCAL STATIC READ_ONLY FORWARD_ONLY
		FOR 
		SELECT value FROM STRING_SPLIT(@P_Category, ';')

		OPEN MY_CURSOR
		FETCH NEXT FROM MY_CURSOR INTO @Category
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			SELECT @CategoryId=dbo.GetCategoryId(@Category);
			SELECT @BookId= dbo.GetBookID();

					INSERT INTO [dbo].[BookCategory]
						([categoryId]
						,[bookId])
					VALUES(
						@CategoryId,
						@BookId)

			FETCH NEXT FROM MY_CURSOR INTO @Category
		END
		CLOSE MY_CURSOR
		DEALLOCATE MY_CURSOR

	

END

GO
/****** Object:  StoredProcedure [dbo].[PRC_DML_HIRE]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_DML_HIRE]
	@P_dmlType varchar(1),
	@P_bookId int,
	@P_userName varchar(50),
	@P_responseTime date,
	@P_isBack tinyint,
	@P_price int,
	@P_hireId int

AS
BEGIN
	
	DECLARE @userId int
	SELECT @userId= Member.personId FROM dbo.Member Where Member.userName=@P_userName
	IF(@P_dmlType='I')
	BEGIN
		IF((SELECT COUNT(*) FROM dbo.Hire WHERE Hire.personId = @userId AND Hire.isBack = 0) < 2)

			INSERT INTO [dbo].[Hire]
					   ([responseTime]
					   ,[price]
					   ,[isBack]
					   ,[bookId]
					   ,[personId])
				 VALUES
					   (@P_responseTime,
					   @P_price,
					   @P_isBack,
					   @P_bookId,
					   (SELECT Member.personId FROM dbo.Member Where Member.userName=@P_userName));

			ELSE
				RAISERROR('Zaten 2 tane kitap kiralamışsın',16,1);
		END

		ELSE IF(@P_dmlType = 'U')
		BEGIN	
			IF((SELECT Hire.isBack FROM dbo.Hire Where Hire.hireId = @P_hireId) = 0 )
				UPDATE dbo.Hire SET Hire.isBack=1
				WHERE Hire.hireId = @P_hireId
			ELSE 
				RAISERROR ('Bu Kitap İade Edilmis',16,1)
		END
			
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_DML_MEMBER]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_DML_MEMBER] 
	@P_dmlType varchar(1),
	@P_name varchar(50),
	@P_surname varchar(50),
	@P_userName varchar(50),
	@P_password varchar(50)
AS
BEGIN

	IF(@P_dmlType = 'I')
		IF((SELECT COUNT(*) FROM dbo.Member WHERE Member.userName=@P_userName) = 0)
		BEGIN
			INSERT INTO [dbo].[Person]
				   ([Name]
				   ,[Surname]
				   ,[isMember]
				   ,[isWriter])
			 VALUES
				   (@P_name,@P_surname,1,0)

				INSERT INTO [dbo].[Member]
				   ([personId]
				   ,[userName]
				   ,[password]
				   ,[bookNumber])
			 VALUES
				   (
				   (SELECT MAX(personId) FROM [dbo].[Person]),
				   @P_userName,
				   @P_password,
				   0
				   );
			END
			ELSE
				RAISERROR('Bu Kullanici Adi Kayitli',16,1);		
END

GO
/****** Object:  StoredProcedure [dbo].[PRC_DML_PRINTERY]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_DML_PRINTERY]
	@P_PrinteryName nvarchar(50),
	@P_TownName nvarchar(50),
	@P_CityName nvarchar(50),
	@P_Adress nvarchar(150)
AS
BEGIN
	INSERT INTO [dbo].[Adress]
			   ([townId]
			   ,[adres])
		 VALUES(
				(SELECT Town.townId FROM dbo.Town
				INNER JOIN dbo.City on City.cityName = @P_CityName
				WHERE Town.townName = @P_TownName),
			   @P_Adress
			   );


	INSERT INTO [dbo].[Printery]
           ([printeryName]
           ,[adressId])
     VALUES(
           @P_PrinteryName,
		   (SELECT MAX(AdressId) FROM dbo.Adress)
		   );

END

GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_BOOK_CATEGORIES]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_GET_BOOK_CATEGORIES]

AS
BEGIN

	SELECT * FROM dbo.Category;
END

GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_BOOK_TYPES]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_GET_BOOK_TYPES] 
AS
BEGIN
	SELECT BookType.typeName FROM dbo.BookType;
END

GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_BOOKS]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_GET_BOOKS]
AS
BEGIN

	SELECT book.bookId,book.bookName,(writerInf.Name + ' ' + writerInf.Surname) as writerName,Printery.printeryName,book.printeryDate,book.hirePrice 
	FROM Book as book
	INNER JOIN (
		SELECT Person.personId,Person.Name,Person.Surname FROM Writer
		INNER JOIN Person ON Person.personId = Writer.personId 
	) as writerInf ON book.writerId = writerInf.personId
	INNER JOIN Printery ON book.printeryId = Printery.printeryId

END
GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_CITY]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_GET_CITY]
AS
BEGIN

	SELECT City.cityName FROM dbo.City
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_HIRED_BOOK]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_GET_HIRED_BOOK]
	@P_UserName varchar(50)
AS
BEGIN
	SELECT hireId,bookName,responseTime,hirePrice,
	(CASE isBack WHEN 0 THEN 'İade Edilmemiş' ELSE 'İade Edilmiş' end) Durumu
	 FROM dbo.Hire
	INNER JOIN dbo.Member ON( Member.personId =Hire.personId AND Member.userName= @P_UserName)
	INNER JOIN dbo.Book ON Book.bookId=Hire.bookId;
		
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_PRINTERY]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_GET_PRINTERY]
AS
BEGIN
	SELECT Printery.printeryName FROM dbo.Printery
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_TOWN]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_GET_TOWN]
	@P_cityName varchar(50)
AS
BEGIN

SELECT Town.townName FROM dbo.Town
INNER JOIN dbo.City ON (City.cityName=@P_cityName and City.cityId=Town.cityId)
	
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_LOGIN]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_LOGIN]
	@P_userName varchar(50),
	@P_password varchar(50)
AS
BEGIN

	
	SELECT * FROM Person as person
		INNER JOIN (
			SELECT * FROM dbo.Member 
			WHERE userName = @P_userName
			AND password = @P_password) as Member
		ON Member.personId = person.personId
	WHERE person.isMember = 1;

	
END

GO
/****** Object:  Trigger [dbo].[T_WRITER_BOOK_INC]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[T_WRITER_BOOK_INC] ON [dbo].[Book] 
	AFTER INSERT
AS 

BEGIN
		DECLARE @writer int;

		SELECT @writer= writerId  FROM inserted;

		
		UPDATE dbo.Writer 
		SET bookNumber = bookNumber + 1
		WHERE Writer.personId=@writer; 

END

GO
ALTER TABLE [dbo].[Book] ENABLE TRIGGER [T_WRITER_BOOK_INC]
GO
/****** Object:  Trigger [dbo].[T_MEMBER_BOOK_INC]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[T_MEMBER_BOOK_INC] ON [dbo].[Hire] 
	AFTER UPDATE
AS 

BEGIN

		IF(((SELECT inserted.isBack FROM inserted) > (SELECT deleted.isBack FROM deleted)) AND (SELECT inserted.isBack FROM inserted) = 1)
		BEGIN
		
			UPDATE dbo.Member 
			SET bookNumber = bookNumber + 1
			WHERE Member.personId=(Select inserted.personId FROM inserted)

		END

END
GO
ALTER TABLE [dbo].[Hire] ENABLE TRIGGER [T_MEMBER_BOOK_INC]
GO
/****** Object:  Trigger [dbo].[T_PERSON_DELETE]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[T_PERSON_DELETE] ON [dbo].[Person] 
	INSTEAD OF DELETE
AS 

BEGIN

IF(EXISTS(Select * from deleted where isMember = 1))
	
	DELETE FROM dbo.Member
	WHERE personId = (Select personId from deleted);

	DELETE FROM dbo.Person
	WHERE personId = (Select personId from deleted);
END

GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [T_PERSON_DELETE]
GO
/****** Object:  Trigger [dbo].[T_PERSON_TYPE]    Script Date: 16/12/2018 23:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[T_PERSON_TYPE] ON [dbo].[Person] 
	AFTER INSERT
AS 

BEGIN

IF(EXISTS(Select * from inserted where isWriter = 1))
	
	INSERT INTO dbo.Writer(personId,bookNumber)
	VALUES(
	(SELECT personId FROM inserted),
	0);
	
END
GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [T_PERSON_TYPE]
GO
