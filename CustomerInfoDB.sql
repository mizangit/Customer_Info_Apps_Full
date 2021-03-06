USE [master]
GO
/****** Object:  Database [ImageStoreDB]    Script Date: 3/3/2016 4:50:47 PM ******/
CREATE DATABASE [ImageStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ImageStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ImageStoreDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ImageStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ImageStoreDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ImageStoreDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ImageStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ImageStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ImageStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ImageStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ImageStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ImageStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ImageStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ImageStoreDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ImageStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ImageStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ImageStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ImageStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ImageStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ImageStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ImageStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ImageStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ImageStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ImageStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ImageStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ImageStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ImageStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ImageStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ImageStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ImageStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ImageStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ImageStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [ImageStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ImageStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ImageStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ImageStoreDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ImageStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[STP_DeleteCustomerInfo]    Script Date: 3/3/2016 4:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_DeleteCustomerInfo]
@ID INT
as
begin
	DELETE tbl_CustomerInfo WHERE ID=@ID
end

GO
/****** Object:  StoredProcedure [dbo].[STP_EditCustomerInfo]    Script Date: 3/3/2016 4:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_EditCustomerInfo]
@ID INT,
@CustomerID varchar(10), 
@Name varchar(50),
@Phone numeric(18,0),
@Email varchar(150),
@Address varchar(500),
@Gender varchar(6),
@DateOfBirth Date,
@Photo varbinary(MAX)
as
begin
	UPDATE  tbl_CustomerInfo SET CustomerID=@CustomerID,Name=@Name,Phone=@Phone,Email=@Email,Address=@Address,Gender=@Gender,DateOfBirth=@DateOfBirth,Photo=@Photo WHERE ID=@ID
end

GO
/****** Object:  StoredProcedure [dbo].[STP_SaveCustomerInfo]    Script Date: 3/3/2016 4:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_SaveCustomerInfo]

@CustomerID varchar(10), 
@Name varchar(50),
@Phone numeric(18,0),
@Email varchar(150),
@Address varchar(500),
@Gender varchar(6),
@DateOfBirth Date,
@Photo varbinary(MAX)
as
begin
INSERT INTO tbl_CustomerInfo(CustomerID,Name,Phone,Email,Address,Gender,DateOfBirth,Photo) values (@CustomerID,@Name,@Phone,@Email,@Address,@Gender,@DateOfBirth,@Photo)
end

GO
/****** Object:  StoredProcedure [dbo].[STP_ViewAllCustomerInfo]    Script Date: 3/3/2016 4:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STP_ViewAllCustomerInfo]
as
begin
SELECT CustomerID,Name,Phone,Email,Address,Gender,DateOfBirth,Photo FROM  tbl_CustomerInfo
end

GO
/****** Object:  Table [dbo].[tbl_CustomerInfo]    Script Date: 3/3/2016 4:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_CustomerInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CustomerID] [varchar](10) NULL,
	[Phone] [numeric](18, 0) NULL,
	[Email] [varchar](150) NULL,
	[Address] [varchar](500) NULL,
	[Photo] [varbinary](max) NULL,
	[Gender] [varchar](6) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK_tbl_CustomerInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [ImageStoreDB] SET  READ_WRITE 
GO
