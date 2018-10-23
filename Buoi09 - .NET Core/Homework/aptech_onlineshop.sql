
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/22/2018 11:07:39
-- Generated from EDMX file: C:\Users\PC\Documents\GitHub\Aptech-WebAPI\Buoi09 - .NET Core\Homework\Homework\Models\Homework.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aptech_onlineshop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_orderdetails_orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orderdetails] DROP CONSTRAINT [FK_orderdetails_orders];
GO
IF OBJECT_ID(N'[dbo].[FK_orderdetails_products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orderdetails] DROP CONSTRAINT [FK_orderdetails_products];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_customers];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_EmployeeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_EmployeeId];
GO
IF OBJECT_ID(N'[dbo].[FK_products_categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_products_categories];
GO
IF OBJECT_ID(N'[dbo].[FK_products_suppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_products_suppliers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categories];
GO
IF OBJECT_ID(N'[dbo].[customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[orderdetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orderdetails];
GO
IF OBJECT_ID(N'[dbo].[orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orders];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[suppliers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Desciption] nvarchar(500)  NULL
);
GO

-- Creating table 'customers'
CREATE TABLE [dbo].[customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [PhoneNumber] varchar(50)  NULL,
    [Address] nvarchar(500)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Birthday] datetime  NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] varchar(500)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(500)  NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [PhoneNumber] varchar(50)  NULL,
    [Address] nvarchar(500)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Birthday] datetime  NULL
);
GO

-- Creating table 'orderdetails'
CREATE TABLE [dbo].[orderdetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'orders'
CREATE TABLE [dbo].[orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedDate] datetime  NULL,
    [ShippedDate] datetime  NULL,
    [Status] varchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [ShippingAddress] nvarchar(500)  NULL,
    [ShippingCity] nvarchar(50)  NULL,
    [PaymentType] varchar(50)  NULL,
    [CustomerId] int  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Discount] decimal(18,2)  NOT NULL,
    [Stock] decimal(18,2)  NOT NULL,
    [CategoryId] int  NOT NULL,
    [SupplierId] int  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'suppliers'
CREATE TABLE [dbo].[suppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [PhoneNumber] varchar(50)  NULL,
    [Address] nvarchar(500)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'categories'
ALTER TABLE [dbo].[categories]
ADD CONSTRAINT [PK_categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'customers'
ALTER TABLE [dbo].[customers]
ADD CONSTRAINT [PK_customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'orderdetails'
ALTER TABLE [dbo].[orderdetails]
ADD CONSTRAINT [PK_orderdetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [PK_orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'suppliers'
ALTER TABLE [dbo].[suppliers]
ADD CONSTRAINT [PK_suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_products_categories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_products_categories'
CREATE INDEX [IX_FK_products_categories]
ON [dbo].[products]
    ([CategoryId]);
GO

-- Creating foreign key on [CustomerId] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_orders_customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_customers'
CREATE INDEX [IX_FK_orders_customers]
ON [dbo].[orders]
    ([CustomerId]);
GO

-- Creating foreign key on [EmployeeId] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_orders_EmployeeId]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_EmployeeId'
CREATE INDEX [IX_FK_orders_EmployeeId]
ON [dbo].[orders]
    ([EmployeeId]);
GO

-- Creating foreign key on [OrderId] in table 'orderdetails'
ALTER TABLE [dbo].[orderdetails]
ADD CONSTRAINT [FK_orderdetails_orders]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orderdetails_orders'
CREATE INDEX [IX_FK_orderdetails_orders]
ON [dbo].[orderdetails]
    ([OrderId]);
GO

-- Creating foreign key on [ProductId] in table 'orderdetails'
ALTER TABLE [dbo].[orderdetails]
ADD CONSTRAINT [FK_orderdetails_products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orderdetails_products'
CREATE INDEX [IX_FK_orderdetails_products]
ON [dbo].[orderdetails]
    ([ProductId]);
GO

-- Creating foreign key on [SupplierId] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_products_suppliers]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[suppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_products_suppliers'
CREATE INDEX [IX_FK_products_suppliers]
ON [dbo].[products]
    ([SupplierId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

--Viết câu lệnh UPDATE để cập nhật Price với điều kiện: Các mặt hàng có Price <= 100000 thì tăng thêm 10%
UPDATE products
SET Price = price + price*0.1
WHERE Price <= 100000;
    
--Viết câu lệnh UPDATE để cập nhật DISCOUNT với điều kiện: Các mặt hàng có Discount <= 10% thì tăng thêm 5%
UPDATE products
SET discount = discount + discount*0.05
WHERE discount <= 0.01;
    
--Viết câu lệnh XOÁ tất cả các mặt hàng có Stock là 0
DELETE FROM products
WHERE stock = 0;