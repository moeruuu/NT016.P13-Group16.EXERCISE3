create database account
create table acc(
UserID int identity(1,1) primary key,
Username varchar(30) unique not null,
Pass varchar(251) not null,
Email varchar(50) unique not null,
Fullname nvarchar(150) not null,
Birthday date not null,
);
