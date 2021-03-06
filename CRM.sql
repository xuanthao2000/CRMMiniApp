USE [master]
GO
/****** Object:  Database [CRMMiniApp]    Script Date: 12/10/2021 4:05:58 PM ******/
CREATE DATABASE [CRMMiniApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRMMiniApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CRMMiniApp.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CRMMiniApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CRMMiniApp_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CRMMiniApp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRMMiniApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRMMiniApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRMMiniApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRMMiniApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRMMiniApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRMMiniApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRMMiniApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CRMMiniApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRMMiniApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRMMiniApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRMMiniApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRMMiniApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRMMiniApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRMMiniApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRMMiniApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRMMiniApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CRMMiniApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRMMiniApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRMMiniApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRMMiniApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRMMiniApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRMMiniApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRMMiniApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRMMiniApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRMMiniApp] SET  MULTI_USER 
GO
ALTER DATABASE [CRMMiniApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRMMiniApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRMMiniApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRMMiniApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CRMMiniApp] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CRMMiniApp]
GO
/****** Object:  User [XUANTHAO\pc]    Script Date: 12/10/2021 4:05:58 PM ******/
CREATE USER [XUANTHAO\pc] FOR LOGIN [XUANTHAO\pc] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[classify]    Script Date: 12/10/2021 4:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classify](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_classify] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer]    Script Date: 12/10/2021 4:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[info1] [nvarchar](50) NULL,
	[info2] [nvarchar](50) NULL,
	[info3] [nvarchar](50) NULL,
	[info4] [nvarchar](50) NULL,
	[info5] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee]    Script Date: 12/10/2021 4:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTenNV] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[classify] ON 

INSERT [dbo].[classify] ([MaLoai], [TenLoai]) VALUES (1, N'Loại 1')
INSERT [dbo].[classify] ([MaLoai], [TenLoai]) VALUES (2, N'Loại 2')
INSERT [dbo].[classify] ([MaLoai], [TenLoai]) VALUES (4, N'Loại 3')
INSERT [dbo].[classify] ([MaLoai], [TenLoai]) VALUES (5, N'Loại 4')
INSERT [dbo].[classify] ([MaLoai], [TenLoai]) VALUES (6, N'Loại 5')
SET IDENTITY_INSERT [dbo].[classify] OFF
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (1, N'Nguyễn Thao', N'11324', N'x@gmail.com', N'123 Tân Phú', 4, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2021-12-09 15:39:59.437' AS DateTime))
INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (2, N'Nhật Long', N'11242', N'2@gmail.com', N'21 Phú Tân', 2, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2021-12-12 00:00:00.000' AS DateTime))
INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (3, N'Nguyễn Quỳnh', N'14245', N'x@gmail.com', N'12 Phú Thọ', 1, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2020-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (11, N'Trần Vũ', N'12411', N'ae@gmail.com', N'34 Phú Nhuận', 4, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2021-12-09 15:28:28.833' AS DateTime))
INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (13, N'Gia Phúc', N'11452', N'bit@gmail.com', N'123 An Dương ', 5, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2021-12-10 08:27:14.060' AS DateTime))
INSERT [dbo].[customer] ([MaKH], [HoTenKH], [DienThoai], [Email], [DiaChi], [MaLoai], [info1], [info2], [info3], [info4], [info5], [NgayTao]) VALUES (14, N'Nguyễn Hiền', N'1234', N'd.black@gmail.com', N'123 Nguyễn Trinh', 1, N'Không', N'Không', N'Không', N'Không', N'Không', CAST(N'2021-12-10 09:16:56.547' AS DateTime))
SET IDENTITY_INSERT [dbo].[customer] OFF
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([MaNV], [HoTenNV], [DiaChi], [DienThoai], [Email], [Password], [Role]) VALUES (1, N'Nguyen Thao', N'123 Cát Minh', N'13214', N'a', N'a', N'Admin')
INSERT [dbo].[employee] ([MaNV], [HoTenNV], [DiaChi], [DienThoai], [Email], [Password], [Role]) VALUES (2, N'Long Phan', N'21 Phú Nhuận', N'23141', N'b', N'b', N'Employee')
INSERT [dbo].[employee] ([MaNV], [HoTenNV], [DiaChi], [DienThoai], [Email], [Password], [Role]) VALUES (3, N'Gia Phúc Vương', N'123 Nguyễn Trinh', N'12342', N'1851010123thao@ou.edu.vn', N'a', N'Employee')
INSERT [dbo].[employee] ([MaNV], [HoTenNV], [DiaChi], [DienThoai], [Email], [Password], [Role]) VALUES (4, N'Gia Phúc', N'23 Quang Trung', N'12412', N'6@gmail.com', N'a', N'Employee')
INSERT [dbo].[employee] ([MaNV], [HoTenNV], [DiaChi], [DienThoai], [Email], [Password], [Role]) VALUES (5, N'a', N'a', N'1', N'a', N'a', N'Employee')
SET IDENTITY_INSERT [dbo].[employee] OFF
ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [FK_customer_classify] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[classify] ([MaLoai])
GO
ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [FK_customer_classify]
GO
USE [master]
GO
ALTER DATABASE [CRMMiniApp] SET  READ_WRITE 
GO
