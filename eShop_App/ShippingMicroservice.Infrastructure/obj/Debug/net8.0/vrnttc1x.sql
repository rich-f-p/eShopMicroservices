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
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE TABLE [Regions] (
        [Id] int NOT NULL IDENTITY,
        [Name] varchar(100) NOT NULL,
        CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE TABLE [Shippers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(256) NOT NULL,
        [EmailId] nvarchar(255) NULL,
        [Phone] nvarchar(max) NULL,
        [Contact_Person] nvarchar(256) NOT NULL,
        CONSTRAINT [PK_Shippers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE TABLE [Shippers_Region] (
        [Region_Id] int NOT NULL,
        [Shipper_Id] int NOT NULL,
        [Active] bit NOT NULL,
        [ShipperId] int NULL,
        [RegionId] int NULL,
        CONSTRAINT [PK_Shippers_Region] PRIMARY KEY ([Region_Id], [Shipper_Id]),
        CONSTRAINT [FK_Shippers_Region_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]),
        CONSTRAINT [FK_Shippers_Region_Shippers_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shippers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE TABLE [Shipping_Details] (
        [Id] int NOT NULL IDENTITY,
        [Order_Id] int NOT NULL,
        [Shipper_Id] int NOT NULL,
        [Shipping_Status] varchar(100) NOT NULL DEFAULT 'Order starting',
        [Tracking_Number] varchar(200) NOT NULL,
        [ShipperId] int NULL,
        CONSTRAINT [PK_Shipping_Details] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Shipping_Details_Shippers_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shippers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE INDEX [IX_Shippers_Region_RegionId] ON [Shippers_Region] ([RegionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE INDEX [IX_Shippers_Region_ShipperId] ON [Shippers_Region] ([ShipperId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    CREATE INDEX [IX_Shipping_Details_ShipperId] ON [Shipping_Details] ([ShipperId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154508_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111154508_Init', N'8.0.10');
END;
GO

COMMIT;
GO

