IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154326_Init'
)
BEGIN
    CREATE TABLE [Promotion] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Discount] float NOT NULL,
        [Start_Date] datetime2 NOT NULL,
        [End_Date] datetime2 NOT NULL,
        CONSTRAINT [PK_Promotion] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154326_Init'
)
BEGIN
    CREATE TABLE [PromotionDetails] (
        [Id] int NOT NULL IDENTITY,
        [Promotion_Id] int NOT NULL,
        [Product_Category_Id] int NOT NULL,
        [Product_Category_Name] nvarchar(max) NOT NULL,
        [SaleId] int NULL,
        CONSTRAINT [PK_PromotionDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PromotionDetails_Promotion_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Promotion] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154326_Init'
)
BEGIN
    CREATE INDEX [IX_PromotionDetails_SaleId] ON [PromotionDetails] ([SaleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154326_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111154326_Init', N'8.0.10');
END;
GO

COMMIT;
GO

