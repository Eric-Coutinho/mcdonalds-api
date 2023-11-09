use master
go

if (exists(select * from sys.databases where name = 'McDataBase'))
	drop database McDataBase
go

create database McDataBase
go

use McDataBase
go

create table Product(
	ID int identify primary key,
	ItemName varchar(80) not null,
	Photo varbinary(MAX) null,
	DescriptionText varchar(400) not null,
);
go

create table Store(
	ID int identify primary key,
	Localization varchar(200) not null,
);
go

create table MenuItem(
	ID int identify primary key,
	ProductID int references Product(ID) not null,
	StoreID int references Store(ID) not null,
	Price decimal(5, 2) not null,
);
go

create table ClientOrder(
	ID int identify primary key,
	OrderCode varchar(12) not null,
	StoreID int references Store(ID) not null,
	Moment datetime not null,
	DeliveryMoment datetime null,
);
go

create table ClientOrderItem(
	ID int identify primary key,
	ClientOrderID int references ClientOrder(ID) not null,
	ProductID int references Product(ID) not null,
);
