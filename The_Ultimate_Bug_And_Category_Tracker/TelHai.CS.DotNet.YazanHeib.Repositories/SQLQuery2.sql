CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL,
    ParentCategoryId INT NULL 
)