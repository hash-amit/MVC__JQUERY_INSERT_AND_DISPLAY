CREATE DATABASE DB_Company
USE DB_Company



truncate table Tbl_Emp
CREATE TABLE Tbl_Emp 
(
	EID INT PRIMARY KEY IDENTITY,
	[NAME] VARCHAR(60),
	EMAIL VARCHAR(60),
	MOBILE BIGINT
)

-- Creating proc to insert data
CREATE PROC sp_Insert
(
	@name varchar(60),
	@email varchar(60),
	@mobile bigint
)
AS
BEGIN
	INSERT INTO Tbl_Emp ([NAME],EMAIL,MOBILE)
	VALUES (@name,@email,@mobile)
END;

exec sp_Insert 'Amit','amit@gmail.com', 6465646464

CREATE PROC sp_GetRecords
AS
BEGIN
	SELECT * FROM Tbl_Emp
END;