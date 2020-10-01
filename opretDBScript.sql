use master
if exists (select * from sys.databases where name = 'DatingApp')
begin
	alter database DatingApp
	set Single_User
	drop database DatingApp
end

create database DatingApp
go
use DatingApp
go

create table users
(
id int primary key identity (1,1)
,username nvarchar(30) not null
,pw nvarchar(40) not null
,email nvarchar(50) not null
)

create table profiles
(
ID int primary key identity(1,1)
,UserId int
,firstname nvarchar(50) not null
,lastname nvarchar(50) not null
,gender nvarchar(10) not null
,interestedIn nvarchar(10) not null
,height int
,eyecolor nvarchar(20) not null default 'N/A'
,haircolor nvarchar(30) not null default 'N/A'
,dateOfBirth date not null
,isActive bit default 1
,about nvarchar(MAX) not null default 'This user has no info yet...'
)

create table likes
(
senderId int not null
,recieverId int not null
,TS datetime
primary key (senderId, recieverId)
)

alter table profiles
add foreign key (userId) references users(id)

alter table likes
add foreign key (senderId) references profiles(ID)

alter table likes
add foreign key (recieverId) references profiles(ID)


Create table [Messages]
(
	SenderId int not null,
	RecieverId int not null,
	TS timestamp,
	Tekst nvarchar(max)
	primary key(SenderId, RecieverId, TS)
)

Alter table [Messages]
Add foreign key (SenderId) references profiles(ID)

Alter table [Messages]
Add foreign key (RecieverId) references profiles(ID)
