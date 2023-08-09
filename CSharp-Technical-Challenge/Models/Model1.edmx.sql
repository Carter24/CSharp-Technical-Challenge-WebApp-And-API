
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/08/2023 23:29:37
-- Generated from EDMX file: C:\Users\carlo\source\repos\CSharp-Technical-Challenge\CSharp-Technical-Challenge\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Shopping];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Employee__Type__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__Type__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Shop__ID_Employe__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shop] DROP CONSTRAINT [FK__Shop__ID_Employe__4F7CD00D];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[EmployeeType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[Shop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shop];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NULL,
    [Type] int  NOT NULL,
    [Telephone] nchar(8)  NULL,
    [Address] nchar(200)  NULL,
    [EmploymentDate] datetime  NULL
);
GO

-- Creating table 'EmployeeType'
CREATE TABLE [dbo].[EmployeeType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NULL,
    [Salary] decimal(18,2)  NULL
);
GO

-- Creating table 'Shop'
CREATE TABLE [dbo].[Shop] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NULL,
    [Address] nchar(200)  NULL,
    [Telephone] nchar(8)  NULL,
    [ID_Employee] int  NULL,
    [Shop_Date] datetime  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EmployeeType'
ALTER TABLE [dbo].[EmployeeType]
ADD CONSTRAINT [PK_EmployeeType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Shop_Date] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [PK_Shop]
    PRIMARY KEY CLUSTERED ([Shop_Date] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Type] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK__Employee__Type__412EB0B6]
    FOREIGN KEY ([Type])
    REFERENCES [dbo].[EmployeeType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__Type__412EB0B6'
CREATE INDEX [IX_FK__Employee__Type__412EB0B6]
ON [dbo].[Employee]
    ([Type]);
GO

-- Creating foreign key on [ID_Employee] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [FK__Shop__ID_Employe__4F7CD00D]
    FOREIGN KEY ([ID_Employee])
    REFERENCES [dbo].[Employee]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Shop__ID_Employe__4F7CD00D'
CREATE INDEX [IX_FK__Shop__ID_Employe__4F7CD00D]
ON [dbo].[Shop]
    ([ID_Employee]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------