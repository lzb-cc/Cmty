use master;
go
--������ݿ���ڣ�ɾ���ؽ�
if exists(select * from dbo.sysdatabases where name = 'CmtyDB')
drop database CmtyDB;

create database CmtyDB
go

use CmtyDB;
go
--������
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
insert into cfg_Universities values (N'������ѧ')
insert into cfg_Universities values (N'�廪��ѧ')
insert into cfg_Universities values (N'�人��ѧ')
insert into cfg_Universities values (N'���пƼ���ѧ')
insert into cfg_Universities values (N'�人�Ƽ���ѧ')

--cfg_UserType--
insert into cfg_UserType values (N'��ͨ�û�')
insert into cfg_UserType values (N'��ʦ')

----


----


----
go

use master;