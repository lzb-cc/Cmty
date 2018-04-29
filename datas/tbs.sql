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
	Avatar      nvarchar(120),
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

if OBJECT_ID('TeacherCommentSets') is not null drop table TeacherCommentSets;
create table TeacherCommentSets
(
	Id			int  identity,
	T_Id		nvarchar(20),
	Email		nvarchar(20),
	cDate		datetime,
	Content		nvarchar(200),
	CmtFloor	int,
	primary key (Id),
	constraint fk_Code_ttcs foreign key (T_Id) references TeacherSets (Email),
	constraint fk_Email_ttcs foreign key (Email) references UserSets (Email)
);


if OBJECT_ID('cfg_SaleStatus') is not null drop table cfg_SaleStatus
create table cfg_SaleStatus
(
	Id	int identity,
	Desp  nvarchar(50),
	primary key (Id)
);

if OBJECT_ID('cfg_GoodsType') is not null drop table cfg_GoodsType
create table cfg_GoodsType
(
	Id		int identity,
	Desp    nvarchar(50),
	primary key(Id)
);

if OBJECT_ID('GoodsSets') is not null drop table GoodsSets
create table GoodsSets
(
	Id			int identity,
	Seller		nvarchar(20),
	Name		nvarchar(30),
	Mny 		int,
	Pic_Url		nvarchar(20),
	Desp		nvarchar(200),
	PubDate		datetime,
	SStatus     int,
	Buyer		nvarchar(20),
	Comment		nvarchar(200),
	GType		int,
	primary key (Id),
	constraint fk_Seller_gs   foreign key (Seller)   references UserSets (Email),
	constraint fk_SStatus_gs foreign key (SStatus) references cfg_SaleStatus (Id),
	constraint fk_GType_gs   foreign key (GType) references cfg_GoodsType (Id)
);

if OBJECT_ID('LeaveMsg') is not null drop table LeaveMsg
create table LeaveMsg
(
	Id		int identity,
	Gid		int,
	Email	nvarchar(20),
	PubDate	datetime,
	Content nvarchar(200),
	LmFloor int,
	primary key (Id),
	constraint fk_Gid_lm foreign key (Gid) references GoodsSets (Id),
	constraint fk_Email  foreign key (Email) references UserSets (Email)
);

if OBJECT_ID('cfg_PostType') is not null drop table cfg_PostType
create table cfg_PostType
(
	Id	int identity,
	Desp nvarchar(20),
	primary key (Id)
);

if OBJECT_ID('PostMsg') is not null drop table PostMsg
create table PostMsg
(
	Id         int identity,
	Email      nvarchar(20),
	Title      nvarchar(20),
	PType      int,
	Content    nvarchar(2000),
	PDate	   datetime,
	NoComments int,
	primary key (Id),
	constraint fk_Email_pm foreign key(Email) references UserSets(Email),
	constraint fk_PType_pm foreign key(PType) references cfg_PostType(Id)
);

if OBJECT_ID('PostReply') is not null drop table PostReply
create table PostReply
(
	Id		int identity,
	Email	nvarchar(20),
	Reply	int,
	Content nvarchar(2000),
	RDate	datetime,
	primary key (Id),
	constraint fk_Email_pr foreign key (Email) references UserSets(Email),
	constraint fk_Reply_pr foreign key (Reply) references PostMsg(Id)
);

if OBJECT_ID('PostReplyMsg') is not null drop table PostReplyMsg
create table PostReplyMsg
(
	Id      int identity,
	Email   nvarchar(20),
	Reply   int,
	Content nvarchar(2000),
	RDate	datetime,
	primary key(Id),
	constraint fk_Reply_prm foreign key (Reply) references PostReply(Id),
	constraint fk_Email_prm foreign key (Email) references UserSets(Email)
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

--cfg_JobTitle--
insert into cfg_JobTitle values (N'����')
insert into cfg_JobTitle values (N'��ʦ')
insert into cfg_JobTitle values (N'������')
insert into cfg_JobTitle values (N'����')
insert into cfg_JobTitle values (N'Ժʿ')

--cfg_SaleStatus--
insert into cfg_SaleStatus values(N'�����')
insert into cfg_SaleStatus values(N'�����')
insert into cfg_SaleStatus values(N'��˲�ͨ��')
insert into cfg_SaleStatus values(N'������')
insert into cfg_SaleStatus values(N'�ȴ��ջ�')
insert into cfg_SaleStatus values(N'�������')
insert into cfg_SaleStatus values(N'�ۺ�/�˻�')
insert into cfg_SaleStatus values(N'�˻����')

--cfg_GooldsType--
insert into cfg_GoodsType values(N'����')
insert into cfg_GoodsType values(N'�γ�����')
insert into cfg_GoodsType values(N'������')
insert into cfg_GoodsType values(N'�ʼ�')
insert into cfg_GoodsType values(N'���ֵ���')
insert into cfg_GoodsType values(N'�˶�����')

--cfg_PostType
insert into cfg_PostType values(N'�����ʴ�')
insert into cfg_PostType values(N'��������')
insert into cfg_PostType values(N'IT���ӻ�')
insert into cfg_PostType values(N'ְҵ����')
insert into cfg_PostType values(N'ѧϰ����')
insert into cfg_PostType values(N'����ר��')
insert into cfg_PostType values(N'��������')
insert into cfg_PostType values(N'��Ȥ����')
insert into cfg_PostType values(N'��ѧָ��')
insert into cfg_PostType values(N'����ר��')



go

use master;


--select * from sys.sysprocesses where dbid = DB_ID('CmtyDB')
--kill 55