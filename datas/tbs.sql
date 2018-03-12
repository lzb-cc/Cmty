
--如果数据库存在，删除重建
if exists(select * from dbo.sysdatabases where name = 'CmtyDB')
drop database CmtyDB;

create database CmtyDB

use CmtyDB;


--创建表
if OBJECT_ID('Universities') is not null
drop table Universities;

create table Universities
(
    Id    int,
	name  nvarchar(20),
	primary key(Id)
);

create table cfg_UserType
(
	Id    int,
	uType nvarchar(10),
	primary key (Id)
);

create table UserSets
(
	Email    nvarchar(20),
	Pwd		 nvarchar(16),
	uType    int,
	uName    nvarchar(20),
	primary key (Email),
	constraint fk_uType foreign key (uType) references cfg_UserType (Id)
);

use master;
