create table UserData
(
   UserName varchar(20) not null, 
   CustomerFirstName varchar(20) not null, 
   CustomerSecondName varchar(20) not null, 
   States varchar(20) not null ,
   City varchar(20) not null ,
   PermenantAddress varchar(20) not null, 
   PinCode int  not null,
   CellNumber bigint not null,
   Email varchar(20) not null ,
   DateOfBirth varchar(20) not null,
   RegistrationNumber varchar(20) not null,
   Passwords varchar(20) not null,  
)
INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords)
values('ja','viki','kg','tamilnadu','erode','amman nagar',632198,0987654321,'jgh@gj.com','14/11/1999',25,'SD852963')
select * from UserData;
drop table UserData

CREATE TABLE Customer(
	CustomerID int,
	CustomerName varchar(30),
	DOB varchar(10)
)