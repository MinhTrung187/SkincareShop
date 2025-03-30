CREATE DATABASE SkincareShop
GO
USE SkincareShop
GO
ALTER DATABASE [SkincareShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SkincareShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SkincareShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SkincareShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SkincareShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SkincareShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SkincareShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [SkincareShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SkincareShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SkincareShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SkincareShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SkincareShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SkincareShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SkincareShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SkincareShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SkincareShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SkincareShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SkincareShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SkincareShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SkincareShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SkincareShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SkincareShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SkincareShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SkincareShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SkincareShop] SET RECOVERY FULL 
GO
ALTER DATABASE [SkincareShop] SET  MULTI_USER 
GO
ALTER DATABASE [SkincareShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SkincareShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SkincareShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SkincareShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SkincareShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SkincareShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SkincareShop', N'ON'
GO
ALTER DATABASE [SkincareShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [SkincareShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SkincareShop]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AddedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Rating] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[SkinTypeID] [int] NULL,
	[ImageUrl] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkinTypes]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkinTypes](
	[SkinTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SkinTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestAnswers]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAnswers](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerText] [nvarchar](max) NOT NULL,
	[SkinTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestQuestions]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestQuestions](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/31/2025 12:06:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (2, 1, 1, 5, N'Sản phẩm rất tốt, làm sạch dịu nhẹ.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (3, 1, 3, 4, N'Toner cấp ẩm tốt nhưng mùi hơi nồng.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (4, 2, 2, 4, N'Kem dưỡng ẩm khá tốt, thấm nhanh.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (5, 2, 5, 5, N'Rất thích kem chống nắng này, không nhờn rít.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (6, 3, 6, 3, N'Sữa rửa mặt kiểm soát dầu ổn, nhưng hơi khô da.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (7, 3, 8, 5, N'Serum trị mụn cực kỳ hiệu quả, mình rất hài lòng.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (8, 4, 4, 4, N'Serum dưỡng sáng da khá tốt, cần kiên trì sử dụng.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (9, 4, 9, 2, N'Không hợp với da mình lắm, bị kích ứng nhẹ.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (10, 5, 7, 5, N'Toner se khít lỗ chân lông hiệu quả, da mịn hơn nhiều.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [ProductID], [Rating], [Comment], [CreatedAt]) VALUES (11, 5, 10, 4, N'Kem chống nắng kiềm dầu ổn, nhưng hơi trắng quá.', CAST(N'2025-03-30T23:41:43.847' AS DateTime))
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (1, N'Gel rửa mặt nhẹ nhàng', N'Làm sạch da mà không làm mất độ ẩm tự nhiên.', CAST(150000.00 AS Decimal(10, 2)), 50, 1, N'https://images.unsplash.com/photo-1556228578-8c89e6adf883')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (2, N'Kem dưỡng ẩm cân bằng', N'Giữ ẩm mà không gây bết dính.', CAST(200000.00 AS Decimal(10, 2)), 40, 1, N'https://images.unsplash.com/photo-1571781926291-c477ebfd024b')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (3, N'Toner cấp ẩm', N'Cung cấp độ ẩm và làm dịu da.', CAST(180000.00 AS Decimal(10, 2)), 35, 1, N'https://images.pexels.com/photos/4041392/pexels-photo-4041392.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (4, N'Serum dưỡng sáng', N'Giúp da sáng khỏe, đều màu.', CAST(300000.00 AS Decimal(10, 2)), 25, 1, N'https://images.unsplash.com/photo-1596755094514-f87e34085b2c')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (5, N'Kem chống nắng dịu nhẹ', N'Bảo vệ da khỏi tia UV mà không gây nhờn.', CAST(250000.00 AS Decimal(10, 2)), 30, 1, N'https://images.pexels.com/photos/6621339/pexels-photo-6621339.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (6, N'Sữa rửa mặt kiểm soát dầu', N'Hỗ trợ giảm dầu thừa, giữ da sạch.', CAST(160000.00 AS Decimal(10, 2)), 50, 2, N'https://images.unsplash.com/photo-1631729371254-42d2890b8d83')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (7, N'Gel dưỡng kiểm soát nhờn', N'Giúp giảm bóng dầu và giữ da khô thoáng.', CAST(220000.00 AS Decimal(10, 2)), 40, 2, N'https://images.pexels.com/photos/4202924/pexels-photo-4202924.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (8, N'Toner se khít lỗ chân lông', N'Giúp kiểm soát dầu và thu nhỏ lỗ chân lông.', CAST(190000.00 AS Decimal(10, 2)), 35, 2, N'https://images.unsplash.com/photo-1625772452859-1c03d5bf1137')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (9, N'Serum trị mụn', N'Hỗ trợ ngăn ngừa và giảm mụn.', CAST(320000.00 AS Decimal(10, 2)), 25, 2, N'https://images.pexels.com/photos/6738588/pexels-photo-6738588.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (10, N'Kem chống nắng kiềm dầu', N'Giảm bóng dầu, bảo vệ da dưới ánh nắng.', CAST(270000.00 AS Decimal(10, 2)), 30, 2, N'https://images.unsplash.com/photo-1556228578-3a5c257abab3')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (11, N'Sữa rửa mặt dưỡng ẩm', N'Làm sạch nhẹ nhàng và cấp ẩm.', CAST(170000.00 AS Decimal(10, 2)), 50, 3, N'https://images.pexels.com/photos/4041391/pexels-photo-4041391.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (12, N'Kem dưỡng ẩm sâu', N'Dưỡng ẩm mạnh mẽ cho da khô.', CAST(240000.00 AS Decimal(10, 2)), 40, 3, N'https://images.unsplash.com/photo-1571781926291-c477ebfd024b')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (13, N'Toner dưỡng ẩm cao', N'Bổ sung độ ẩm giúp da mềm mại.', CAST(200000.00 AS Decimal(10, 2)), 35, 3, N'https://images.pexels.com/photos/4041393/pexels-photo-4041393.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (14, N'Serum cấp nước', N'Tăng cường độ ẩm và đàn hồi cho da.', CAST(330000.00 AS Decimal(10, 2)), 25, 3, N'https://images.unsplash.com/photo-1596755094514-f87e34085b2c')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (15, N'Kem chống nắng dưỡng ẩm', N'Vừa bảo vệ vừa cấp ẩm cho da khô.', CAST(280000.00 AS Decimal(10, 2)), 30, 3, N'https://images.pexels.com/photos/6621339/pexels-photo-6621339.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (16, N'Sữa rửa mặt dịu nhẹ', N'Giúp làm sạch mà không gây kích ứng.', CAST(180000.00 AS Decimal(10, 2)), 50, 4, N'https://images.unsplash.com/photo-1631729253089-467e08d2ca85')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (17, N'Kem dưỡng làm dịu', N'Giảm mẩn đỏ, giúp da thư giãn.', CAST(260000.00 AS Decimal(10, 2)), 40, 4, N'https://images.pexels.com/photos/4202925/pexels-photo-4202925.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (18, N'Toner làm dịu', N'Cân bằng da, giảm kích ứng.', CAST(210000.00 AS Decimal(10, 2)), 35, 4, N'https://images.unsplash.com/photo-1625772452549-1b335d2f4a23')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (19, N'Serum phục hồi da', N'Hỗ trợ tái tạo và bảo vệ da.', CAST(340000.00 AS Decimal(10, 2)), 25, 4, N'https://images.pexels.com/photos/4041394/pexels-photo-4041394.jpeg')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Stock], [SkinTypeID], [ImageUrl]) VALUES (20, N'Kem chống nắng cho da nhạy cảm', N'Bảo vệ da mà không gây kích ứng.', CAST(290000.00 AS Decimal(10, 2)), 30, 4, N'https://images.unsplash.com/photo-1571781926291-c477ebfd024b')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[SkinTypes] ON 

INSERT [dbo].[SkinTypes] ([SkinTypeID], [Name], [Description]) VALUES (1, N'Da thường', N'Loại da cân bằng, ít khuyết điểm. Dễ chăm sóc nhưng cần duy trì độ ẩm.')
INSERT [dbo].[SkinTypes] ([SkinTypeID], [Name], [Description]) VALUES (2, N'Da dầu', N'Loại da tiết nhiều dầu, dễ bóng nhờn và lỗ chân lông to. Cần sản phẩm kiểm soát dầu và làm sạch sâu.')
INSERT [dbo].[SkinTypes] ([SkinTypeID], [Name], [Description]) VALUES (3, N'Da khô', N'Loại da thiếu ẩm, dễ bong tróc, căng rát. Ưu tiên sản phẩm cấp ẩm và dịu nhẹ.')
INSERT [dbo].[SkinTypes] ([SkinTypeID], [Name], [Description]) VALUES (4, N'Da nhạy cảm', N'Loại da dễ bị kích ứng, mẩn đỏ, cần sản phẩm dịu nhẹ, không gây kích ứng.')
SET IDENTITY_INSERT [dbo].[SkinTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[TestAnswers] ON 

INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (25, 1, N'Giống như tình trạng của da từ lúc trước khi đi ngủ - bình thường', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (26, 1, N'Nhiều dầu, đặc biệt dầu tập trung ở vùng mũi và trán', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (27, 1, N'Khô và nẻ', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (28, 1, N'Tấy đỏ và thậm chí bong da thành từng mảng', 4)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (29, 2, N'Tốt', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (30, 2, N'Vẫn còn nhiều dầu', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (31, 2, N'Khô và ráp', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (32, 2, N'Mẩn đỏ', 4)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (33, 3, N'Nhỏ', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (34, 3, N'Lớn', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (35, 3, N'Khô', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (36, 3, N'Đỏ', 4)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (37, 4, N'Mềm, mịn', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (38, 4, N'Nhiều dầu', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (39, 4, N'Hơi thô ráp', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (40, 4, N'Mỏng và để lộ những đường mạch máu', 4)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (41, 5, N'Tình trạng giống như buổi sáng', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (42, 5, N'Sáng', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (43, 5, N'Khô', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (44, 5, N'Nhạy cảm', 4)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (45, 6, N'Thỉnh thoảng', 1)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (46, 6, N'Thường xuyên, đặc biệt vào chu kỳ', 2)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (47, 6, N'Không bao giờ', 3)
INSERT [dbo].[TestAnswers] ([AnswerID], [QuestionID], [AnswerText], [SkinTypeID]) VALUES (48, 6, N'Chỉ khi trang điểm', 4)
SET IDENTITY_INSERT [dbo].[TestAnswers] OFF
GO
SET IDENTITY_INSERT [dbo].[TestQuestions] ON 

INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (1, N'Vào mỗi bữa sáng thức dậy, bạn thấy da mình như thế nào?')
INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (2, N'Thực hiện rửa mặt với sữa rửa mặt của bạn với nước ấm. Từ 20 - 30'' sau, cảm nhận của da bạn là thế nào?')
INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (3, N'Hãy nhìn kỹ xem lỗ chân lông trên da bạn ra sao?')
INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (4, N'Từ nào dưới đây có thể miêu tả kết cấu da bạn?')
INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (5, N'Vào buổi trưa, da bạn ở tình trạng nào? (Không dùng tay, chỉ soi gương để đoán)')
INSERT [dbo].[TestQuestions] ([QuestionID], [QuestionText]) VALUES (6, N'Bạn có thường xuyên nặn mụn trứng cá?')
SET IDENTITY_INSERT [dbo].[TestQuestions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (1, N'Nguyen Van A', N'nguyenvana@example.com', N'hashed_password_123', N'Customer', CAST(N'2025-03-30T18:12:08.410' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (2, N'Tran Thi B', N'tranthib@example.com', N'hashed_password_456', N'Customer', CAST(N'2025-03-30T18:12:08.410' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (3, N'Admin User', N'admin@example.com', N'hashed_admin_password', N'Manager', CAST(N'2025-03-30T18:12:08.410' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (4, N'Hoàng Minh Tuấn', N'minhtuan@example.com', N'123456', N'Customer', CAST(N'2025-03-30T19:52:32.750' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (5, N'Nguyễn Thị Lan', N'lannguyen@example.com', N'123456', N'Customer', CAST(N'2025-03-30T19:52:32.750' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (6, N'Phạm Quốc Huy', N'quochuy@example.com', N'123456', N'Customer', CAST(N'2025-03-30T19:52:32.750' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (7, N'Lê Thanh Trúc', N'thanhtruc@example.com', N'123456', N'Customer', CAST(N'2025-03-30T19:52:32.750' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (8, N'Trần Văn Dũng', N'vandung@example.com', N'123456', N'Customer', CAST(N'2025-03-30T19:52:32.750' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105345701A1C3]    Script Date: 3/31/2025 12:06:53 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT (getdate()) FOR [AddedAt]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([SkinTypeID])
REFERENCES [dbo].[SkinTypes] ([SkinTypeID])
GO
ALTER TABLE [dbo].[TestAnswers]  WITH CHECK ADD FOREIGN KEY([QuestionID])
REFERENCES [dbo].[TestQuestions] ([QuestionID])
GO
ALTER TABLE [dbo].[TestAnswers]  WITH CHECK ADD FOREIGN KEY([SkinTypeID])
REFERENCES [dbo].[SkinTypes] ([SkinTypeID])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CHECK  (([Status]='Cancelled' OR [Status]='Completed' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Manager' OR [Role]='Staff' OR [Role]='Customer' OR [Role]='Guest'))
GO
USE [master]
GO
ALTER DATABASE [SkincareShop] SET  READ_WRITE 
GO
