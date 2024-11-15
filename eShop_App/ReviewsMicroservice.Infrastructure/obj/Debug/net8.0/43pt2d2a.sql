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
    WHERE [MigrationId] = N'20241111154418_Init'
)
BEGIN
    CREATE TABLE [Customer_Reviews] (
        [Id] int NOT NULL IDENTITY,
        [Customer_Id] int NOT NULL,
        [Customer_Name] nvarchar(max) NOT NULL,
        [Order_Id] int NOT NULL,
        [Order_Date] datetime2 NOT NULL,
        [Product_Id] int NOT NULL,
        [Product_Name] nvarchar(max) NOT NULL,
        [Rating_Value] int NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        [Review_Date] datetime2 NOT NULL,
        [AdminApproval] nvarchar(max) NULL DEFAULT N'UnderReview',
        CONSTRAINT [PK_Customer_Reviews] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154418_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111154418_Init', N'8.0.10');
END;
GO

COMMIT;
GO

