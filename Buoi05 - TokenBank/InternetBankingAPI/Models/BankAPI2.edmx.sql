
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/03/2018 09:42:41
-- Generated from EDMX file: C:\Users\PC\Documents\GitHub\Aptech-WebAPI\Buoi05 - TokenBank\InternetBankingAPI\Models\BankAPI.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_Accounts2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Accounts2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountName] nvarchar(50)  NOT NULL,
    [AccountNo] varchar(15)  NOT NULL,
    [PIN] varchar(100)  NOT NULL,
    [Balance] decimal(18,0)  NOT NULL,
    [isActive] bit  NOT NULL,
    [Token] nvarchar(100)  NULL,
    [LastLogin] datetime  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountIdFrom] int  NOT NULL,
    [AccountIdTo] int  NOT NULL,
    [Ammount] decimal(18,0)  NOT NULL,
    [TransDate] datetime  NOT NULL,
    [Messsage] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountIdFrom] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Accounts]
    FOREIGN KEY ([AccountIdFrom])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Accounts'
CREATE INDEX [IX_FK_Transactions_Accounts]
ON [dbo].[Transactions]
    ([AccountIdFrom]);
GO

-- Creating foreign key on [AccountIdTo] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Accounts2]
    FOREIGN KEY ([AccountIdTo])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Accounts2'
CREATE INDEX [IX_FK_Transactions_Accounts2]
ON [dbo].[Transactions]
    ([AccountIdTo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------