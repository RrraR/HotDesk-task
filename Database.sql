USE [master]
GO
/****** Object:  Database [HotDeskDB]    Script Date: 11/29/2022 12:33:55 AM ******/
CREATE DATABASE [HotDeskDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotDeskDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotDeskDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotDeskDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotDeskDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotDeskDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotDeskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotDeskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotDeskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotDeskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotDeskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotDeskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotDeskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotDeskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotDeskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotDeskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotDeskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotDeskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotDeskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotDeskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotDeskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotDeskDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotDeskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotDeskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotDeskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotDeskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotDeskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotDeskDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotDeskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotDeskDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotDeskDB] SET  MULTI_USER 
GO
ALTER DATABASE [HotDeskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotDeskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotDeskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotDeskDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotDeskDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotDeskDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotDeskDB] SET QUERY_STORE = OFF
GO
USE [HotDeskDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nchar](20) NOT NULL,
	[LastName] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentId] [int] NOT NULL,
	[Type] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentForWorkplace]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentForWorkplace](
	[EFW_Id] [int] NOT NULL,
	[IdWorkplace] [int] NOT NULL,
	[IdEquipment] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentForWorkplace] PRIMARY KEY CLUSTERED 
(
	[EFW_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationId] [int] NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[IdWorkplace] [int] NOT NULL,
	[TimeFrom] [datetime] NOT NULL,
	[TimeTo] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workplace]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workplace](
	[WorkplaceId] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[Room] [int] NOT NULL,
	[TableNumber] [int] NOT NULL,
 CONSTRAINT [PK_Workplace] PRIMARY KEY CLUSTERED 
(
	[WorkplaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EquipmentForWorkplace]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentForWorkplace_Equipment] FOREIGN KEY([IdEquipment])
REFERENCES [dbo].[Equipment] ([EquipmentId])
GO
ALTER TABLE [dbo].[EquipmentForWorkplace] CHECK CONSTRAINT [FK_EquipmentForWorkplace_Equipment]
GO
ALTER TABLE [dbo].[EquipmentForWorkplace]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentForWorkplace_Workplace] FOREIGN KEY([IdWorkplace])
REFERENCES [dbo].[Workplace] ([WorkplaceId])
GO
ALTER TABLE [dbo].[EquipmentForWorkplace] CHECK CONSTRAINT [FK_EquipmentForWorkplace_Workplace]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Employee]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Workplace] FOREIGN KEY([IdWorkplace])
REFERENCES [dbo].[Workplace] ([WorkplaceId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Workplace]
GO
/****** Object:  StoredProcedure [dbo].[DeleteOnExpirationDate]    Script Date: 11/29/2022 12:33:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteOnExpirationDate]
AS
BEGIN
	SET NOCOUNT ON;
	Delete Reservation FROM dbo.Reservation
	WHERE TimeTo = GETDATE()
END
GO
USE [master]
GO
ALTER DATABASE [HotDeskDB] SET  READ_WRITE 
GO

INSERT INTO [dbo].[Employee]
           ([EmployeeId]
           ,[FirstName]
           ,[LastName])
     VALUES
           (1, 'Ann', 'Tree'),
		   (2, 'Sam', 'Can')
GO

INSERT INTO [dbo].[Equipment]
           ([EquipmentId]
           ,[Type])
     VALUES
           (1, 'Monitor'),
		   (2, 'Mouse'),
		   (3, 'Keyboard'),
		   (4, 'Desk lamp')

GO

INSERT INTO [dbo].[Workplace]
           ([WorkplaceId]
           ,[Floor]
           ,[Room]
           ,[TableNumber])
     VALUES
           (1, 1, 1, 1),
		   (2, 1, 1, 2),
		   (3, 2, 1, 1 )    
GO

INSERT INTO [dbo].[EquipmentForWorkplace]
           ([EFW_Id]
           ,[IdWorkplace]
           ,[IdEquipment]
           ,[Count])
     VALUES
           	(1,1,1,2),
		   	(2,1,2,1),
		   	(3,1,3,1),
		   	(4,2,1,1),
			(5,2,3,1),
			(6,2,4,1),
			(7,3,1,2),
			(8,3,4,1)
GO


