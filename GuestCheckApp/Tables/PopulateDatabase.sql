
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='GuestCheck' and xtype='U')
	CREATE TABLE GuestCheck (      
		GuestCheckID INT IDENTITY(1,1) NOT NULL PRIMARY KEY     
		,GuestCheckStatus VARCHAR(10) NOT NULL CHECK (GuestCheckStatus IN('pending','completed','deleted')) 
		,GuestCheckValue DECIMAL(9,2) DEFAULT 0.00 NOT NULL
		,GuestCheckDateCreated DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL
	)      
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Product' and xtype='U')
	CREATE TABLE Product (      
		ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY      
		,ProductName varchar(20) NOT NULL      
		,ProductDescription varchar(20) NOT NULL    
		,ProductType VARCHAR(10) NOT NULL CHECK (ProductType IN('drink','food','dessert')) 
		,ProductValue FLOAT DEFAULT 0.00 NOT NULL
	)      
GO      

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='GuestCheckProduct' and xtype='U')
	CREATE TABLE GuestCheckProduct (      
		GuestCheckID int NOT NULL
		,ProductID int NOT NULL
		,ProductQty int NOT NULL
	)      
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='Product' and xtype='U')
INSERT INTO Product
(ProductName, ProductDescription, ProductType, ProductValue)
VALUES
('Coke', 'Better than pepsi', 'drink', '2.50'),
('Pepsi', 'Worst than Coke', 'drink', '1.50'),
('Dr. Pepper', 'Unusual', 'drink', '3.50'),
('Steak', '1kg', 'food', '12.50'),
('Meat Stew', 'Smells like heaven', 'food', '7.50'),
('Wine Balls', 'No Alcohol', 'dessert', '4.50')
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='GuestCheck' and xtype='U')
INSERT INTO GuestCheck
(GuestCheckStatus, GuestCheckValue)
VALUES
('pending', '15.00'),
('completed', '10.00'),
('deleted', '12.00')
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='GuestCheckProduct' and xtype='U')
INSERT INTO GuestCheckProduct
(GuestCheckID, ProductID, ProductQty)
VALUES
('1', '1', '1'),
('1', '4', '1'),
('2', '1', '1'),
('2', '5', '1'),
('3', '5', '1'),
('3', '6', '1')
GO