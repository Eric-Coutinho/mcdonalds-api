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
	ID int Identity primary key,
	ItemName varchar(80) not null,
	Photo varbinary(MAX) null,
	DescriptionText varchar(400) not null,
);
go

create table Store(
	ID int Identity primary key,
	Localization varchar(200) not null,
);
go

create table MenuItem(
	ID int Identity primary key,
	ProductID int references Product(ID) not null,
	StoreID int references Store(ID) not null,
	Price decimal(5, 2) not null,
);
go

create table ClientOrder(
	ID int Identity primary key,
	OrderCode varchar(12) not null,
	StoreID int references Store(ID) not null,
	FinishMoment datetime null,
	DeliveryMoment datetime null,
);
go

create table ClientOrderItem(
	ID int Identity primary key,
	ClientOrderID int references ClientOrder(ID) not null,
	ProductID int references Product(ID) not null,
);
go

insert Store values
	('Mc do Portão pai'),
	('Mc do Pinheirinho pai'),
	('Mc do xaxim')
go
