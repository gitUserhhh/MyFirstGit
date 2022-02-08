create database SQLModel
go
use SQLModel
go
create table LoginInfo
(
Lid int primary key identity(1,1),
Lusername nvarchar(50),
Luserpwd nvarchar(50),
Lrealname nvarchar(50)
)
go
create table ClsInfo
(
Cid int primary key identity(1,1),
Cname nvarchar(50)
)
go
create table StuInfo
(
Sid int primary key identity(101,1),
Ssex int check(Ssex = 1 or Ssex = 0),
Sschool nvarchar(50),
Sjobname nvarchar(50),
Sphone nvarchar(50),
Addtime datetime,
Scid int foreign key references ClsInfo(Cid)
)
go
insert into LoginInfo values('admin-zhangsan','pwd123','张三')
insert into LoginInfo values('admin-lisi','pwd456','李四')
insert into LoginInfo values('admin-wangwu','pwd789','王五')
insert into ClsInfo values('高计HP1901')
insert into ClsInfo values('高计HP1902')
insert into ClsInfo values('高计HP1903')
insert into StuInfo values(1,'清华大学','班长','13908761234','2019-11-11',1)
insert into StuInfo values(0,'北京大学','副班长','13508761201','2013-10-01',2)
insert into StuInfo values(1,'南京大学','学习委员','145087616348','2020-01-12',3)
select * from LoginInfo
select * from ClsInfo
select * from StuInfo
select * from ClsInfo inner join StuInfo on ClsInfo.Cid = StuInfo.Scid
go
declare @date datetime
select @date = DATEPART(YY,getdate())
print @date
go

