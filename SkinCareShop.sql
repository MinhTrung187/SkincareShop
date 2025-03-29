CREATE DATABASE SkincareShop;
USE SkincareShop;

DROP DATABASE SkincareShop

-- Bảng lưu thông tin người dùng
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Guest', 'Customer', 'Staff', 'Manager')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng lưu thông tin loại da
CREATE TABLE SkinTypes (
    SkinTypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) UNIQUE NOT NULL
);

-- Bảng lưu bài kiểm tra loại da của khách hàng
CREATE TABLE UserSkinTests (
    TestID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    SkinTypeID INT,
    TestDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (SkinTypeID) REFERENCES SkinTypes(SkinTypeID)
);

-- Bảng lưu thông tin sản phẩm chăm sóc da
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    SkinTypeID INT,
    FOREIGN KEY (SkinTypeID) REFERENCES SkinTypes(SkinTypeID)
);

-- Bảng lưu đơn hàng của khách hàng
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng lưu chi tiết đơn hàng
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Bảng lưu phản hồi của khách hàng
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    ProductID INT,
    Rating INT CHECK(Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES
('Nguyen Van A', 'nguyenvana@example.com', 'hashed_password_123', 'Customer'),
('Tran Thi B', 'tranthib@example.com', 'hashed_password_456', 'Customer'),
('Admin User', 'admin@example.com', 'hashed_admin_password', 'Manager');

-- Chèn dữ liệu mẫu vào bảng SkinTypes
INSERT INTO SkinTypes (TypeName) VALUES
('Da dầu'),
('Da khô'),
('Da hỗn hợp'),
('Da thường');

-- Chèn dữ liệu mẫu vào bảng Products
INSERT INTO Products (Name, Description, Price, Stock, SkinTypeID) VALUES
('Sữa rửa mặt A', 'Sữa rửa mặt dành cho da dầu', 150000, 50, 1),
('Kem dưỡng B', 'Kem dưỡng ẩm dành cho da khô', 200000, 30, 2),
('Serum C', 'Serum dưỡng da hỗn hợp', 250000, 20, 3);

-- Chèn dữ liệu mẫu vào bảng Orders
INSERT INTO Orders (UserID, Status, TotalAmount) VALUES
(1, 'Completed', 150000),
(2, 'Pending', 200000);

-- Chèn dữ liệu mẫu vào bảng OrderDetails
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES
(1, 1, 1, 150000),
(2, 2, 1, 200000);

-- Chèn dữ liệu mẫu vào bảng Feedback
INSERT INTO Feedback (UserID, ProductID, Rating, Comment) VALUES
(1, 1, 5, 'Sản phẩm rất tốt!'),
(2, 2, 4, 'Chất lượng ổn, nhưng giá hơi cao.');