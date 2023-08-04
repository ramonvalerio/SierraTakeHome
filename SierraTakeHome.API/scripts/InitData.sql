CREATE PROCEDURE InitData
AS
BEGIN
    -- CLEAR TABLES
    DELETE FROM TB_PRODUCT;
    DELETE FROM TB_CUSTOMER;

    -- Inser Products
    INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 1', 10.00);
    INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 2', 20.25);
    INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 3', 30.50);
    INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 4', 50.75);
    INSERT INTO TB_PRODUCT (Name, Price) VALUES ('Product 5', 100.00);

    -- Insert Customers
    INSERT INTO TB_CUSTOMER (Name) VALUES ('Ramon Valerio');
    INSERT INTO TB_CUSTOMER (Name) VALUES ('Thor');
    INSERT INTO TB_CUSTOMER (Name) VALUES ('Batman');
    INSERT INTO TB_CUSTOMER (Name) VALUES ('Maria');
    INSERT INTO TB_CUSTOMER (Name) VALUES ('Kate');
END
