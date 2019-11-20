IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGuestCheckProduct' and xtype='U')
	CREATE TABLE tblGuestCheckProduct (      
		GuestCheckProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY
		,GuestCheckID int NOT NULL
		,ProductID int NOT NULL
		,ProductQty int NOT NULL
	)      
GO