CREATE DATABASE SierraTakeHome_DB
GO

USE SierraTakeHome_DB
GO

-- Create Tables
CREATE TABLE TB_PRODUCT (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
)
GO

CREATE TABLE TB_CUSTOMER (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
)
GO

CREATE TABLE TB_ORDER (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    TotalCost INT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES TB_PRODUCT(Id)
)
GO

-- Insert data
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 1', 10.00);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 2', 20.25);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 3', 30.50);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 4', 50.75);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 5', 100.00);

INSERT INTO TB_CUSTOMER (Name) VALUES ('Ramon Valerio');
INSERT INTO TB_CUSTOMER (Name) VALUES ('Thor');
INSERT INTO TB_CUSTOMER (Name) VALUES ('Batman');
GO

-- Create Procedure
CREATE PROCEDURE CreateOrder
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    DECLARE @Price DECIMAL(18, 2)
    DECLARE @TotalCost DECIMAL(18, 2)

    -- Get product price
    SELECT @Price = Price FROM TB_PRODUCT WHERE Id = @ProductID

    -- Calculate total cost
    SET @TotalCost = @Price * @Quantity

    -- Insert an order
    INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost)
    VALUES (@CustomerID, @ProductID, @Quantity, @TotalCost)
END
GO

