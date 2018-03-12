
--如果数据库存在，删除重建
if exists(select * from dbo.sysdatabases where name = 'CmtyDB')
drop database CmtyDB;

create database CmtyDB

use CmtyDB;


--创建表
if OBJECT_ID('Universities') is not null
drop table Universities;

create table cfg_Universities
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
	uType    int default 0,
	uName    nvarchar(20),
	primary key (Email),
	constraint fk_uType foreign key (uType) references cfg_UserType (Id)
);

create table CourseSets
(
    Id          int,
    university  int,
    name        nvarchar(20),
    primary key (Id),
    constraint fk_university references cfg_Universities (Id)
);

create table TeacherSets
(
    Email       nvarchar(20),
    university  int,
    primary key (Email),
    constraint fk_university references cfg_Universities (Id),
    constraint fk_Email Email references UserSets (Email)
);


create table TeacherCourseSets
(
    Email       nvarchar(20),
    CourseId    int,
    primary key (Email, CourseId),
    constraint fk_Email Email references UserSets (Email),
    constraint fk_CourseId CourseId references CourseSets (Id)
);

create table BookSets
(
    Id          int,
    name        nvarchar(50),
    author      nvarchar(50),
    pic         nvarchar(50),
    desp        nvarchar(200),
    primary key (Id)
);



use master;
