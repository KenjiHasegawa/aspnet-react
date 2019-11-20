IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblProduct' and xtype='U')
	CREATE TABLE tblProduct (      
		ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY      
		,ProductName varchar(20) NOT NULL      
		,ProductDescription varchar(20) NOT NULL    
		,ProductType VARCHAR(10) NOT NULL CHECK (ProductType IN('drink','food','dessert')) 
	)      
GO      

IF EXISTS (SELECT * FROM sysobjects WHERE name='tblProduct' and xtype='U')
INSERT INTO tblProduct
(ProductName, ProductDescription, ProductType)
VALUES
('Coke', 'Better than pepsi', 'drink'),
('Pepsi', 'Worst than Coke', 'drink'),
('Dr. Pepper', 'Unusual', 'drink'),
('Steak', '1kg', 'food'),
('Meat Stew', 'Smells like heaven', 'food'),
('Wine Balls', 'No Alcohol', 'dessert')
GO