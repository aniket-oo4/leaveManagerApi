Begin Tran
rollback tran
/****** Object:  Database [[LeaveManagement2]]    Script Date: 22-11-2024 18:18:33 ******/
CREATE DATABASE [LeaveManagement2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeaveManagement2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LeaveManagement2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LeaveManagement2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LeaveManagement2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

begin Tran

ALTER DATABASE [LeaveManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeaveManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeaveManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeaveManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeaveManagement] SET ANSI_PADDING OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET ANSI_WARNINGS OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET ARITHABORT OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET AUTO_CLOSE OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET AUTO_SHRINK OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET AUTO_UPDATE_STATISTICS ON 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET CURSOR_DEFAULT  GLOBAL 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET NUMERIC_ROUNDABORT OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET QUOTED_IDENTIFIER OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET RECURSIVE_TRIGGERS OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET  DISABLE_BROKER 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET TRUSTWORTHY OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET PARAMETERIZATION SIMPLE 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET HONOR_BROKER_PRIORITY OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET RECOVERY FULL 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET  MULTI_USER 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET PAGE_VERIFY CHECKSUM  
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET DB_CHAINING OFF 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET DELAYED_DURABILITY = DISABLED 
GO			   [LeaveManagement]
ALTER DATABASE [LeaveManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LeaveManagement', N'ON'
GO
ALTER DATABASE [LeaveManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [LeaveManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LeaveManagement]
GO
/****** Object:  Table [dbo].[ActionMaster]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionMaster](
	[actionMasterId] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [int] NOT NULL,
	[actionId] [int] NOT NULL,
	[updatedStatusId] [int] NOT NULL,
 CONSTRAINT [PK_ActionMaster] PRIMARY KEY CLUSTERED 
(
	[actionMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[actionId] [int] IDENTITY(1,1) NOT NULL,
	[actionName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED 
(
	[actionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationStatus]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationStatus](
	[statusId] [int] IDENTITY(1,1) NOT NULL,
	[statusName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ApplicationStatus] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostCenters]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCenters](
	[costCenterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[orgId] [int] NOT NULL,
 CONSTRAINT [PK_CostCenters] PRIMARY KEY CLUSTERED 
(
	[costCenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[dptId] [int] IDENTITY(1,1) NOT NULL,
	[dptName] [varchar](100) NOT NULL,
	[location] [varchar](100) NOT NULL,
	[orgId] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[dptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[emailAddress] [varchar](100) NOT NULL,
	[birthDate] [datetime] NOT NULL,
	[city] [varchar](60) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
	[userId] [int] NOT NULL,
	[dptId] [int] NOT NULL,
	[costCenterId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
	[managerId] [int] NULL,
	[orgId] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveApplications]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveApplications](
	[leaveId] [int] IDENTITY(1,1) NOT NULL,
	[leaveTypeId] [int] NOT NULL,
	[leaveDateFrom] [datetime] NOT NULL,
	[leaveDateTo] [datetime] NOT NULL,
	[remark] [varchar](80) NOT NULL,
	[statusId] [int] NOT NULL,
	[applicationDate] [datetime] NOT NULL,
	[updatedDate] [datetime] NOT NULL,
	[empId] [int] NOT NULL,
	[totalLeaves] [int] NULL,
 CONSTRAINT [PK_LeaveApplications] PRIMARY KEY CLUSTERED 
(
	[leaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveBalances]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveBalances](
	[leaveBalanceId] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[leaveTypeId] [int] NOT NULL,
	[openingBalance] [numeric](18, 0) NOT NULL,
	[currentBalance] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_LeaveBalances] PRIMARY KEY CLUSTERED 
(
	[leaveBalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveTypes]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveTypes](
	[leaveTypeId] [int] IDENTITY(1,1) NOT NULL,
	[leaveType] [varchar](80) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NOT NULL,
 CONSTRAINT [PK_LeaveTypes] PRIMARY KEY CLUSTERED 
(
	[leaveTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuAccessMaster]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuAccessMaster](
	[accessMasterId] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [int] NOT NULL,
	[menuId] [int] NOT NULL,
 CONSTRAINT [PK_MenuAccessMaster] PRIMARY KEY CLUSTERED 
(
	[accessMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[menuId] [int] IDENTITY(1,1) NOT NULL,
	[menuName] [varchar](100) NULL,
	[url] [varchar](500) NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[menuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organisations]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organisations](
	[orgId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Organisations] PRIMARY KEY CLUSTERED 
(
	[orgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Process]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Process](
	[processId] [int] IDENTITY(1,1) NOT NULL,
	[processName] [varchar](100) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[processId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessMaster]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessMaster](
	[processMasterId] [int] IDENTITY(1,1) NOT NULL,
	[applicationType] [varchar](60) NOT NULL,
	[processId] [int] NOT NULL,
 CONSTRAINT [PK_ProcessMaster] PRIMARY KEY CLUSTERED 
(
	[processMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessStages]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessStages](
	[nextStageId] [int] NULL,
	[stageId] [int] IDENTITY(1,1) NOT NULL,
	[stageName] [varchar](100) NOT NULL,
	[stageStatus] [varchar](100) NOT NULL,
	[performedByRoleId] [int] NOT NULL,
	[processId] [int] NOT NULL,
 CONSTRAINT [PK_ProcessStages] PRIMARY KEY CLUSTERED 
(
	[stageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublicHolidays]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublicHolidays](
	[holidayId] [int] IDENTITY(1,1) NOT NULL,
	[holidayDate] [datetime] NOT NULL,
	[holidayInfo] [varchar](100) NOT NULL,
	[orgId] [int] NOT NULL,
 CONSTRAINT [PK_PublicHolidays] PRIMARY KEY CLUSTERED 
(
	[holidayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[roleId] [int] NOT NULL,
	[roleName] [varchar](100) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
	[createdBy] [int] NULL,
	[updatedBy] [int] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22-11-2024 18:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](60) NOT NULL,
	[password] [varchar](300) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
	[createdBy] [int] NULL,
	[updatedBy] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ActionMaster] ON 
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (175, 2, 1, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (176, 2, 4, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (177, 2, 5, 2)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (178, 3, 2, 3)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (179, 3, 3, 4)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (180, 3, 1, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (181, 3, 4, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (182, 3, 5, 2)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (183, 1, 1, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (184, 1, 4, 1)
GO
INSERT [dbo].[ActionMaster] ([actionMasterId], [roleId], [actionId], [updatedStatusId]) VALUES (185, 1, 5, 2)
GO
SET IDENTITY_INSERT [dbo].[ActionMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Actions] ON 
GO
INSERT [dbo].[Actions] ([actionId], [actionName]) VALUES (1, N'submit')
GO
INSERT [dbo].[Actions] ([actionId], [actionName]) VALUES (2, N'approve')
GO
INSERT [dbo].[Actions] ([actionId], [actionName]) VALUES (3, N'decline')
GO
INSERT [dbo].[Actions] ([actionId], [actionName]) VALUES (4, N'edit')
GO
INSERT [dbo].[Actions] ([actionId], [actionName]) VALUES (5, N'cancel')
GO
SET IDENTITY_INSERT [dbo].[Actions] OFF
GO
SET IDENTITY_INSERT [dbo].[ApplicationStatus] ON 
GO
INSERT [dbo].[ApplicationStatus] ([statusId], [statusName]) VALUES (1, N'pending')
GO
INSERT [dbo].[ApplicationStatus] ([statusId], [statusName]) VALUES (2, N'cancelled')
GO
INSERT [dbo].[ApplicationStatus] ([statusId], [statusName]) VALUES (3, N'approved')
GO
INSERT [dbo].[ApplicationStatus] ([statusId], [statusName]) VALUES (4, N'declined')
GO
SET IDENTITY_INSERT [dbo].[ApplicationStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[CostCenters] ON 
GO
INSERT [dbo].[CostCenters] ([costCenterId], [Name], [orgId]) VALUES (1, N'Marketing', 1)
GO
INSERT [dbo].[CostCenters] ([costCenterId], [Name], [orgId]) VALUES (2, N'Operations', 1)
GO
INSERT [dbo].[CostCenters] ([costCenterId], [Name], [orgId]) VALUES (3, N'Finance', 1)
GO
SET IDENTITY_INSERT [dbo].[CostCenters] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([dptId], [dptName], [location], [orgId]) VALUES (1, N'Human Resources', N'Pune', 1)
GO
INSERT [dbo].[Departments] ([dptId], [dptName], [location], [orgId]) VALUES (2, N'Research and Development', N'Mumbai', 1)
GO
INSERT [dbo].[Departments] ([dptId], [dptName], [location], [orgId]) VALUES (3, N'Sales', N'Delhi', 1)
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (61, N'Chetan', N'Sharma', N'chetan@example.com', CAST(N'1980-01-01T00:00:00.000' AS DateTime), N'Pune', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 1, 1, 1, 1, 61, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (62, N'Himanshu', N'Patel', N'himanshu@example.com', CAST(N'1985-02-02T00:00:00.000' AS DateTime), N'Mumbai', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 2, 2, 2, 3, 61, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (63, N'Arjun', N'Deshpande', N'arjun@example.com', CAST(N'1990-03-03T00:00:00.000' AS DateTime), N'Pune', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-10-06T20:22:32.203' AS DateTime), 3, 3, 3, 2, 62, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (64, N'Priya', N'Kumar', N'priya@example.com', CAST(N'1991-04-04T00:00:00.000' AS DateTime), N'Chennai', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 4, 3, 3, 2, 62, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (65, N'Rahul', N'Verma', N'rahul@example.com', CAST(N'1992-05-05T00:00:00.000' AS DateTime), N'Kolkata', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 5, 3, 3, 2, 62, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (66, N'Neha', N'Gupta', N'neha@example.com', CAST(N'1993-06-06T00:00:00.000' AS DateTime), N'Hyderabad', CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 6, 3, 3, 2, 62, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (68, N'Akash', N'patil', N'Akash@example.com', CAST(N'2001-02-02T00:00:00.000' AS DateTime), N'Mumbai', CAST(N'2024-10-03T12:27:31.940' AS DateTime), CAST(N'2024-10-03T12:27:31.940' AS DateTime), 7, 2, 2, 2, 62, 1)
GO
INSERT [dbo].[Employees] ([empId], [firstName], [lastName], [emailAddress], [birthDate], [city], [createdAt], [updatedAt], [userId], [dptId], [costCenterId], [roleId], [managerId], [orgId]) VALUES (69, N'Ganesh', N'takale', N'ganesh@example.com', CAST(N'2001-03-04T00:00:00.000' AS DateTime), N'pune', CAST(N'2024-10-03T12:32:19.967' AS DateTime), CAST(N'2024-10-03T12:32:19.967' AS DateTime), 8, 3, 3, 2, 62, 1)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveApplications] ON 
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (133, 2, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(N'2024-12-10T00:00:00.000' AS DateTime), N'Family function', 2, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-03T00:40:04.903' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (134, 2, CAST(N'2024-11-15T00:00:00.000' AS DateTime), CAST(N'2024-11-16T00:00:00.000' AS DateTime), N'Personal work', 4, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-06T22:33:34.620' AS DateTime), 61, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (135, 2, CAST(N'2024-12-25T00:00:00.000' AS DateTime), CAST(N'2024-12-27T00:00:00.000' AS DateTime), N'Vacation to dubai', 3, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-10-03T14:51:28.587' AS DateTime), 61, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (136, 2, CAST(N'2024-12-29T00:00:00.000' AS DateTime), CAST(N'2024-12-30T00:00:00.000' AS DateTime), N'Vacation to dubai', 2, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-02T21:00:57.060' AS DateTime), 62, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (137, 1, CAST(N'2024-12-05T00:00:00.000' AS DateTime), CAST(N'2024-12-07T00:00:00.000' AS DateTime), N'Conference', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 62, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (138, 2, CAST(N'2024-09-20T00:00:00.000' AS DateTime), CAST(N'2024-09-21T00:00:00.000' AS DateTime), N'Medical appointment', 4, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-03T01:48:30.847' AS DateTime), 62, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (139, 1, CAST(N'2024-12-01T00:00:00.000' AS DateTime), CAST(N'2024-12-03T00:00:00.000' AS DateTime), N'Vacation', 3, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-03T01:43:47.127' AS DateTime), 63, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (140, 2, CAST(N'2024-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-11T00:00:00.000' AS DateTime), N'Family event', 3, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-03T01:47:26.250' AS DateTime), 63, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (141, 1, CAST(N'2024-11-25T00:00:00.000' AS DateTime), CAST(N'2024-11-27T00:00:00.000' AS DateTime), N'Workshop', 2, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-06T22:54:10.013' AS DateTime), 63, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (142, 2, CAST(N'2024-09-15T00:00:00.000' AS DateTime), CAST(N'2024-09-16T00:00:00.000' AS DateTime), N'Medical appointment', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 64, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (143, 1, CAST(N'2024-10-25T00:00:00.000' AS DateTime), CAST(N'2024-10-27T00:00:00.000' AS DateTime), N'Travel', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 64, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (144, 2, CAST(N'2024-11-20T00:00:00.000' AS DateTime), CAST(N'2024-11-21T00:00:00.000' AS DateTime), N'Personal work', 4, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-11-03T01:45:18.970' AS DateTime), 64, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (145, 1, CAST(N'2024-10-20T00:00:00.000' AS DateTime), CAST(N'2024-10-22T00:00:00.000' AS DateTime), N'Travel', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 65, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (146, 2, CAST(N'2024-11-10T00:00:00.000' AS DateTime), CAST(N'2024-11-11T00:00:00.000' AS DateTime), N'Family event', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 65, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (147, 1, CAST(N'2024-12-15T00:00:00.000' AS DateTime), CAST(N'2024-12-17T00:00:00.000' AS DateTime), N'Conference', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 65, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (148, 2, CAST(N'2024-11-05T00:00:00.000' AS DateTime), CAST(N'2024-11-06T00:00:00.000' AS DateTime), N'Family event', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 66, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (149, 1, CAST(N'2024-12-01T00:00:00.000' AS DateTime), CAST(N'2024-12-03T00:00:00.000' AS DateTime), N'Vacation', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 66, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (150, 2, CAST(N'2024-10-15T00:00:00.000' AS DateTime), CAST(N'2024-10-16T00:00:00.000' AS DateTime), N'Personal work', 1, CAST(N'2024-09-28T01:03:09.060' AS DateTime), CAST(N'2024-09-28T01:03:09.060' AS DateTime), 66, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (151, 1, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), N'not interested', 1, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-11-06T22:34:41.163' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (152, 2, CAST(N'2024-10-15T00:00:00.000' AS DateTime), CAST(N'2024-10-15T00:00:00.000' AS DateTime), N'good Job', 1, CAST(N'2024-10-01T23:27:12.330' AS DateTime), CAST(N'2024-11-12T00:34:41.030' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (153, 1, CAST(N'2024-10-02T00:00:00.000' AS DateTime), CAST(N'2024-10-02T00:00:00.000' AS DateTime), N'Family function', 1, CAST(N'2024-10-01T23:31:18.647' AS DateTime), CAST(N'2024-10-01T23:31:18.917' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (154, 1, CAST(N'2024-10-03T00:00:00.000' AS DateTime), CAST(N'2024-10-03T00:00:00.000' AS DateTime), N'Family function', 1, CAST(N'2024-10-01T23:35:31.687' AS DateTime), CAST(N'2024-10-01T23:35:31.750' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (155, 1, CAST(N'2024-10-08T00:00:00.000' AS DateTime), CAST(N'2024-10-09T00:00:00.000' AS DateTime), N'not interested', 1, CAST(N'2024-10-02T22:51:16.920' AS DateTime), CAST(N'2024-11-06T22:34:06.040' AS DateTime), 61, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (156, 1, CAST(N'2024-10-06T00:00:00.000' AS DateTime), CAST(N'2024-10-07T00:00:00.000' AS DateTime), N'Family function', 1, CAST(N'2024-10-02T23:35:31.170' AS DateTime), CAST(N'2024-10-02T23:35:31.387' AS DateTime), 61, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (157, 1, CAST(N'2024-10-17T00:00:00.000' AS DateTime), CAST(N'2024-10-17T00:00:00.000' AS DateTime), N'Family function', 1, CAST(N'2024-10-04T00:24:17.203' AS DateTime), CAST(N'2024-10-04T00:24:17.203' AS DateTime), 64, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1157, 2, CAST(N'2024-10-31T00:00:00.000' AS DateTime), CAST(N'2024-10-31T00:00:00.000' AS DateTime), N'ok', 1, CAST(N'2024-10-30T13:46:49.807' AS DateTime), CAST(N'2024-10-30T13:46:49.807' AS DateTime), 63, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1158, 2, CAST(N'2024-11-01T00:00:00.000' AS DateTime), CAST(N'2024-11-02T00:00:00.000' AS DateTime), N'test ', 1, CAST(N'2024-10-30T14:12:52.480' AS DateTime), CAST(N'2024-10-30T14:12:52.480' AS DateTime), 63, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1159, 1, CAST(N'2024-11-03T00:00:00.000' AS DateTime), CAST(N'2024-11-03T00:00:00.000' AS DateTime), N'aa', 1, CAST(N'2024-10-30T14:14:20.863' AS DateTime), CAST(N'2024-10-30T14:14:20.863' AS DateTime), 63, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1160, 1, CAST(N'2024-11-04T00:00:00.000' AS DateTime), CAST(N'2024-11-04T00:00:00.000' AS DateTime), N'aa', 1, CAST(N'2024-10-30T14:14:49.223' AS DateTime), CAST(N'2024-10-30T14:14:49.223' AS DateTime), 63, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1161, 2, CAST(N'2024-11-01T00:00:00.000' AS DateTime), CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'diwali', 1, CAST(N'2024-10-31T22:23:48.697' AS DateTime), CAST(N'2024-10-31T22:23:48.697' AS DateTime), 64, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1162, 1, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(N'2024-12-13T00:00:00.000' AS DateTime), N'No Problem', 1, CAST(N'2024-11-02T21:02:36.390' AS DateTime), CAST(N'2024-11-06T22:35:34.320' AS DateTime), 61, 3)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1163, 2, CAST(N'2024-12-18T00:00:00.000' AS DateTime), CAST(N'2024-12-18T00:00:00.000' AS DateTime), N'School holiday', 3, CAST(N'2024-11-02T21:27:11.357' AS DateTime), CAST(N'2024-11-02T21:57:49.207' AS DateTime), 61, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1164, 1, CAST(N'2024-12-15T00:00:00.000' AS DateTime), CAST(N'2024-12-16T00:00:00.000' AS DateTime), N'London', 2, CAST(N'2024-11-02T22:06:23.537' AS DateTime), CAST(N'2024-11-02T22:06:53.527' AS DateTime), 61, 2)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1165, 1, CAST(N'2024-11-07T00:00:00.000' AS DateTime), CAST(N'2024-11-07T00:00:00.000' AS DateTime), N'Today is fun day ', 1, CAST(N'2024-11-03T00:43:47.473' AS DateTime), CAST(N'2024-11-03T00:43:47.473' AS DateTime), 62, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1166, 2, CAST(N'2024-11-19T00:00:00.000' AS DateTime), CAST(N'2024-11-19T00:00:00.000' AS DateTime), N'temp ok ', 2, CAST(N'2024-11-06T22:50:36.087' AS DateTime), CAST(N'2024-11-06T22:54:45.673' AS DateTime), 63, 1)
GO
INSERT [dbo].[LeaveApplications] ([leaveId], [leaveTypeId], [leaveDateFrom], [leaveDateTo], [remark], [statusId], [applicationDate], [updatedDate], [empId], [totalLeaves]) VALUES (1167, 1, CAST(N'2024-12-19T00:00:00.000' AS DateTime), CAST(N'2024-12-20T00:00:00.000' AS DateTime), N'ok', 3, CAST(N'2024-11-16T10:18:33.350' AS DateTime), CAST(N'2024-11-16T10:19:42.537' AS DateTime), 64, 2)
GO
SET IDENTITY_INSERT [dbo].[LeaveApplications] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveBalances] ON 
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (41, 61, 1, CAST(20 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (42, 61, 2, CAST(10 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (43, 62, 1, CAST(20 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (44, 62, 2, CAST(10 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (45, 63, 1, CAST(20 AS Numeric(18, 0)), CAST(23 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (46, 63, 2, CAST(10 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (47, 64, 1, CAST(20 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (48, 64, 2, CAST(10 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (49, 65, 1, CAST(20 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (50, 65, 2, CAST(10 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (51, 66, 1, CAST(20 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)))
GO
INSERT [dbo].[LeaveBalances] ([leaveBalanceId], [empId], [leaveTypeId], [openingBalance], [currentBalance]) VALUES (52, 66, 2, CAST(10 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[LeaveBalances] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveTypes] ON 
GO
INSERT [dbo].[LeaveTypes] ([leaveTypeId], [leaveType], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (1, N'Earned Leave', CAST(N'2024-09-28T00:17:09.940' AS DateTime), CAST(N'2024-09-28T00:17:09.940' AS DateTime), 1, 1)
GO
INSERT [dbo].[LeaveTypes] ([leaveTypeId], [leaveType], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (2, N'Casual Leave', CAST(N'2024-09-28T00:17:09.940' AS DateTime), CAST(N'2024-09-28T00:17:09.940' AS DateTime), 1, 1)
GO
INSERT [dbo].[LeaveTypes] ([leaveTypeId], [leaveType], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (3, N'Sick Leave', CAST(N'2024-10-25T23:47:38.050' AS DateTime), CAST(N'2024-10-25T23:47:38.677' AS DateTime), 61, 61)
GO
SET IDENTITY_INSERT [dbo].[LeaveTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuAccessMaster] ON 
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (310, 2, 2)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (311, 2, 3)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (312, 2, 4)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (313, 2, 5)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (314, 2, 6)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (315, 3, 2)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (316, 3, 3)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (317, 3, 4)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (318, 3, 5)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (319, 3, 6)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (320, 3, 7)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (321, 3, 8)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (322, 3, 1)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (323, 1, 9)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (324, 1, 10)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (325, 1, 2)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (326, 1, 3)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (327, 1, 4)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (328, 1, 5)
GO
INSERT [dbo].[MenuAccessMaster] ([accessMasterId], [roleId], [menuId]) VALUES (329, 1, 6)
GO
SET IDENTITY_INSERT [dbo].[MenuAccessMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (1, N'Employees Dashboard', N'/dashboard')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (2, N'Apply Leave', N'/apply-leave')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (3, N'Cancel Leave', N'/cancel-leave')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (4, N'Edit Leave ', N'/edit-leave-application')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (5, N'View Public Holidays', N'/view-public-holidays')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (6, N'Profile Settings', N'/profile-settings')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (7, N'Approve Leaves', N'/approve-leaves')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (8, N'Decline Leaves', N'/decline-leaves')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (9, N'Manage Employee Profiles', N'/manage-employee-profiles')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (10, N'Admin Panel', N'/admin-panel')
GO
INSERT [dbo].[Menus] ([menuId], [menuName], [url]) VALUES (11, N'WorkFlow Dashboard', N'/workflowDashboard')
GO
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[Organisations] ON 
GO
INSERT [dbo].[Organisations] ([orgId], [name]) VALUES (1, N'Demo Technologies')
GO
SET IDENTITY_INSERT [dbo].[Organisations] OFF
GO
SET IDENTITY_INSERT [dbo].[Process] ON 
GO
INSERT [dbo].[Process] ([processId], [processName], [createdAt], [updatedAt], [CreatedBy], [UpdatedBy]) VALUES (1, N'Leave Management', CAST(N'2024-09-28T00:17:09.930' AS DateTime), CAST(N'2024-09-28T00:17:09.930' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Process] OFF
GO
SET IDENTITY_INSERT [dbo].[ProcessMaster] ON 
GO
INSERT [dbo].[ProcessMaster] ([processMasterId], [applicationType], [processId]) VALUES (1, N'leave application', 1)
GO
SET IDENTITY_INSERT [dbo].[ProcessMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ProcessStages] ON 
GO
INSERT [dbo].[ProcessStages] ([nextStageId], [stageId], [stageName], [stageStatus], [performedByRoleId], [processId]) VALUES (NULL, 19, N'Manager Approval', N'pending', 3, 1)
GO
SET IDENTITY_INSERT [dbo].[ProcessStages] OFF
GO
SET IDENTITY_INSERT [dbo].[PublicHolidays] ON 
GO
INSERT [dbo].[PublicHolidays] ([holidayId], [holidayDate], [holidayInfo], [orgId]) VALUES (1, CAST(N'2024-01-01T00:00:00.000' AS DateTime), N'New Year ', 1)
GO
INSERT [dbo].[PublicHolidays] ([holidayId], [holidayDate], [holidayInfo], [orgId]) VALUES (2, CAST(N'2024-08-15T00:00:00.000' AS DateTime), N'Independence Day', 1)
GO
INSERT [dbo].[PublicHolidays] ([holidayId], [holidayDate], [holidayInfo], [orgId]) VALUES (3, CAST(N'2024-12-25T00:00:00.000' AS DateTime), N'Christmas Day', 1)
GO
SET IDENTITY_INSERT [dbo].[PublicHolidays] OFF
GO
INSERT [dbo].[UserRoles] ([roleId], [roleName], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (1, N'admin', CAST(N'2024-09-28T01:03:09.057' AS DateTime), CAST(N'2024-09-28T01:03:09.057' AS DateTime), 61, 61)
GO
INSERT [dbo].[UserRoles] ([roleId], [roleName], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (2, N'user', CAST(N'2024-09-28T01:03:09.057' AS DateTime), CAST(N'2024-09-28T01:03:09.057' AS DateTime), 61, 61)
GO
INSERT [dbo].[UserRoles] ([roleId], [roleName], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (3, N'manager', CAST(N'2024-09-28T01:03:09.057' AS DateTime), CAST(N'2024-09-28T01:03:09.057' AS DateTime), 61, 61)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (1, N'chetan', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (2, N'himanshu', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (3, N'arjun', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (4, N'priya', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (5, N'rahul', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (6, N'neha', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-09-28T00:17:09.937' AS DateTime), CAST(N'2024-09-28T00:17:09.937' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (7, N'akash', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-03T12:12:26.877' AS DateTime), CAST(N'2024-10-03T12:12:27.080' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (8, N'GaneshT', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-03T12:31:32.767' AS DateTime), CAST(N'2024-10-03T13:08:14.957' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (9, N'NOEMP1', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T15:45:11.583' AS DateTime), CAST(N'2024-10-04T15:45:11.583' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (10, N'NOEMP3', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T15:52:41.203' AS DateTime), CAST(N'2024-10-04T15:52:41.203' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (11, N'NOEMP4', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T15:53:11.897' AS DateTime), CAST(N'2024-10-04T15:53:12.090' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (12, N'NOEMP5', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T18:09:08.240' AS DateTime), CAST(N'2024-10-04T18:09:08.240' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (13, N'NOEMP6', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T18:12:57.557' AS DateTime), CAST(N'2024-10-04T18:12:57.880' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (14, N'NOEMP7', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-04T18:23:42.877' AS DateTime), CAST(N'2024-10-04T18:23:43.777' AS DateTime), 61, 61)
GO
INSERT [dbo].[Users] ([userId], [userName], [password], [isActive], [createdAt], [updatedAt], [createdBy], [updatedBy]) VALUES (15, N'Ganesh', N'zYvM3/8mwYx8emNEgxpgNQ==', 1, CAST(N'2024-10-06T21:23:09.293' AS DateTime), CAST(N'2024-10-06T21:23:09.293' AS DateTime), 61, 61)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ProcessStages] ADD  CONSTRAINT [DF_ProcessStages_nextStageId]  DEFAULT ((-1)) FOR [nextStageId]
GO
ALTER TABLE [dbo].[ActionMaster]  WITH CHECK ADD  CONSTRAINT [FK_ActionMaster_Actions] FOREIGN KEY([actionId])
REFERENCES [dbo].[Actions] ([actionId])
GO
ALTER TABLE [dbo].[ActionMaster] CHECK CONSTRAINT [FK_ActionMaster_Actions]
GO
ALTER TABLE [dbo].[ActionMaster]  WITH CHECK ADD  CONSTRAINT [FK_ActionMaster_ApplicationStatus] FOREIGN KEY([updatedStatusId])
REFERENCES [dbo].[ApplicationStatus] ([statusId])
GO
ALTER TABLE [dbo].[ActionMaster] CHECK CONSTRAINT [FK_ActionMaster_ApplicationStatus]
GO
ALTER TABLE [dbo].[ActionMaster]  WITH CHECK ADD  CONSTRAINT [FK_ActionMaster_UserRoles] FOREIGN KEY([roleId])
REFERENCES [dbo].[UserRoles] ([roleId])
GO
ALTER TABLE [dbo].[ActionMaster] CHECK CONSTRAINT [FK_ActionMaster_UserRoles]
GO
ALTER TABLE [dbo].[CostCenters]  WITH CHECK ADD  CONSTRAINT [FK_CostCenters_Organisations] FOREIGN KEY([orgId])
REFERENCES [dbo].[Organisations] ([orgId])
GO
ALTER TABLE [dbo].[CostCenters] CHECK CONSTRAINT [FK_CostCenters_Organisations]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Organisations] FOREIGN KEY([orgId])
REFERENCES [dbo].[Organisations] ([orgId])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Organisations]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_CostCenters] FOREIGN KEY([costCenterId])
REFERENCES [dbo].[CostCenters] ([costCenterId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_CostCenters]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([dptId])
REFERENCES [dbo].[Departments] ([dptId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Organisations] FOREIGN KEY([orgId])
REFERENCES [dbo].[Organisations] ([orgId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Organisations]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_UserRoles] FOREIGN KEY([roleId])
REFERENCES [dbo].[UserRoles] ([roleId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_UserRoles]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[LeaveApplications]  WITH CHECK ADD  CONSTRAINT [FK_LeaveApplications_Employees] FOREIGN KEY([empId])
REFERENCES [dbo].[Employees] ([empId])
GO
ALTER TABLE [dbo].[LeaveApplications] CHECK CONSTRAINT [FK_LeaveApplications_Employees]
GO
ALTER TABLE [dbo].[LeaveApplications]  WITH CHECK ADD  CONSTRAINT [FK_LeaveApplications_LeaveTypes] FOREIGN KEY([leaveTypeId])
REFERENCES [dbo].[LeaveTypes] ([leaveTypeId])
GO
ALTER TABLE [dbo].[LeaveApplications] CHECK CONSTRAINT [FK_LeaveApplications_LeaveTypes]
GO
ALTER TABLE [dbo].[LeaveBalances]  WITH CHECK ADD  CONSTRAINT [FK_LeaveBalances_Employees] FOREIGN KEY([empId])
REFERENCES [dbo].[Employees] ([empId])
GO
ALTER TABLE [dbo].[LeaveBalances] CHECK CONSTRAINT [FK_LeaveBalances_Employees]
GO
ALTER TABLE [dbo].[LeaveBalances]  WITH CHECK ADD  CONSTRAINT [FK_LeaveBalances_LeaveTypes] FOREIGN KEY([leaveTypeId])
REFERENCES [dbo].[LeaveTypes] ([leaveTypeId])
GO
ALTER TABLE [dbo].[LeaveBalances] CHECK CONSTRAINT [FK_LeaveBalances_LeaveTypes]
GO
ALTER TABLE [dbo].[MenuAccessMaster]  WITH CHECK ADD  CONSTRAINT [FK_MenuAccessMaster_Menus] FOREIGN KEY([menuId])
REFERENCES [dbo].[Menus] ([menuId])
GO
ALTER TABLE [dbo].[MenuAccessMaster] CHECK CONSTRAINT [FK_MenuAccessMaster_Menus]
GO
ALTER TABLE [dbo].[MenuAccessMaster]  WITH CHECK ADD  CONSTRAINT [FK_MenuAccessMaster_UserRoles] FOREIGN KEY([roleId])
REFERENCES [dbo].[UserRoles] ([roleId])
GO
ALTER TABLE [dbo].[MenuAccessMaster] CHECK CONSTRAINT [FK_MenuAccessMaster_UserRoles]
GO
ALTER TABLE [dbo].[ProcessMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProcessMaster_Process] FOREIGN KEY([processId])
REFERENCES [dbo].[Process] ([processId])
GO
ALTER TABLE [dbo].[ProcessMaster] CHECK CONSTRAINT [FK_ProcessMaster_Process]
GO
ALTER TABLE [dbo].[ProcessStages]  WITH CHECK ADD  CONSTRAINT [FK_ProcessStages_Process] FOREIGN KEY([processId])
REFERENCES [dbo].[Process] ([processId])
GO
ALTER TABLE [dbo].[ProcessStages] CHECK CONSTRAINT [FK_ProcessStages_Process]
GO
ALTER TABLE [dbo].[ProcessStages]  WITH CHECK ADD  CONSTRAINT [FK_ProcessStages_ProcessStages] FOREIGN KEY([nextStageId])
REFERENCES [dbo].[ProcessStages] ([stageId])
GO
ALTER TABLE [dbo].[ProcessStages] CHECK CONSTRAINT [FK_ProcessStages_ProcessStages]
GO
ALTER TABLE [dbo].[PublicHolidays]  WITH CHECK ADD  CONSTRAINT [FK_PublicHolidays_Organisations] FOREIGN KEY([orgId])
REFERENCES [dbo].[Organisations] ([orgId])
GO
ALTER TABLE [dbo].[PublicHolidays] CHECK CONSTRAINT [FK_PublicHolidays_Organisations]
GO
USE [master]
GO
ALTER DATABASE [LeaveManagement] SET  READ_WRITE 
GO

 use LeaveManagement 