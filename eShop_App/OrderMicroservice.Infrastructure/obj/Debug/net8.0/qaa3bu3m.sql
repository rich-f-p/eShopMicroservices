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
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Addresses] (
        [Id] int NOT NULL IDENTITY,
        [Street1] varchar(50) NOT NULL,
        [Street2] varchar(50) NOT NULL,
        [City] varchar(50) NOT NULL,
        [ZipCode] varchar(9) NOT NULL,
        [State] varchar(52) NOT NULL,
        [Country] varchar(56) NOT NULL,
        CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] varchar(50) NOT NULL,
        [LastName] varchar(50) NOT NULL,
        [Gender] varchar(50) NOT NULL,
        [Phone] varchar(15) NOT NULL,
        [Profile_PIC] varchar(300) NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [Order_Date] datetime2 NOT NULL,
        [CustomerId] int NOT NULL,
        [CustomerName] varchar(50) NOT NULL,
        [PaymentMethodId] int NOT NULL,
        [PaymentName] varchar(100) NOT NULL,
        [ShippingAddress] varchar(100) NOT NULL,
        [ShippingMethod] varchar(30) NOT NULL,
        [BillAmount] decimal(5,2) NOT NULL,
        [Order_Status] varchar(30) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Payment_Types] (
        [Id] int NOT NULL IDENTITY,
        [Name] varchar(100) NOT NULL,
        CONSTRAINT [PK_Payment_Types] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [ShoppingCarts] (
        [Id] int NOT NULL IDENTITY,
        [CustomerId] int NOT NULL,
        [CustomerName] varchar(100) NOT NULL,
        CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [User_Addresses] (
        [Id] int NOT NULL IDENTITY,
        [Customer_Id] int NOT NULL,
        [Address_Id] int NOT NULL,
        [IsDefaultAddress] bit NOT NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_User_Addresses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_User_Addresses_Addresses_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [Addresses] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_User_Addresses_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Order_Details] (
        [Id] int NOT NULL IDENTITY,
        [Order_Id] int NOT NULL,
        [Product_Id] int NOT NULL,
        [Product_Name] varchar(100) NOT NULL,
        [Qty] int NOT NULL,
        [Price] int NOT NULL,
        [Discount] int NOT NULL,
        CONSTRAINT [PK_Order_Details] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_Details_Orders_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [PaymentMethods] (
        [Id] int NOT NULL IDENTITY,
        [Payment_Type_Id] int NOT NULL,
        [Provider] varchar(60) NOT NULL,
        [AccountNumber] varchar(17) NOT NULL,
        [Expiry] varchar(10) NOT NULL,
        [IsDefault] bit NOT NULL,
        [CustomerId] int NOT NULL,
        [Payment_TypeId] int NULL,
        CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PaymentMethods_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PaymentMethods_Payment_Types_Payment_TypeId] FOREIGN KEY ([Payment_TypeId]) REFERENCES [Payment_Types] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE TABLE [Shopping_Cart_Items] (
        [Id] int NOT NULL IDENTITY,
        [Cart_Id] int NOT NULL,
        [ProductId] int NOT NULL,
        [ProductName] varchar(100) NOT NULL,
        [Qty] int NOT NULL,
        [Price] decimal(5,2) NOT NULL,
        CONSTRAINT [PK_Shopping_Cart_Items] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Shopping_Cart_Items_ShoppingCarts_Cart_Id] FOREIGN KEY ([Cart_Id]) REFERENCES [ShoppingCarts] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE INDEX [IX_Order_Details_Order_Id] ON [Order_Details] ([Order_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE INDEX [IX_PaymentMethods_CustomerId] ON [PaymentMethods] ([CustomerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE INDEX [IX_PaymentMethods_Payment_TypeId] ON [PaymentMethods] ([Payment_TypeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE INDEX [IX_Shopping_Cart_Items_Cart_Id] ON [Shopping_Cart_Items] ([Cart_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE UNIQUE INDEX [IX_User_Addresses_Address_Id] ON [User_Addresses] ([Address_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    CREATE INDEX [IX_User_Addresses_CustomerId] ON [User_Addresses] ([CustomerId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111153604_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111153604_Init', N'8.0.10');
END;
GO

COMMIT;
GO

