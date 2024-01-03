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

IF SCHEMA_ID(N'tingum') IS NULL EXEC(N'CREATE SCHEMA [tingum];');
GO

CREATE TABLE [tingum].[AppUsers] (
    [Id] uniqueidentifier NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [UserName] nvarchar(255) NOT NULL,
    [DisplayPhoto] nvarchar(255) NULL,
    [Email] nvarchar(255) NOT NULL,
    [Password] nvarchar(255) NOT NULL,
    [Biography] nvarchar(1024) NULL,
    [Role] int NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tingum].[ArticleCategories] (
    [Id] uniqueidentifier NOT NULL,
    [ArticleCategoryId] int NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [Description] nvarchar(720) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_ArticleCategories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tingum].[ArticleTags] (
    [Id] uniqueidentifier NOT NULL,
    [ArticleTagId] int NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tingum].[Articles] (
    [Id] uniqueidentifier NOT NULL,
    [ArticleId] int NOT NULL,
    [Title] nvarchar(255) NULL,
    [Description] nvarchar(512) NOT NULL,
    [Thumbnail] nvarchar(255) NULL,
    [CategoryId] uniqueidentifier NULL,
    [MarkupData] nvarchar(max) NULL,
    [ViewsCount] int NOT NULL,
    [LikesCount] int NOT NULL,
    [CommentsCount] int NOT NULL,
    [Status] int NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [DatePublished] datetime2 NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Articles_AppUsers_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [tingum].[AppUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Articles_ArticleCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [tingum].[ArticleCategories] ([Id])
);
GO

CREATE TABLE [tingum].[ArticleComments] (
    [Id] uniqueidentifier NOT NULL,
    [ArticleCommentId] int NOT NULL,
    [Message] nvarchar(512) NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [ArticleId] uniqueidentifier NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ArticleComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ArticleComments_AppUsers_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [tingum].[AppUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleComments_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [tingum].[Articles] ([Id])
);
GO

CREATE TABLE [tingum].[ArticleTagMap] (
    [ArticleId] uniqueidentifier NOT NULL,
    [TagsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ArticleTagMap] PRIMARY KEY ([ArticleId], [TagsId]),
    CONSTRAINT [FK_ArticleTagMap_ArticleTags_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [tingum].[ArticleTags] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTagMap_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [tingum].[Articles] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_AppUsers_Email] ON [tingum].[AppUsers] ([Email]);
GO

CREATE UNIQUE INDEX [IX_AppUsers_UserName] ON [tingum].[AppUsers] ([UserName]);
GO

CREATE INDEX [IX_ArticleComments_ArticleId] ON [tingum].[ArticleComments] ([ArticleId]);
GO

CREATE INDEX [IX_ArticleComments_AuthorId] ON [tingum].[ArticleComments] ([AuthorId]);
GO

CREATE INDEX [IX_Articles_AuthorId] ON [tingum].[Articles] ([AuthorId]);
GO

CREATE INDEX [IX_Articles_CategoryId] ON [tingum].[Articles] ([CategoryId]);
GO

CREATE INDEX [IX_ArticleTagMap_TagsId] ON [tingum].[ArticleTagMap] ([TagsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240103071730_MigrationAlpha', N'7.0.14');
GO

COMMIT;
GO

