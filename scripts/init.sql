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
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product1', 100.50);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product2', 200.25);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product3', 150.75);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product4', 300.40);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product5', 50.10);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product6', 60.60);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product7', 120.80);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product8', 220.90);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product9', 130.00);
INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product10', 240.30);

INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (101, 1, 2, 201);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (102, 2, 3, 601);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (103, 3, 1, 151);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (104, 4, 5, 1502);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (105, 5, 4, 201);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (106, 6, 2, 121);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (107, 7, 3, 362);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (108, 8, 1, 221);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (109, 9, 2, 260);
INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost) VALUES (110, 10, 5, 1202);
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

