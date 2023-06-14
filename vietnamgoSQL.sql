create database Vietnamgo
use Vietnamgo
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

create table TourGuide(
	id int identity primary key,
	email varchar(50) not null,
	password varchar(50) not null,
	firstName nvarchar(20) not null,
	middleName nvarchar(30),
	lastName nvarchar(20)
)

create table Tour(
	id int identity primary key,
	tourGuideId int references TourGuide(id),
	locationId int references Location(location_id),
	name nvarchar(50),
	price money not null default 0
)
--drop table Booking
create table Booking(
	id int identity primary key,
	customerId int references Customer(id),
	tourId int references Tour(id),
	discount float,
	paymentStatus bit default 0 not null,
	tripStatus bit default 0,
	bookingDate datetime,
	tripDate dateTime,
	paymentDate datetime
)