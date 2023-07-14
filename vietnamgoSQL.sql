create database Vietnamgo
use Vietnamgo
--drop table Image
create table Image(
	id int identity primary key,
	width float,
	height float,
	url nvarchar(150)
)
--drop table Location
create table Location(
	location_id int primary key,
	name nvarchar(150),
	raw_ranking int default 5 not null,
	rating float default 0 not null,
	ranking nvarchar(150),
	description nvarchar(150),
	address nvarchar(150),
)
--drop table Review
create table Review(
	review_id int identity primary key,
	location_id int references Location(location_id),
	title nvarchar(100),
	rating int not null default 0,
	published_date datetime,
	published_platform varchar(20),
	machine_translated bit default 0,
	summary nvarchar(500),
	author nvarchar(50)
)
--drop table LocationImages
create table LocationImages(
	location_id int primary key references Location(location_id) on delete cascade on update cascade,
	smallId int references Image(id),
	mediumId int references Image(id),
	largeId int references Image(id),
	originalId int references Image(id),
	thumbnailId int references Image(id),
)
--drop table Customer
create table Customer(
	id int identity primary key,
	email varchar(50) not null,
	password varchar(50) not null,
	firstName nvarchar(20) not null,
	middleName nvarchar(30),
	lastName nvarchar(20)
)
--drop table TourGuide
create table TourGuide(
	id int identity primary key,
	email varchar(50) not null,
	password varchar(50) not null,
	firstName nvarchar(20) not null,
	middleName nvarchar(30),
	lastName nvarchar(20)
)
--drop table Tour
create table Tour(
	id int identity primary key,
	tourGuideId int references TourGuide(id),
	locationId int references Location(location_id) not null,
	tourName nvarchar(50),
	tourDescription nvarchar(500),
	tourTime nvarchar(20),
	price money not null default 0
)
--drop table Booking
create table Booking(
	id varchar(12) primary key,
	customerId int references Customer(id),
	tourId int references Tour(id),
	touristNum int default 1,
	discount float,
	paymentStatus bit default 0 not null,
	tripStatus varchar(10) default 'Pending',
	bookingDate datetime,
	tripDate dateTime,
	paymentDate datetime
)

USE [Vietnamgo]
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (1, NULL, NULL, N'https://ik.imagekit.io/tvlk/blog/2023/04/bao-tang-chung-tich-chien-tranh-1.jpg?tr=dpr-2,w-675')
INSERT [dbo].[Image] ([id], [width], [height], [url]) VALUES (2, NULL, NULL, N'https://ik.imagekit.io/tvlk/blog/2023/04/bao-tang-chung-tich-chien-tranh-1.jpg?tr=dpr-2,w-675')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
INSERT [dbo].[Location] ([location_id], [name], [raw_ranking], [rating], [ranking], [description], [address]) VALUES (2200, N'Live with history', 5, 4, N'History Symbol
', N'Explore Vietnamese history with time flow. From  colonized by French to Independent Day in the war with America', N'Ho Chi Minh City')
GO
INSERT [dbo].[LocationImages] ([location_id], [smallId], [mediumId], [largeId], [originalId], [thumbnailId]) VALUES (2200, 2, 2, 1, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([review_id], [location_id], [title], [rating], [published_date], [published_platform], [machine_translated], [summary], [author]) VALUES (1, 2200, N'Good', 4, CAST(N'2023-07-12T23:28:02.337' AS DateTime), NULL, 0, N'Learn a lot about Vietnamese History', N'Nguyễn Trân')
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
SET IDENTITY_INSERT [dbo].[TourGuide] ON 

INSERT [dbo].[TourGuide] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (2, N'tran@gmail.com', N'1', N'Tran', N'Nguyen', N'Bao')
SET IDENTITY_INSERT [dbo].[TourGuide] OFF
GO
SET IDENTITY_INSERT [dbo].[Tour] ON 

INSERT [dbo].[Tour] ([id], [tourGuideId], [locationId], [tourName], [tourDescription], [tourTime], [price]) VALUES (2, NULL, 2200, N'Full support ', N'Pick-up Included, without accomodation', N'2 days', 1500000.0000)
SET IDENTITY_INSERT [dbo].[Tour] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [email], [password], [firstName], [middleName], [lastName]) VALUES (1, N'kristenguyenn@gmail.com', N'1', N'Nguyễn', N'Bảo', N'Trân')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Booking] ([id], [customerId], [tourId], [touristNum], [discount], [paymentStatus], [tripStatus], [bookingDate], [tripDate], [paymentDate]) VALUES (N'DH5585958', 1, 2, 1, 0, 1, N'Completed', CAST(N'2023-07-12T23:28:56.703' AS DateTime), CAST(N'2023-07-12T23:29:00.000' AS DateTime), CAST(N'2023-07-12T23:29:37.107' AS DateTime))
GO