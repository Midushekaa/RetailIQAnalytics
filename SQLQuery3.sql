USE master;
GO

ALTER DATABASE RetailIQAnalytics 
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE RetailIQAnalytics;
GO

CREATE DATABASE RetailIQAnalytics;
GO

USE RetailIQAnalytics;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'Executive',
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(150) NOT NULL,
    CategoryID INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL CHECK (UnitPrice >= 0),
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0),
    ReorderLevel INT NOT NULL DEFAULT 10,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Products_Category 
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO


CREATE TABLE InventoryTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    QuantityChange INT NOT NULL,
    TransactionType NVARCHAR(50) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Inventory_Product
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

CREATE INDEX IX_Products_CategoryID ON Products(CategoryID);
CREATE INDEX IX_Products_StockQuantity ON Products(StockQuantity);
CREATE INDEX IX_Inventory_ProductID ON InventoryTransactions(ProductID);
CREATE INDEX IX_Inventory_Date ON InventoryTransactions(TransactionDate);
GO


CREATE VIEW vw_ProductInventoryValue AS
SELECT 
    P.ProductID,
    P.ProductName,
    C.CategoryName,
    P.StockQuantity,
    P.UnitPrice,
    (P.StockQuantity * P.UnitPrice) AS InventoryValue,
    P.ReorderLevel,
    CASE 
        WHEN P.StockQuantity <= P.ReorderLevel THEN 'Low'
        ELSE 'Healthy'
    END AS StockStatus
FROM Products P
INNER JOIN Categories C ON P.CategoryID = C.CategoryID;
GO

CREATE TRIGGER trg_UpdateProductTimestamp
ON Products
AFTER UPDATE
AS
BEGIN
    UPDATE Products
    SET UpdatedAt = GETDATE()
    WHERE ProductID IN (SELECT ProductID FROM inserted);
END;
GO


CREATE PROCEDURE sp_GetExecutiveKPIs
AS
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Products) AS TotalProducts,
        (SELECT SUM(StockQuantity) FROM Products) AS TotalStock,
        (SELECT SUM(StockQuantity * UnitPrice) FROM Products) AS TotalInventoryValue,
        (SELECT AVG(StockQuantity) FROM Products) AS AvgStockPerProduct,
        (SELECT COUNT(*) FROM Products WHERE StockQuantity <= ReorderLevel) AS LowStockProducts,
        (SELECT TOP 1 ProductName 
         FROM Products
         ORDER BY (StockQuantity * UnitPrice) DESC) AS HighestValueProduct;
END;
GO


CREATE PROCEDURE sp_StockByProduct
AS
BEGIN
    SELECT ProductName, StockQuantity
    FROM Products
    ORDER BY ProductName;
END;
GO


CREATE PROCEDURE sp_CategoryDistribution
AS
BEGIN
    SELECT 
        C.CategoryName,
        SUM(P.StockQuantity) AS TotalStock
    FROM Products P
    INNER JOIN Categories C ON P.CategoryID = C.CategoryID
    GROUP BY C.CategoryName;
END;
GO


CREATE PROCEDURE sp_RiskAnalysis
AS
BEGIN
    SELECT 
        StockStatus,
        COUNT(*) AS ProductCount
    FROM vw_ProductInventoryValue
    GROUP BY StockStatus;
END;
GO

CREATE PROCEDURE sp_RegisterUser
    @FullName NVARCHAR(150),
    @Username NVARCHAR(100),
    @PasswordHash NVARCHAR(256),
    @Role NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        SELECT 'USERNAME_EXISTS' AS Result;
        RETURN;
    END

    INSERT INTO Users (FullName, Username, PasswordHash, Role)
    VALUES (@FullName, @Username, @PasswordHash, @Role);

    SELECT 'SUCCESS' AS Result;
END;
GO

CREATE PROCEDURE sp_LoginUser
    @Username NVARCHAR(100),
    @PasswordHash NVARCHAR(256)
AS
BEGIN
    SELECT 
        UserID,
        FullName,
        Username,
        Role
    FROM Users
    WHERE Username = @Username
      AND PasswordHash = @PasswordHash
      AND IsActive = 1;
END;
GO

-- Sample Users
DECLARE @PasswordHash NVARCHAR(256) = 'password123'; -- Use hashed passwords in real apps

EXEC sp_RegisterUser 'John Doe', 'john_doe', @PasswordHash, 'Executive';
EXEC sp_RegisterUser 'Jane Smith', 'jane_smith', @PasswordHash, 'Executive';
EXEC sp_RegisterUser 'Mike Lee', 'mike_lee', @PasswordHash, 'Executive';
EXEC sp_RegisterUser 'Alice Brown', 'alice_b', @PasswordHash, 'Executive';


INSERT INTO Categories (CategoryName) VALUES
('Electronics'),
('Groceries'),
('Clothing'),
('Home Appliances'),
('Furniture'),
('Sports & Fitness'),
('Beauty & Personal Care'),
('Stationery');


-- Electronics
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Laptop Pro 15"', 1, 285000.00, 18, 5),
('Smartphone X', 1, 165000.00, 7, 10),
('Bluetooth Headphones', 1, 12500.00, 45, 15),
('4K Smart TV 55"', 1, 325000.00, 4, 5);

-- Groceries
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Rice 5kg Pack', 2, 5500.00, 120, 30),
('Sugar 1kg', 2, 320.00, 200, 50),
('Cooking Oil 2L', 2, 1800.00, 85, 20),
('Milk Powder 400g', 2, 1350.00, 60, 25);

-- Clothing
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Men T-Shirt', 3, 3500.00, 70, 20),
('Women Jeans', 3, 8500.00, 30, 10),
('Kids Jacket', 3, 6500.00, 12, 8);

-- Home Appliances
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Microwave Oven', 4, 48000.00, 6, 5),
('Refrigerator 300L', 4, 210000.00, 3, 4),
('Electric Kettle', 4, 4500.00, 40, 15);

-- Furniture
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Office Chair', 5, 18500.00, 22, 10),
('Wooden Desk', 5, 45000.00, 8, 5),
('Bookshelf', 5, 22000.00, 14, 7);

-- Sports
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Treadmill', 6, 175000.00, 5, 3),
('Yoga Mat', 6, 2500.00, 60, 15),
('Dumbbell Set', 6, 15000.00, 20, 8);

-- Beauty & Personal Care
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Face Cream', 7, 2800.00, 75, 20),
('Shampoo 400ml', 7, 1200.00, 95, 25);

-- Stationery
INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) VALUES
('Notebook A4', 8, 450.00, 150, 40),
('Ballpoint Pen Pack', 8, 600.00, 180, 50);


INSERT INTO InventoryTransactions (ProductID, QuantityChange, TransactionType, TransactionDate) VALUES
(1, 5, 'Purchase', '2026-01-01'),
(1, -2, 'Sale', '2026-01-05'),
(2, -3, 'Sale', '2026-01-03'),
(3, 10, 'Purchase', '2026-01-04'),
(4, -1, 'Sale', '2026-01-06'),
(5, 25, 'Purchase', '2026-01-02'),
(6, -10, 'Sale', '2026-01-07'),
(7, 15, 'Purchase', '2026-01-08'),
(8, -5, 'Sale', '2026-01-09'),
(9, -8, 'Sale', '2026-01-10'),
(10, 10, 'Purchase', '2026-01-11'),
(11, -4, 'Sale', '2026-01-12'),
(12, 3, 'Purchase', '2026-01-13'),
(13, -1, 'Sale', '2026-01-14'),
(14, 12, 'Purchase', '2026-01-15'),
(15, -5, 'Sale', '2026-01-16'),
(16, 2, 'Purchase', '2026-01-17'),
(17, -3, 'Sale', '2026-01-18'),
(18, 1, 'Purchase', '2026-01-19'),
(19, -6, 'Sale', '2026-01-20'),
(20, 5, 'Purchase', '2026-01-21'),
(21, -7, 'Sale', '2026-01-22'),
(22, 10, 'Purchase', '2026-01-23'),
(23, -12, 'Sale', '2026-01-24'),
(24, 20, 'Purchase', '2026-01-25');

SELECT * FROM Users;
SELECT * FROM Categories;
SELECT * FROM Products;
SELECT * FROM vw_ProductInventoryValue;

SELECT name 
FROM sys.databases 
WHERE name = 'RetailIQAnalytics';