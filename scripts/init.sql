CREATE DATABASE SierraTakeHome_DB
GO

USE SierraTakeHome_DB
GO

-- Create Procedure
CREATE PROCEDURE CreateOrder
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    DECLARE @Price FLOAT
    DECLARE @TotalCost FLOAT

    -- Get product price
    SELECT @Price = Price FROM TB_PRODUCT WHERE Id = @ProductID

    -- Calculate total cost
    SET @TotalCost = @Price * @Quantity

    -- Insert an order
    INSERT INTO TB_ORDER (CustomerID, ProductId, Quantity, TotalCost)
    VALUES (@CustomerID, @ProductID, @Quantity, @TotalCost)
END
GO

