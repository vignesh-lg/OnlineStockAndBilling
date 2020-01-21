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
   DateOfBirth varchar(20)not null,
   RegistrationNumber varchar(20) not null,
   Passwords varchar(20) not null,  
)
select * from UserData;
drop table UserData