
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGuestCheck' and xtype='U')
	CREATE TABLE tblGuestCheck (      
		GuestCheckID INT IDENTITY(1,1) NOT NULL PRIMARY KEY     
		,GuestCheckStatus VARCHAR(10) NOT NULL CHECK (GuestCheckStatus IN('created','completed','deleted')) 
		,GuestCheckValue DECIMAL(9,2) DEFAULT 0.00 NOT NULL
	)      
GO
