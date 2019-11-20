IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblProduct' and xtype='U')
	CREATE TABLE tblProduct (      
		ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY      
		,ProductName varchar(20) NOT NULL      
		,ProductDescription varchar(20) NOT NULL    
		,ProductType VARCHAR(10) NOT NULL CHECK (ProductType IN('drink','food','dessert')) 
	)      
GO      
