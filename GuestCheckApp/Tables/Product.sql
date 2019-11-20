IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblProduct' and xtype='U')
	CREATE TABLE tblProduct (      
		ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY      
		,ProductName varchar(20) NOT NULL      
		,ProductDescription varchar(20) NOT NULL    
		,ProductType VARCHAR(10) NOT NULL CHECK (ProductType IN('drink','food','dessert')) 
		,ProductValue FLOAT DEFAULT 0.00 NOT NULL
	)      
GO      

IF EXISTS (SELECT * FROM sysobjects WHERE name='tblProduct' and xtype='U')
INSERT INTO tblProduct
(ProductName, ProductDescription, ProductType, ProductValue)
VALUES
('Coke', 'Better than pepsi', 'drink', '2.50'),
('Pepsi', 'Worst than Coke', 'drink', '1.50'),
('Dr. Pepper', 'Unusual', 'drink', '3.50'),
('Steak', '1kg', 'food', '12.50'),
('Meat Stew', 'Smells like heaven', 'food', '7.50'),
('Wine Balls', 'No Alcohol', 'dessert', '4.50')
GO