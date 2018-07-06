﻿--
-- Скрипт сгенерирован Devart dbForge Studio for SQL Server, Версия 5.5.327.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/sql/studio
-- Дата скрипта: 7/6/2018 3:42:21 PM
-- Версия сервера: 14.00.1000
--



USE Library
GO

IF DB_NAME() <> N'Library' SET NOEXEC ON
GO

--
-- Создать таблицу [dbo].[Publisher]
--
PRINT (N'Создать таблицу [dbo].[Publisher]')
GO
CREATE TABLE dbo.Publisher (
  ID_Publisher int IDENTITY,
  Name varchar(100) NOT NULL,
  City varchar(80) NOT NULL,
  Street varchar(80) NOT NULL,
  House_Number int NOT NULL,
  CONSTRAINT PK_PUBLISHER PRIMARY KEY CLUSTERED (ID_Publisher)
)
ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO

--
-- Создать процедуру [dbo].[Publisher_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Publisher_Insert]')
GO

CREATE OR ALTER PROCEDURE dbo.Publisher_Insert
  @Name varchar(100),
  @City varchar(80),
  @Street varchar(80),
   @House_Number INT,
  @ID_Publisher INT OUTPUT AS

BEGIN
      INSERT INTO dbo.Publisher (Name,City, Street, House_Number)
      VALUES(@Name,@City,@Street,@House_Number)
      SET @ID_Publisher = SCOPE_IDENTITY()
END
GO

--
-- Создать таблицу [dbo].[Publication]
--
PRINT (N'Создать таблицу [dbo].[Publication]')
GO
CREATE TABLE dbo.Publication (
  ID_Publication int IDENTITY,
  Name varchar(170) NOT NULL,
  Publishing_Year int NOT NULL,
  ID_Magazine int NOT NULL,
  CONSTRAINT PK_PUBLICATION PRIMARY KEY CLUSTERED (ID_Publication)
)
ON [PRIMARY]
GO

--
-- Создать таблицу [dbo].[Magazine]
--
PRINT (N'Создать таблицу [dbo].[Magazine]')
GO
CREATE TABLE dbo.Magazine (
  ID_Magazine int IDENTITY,
  Name varchar(160) NOT NULL,
  ID_Publisher int NOT NULL,
  CONSTRAINT PK_MAGAZINE PRIMARY KEY CLUSTERED (ID_Magazine)
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Magazine_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Magazine_Insert]')
GO
CREATE OR ALTER PROCEDURE dbo.Magazine_Insert @Magazine_Name VARCHAR(160),@ID_Publisher INT,@ID_Magazine INT OUTPUT
AS 
BEGIN
    INSERT INTO Magazine VALUES(@Magazine_Name,@ID_Publisher)
    SET @ID_Magazine=SCOPE_IDENTITY()
END
GO

--
-- Создать таблицу [dbo].[Genre]
--
PRINT (N'Создать таблицу [dbo].[Genre]')
GO
CREATE TABLE dbo.Genre (
  ID_Genre int IDENTITY,
  Name varchar(70) NOT NULL,
  CONSTRAINT PK_GENRE PRIMARY KEY CLUSTERED (ID_Genre),
  CONSTRAINT KEY_Genre_Name UNIQUE (Name)
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Genre_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Genre_Insert]')
GO
CREATE OR ALTER PROCEDURE dbo.Genre_Insert 
  @NewGenre VARCHAR(64),
  @Genre_ID INTEGER OUTPUT
AS 
BEGIN
      INSERT INTO dbo.Genre(Name) VALUES(@NewGenre)
        SET @Genre_ID=SCOPE_IDENTITY()
end
GO

--
-- Создать таблицу [dbo].[Book]
--
PRINT (N'Создать таблицу [dbo].[Book]')
GO
CREATE TABLE dbo.Book (
  ID_Book int IDENTITY,
  Name varchar(150) NOT NULL,
  Publishing_Year int NOT NULL,
  ID_Publisher int NULL,
  CONSTRAINT PK_BOOK PRIMARY KEY CLUSTERED (ID_Book),
  CONSTRAINT KEY_Book UNIQUE (Name, Publishing_Year)
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Select_Book_By_Id]
--
GO
PRINT (N'Создать процедуру [dbo].[Select_Book_By_Id]')
GO
CREATE OR ALTER PROCEDURE dbo.Select_Book_By_Id @Book_ID INT
AS BEGIN
SELECT * FROM Book b WHERE b.ID_Book=@Book_ID
END
GO

--
-- Создать таблицу [dbo].[Author]
--
PRINT (N'Создать таблицу [dbo].[Author]')
GO
CREATE TABLE dbo.Author (
  ID_Author int IDENTITY,
  Name varchar(150) NOT NULL,
  Surname varchar(150) NOT NULL,
  CONSTRAINT PK_AUTHOR PRIMARY KEY CLUSTERED (ID_Author)
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Author_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Author_Insert]')
GO
CREATE OR ALTER PROCEDURE dbo.Author_Insert @Author_Name VARCHAR(150), @Author_Surname VARCHAR(150),@ID_Author INT OUTPUT
AS 
BEGIN
       INSERT INTO Author VALUES (@Author_Name,@Author_Surname)
       SET @ID_Author = SCOPE_IDENTITY()
END
GO

--
-- Создать таблицу [dbo].[Book_To_Genre]
--
PRINT (N'Создать таблицу [dbo].[Book_To_Genre]')
GO
CREATE TABLE dbo.Book_To_Genre (
  ID_Book int NOT NULL,
  ID_Genre int NOT NULL
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Select_Genres_By_IDBook]
--
GO
PRINT (N'Создать процедуру [dbo].[Select_Genres_By_IDBook]')
GO
CREATE OR ALTER PROCEDURE dbo.Select_Genres_By_IDBook @Book_ID INT 
AS 
BEGIN
  SELECT btg.ID_Genre,g.Name FROM Book_To_Genre btg JOIN Genre g ON btg.ID_Genre = g.ID_Genre WHERE btg.ID_Book=@Book_ID
END
GO

--
-- Создать процедуру [dbo].[Select_Books_By_Genre]
--
GO
PRINT (N'Создать процедуру [dbo].[Select_Books_By_Genre]')
GO
CREATE OR ALTER PROCEDURE dbo.Select_Books_By_Genre @Genre_ID INT
AS BEGIN
  SELECT * FROM Book_To_Genre btg JOIN Book b ON b.ID_Book=btg.ID_Book WHERE btg.ID_Genre=@Genre_ID
END
GO

--
-- Создать процедуру [dbo].[Add_Genre_To_book]
--
GO
PRINT (N'Создать процедуру [dbo].[Add_Genre_To_book]')
GO
CREATE OR ALTER PROCEDURE dbo.Add_Genre_To_book @Book_ID INT,@Genre_ID INT
AS
BEGIN
  INSERT INTO Book_To_Genre VALUES(@Book_ID,@Genre_ID)
END 
GO

--
-- Создать таблицу [dbo].[Publication_To_Author]
--
PRINT (N'Создать таблицу [dbo].[Publication_To_Author]')
GO
CREATE TABLE dbo.Publication_To_Author (
  ID_Author int NOT NULL,
  ID_Publication int NOT NULL,
  Placement int NOT NULL
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Publication_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Publication_Insert]')
GO
CREATE OR ALTER PROCEDURE dbo.Publication_Insert @Name VARCHAR(170), @Year INT, @Magazine_ID INT, @Author_ID INT, @Publication_ID INT OUTPUT
AS 
BEGIN
      INSERT INTO Publication VALUES(@Name,@Year,@Magazine_ID)
      INSERT INTO Publication_To_Author VALUES (@Author_ID,SCOPE_IDENTITY(),1)
END
GO

--
-- Создать процедуру [dbo].[Count_Publication_Authors]
--
GO
PRINT (N'Создать процедуру [dbo].[Count_Publication_Authors]')
GO
CREATE OR ALTER PROCEDURE dbo.Count_Publication_Authors @Publication_ID INT,@Count INT OUTPUT
AS
BEGIN
  SELECT @Count=COUNT(*) FROM Publication_To_Author pta WHERE pta.ID_Publication=@Publication_ID
END
GO

--
-- Создать процедуру [dbo].[Add_Author_To_Publication]
--
GO
PRINT (N'Создать процедуру [dbo].[Add_Author_To_Publication]')
GO
CREATE OR ALTER PROCEDURE dbo.Add_Author_To_Publication @ID_Author INT,@ID_Publication INT,@Placement INT
AS 
BEGIN
  INSERT INTO Publication_To_Author VALUES (@ID_Author,@ID_Publication,@Placement)
END
GO

--
-- Создать таблицу [dbo].[Book_To_Author]
--
PRINT (N'Создать таблицу [dbo].[Book_To_Author]')
GO
CREATE TABLE dbo.Book_To_Author (
  ID_Book int NOT NULL,
  ID_Author int NOT NULL,
  Placement int NOT NULL
)
ON [PRIMARY]
GO

--
-- Создать процедуру [dbo].[Count_Book_Authors]
--
GO
PRINT (N'Создать процедуру [dbo].[Count_Book_Authors]')
GO
CREATE OR ALTER PROCEDURE dbo.Count_Book_Authors @Book_ID INT,@Count INT OUTPUT
AS 
BEGIN
  SELECT @Count=COUNT(*) FROM Book_To_Author bta WHERE bta.ID_Book=@Book_ID
END
GO

--
-- Создать процедуру [dbo].[Book_Insert]
--
GO
PRINT (N'Создать процедуру [dbo].[Book_Insert]')
GO
CREATE OR ALTER PROCEDURE dbo.Book_Insert @Name VARCHAR(150),@Year INT,@Publisher_ID INT NULL,@Genre_ID INT,@Author_ID INT NULL,@Book_ID INT OUTPUT
AS 
BEGIN
  INSERT INTO Book VALUES(@Name,@Year,@Publisher_ID)
   SET @Book_ID=SCOPE_IDENTITY()
  INSERT INTO Book_To_Genre VALUES(@Book_ID,@Genre_ID)
  IF @Author_ID IS NOT NULL
  INSERT INTO Book_To_Author VALUES (@Book_ID,@Author_ID,1)
END
GO

--
-- Создать процедуру [dbo].[Add_Author_To_Book]
--
GO
PRINT (N'Создать процедуру [dbo].[Add_Author_To_Book]')
GO
CREATE OR ALTER PROCEDURE dbo.Add_Author_To_Book @ID_Author INT,@ID_Book INT,@Placemwent INT
AS 
BEGIN
    INSERT INTO Book_To_Author VALUES (@ID_Book,@ID_Author,@Placemwent)
END
GO
-- 
-- Вывод данных для таблицы Author
--
SET IDENTITY_INSERT dbo.Author ON
GO
INSERT dbo.Author(ID_Author, Name, Surname) VALUES (2, N'Carl', N'Sagan')
INSERT dbo.Author(ID_Author, Name, Surname) VALUES (3, N'Stanley', N'Dermott')
GO
SET IDENTITY_INSERT dbo.Author OFF
GO
-- 
-- Вывод данных для таблицы Book
--
SET IDENTITY_INSERT dbo.Book ON
GO
INSERT dbo.Book(ID_Book, Name, Publishing_Year, ID_Publisher) VALUES (6, N'Contact', 2014, 1)
GO
SET IDENTITY_INSERT dbo.Book OFF
GO
-- 
-- Вывод данных для таблицы Book_To_Author
--
INSERT dbo.Book_To_Author VALUES (6, 2, 1)
GO
-- 
-- Вывод данных для таблицы Book_To_Genre
--
INSERT dbo.Book_To_Genre VALUES (6, 1)
INSERT dbo.Book_To_Genre VALUES (6, 4)
GO
-- 
-- Вывод данных для таблицы Genre
--
SET IDENTITY_INSERT dbo.Genre ON
GO
INSERT dbo.Genre(ID_Genre, Name) VALUES (4, N'Hard Sci-Fi')
INSERT dbo.Genre(ID_Genre, Name) VALUES (2, N'Horror')
INSERT dbo.Genre(ID_Genre, Name) VALUES (1, N'Sci-Fi')
GO
SET IDENTITY_INSERT dbo.Genre OFF
GO
-- 
-- Вывод данных для таблицы Magazine
--
SET IDENTITY_INSERT dbo.Magazine ON
GO
INSERT dbo.Magazine(ID_Magazine, Name, ID_Publisher) VALUES (1, N'Nature', 1)
GO
SET IDENTITY_INSERT dbo.Magazine OFF
GO
-- 
-- Вывод данных для таблицы Publication
--
SET IDENTITY_INSERT dbo.Publication ON
GO
INSERT dbo.Publication(ID_Publication, Name, Publishing_Year, ID_Magazine) VALUES (2, N'The tide in the seas of Titan', 1982, 1)
INSERT dbo.Publication(ID_Publication, Name, Publishing_Year, ID_Magazine) VALUES (3, N'Sulphur flows on Io n', 1979, 1)
GO
SET IDENTITY_INSERT dbo.Publication OFF
GO
-- 
-- Вывод данных для таблицы Publication_To_Author
--
INSERT dbo.Publication_To_Author VALUES (2, 2, 1)
INSERT dbo.Publication_To_Author VALUES (2, 3, 1)
INSERT dbo.Publication_To_Author VALUES (3, 2, 2)
GO
-- 
-- Вывод данных для таблицы Publisher
--
SET IDENTITY_INSERT dbo.Publisher ON
GO
INSERT dbo.Publisher(ID_Publisher, Name, City, Street, House_Number) VALUES (1, N'Publisher', N'Default City', N'Elizabeth Street', 4)
GO
SET IDENTITY_INSERT dbo.Publisher OFF
GO

USE Library
GO

IF DB_NAME() <> N'Library' SET NOEXEC ON
GO

--
-- Создать внешний ключ [FK_Magazine_ID_Publisher] для объекта типа таблица [dbo].[Magazine]
--
PRINT (N'Создать внешний ключ [FK_Magazine_ID_Publisher] для объекта типа таблица [dbo].[Magazine]')
GO
ALTER TABLE dbo.Magazine
  ADD CONSTRAINT FK_Magazine_ID_Publisher FOREIGN KEY (ID_Publisher) REFERENCES dbo.Publisher (ID_Publisher)
GO

--
-- Создать внешний ключ [FK_Publication_ID_Magazine] для объекта типа таблица [dbo].[Publication]
--
PRINT (N'Создать внешний ключ [FK_Publication_ID_Magazine] для объекта типа таблица [dbo].[Publication]')
GO
ALTER TABLE dbo.Publication
  ADD CONSTRAINT FK_Publication_ID_Magazine FOREIGN KEY (ID_Magazine) REFERENCES dbo.Magazine (ID_Magazine)
GO

--
-- Создать внешний ключ [FK_Publication_To_Author_ID_Author] для объекта типа таблица [dbo].[Publication_To_Author]
--
PRINT (N'Создать внешний ключ [FK_Publication_To_Author_ID_Author] для объекта типа таблица [dbo].[Publication_To_Author]')
GO
ALTER TABLE dbo.Publication_To_Author
  ADD CONSTRAINT FK_Publication_To_Author_ID_Author FOREIGN KEY (ID_Author) REFERENCES dbo.Author (ID_Author)
GO

--
-- Создать внешний ключ [FK_Publication_To_Author_ID_Publication] для объекта типа таблица [dbo].[Publication_To_Author]
--
PRINT (N'Создать внешний ключ [FK_Publication_To_Author_ID_Publication] для объекта типа таблица [dbo].[Publication_To_Author]')
GO
ALTER TABLE dbo.Publication_To_Author
  ADD CONSTRAINT FK_Publication_To_Author_ID_Publication FOREIGN KEY (ID_Publication) REFERENCES dbo.Publication (ID_Publication)
GO

--
-- Создать внешний ключ [FK_Book_ID_Publisher] для объекта типа таблица [dbo].[Book]
--
PRINT (N'Создать внешний ключ [FK_Book_ID_Publisher] для объекта типа таблица [dbo].[Book]')
GO
ALTER TABLE dbo.Book
  ADD CONSTRAINT FK_Book_ID_Publisher FOREIGN KEY (ID_Publisher) REFERENCES dbo.Publisher (ID_Publisher)
GO

--
-- Создать внешний ключ [FK_Book_To_Genre_ID_Book] для объекта типа таблица [dbo].[Book_To_Genre]
--
PRINT (N'Создать внешний ключ [FK_Book_To_Genre_ID_Book] для объекта типа таблица [dbo].[Book_To_Genre]')
GO
ALTER TABLE dbo.Book_To_Genre
  ADD CONSTRAINT FK_Book_To_Genre_ID_Book FOREIGN KEY (ID_Book) REFERENCES dbo.Book (ID_Book)
GO

--
-- Создать внешний ключ [FK_Book_To_Genre_ID_Genre] для объекта типа таблица [dbo].[Book_To_Genre]
--
PRINT (N'Создать внешний ключ [FK_Book_To_Genre_ID_Genre] для объекта типа таблица [dbo].[Book_To_Genre]')
GO
ALTER TABLE dbo.Book_To_Genre
  ADD CONSTRAINT FK_Book_To_Genre_ID_Genre FOREIGN KEY (ID_Genre) REFERENCES dbo.Genre (ID_Genre)
GO

--
-- Создать внешний ключ [FK_Book_To_Author_ID_Author] для объекта типа таблица [dbo].[Book_To_Author]
--
PRINT (N'Создать внешний ключ [FK_Book_To_Author_ID_Author] для объекта типа таблица [dbo].[Book_To_Author]')
GO
ALTER TABLE dbo.Book_To_Author
  ADD CONSTRAINT FK_Book_To_Author_ID_Author FOREIGN KEY (ID_Author) REFERENCES dbo.Author (ID_Author)
GO

--
-- Создать внешний ключ [FK_Book_To_Author_ID_Book] для объекта типа таблица [dbo].[Book_To_Author]
--
PRINT (N'Создать внешний ключ [FK_Book_To_Author_ID_Book] для объекта типа таблица [dbo].[Book_To_Author]')
GO
ALTER TABLE dbo.Book_To_Author
  ADD CONSTRAINT FK_Book_To_Author_ID_Book FOREIGN KEY (ID_Book) REFERENCES dbo.Book (ID_Book)
GO
SET NOEXEC OFF
GO