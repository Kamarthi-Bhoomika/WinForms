create database windowApp
use windowApp

create table user_login(
id int primary key,
password varchar(20))

insert into user_login values (2567455,'bhoomika@123')

select * from user_login

create table addTask(
Task varchar(50),
startDate date,
endDate date,
Progress int,  check (Progress between 0 and 100),
Status varchar(50), check (Status in ('In Progress','Completed')))

insert into addTask values( 'Windows Form', '11-23-2023','11-25-2023',100,'Completed')

CREATE PROCEDURE dbo.addData 
       @Task     varchar(50), 
       @startDate     date, 
       @endDate    date, 
       @Progress   int,
	   @Status    varchar(50)
AS 
BEGIN 
     INSERT INTO dbo.addTask ( Task, startDate, endDate, Progress, Status ) 
     VALUES ( @Task, @startDate, @endDate, @Progress, @Status) 
END

drop procedure addData

select * from addTask