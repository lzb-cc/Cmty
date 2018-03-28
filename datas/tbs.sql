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

if OBJECT_ID('CourseSets') is not null drop table CourseSets;
create table CourseSets
(
    Id          nvarchar(20),
    university  int,
    name        nvarchar(20),
	desp		nvarchar(200),
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
	CommitUser   nvarchar(20),
	CommitDate   datetime,
	ReviewStatus int,
	Code	     nvarchar(20),
    university   int,
    name         nvarchar(20),
	desp		 nvarchar(200),
	pic_url		 nvarchar(200),
	primary key (CommitUser),
	constraint fk_CommitUser_tcs foreign key (CommitUser) references UserSets (Email),
	constraint fk_ReviewStatus_tcs foreign key (ReviewStatus) references cfg_ReviewStatus (Id)
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
insert into cfg_AdminType values (N'��������Ա')
insert into cfg_AdminType values (N'��ͨ����Ա')
insert into cfg_AdminType values (N'����Ա')

--AdminUsers--
insert into AdminUsers values (N'349911680@qq.com', N'123456', 1)


--cfg_ReviewStatus--
insert into cfg_ReviewStatus values (N'�����')
insert into cfg_ReviewStatus values (N'�����')
insert into cfg_ReviewStatus values (N'���ͨ��')
insert into cfg_ReviewStatus values (N'��˲�ͨ��')

----
go

use master;