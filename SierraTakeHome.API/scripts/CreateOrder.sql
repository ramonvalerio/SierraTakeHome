CREATE PROCEDURE CreateOrder
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT,
    @OrderID INT OUTPUT
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
    
    -- Get the ID of the inserted order
    SET @OrderID = SCOPE_IDENTITY()
END
