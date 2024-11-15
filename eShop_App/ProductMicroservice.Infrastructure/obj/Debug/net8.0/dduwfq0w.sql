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
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE TABLE [product_Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] varchar(50) NOT NULL,
        [Parent_Category_Id] int NULL,
        [Parent_CategoryId] int NULL,
        CONSTRAINT [PK_product_Categories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_product_Categories_product_Categories_Parent_CategoryId] FOREIGN KEY ([Parent_CategoryId]) REFERENCES [product_Categories] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE TABLE [Category_Variations] (
        [Id] int NOT NULL IDENTITY,
        [Category_Id] int NOT NULL,
        [Variation_Name] varchar(50) NOT NULL,
        [Product_CategoryId] int NULL,
        CONSTRAINT [PK_Category_Variations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Category_Variations_product_Categories_Product_CategoryId] FOREIGN KEY ([Product_CategoryId]) REFERENCES [product_Categories] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] varchar(128) NOT NULL,
        [Description] varchar(128) NOT NULL,
        [CategoryId] int NOT NULL,
        [Price] decimal(6,2) NOT NULL,
        [Qty] int NOT NULL,
        [Product_Image] varchar(128) NOT NULL,
        [SKU] varchar(10) NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_product_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [product_Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE TABLE [Variation_Values] (
        [Id] int NOT NULL IDENTITY,
        [Variation_Id] int NOT NULL,
        [Value] varchar(40) NOT NULL,
        [Category_VariationId] int NULL,
        CONSTRAINT [PK_Variation_Values] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Variation_Values_Category_Variations_Category_VariationId] FOREIGN KEY ([Category_VariationId]) REFERENCES [Category_Variations] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE TABLE [product_Variation_Values] (
        [Product_Id] int NOT NULL,
        [Variation_Value_Id] int NOT NULL,
        [Variation_ValueId] int NULL,
        [ProductId] int NULL,
        CONSTRAINT [PK_product_Variation_Values] PRIMARY KEY ([Product_Id], [Variation_Value_Id]),
        CONSTRAINT [FK_product_Variation_Values_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]),
        CONSTRAINT [FK_product_Variation_Values_Variation_Values_Variation_ValueId] FOREIGN KEY ([Variation_ValueId]) REFERENCES [Variation_Values] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_Category_Variations_Product_CategoryId] ON [Category_Variations] ([Product_CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_product_Categories_Parent_CategoryId] ON [product_Categories] ([Parent_CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_product_Variation_Values_ProductId] ON [product_Variation_Values] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_product_Variation_Values_Variation_ValueId] ON [product_Variation_Values] ([Variation_ValueId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    CREATE INDEX [IX_Variation_Values_Category_VariationId] ON [Variation_Values] ([Category_VariationId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111154229_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111154229_Init', N'8.0.10');
END;
GO

COMMIT;
GO

