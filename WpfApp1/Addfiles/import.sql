create database TestDb
go
use TestDb
go
create table YourTableName(
	qw int,
	ww int,
	tt int
)
go
BULK INSERT YourTableName
FROM 'C:\Users\User\Desktop\qwe.txt'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
go
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;
go
SELECT *
INTO YourTableName1
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
                'Excel 12.0;Database=C:\Users\User\Desktop\qwe.xlsx',
                'SELECT * FROM [Sheet$]');




/*

SELECT *
INTO YourTableName
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
                'Excel 12.0;Database=C:\path\to\your\file.xlsx',
                'SELECT * FROM [Sheet1$]');


*/