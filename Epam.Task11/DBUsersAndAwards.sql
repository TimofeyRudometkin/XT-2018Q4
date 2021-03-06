USE [master]
GO
/****** Object:  Database [UsersAndAwards]    Script Date: 19.02.2019 7:45:15 ******/
CREATE DATABASE [UsersAndAwards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsersAndAwards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsersAndAwards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UsersAndAwards] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndAwards] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsersAndAwards] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UsersAndAwards] SET QUERY_STORE = OFF
GO
USE [UsersAndAwards]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 19.02.2019 7:45:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteUserAwards]    Script Date: 19.02.2019 7:45:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteUserAwards](
	[Name] [nvarchar](50) NOT NULL,
	[Award] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteUsers]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteUsers](
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[AccessPermission] [nvarchar](10) NULL,
 CONSTRAINT [PK_SiteUser] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirthday] [date] NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndTheirAwards]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndTheirAwards](
	[UserId] [int] NOT NULL,
	[AwardId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward]
	@Title nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Awards(Title)
	VALUES(@Title)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSiteUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSiteUser]
	@siteUserName nvarchar(50),
	@userPassword nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO SiteUsers(Name, Password)
	VALUES(@siteUserName, @userPassword)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@Name nvarchar(50),
	@DateOfBirthday date,
	@Age int
AS
BEGIN 
	SET NOCOUNT ON;
	INSERT INTO Users(Name, DateOfBirthday, Age)
	VALUES(@Name, @DateOfBirthday, @Age)
END
GO
/****** Object:  StoredProcedure [dbo].[CorrectionOfAccessPermission]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CorrectionOfAccessPermission]
	@siteUserName nvarchar(50),
	@adminPermission nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE SiteUsers
		SET AccessPermission=@adminPermission
			WHERE Name=@siteUserName
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAward]
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Awards WHERE Id=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSiteUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSiteUser]
	@siteUserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM SiteUsers WHERE Name=@siteUserName
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Users WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAwards]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT A.id,
		   A.Title
	  FROM Awards A
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSiteUsersWithoutAwardsId]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSiteUsersWithoutAwardsId]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	 S.Name,
			 S.Password,
			 S.AccessPermission
		FROM SiteUsers S
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT	 U.Id,
			 U.Name,
			 U.DateOfBirthday,
			 U.Age
		FROM Users U

END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardById]
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT A.Title
		FROM Awards A
			WHERE A.id=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardsIdBySiteUserName]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardsIdBySiteUserName]
	@siteUserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT S.Award FROM SiteUserAwards S
	WHERE S.Name=@siteUserName AND S.Award<>NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardsIdByUserId]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardsIdByUserId]
	@userId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT U.AwardId FROM UsersAndTheirAwards U
	WHERE U.UserId=@userId
END
GO
/****** Object:  StoredProcedure [dbo].[GetById]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetById]
@userId int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	 U.Id,
			 U.Name,
			 U.DateOfBirthday,
			 U.Age
		FROM Users U WHERE U.Id=@userId
END
GO
/****** Object:  StoredProcedure [dbo].[GetBySiteUserName]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBySiteUserName]
	@siteUserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	 S.Name,
			 S.Password,
			 S.AccessPermission
		FROM SiteUsers S WHERE S.Name=@siteUserName
END
GO
/****** Object:  StoredProcedure [dbo].[ToAward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ToAward]
	@userId int,
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO UsersAndTheirAwards(UserId, AwardId)
	VALUES(@userId, @awardId)
END
GO
/****** Object:  StoredProcedure [dbo].[ToAwardSiteUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ToAwardSiteUser]
	@siteUserName nvarchar(50),
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO SiteUserAwards(Name, Award)
	VALUES(@siteUserName, @awardId)
END
GO
/****** Object:  StoredProcedure [dbo].[ToRemoveSiteUserReward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ToRemoveSiteUserReward]
	@siteUserName nvarchar(50),
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM SiteUserAwards
	WHERE Name=@siteUserName AND Award=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[ToRemoveUserReward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ToRemoveUserReward]
	@userId int,
	@awardId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM UsersAndTheirAwards
	WHERE UserId=@userId AND AwardId=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAward]
	@awardId int,
	@awardTitle nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Awards
		SET Title=@awardTitle
			WHERE Id=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 19.02.2019 7:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Name nvarchar(50),
	@DateOfBirthday date,
	@Age int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET Name=@Name, DateOfBirthday=@DateOfBirthday, Age=@Age WHERE Id=@Id
END
GO
USE [master]
GO
ALTER DATABASE [UsersAndAwards] SET  READ_WRITE 
GO
