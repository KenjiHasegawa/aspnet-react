
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGuestCheck' and xtype='U')
	CREATE TABLE tblGuestCheck (      
		GuestCheckID int IDENTITY(1,1) NOT NULL PRIMARY KEY,      
		GuestCheckStatus VARCHAR(10) NOT NULL CHECK (GuestCheckStatus IN('created','completed','deleted')) 
	)      
GO
