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

if OBJECT_ID('cfg_AdminType') is not null drop table cfg_AdminType;
create table cfg_AdminType
(
	Id    int identity,
	desp  nvarchar(10),
	primary key (Id)
);

if OBJECT_ID('cfg_ReviewStatus') is not null drop table cfg_ReviewStatus;
create table cfg_ReviewStatus
(
	Id	   int identity,
	Desp   nvarchar(20),
	primary key (Id)
);


if OBJECT_ID('cfg_JobTitle') is not null drop table cfg_JobTitle;
create table cfg_JobTitle
(
	Id	 int identity,
	Desp nvarchar(20),
	primary key (Id)
);

if OBJECT_ID('UserSets') is not null drop table UserSets;
create table UserSets
(
	Email      nvarchar(20),
	Pwd		   nvarchar(16),
	uName      nvarchar(20),
	rDate      datetime,
	Tel		   nvarchar(11),
	university int,
	primary key (Email),
	constraint fk_university_us foreign key (university) references cfg_Universities (Id),
);

if OBJECT_ID('TeacherSets') is not null drop table TeacherSets;
create table TeacherSets
(
	Email      nvarchar(20),
	uName      nvarchar(20),
	rDate      datetime,
	Sex		   nvarchar(10),
	Tel		   nvarchar(11),
	university int,
	jTitle	   int,
	Desp	   nvarchar(2000),
	primary key (Email),
	constraint fk_university_ts foreign key (university) references cfg_Universities (Id),
	constraint fk_jTitle_ts foreign key (jTitle) references cfg_JobTitle (Id)
);

if OBJECT_ID('CourseSets') is not null drop table CourseSets;
create table CourseSets
(
    Id          nvarchar(20),
    university  int,
    name        nvarchar(20),
	desp		nvarchar(2000),
	pic_url		nvarchar(200),
    primary key (Id),
    constraint fk_university_cs foreign key (university) references cfg_Universities (Id)
);


if OBJECT_ID('TeacherCourseSets') is not null drop table TeacherCourseSets;
create table TeacherCourseSets
(
    Email       nvarchar(20),
    CourseId    nvarchar(20),
    primary key (Email, CourseId),
    constraint fk_Email_tcs foreign key (Email) references TeacherSets (Email),
    constraint fk_CourseId_tcs foreign key (CourseId) references CourseSets (Id)
);

if OBJECT_ID('BookSets') is not null drop table BookSets;
create table BookSets
(
    Id          int,
    name        nvarchar(50),
    author      nvarchar(50),
    pic         nvarchar(50),
    desp        nvarchar(2000),
    primary key (Id)
);

if OBJECT_ID('ExtraUserInfo') is not null drop table ExtraUserInfo;
create table ExtraUserInfo
(
	Email		nvarchar(20),
	Sex			nvarchar(10),
	Nick		nvarchar(20),
	Hobby		nvarchar(30),
	primary key (Email),
	constraint fk_email_eui foreign key (Email) references UserSets (Email)
);

if OBJECT_ID('AdminUsers') is not null drop table AdminUsers;
create table AdminUsers
(
	Email		nvarchar(20),
	Pwd			nvarchar(20),
	authority	int,
	primary key (Email),
	constraint fk_authority_au foreign key (authority) references cfg_AdminType(Id)
);

if OBJECT_ID('tmp_CourseSets') is not null drop table tmp_CourseSets;
create table tmp_CourseSets
(
	Code	     nvarchar(20),	
	CommitUser   nvarchar(20),
	CommitDate   datetime,
	ReviewStatus int,
    university   int,
    name         nvarchar(20),
	desp		 nvarchar(2000),
	pic_url		 nvarchar(200),
	primary key (Code),
	constraint fk_CommitUser_tcs foreign key (CommitUser) references UserSets (Email),
	constraint fk_ReviewStatus_tcs foreign key (ReviewStatus) references cfg_ReviewStatus (Id)
);

if OBJECT_ID('CourseCommentSets') is not null drop table CourseCommentSets;
create table CourseCommentSets
(
	Id			int  identity,
	Code		nvarchar(20),
	Email		nvarchar(20),
	cDate		datetime,
	Content		nvarchar(200),
	CmtFloor	int,
	primary key (Id),
	constraint fk_Code_ccs foreign key (Code) references CourseSets (Id),
	constraint fk_Email_ccs foreign key (Email) references UserSets (Email)
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
insert into cfg_AdminType values (N'超级管理员')
insert into cfg_AdminType values (N'普通管理员')
insert into cfg_AdminType values (N'操作员')

--AdminUsers--
insert into AdminUsers values (N'349911680@qq.com', N'123456', 1)


--cfg_ReviewStatus--
insert into cfg_ReviewStatus values (N'待审核')
insert into cfg_ReviewStatus values (N'审核中')
insert into cfg_ReviewStatus values (N'审核通过')
insert into cfg_ReviewStatus values (N'审核不通过')

--cfg_JobTitle--
insert into cfg_JobTitle values (N'助教')
insert into cfg_JobTitle values (N'讲师')
insert into cfg_JobTitle values (N'副教授')
insert into cfg_JobTitle values (N'教授')
insert into cfg_JobTitle values (N'院士')


go

use master;