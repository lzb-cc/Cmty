use master;
go
--如果数据库存在，删除重建
if exists(select * from dbo.sysdatabases where name = 'CmtyDB')
drop database CmtyDB;

create database CmtyDB
go

use CmtyDB;
go
--创建表
if OBJECT_ID('cfg_Universities') is not null drop table cfg_Universities;
create table cfg_Universities
(
    Id    int identity,
	name  nvarchar(20),
	primary key(Id)
);

if OBJECT_ID('cfg_UserType') is not null drop table cfg_UserType;
create table cfg_UserType
(
	Id    int identity,
	uType nvarchar(10),
	primary key (Id)
);

if OBJECT_ID('UserSets') is not null drop table UserSets;
create table UserSets
(
	Email    nvarchar(20),
	Pwd		 nvarchar(16),
	uType    int default 0,
	uName    nvarchar(20),
	rDate    datetime,
	destroy  bit default 0,
	primary key (Email),
	constraint fk_uType_us foreign key (uType) references cfg_UserType (Id)
);

if OBJECT_ID('CourseSets') is not null drop table CourseSets;
create table CourseSets
(
    Id          int,
    university  int,
    name        nvarchar(20),
    primary key (Id),
    constraint fk_university_cs foreign key (university) references cfg_Universities (Id)
);

if OBJECT_ID('TeacherSets') is not null drop table TeacherSets;
create table TeacherSets
(
    Email       nvarchar(20),
    university  int,
    primary key (Email),
    constraint fk_university_ts foreign key (university) references cfg_Universities (Id),
    constraint fk_Email_ts foreign key (Email) references UserSets (Email)
);

if OBJECT_ID('TeacherCourseSets') is not null drop table TeacherCourseSets;
create table TeacherCourseSets
(
    Email       nvarchar(20),
    CourseId    int,
    primary key (Email, CourseId),
    constraint fk_Email_tcs foreign key (Email) references UserSets (Email),
    constraint fk_CourseId_tcs foreign key (CourseId) references CourseSets (Id)
);

if OBJECT_ID('BookSets') is not null drop table BookSets;
create table BookSets
(
    Id          int,
    name        nvarchar(50),
    author      nvarchar(50),
    pic         nvarchar(50),
    desp        nvarchar(200),
    primary key (Id)
);
go


use CmtyDB;
go
--cfg_Universities--
insert into cfg_Universities values (N'北京大学')
insert into cfg_Universities values (N'清华大学')
insert into cfg_Universities values (N'武汉大学')
insert into cfg_Universities values (N'华中科技大学')
insert into cfg_Universities values (N'武汉科技大学')

--cfg_UserType--
insert into cfg_UserType values (N'普通用户')
insert into cfg_UserType values (N'教师')

----


----


----
go

use master;