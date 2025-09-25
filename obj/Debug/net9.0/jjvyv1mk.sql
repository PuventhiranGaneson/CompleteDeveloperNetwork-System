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
CREATE TABLE [developers] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_developers] PRIMARY KEY ([Id])
);

CREATE TABLE [Hobbies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [DeveloperId] int NOT NULL,
    CONSTRAINT [PK_Hobbies] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Hobbies_developers_DeveloperId] FOREIGN KEY ([DeveloperId]) REFERENCES [developers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Skillsets] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [DeveloperId] int NOT NULL,
    CONSTRAINT [PK_Skillsets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Skillsets_developers_DeveloperId] FOREIGN KEY ([DeveloperId]) REFERENCES [developers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Hobbies_DeveloperId] ON [Hobbies] ([DeveloperId]);

CREATE INDEX [IX_Skillsets_DeveloperId] ON [Skillsets] ([DeveloperId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250925031225_InitialCreate', N'9.0.9');

COMMIT;
GO

