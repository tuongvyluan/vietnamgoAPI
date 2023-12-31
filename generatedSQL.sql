USE [master]
GO
/****** Object:  Database [Vietnamgo]    Script Date: 6/23/2023 10:00:05 PM ******/
CREATE DATABASE [Vietnamgo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vietnamgo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.VYLUAN\MSSQL\DATA\Vietnamgo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vietnamgo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.VYLUAN\MSSQL\DATA\Vietnamgo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Vietnamgo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vietnamgo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vietnamgo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vietnamgo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vietnamgo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vietnamgo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vietnamgo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vietnamgo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Vietnamgo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vietnamgo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vietnamgo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vietnamgo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vietnamgo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vietnamgo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vietnamgo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vietnamgo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vietnamgo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Vietnamgo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vietnamgo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vietnamgo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vietnamgo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vietnamgo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vietnamgo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vietnamgo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vietnamgo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Vietnamgo] SET  MULTI_USER 
GO
ALTER DATABASE [Vietnamgo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vietnamgo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vietnamgo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vietnamgo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vietnamgo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Vietnamgo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Vietnamgo] SET QUERY_STORE = ON
GO
ALTER DATABASE [Vietnamgo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Vietnamgo]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[id] [varchar](12) NOT NULL,
	[customerId] [int] NULL,
	[tourId] [int] NULL,
	[touristNum] [int] NULL,
	[discount] [float] NULL,
	[paymentStatus] [bit] NOT NULL,
	[tripStatus] [varchar](10) NULL,
	[bookingDate] [datetime] NULL,
	[tripDate] [datetime] NULL,
	[paymentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstName] [nvarchar](20) NOT NULL,
	[middleName] [nvarchar](30) NULL,
	[lastName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[width] [float] NULL,
	[height] [float] NULL,
	[url] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[location_id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
	[raw_ranking] [int] NOT NULL,
	[rating] [float] NOT NULL,
	[ranking] [nvarchar](150) NULL,
	[description] [nvarchar](1000) NULL,
	[address] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationImages]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationImages](
	[location_id] [int] NOT NULL,
	[smallId] [int] NULL,
	[mediumId] [int] NULL,
	[largeId] [int] NULL,
	[originalId] [int] NULL,
	[thumbnailId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[location_id] [int] NULL,
	[title] [nvarchar](100) NULL,
	[rating] [int] NOT NULL,
	[published_date] [datetime] NULL,
	[published_platform] [varchar](20) NULL,
	[machine_translated] [bit] NULL,
	[summary] [nvarchar](500) NULL,
	[author] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tourGuideId] [int] NULL,
	[locationId] [int] NOT NULL,
	[tourName] [nvarchar](50) NULL,
	[tourDescription] [nvarchar](500) NULL,
	[tourTime] [nvarchar](20) NULL,
	[price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourGuide]    Script Date: 6/23/2023 10:00:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourGuide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstName] [nvarchar](20) NOT NULL,
	[middleName] [nvarchar](30) NULL,
	[lastName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Booking] ([id], [customerId], [tourId], [touristNum], [discount], [paymentStatus], [tripStatus], [bookingDate], [tripDate], [paymentDate]) VALUES (N'DH8326553', 6, 2, 1, 0, 1, N'Pending', CAST(N'2023-06-23T12:38:46.940' AS DateTime), NULL, CAST(N'2023-06-23T13:02:14.673' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (1, N'vy@gmail.com', N'1', N'Vy', NULL, N'Luan')
INSERT [dbo].[Customer] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (2, N'vytlse161396@fpt.edu.vn', N'1', N'Vy', N'Tuong', N'Luan')
INSERT [dbo].[Customer] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (6, N'vy1@gmail.com', N'2', N'Vy', N'', N'')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (1, 150, 150, N'https://statics.vinpearl.com/nha-tho-duc-ba-2_1624854355.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (2, 150, 150, N'https://ik.imagekit.io/tvlk/blog/2023/01/nha-tho-duc-ba-3.jpg?tr=dpr-2,w-675')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (3, 410, 550, N'https://i.ex-cdn.com/vntravellive.com/files/f1/uploaded/images/photo_news/800x800/news_20120524033118/nhathoducba0.jpg.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (4, 150, 150, N'https://statics.vinpearl.com/Ho-Chi-Minh-City-Book-Street-01_1678285459.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (6, 150, 150, N'https://cdn3.dhht.vn/wp-content/uploads/2022/08/bia-landmark-81-o-dau-an-gi-choi-gi-cac-goc-chup-hinh-dep.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (7, 150, 150, N'https://image.vietnamnews.vn/uploadvnnews/Article/2022/4/3/207346_cho.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (8, 150, 150, N'https://sacotravel.com/wp-content/uploads/2022/10/dia-dao-cu-chi-1.jpg')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (9, 150, 150, N'https://ik.imagekit.io/tvlk/blog/2018/11/bao-tang-lich-su-viet-nam-2.jpg?tr=dpr-2,w-675')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (10, 150, 150, N'https://image-tc.galaxy.tf/wijpeg-1czqq8n5w9kv36u4v66215tar/btmt-1_wide.jpg?crop=0%2C40%2C1280%2C720&width=1100')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (11, 150, 150, N'https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/20190923_Independence_Palace-10.jpg/1280px-20190923_Independence_Palace-10.jpg')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1234, N'Notre Dame Cathedral of Saigon', 5, 0, N'Places must visit in Ho Chi Minh City.', N'Established by French colonists who initially named it the Church of Saigon (French: l''Eglise de Saïgon), the cathedral was constructed between 1863 and 1880. The name Notre-Dame Cathedral has been used since 1959. It has two bell towers, reaching a height of 58 meters (190 feet).', N'01 Công xã Paris, Bến Nghé, District 1, Ho Chi Minh City.')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1235, N'Landmark 81', 5, 0, N'The highest building in Vietnam', N'Landmark 81 Vietnam has been the tallest skyscraper in the country until now. This is a magnificent structure with a total floor area of 141,000 square meters that includes hotels, serviced apartments, officetel commercial apartments, shopping centers, bars, restaurants, observation decks, and other amenities.', N'720 A Dien Bien Phu, Ward 22, Binh Thanh District, Ho Chi Minh City')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1236, N'Mekong Delta', 5, 0, NULL, N'The Mekong Delta in southern Vietnam is a vast maze of rivers, swamps and islands, home to floating markets, Khmer pagodas and villages surrounded by rice paddies.', N'South Vietnam')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1237, N'Cu Chi Tunnel', 5, 0, N'TOP 7 most adventurous destinations in Southeast Asia and TOP 12 most attractive underground wonders in the globe', N'Besides being the hustle and bustle of an economic hub, Ho Chi Minh City (Saigon) embraces historical vestiges appealing to both domestic and international tourists. Cu Chi Tunnels are one of the most significant relics of the city, offering first-hand experiences inside the massive underground cave and interesting insights into the lives of Vietnamese soldiers during the war. ', N'TL15, Phu Hiep, Cu Chi District, Ho Chi Minh City')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1238, N'Nguyen Van Binh Book Street', 5, 0, N'The first and most common book street in Ho Chi Minh City', N'Located in the heart of the city, Ho Chi Minh City book street, stretching 100 meters from Hai Ba Trung street to Notre Dame Cathedral, deeply impresses not only book lovers but also regular tourists. Besides immersing yourself in the book world, you can sit down and enjoy a sip of drink in the calming atmosphere. The place is also very close to some must-see destinations in Ho Chi Minh City.', N'Nguyen Van Binh Street, Ben Nghe Sub-district, District 1')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1239, N'Ho Chi Minh City Museum of History', 5, 0, N'History Museum - an ancient architecture built by the French for nearly a century (1929) with the style of "Innovative Indochina".', N'The museum owns more than 40,000 artifacts with many unique and precious collections originating from many countries and ethnic groups; materials and types are extremely diverse and rich. The collections introduce Vietnamese history and culture from primitive times to 1945 and introduce unique cultural features in the southern provinces and some countries in Asia.', N'Số 2 Nguyễn Bỉnh Khiêm, Phường Bến Nghé, Quận 1,
Thành phố Hồ Chí Minh')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1240, N'The Vietnam Fine Arts Museum', 5, 0, NULL, N'Housed in an elegant 1930s French colonial building, the Vietnam National Fine Arts Museum in Hanoi is arguably the country’s premier art museum. The building’s facade and interiors are extremely well-preserved and have a compelling mix of Indochine and classical French architecture.', N'97A Duc Chinh Street, Nguyen Thai Binh Ward, District 1, Ho Chi Minh City')
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (1241, N'Independance Palace', 5, 0, N'Peace symbol of Viet Nam', N'In 1858, French naval forces opened fire on Da Nang, launching an invasion of Vietnam. By 1867, the French had occupied the South’s six provinces (Bien Hoa, Gia Dinh, Dinh Tuong, Vinh Long, An Giang, Ha Tien). The following year, French authorities selected a location in the center of Saigon (the present site of the Independence Palace) to build a residence for the Governor-General of Indochina. The palace was known as Norodom Palace.', N'135 Nam Ky Khoi Nghia st., Dist. 1, HCMC')
GO
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1234, 1, 3, 2, 3, 3)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1235, 6, 6, 6, 6, 6)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1236, 7, 7, 7, 7, 7)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1237, 8, 8, 8, 8, 8)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1238, 4, 4, 4, 4, 4)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1239, 9, 9, 9, 9, 9)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1240, 10, 10, 10, 10, 10)
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (1241, 11, 11, 11, 11, 11)
GO
SET IDENTITY_INSERT [dbo].[Tour] ON 

INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (1, 1, 1234, N'2-hour Cathedral Guided Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'2 hours', 2.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (2, 1, 1234, N'1-hour Cathedral Guided Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'1 hour', 1.5000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (3, 1, 1235, N'Landmark Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'2 hours', 1.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (4, 1, 1236, N'Mekong Delta Full Combo', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'1 day', 30.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (5, 1, 1238, N'Book Street Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'1 hour', 0.5000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (6, 1, 1239, N'History Museum Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'4 hours', 2.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (7, 1, 1240, N'Art Museum Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'4 hours', 1.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (8, 1, 1241, N'Vietnamese Independence Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'4 hours', 3.0000)
INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (9, 1, 1237, N'Cu Chi Tunnel Tour', N'Join a guided group tour. All entrance fees, travel insurance, pick up & drop off included.', N'1 day', 40.0000)
SET IDENTITY_INSERT [dbo].[Tour] OFF
GO
SET IDENTITY_INSERT [dbo].[TourGuide] ON 

INSERT [dbo].[TourGuide] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (1, N'vy@gmail.com', N'1', N'Vy', NULL, N'Luan')
SET IDENTITY_INSERT [dbo].[TourGuide] OFF
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((1)) FOR [touristNum]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [paymentStatus]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT ('Pending') FOR [tripStatus]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT ((5)) FOR [raw_ranking]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT ((0)) FOR [rating]
GO
ALTER TABLE [dbo].[Review] ADD  DEFAULT ((0)) FOR [rating]
GO
ALTER TABLE [dbo].[Review] ADD  DEFAULT ((0)) FOR [machine_translated]
GO
ALTER TABLE [dbo].[Tour] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([tourId])
REFERENCES [dbo].[Tour] ([id])
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([largeId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([location_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([mediumId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([originalId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([smallId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[LocationImages]  WITH CHECK ADD FOREIGN KEY([thumbnailId])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([location_id])
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD FOREIGN KEY([locationId])
REFERENCES [dbo].[Location] ([location_id])
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD FOREIGN KEY([tourGuideId])
REFERENCES [dbo].[TourGuide] ([id])
GO
USE [master]
GO
ALTER DATABASE [Vietnamgo] SET  READ_WRITE 
GO
