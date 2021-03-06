USE [master]
GO
/****** Object:  Database [prayasdb]    Script Date: 25-09-2020 12:26:30 ******/
CREATE DATABASE [prayasdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prayasdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.VIRAJ\MSSQL\DATA\prayasdb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'prayasdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.VIRAJ\MSSQL\DATA\prayasdb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [prayasdb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prayasdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prayasdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prayasdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prayasdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prayasdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prayasdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [prayasdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prayasdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prayasdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prayasdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prayasdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prayasdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prayasdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prayasdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prayasdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prayasdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prayasdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prayasdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prayasdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prayasdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prayasdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prayasdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prayasdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prayasdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [prayasdb] SET  MULTI_USER 
GO
ALTER DATABASE [prayasdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prayasdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prayasdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prayasdb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [prayasdb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [prayasdb]
GO
/****** Object:  Table [dbo].[wb_category_list]    Script Date: 25-09-2020 12:26:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wb_category_list](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_name] [nvarchar](max) NULL,
	[created_date] [date] NULL,
	[edited_date] [date] NULL,
 CONSTRAINT [PK_wb_category_list] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[wb_menu]    Script Date: 25-09-2020 12:26:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[wb_menu](
	[menu_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_name] [varchar](150) NULL,
	[menu_order] [int] NULL,
	[iconid] [varchar](100) NULL,
	[actionname] [varchar](150) NULL,
	[controllername] [varchar](150) NULL,
 CONSTRAINT [PK_wb_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[wb_product_list]    Script Date: 25-09-2020 12:26:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wb_product_list](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_id] [int] NOT NULL,
	[pro_name] [nvarchar](max) NULL,
	[created_date] [date] NULL,
	[edited_date] [date] NULL,
 CONSTRAINT [PK_wb_product_list] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[wb_category_list] ON 

INSERT [dbo].[wb_category_list] ([cat_id], [cat_name], [created_date], [edited_date]) VALUES (1, N'Books', CAST(N'2020-09-24' AS Date), CAST(N'2020-09-24' AS Date))
INSERT [dbo].[wb_category_list] ([cat_id], [cat_name], [created_date], [edited_date]) VALUES (2, N'Mobiles', CAST(N'2020-09-24' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[wb_category_list] OFF
SET IDENTITY_INSERT [dbo].[wb_menu] ON 

INSERT [dbo].[wb_menu] ([menu_id], [menu_name], [menu_order], [iconid], [actionname], [controllername]) VALUES (1, N'Category', 1, N'icon-list', N'Category', N'Category')
INSERT [dbo].[wb_menu] ([menu_id], [menu_name], [menu_order], [iconid], [actionname], [controllername]) VALUES (2, N'Product', 2, N'icon-list', N'Product', N'Product')
SET IDENTITY_INSERT [dbo].[wb_menu] OFF
SET IDENTITY_INSERT [dbo].[wb_product_list] ON 

INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (1, 1, N'SULA RASA', CAST(N'2020-09-24' AS Date), CAST(N'2020-09-24' AS Date))
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (2, 1, N'HK Book', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (3, 1, N'NB Book', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (4, 1, N'MK Book', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (5, 1, N'SD Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (6, 1, N'TATA Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (7, 1, N'WQ Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (8, 1, N'JK Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (9, 1, N'ERP Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (10, 1, N'DAQ Books', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (11, 2, N'Nokia', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (12, 2, N'One Plus', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (13, 2, N'Iphone', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (14, 2, N'RealMe', CAST(N'2020-09-24' AS Date), NULL)
INSERT [dbo].[wb_product_list] ([pro_id], [cat_id], [pro_name], [created_date], [edited_date]) VALUES (15, 2, N'Redmi', CAST(N'2020-09-24' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[wb_product_list] OFF
ALTER TABLE [dbo].[wb_product_list]  WITH CHECK ADD  CONSTRAINT [FK_wb_product_list_wb_product_list] FOREIGN KEY([cat_id])
REFERENCES [dbo].[wb_category_list] ([cat_id])
GO
ALTER TABLE [dbo].[wb_product_list] CHECK CONSTRAINT [FK_wb_product_list_wb_product_list]
GO
/****** Object:  StoredProcedure [dbo].[Master_Table_Transaction]    Script Date: 25-09-2020 12:26:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Master_Table_Transaction]
@tablename nvarchar(200), 
@trantype nvarchar(50),
@fieldname nvarchar(max),
@insertvalues nvarchar(max),
@filter nvarchar(max),
@orderby nvarchar(300),
@relationtable nvarchar(max),
@strRetVal varchar(8000)='' OUTPUT
as
Declare @strsql nvarchar(max)
begin
SET NOCOUNT ON;
BEGIN TRY
BEGIN TRANSACTION

if @trantype='Select' 

begin

set @strsql='Select '+@fieldname+' from '+@tablename+' with (nolock)  '+@relationtable+'';

if @filter!=''

begin

set @strsql=@strsql+' where '+@filter;

end

if @orderby!=''

begin

set @strsql=@strsql+' order by '+@orderby;

end  

end



else if @trantype='Insert'

begin

set @strsql='Insert Into '+@tablename+ ' ('+@fieldname+')  values ('+@insertvalues+')';

end 



else if @trantype='Update'

begin

set @strsql='UPDATE '+@tablename+' SET ' +@insertvalues+' where '+@filter;

end 



else if @trantype='Delete'

begin

set @strsql='Delete from '+@tablename+' where '+@filter;

end 





else if @trantype='Mutiple'

begin

set @strsql='Insert Into '+@tablename+ ' ('+@fieldname+')  ('+@insertvalues+')';

end 



Exec(@strsql);



COMMIT



END TRY

BEGIN CATCH

ROLLBACK TRANSACTION outProc;

SELECT @strRetVal= ERROR_MESSAGE();

END CATCH

end


GO
USE [master]
GO
ALTER DATABASE [prayasdb] SET  READ_WRITE 
GO
