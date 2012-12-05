
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/05/2012 03:11:51
-- Generated from EDMX file: C:\Users\dimitar\Documents\Visual Studio 2012\Projects\pt_project\PTProject\Models\EFModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PHT_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_parentsearchable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Searchables] DROP CONSTRAINT [FK_parentsearchable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Searchables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Searchables];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Searchables'
CREATE TABLE [dbo].[Searchables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [content] nvarchar(max)  NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [unitId] int  NOT NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [unit_id] int  NULL,
    [in_progress] bit  NULL,
    [approved] bit  NULL,
    [usersId] nvarchar(max)  NOT NULL,
    [can_be_searched] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Searchables'
ALTER TABLE [dbo].[Searchables]
ADD CONSTRAINT [PK_Searchables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [unitId] in table 'Searchables'
ALTER TABLE [dbo].[Searchables]
ADD CONSTRAINT [FK_parentsearchable]
    FOREIGN KEY ([unitId])
    REFERENCES [dbo].[Units]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_parentsearchable'
CREATE INDEX [IX_FK_parentsearchable]
ON [dbo].[Searchables]
    ([unitId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------