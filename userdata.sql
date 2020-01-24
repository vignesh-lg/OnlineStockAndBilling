use Project

create table UserData
(
   UserName varchar(20) not null, 
   CustomerFirstName varchar(20) not null, 
   CustomerSecondName varchar(20) not null, 
   States varchar(20) not null ,
   City varchar(20) not null ,
   PermenantAddress varchar(20) not null, 
   PinCode int  not null ,
   CellNumber bigint not null,
   Email varchar(20) not null ,
   DateOfBirth varchar(20) not null,
   RegistrationNumber varchar(20) not null,
   Passwords varchar(20) not null,  
   Personid int IDENTITY(1000,1)not null primary key,
)

INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords)
values('ja','viki','kg','tamilnadu','erode','amman nagar',632198,0987654321,'jgh@gj.com','14/11/1999',25,'SD852963')
select * from UserData;
--drop table Name.UserData
CREATE PROCEDURE UserData_Procedure
	@Action int,
	@UserName varchar(20) , 
	@CustomerFirstName varchar(20) , 
	@CustomerSecondName varchar(20) , 
	@State varchar(20)  ,
	@City varchar(20)  ,
	@PermenantAddress varchar(20) , 
	@PinCode int ,
	@CellNumber bigint ,
	@Email varchar(20)  ,
	@DateOfBirth varchar(20) ,
	@RegistrationNumber varchar(20) ,
	@Password varchar(20)
	
AS

BEGIN	
      --INSERT
      IF @Action = 1
      BEGIN
            INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords) VALUES (  @UserName,@CustomerFirstName,  @CustomerSecondName, @State,  @City,  @PermenantAddress  ,@PinCode,  @CellNumber,  @Email,  @DateOfBirth,  @RegistrationNumber,  @Password )
      END
 
      --UPDATE
      IF @Action = 2
      BEGIN
            Update UserData Set CustomerFirstName=@CustomerFirstName, CustomerSecondName= @CustomerSecondName,States= @State, City= @City, PermenantAddress= @PermenantAddress  ,PinCode=@PinCode, CellNumber= @CellNumber, Email= @Email,DateOfBirth=  @DateOfBirth, RegistrationNumber= @RegistrationNumber, Passwords= @Password where UserName=@UserName
			END
END

drop procedure UserData_Procedure

Create PROCEDURE User_Procedure
	@Action int,
	@UserName varchar(20) 
AS

BEGIN
	--SELECT
      IF @Action = 3
      BEGIN
            SELECT * FROM UserData
				WHERE UserName = @UserName
      END
       
      --DELETE
      IF @Action = 4
      BEGIN
            DELETE FROM UserData 
				WHERE UserName = @UserName
      END
END
Alter PROCEDURE User_Procedure_Login
	@UserName1 varchar(20), 
	@Password1 varchar(20)
AS

BEGIN
	--Login
            SELECT * from UserData WHERE UserName = @UserName1 and Passwords=@Password1
      END
	  --__________________________________________________________________________________--

create table ProductData
(
	OrderID int NOT NULL,
	PersonID int not null,
	FOREIGN KEY (personid) REFERENCES UserData(Personid),
   ProductName varchar(20) not null, 
   ProductNumber varchar(20) not null,
)
Insert into ProductData(OrderID,ProductName,ProductNumber,PersonID) values (1133,'viki','viki',1001)
select * from ProductData
drop table ProductData