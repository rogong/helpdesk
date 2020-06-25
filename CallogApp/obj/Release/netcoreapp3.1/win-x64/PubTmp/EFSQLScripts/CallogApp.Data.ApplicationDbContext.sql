IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    CREATE TABLE [Departments] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    CREATE TABLE [Issues] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Issues] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    CREATE TABLE [Calls] (
        [Id] int NOT NULL IDENTITY,
        [Caller] nvarchar(max) NULL,
        [Receiver] nvarchar(max) NULL,
        [Suject] nvarchar(max) NULL,
        [Note] nvarchar(max) NULL,
        [Remark] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [DepartmentId] int NOT NULL,
        [IssueId] int NOT NULL,
        CONSTRAINT [PK_Calls] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Calls_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Calls_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    CREATE INDEX [IX_Calls_DepartmentId] ON [Calls] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    CREATE INDEX [IX_Calls_IssueId] ON [Calls] ([IssueId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200327180534_AddCallDepatmentIssueToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200327180534_AddCallDepatmentIssueToDatabase', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328105740_AddCallDepartmentIssueToDatabase')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Calls]') AND [c].[name] = N'Suject');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Calls] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Calls] ALTER COLUMN [Suject] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328105740_AddCallDepartmentIssueToDatabase')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Calls]') AND [c].[name] = N'Receiver');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Calls] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Calls] ALTER COLUMN [Receiver] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328105740_AddCallDepartmentIssueToDatabase')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Calls]') AND [c].[name] = N'Note');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Calls] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Calls] ALTER COLUMN [Note] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328105740_AddCallDepartmentIssueToDatabase')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Calls]') AND [c].[name] = N'Caller');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Calls] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Calls] ALTER COLUMN [Caller] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328105740_AddCallDepartmentIssueToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200328105740_AddCallDepartmentIssueToDatabase', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200328184148_updateCallModel-Note-Remark-To-Text')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200328184148_updateCallModel-Note-Remark-To-Text', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200404175730_AddMoreFieldToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Department] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200404175730_AddMoreFieldToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200404175730_AddMoreFieldToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Title] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200404175730_AddMoreFieldToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200404175730_AddMoreFieldToRegistration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200404175730_AddMoreFieldToRegistration', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200405061936_AddNewDepartmentToRegistration')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Department');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Department];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200405061936_AddNewDepartmentToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [DepartmentId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200405061936_AddNewDepartmentToRegistration')
BEGIN
    CREATE INDEX [IX_AspNetUsers_DepartmentId] ON [AspNetUsers] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200405061936_AddNewDepartmentToRegistration')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200405061936_AddNewDepartmentToRegistration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200405061936_AddNewDepartmentToRegistration', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    CREATE TABLE [Devices] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_Devices] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    CREATE TABLE [RequestTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_RequestTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    CREATE TABLE [Statuses] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Statuses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406064557_AddStatusRequestTypeDeviceToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200406064557_AddStatusRequestTypeDeviceToDatabase', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070014_AdjustRequestToRemoveApplicationUserDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200406070014_AdjustRequestToRemoveApplicationUserDatabase', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE TABLE [Requests] (
        [Id] int NOT NULL IDENTITY,
        [StatusId] int NOT NULL,
        [UserId] nvarchar(max) NULL,
        [DateCreated] datetime2 NOT NULL,
        [DepartmentId] int NOT NULL,
        [IssueId] int NOT NULL,
        [DeviceId] int NOT NULL,
        [RequestTypeId] int NOT NULL,
        [Subject] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        [ResolvedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Requests_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Issues_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]),
        CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Statuses] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE INDEX [IX_Requests_DepartmentId] ON [Requests] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE INDEX [IX_Requests_DeviceId] ON [Requests] ([DeviceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE INDEX [IX_Requests_IssueId] ON [Requests] ([IssueId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    CREATE INDEX [IX_Requests_StatusId] ON [Requests] ([StatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200406070401_AddRequestToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200406070401_AddRequestToDatabase', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408070240_AdjustCallModelAddDevice')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Issues_DeviceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408070240_AdjustCallModelAddDevice')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408070240_AdjustCallModelAddDevice')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200408070240_AdjustCallModelAddDevice', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408214848_ChangeSubjectAndMassegeInRequest')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Requests]') AND [c].[name] = N'Subject');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Requests] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Requests] ALTER COLUMN [Subject] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408214848_ChangeSubjectAndMassegeInRequest')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Requests]') AND [c].[name] = N'Message');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Requests] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Requests] ALTER COLUMN [Message] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200408214848_ChangeSubjectAndMassegeInRequest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200408214848_ChangeSubjectAndMassegeInRequest', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Requests]') AND [c].[name] = N'ResolvedBy');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Requests] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Requests] DROP COLUMN [ResolvedBy];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    ALTER TABLE [Requests] ADD [ITStaffId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    CREATE TABLE [ITStaff] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Specialisation] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ITStaff] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    CREATE INDEX [IX_Requests_ITStaffId] ON [Requests] ([ITStaffId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_ITStaff_ITStaffId] FOREIGN KEY ([ITStaffId]) REFERENCES [ITStaff] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411145345_AddITStaffModelToRequestModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200411145345_AddITStaffModelToRequestModel', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_ITStaff_ITStaffId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    ALTER TABLE [ITStaff] DROP CONSTRAINT [PK_ITStaff];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    EXEC sp_rename N'[ITStaff]', N'ITStaffs';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    ALTER TABLE [ITStaffs] ADD CONSTRAINT [PK_ITStaffs] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_ITStaffs_ITStaffId] FOREIGN KEY ([ITStaffId]) REFERENCES [ITStaffs] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200411150318_AddITStaffModelToRequestModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200411150318_AddITStaffModelToRequestModel2', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200502192052_CurrencyAndPaymentModes')
BEGIN
    CREATE TABLE [Currencies] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Currencies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200502192052_CurrencyAndPaymentModes')
BEGIN
    CREATE TABLE [PaymentModes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_PaymentModes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200502192052_CurrencyAndPaymentModes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200502192052_CurrencyAndPaymentModes', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentModes]') AND [c].[name] = N'Name');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [PaymentModes] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [PaymentModes] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Currencies]') AND [c].[name] = N'Name');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Currencies] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Currencies] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE TABLE [ApprovalLevels] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ApprovalLevels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE TABLE [ApprovedStatuses] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ApprovedStatuses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE TABLE [Requesters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Requesters] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE TABLE [Approvals] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NOT NULL,
        [Name] int NOT NULL,
        [RequesterId] int NOT NULL,
        [PaymentModeId] int NOT NULL,
        [CurrencyId] int NOT NULL,
        [LeagerName] nvarchar(max) NULL,
        [AnnualBudget] float NOT NULL,
        [YTD] float NOT NULL,
        [CurrentRequest] float NOT NULL,
        [YTDPercent] float NOT NULL,
        [Beneficiary] nvarchar(max) NULL,
        [JobDescription] nvarchar(max) NULL,
        [Reason] nvarchar(max) NULL,
        [TotalCost] float NOT NULL,
        [AdvanceRequired] nvarchar(max) NULL,
        [PreparedBy] nvarchar(max) NULL,
        [CheckedBy] nvarchar(max) NULL,
        [AuthorisedBy] nvarchar(max) NULL,
        [ApprovedBy] nvarchar(max) NULL,
        [DepartmentId] int NOT NULL,
        [ApprovalLevelId] int NOT NULL,
        [ApprovedStatusId] int NOT NULL,
        CONSTRAINT [PK_Approvals] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId] FOREIGN KEY ([ApprovalLevelId]) REFERENCES [ApprovalLevels] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId] FOREIGN KEY ([ApprovedStatusId]) REFERENCES [ApprovedStatuses] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Approvals_Currencies_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currencies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Approvals_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId] FOREIGN KEY ([PaymentModeId]) REFERENCES [PaymentModes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Approvals_Requesters_RequesterId] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_ApprovalLevelId] ON [Approvals] ([ApprovalLevelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_ApprovedStatusId] ON [Approvals] ([ApprovedStatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_CurrencyId] ON [Approvals] ([CurrencyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_DepartmentId] ON [Approvals] ([DepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_PaymentModeId] ON [Approvals] ([PaymentModeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    CREATE INDEX [IX_Approvals_RequesterId] ON [Approvals] ([RequesterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503122347_ApprovalAndOthers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200503122347_ApprovalAndOthers', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503133516_Adjust Approval Model')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Approvals]') AND [c].[name] = N'Name');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Approvals] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Approvals] ALTER COLUMN [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503133516_Adjust Approval Model')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200503133516_Adjust Approval Model', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503174644_AddUserId')
BEGIN
    ALTER TABLE [Approvals] ADD [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503174644_AddUserId')
BEGIN
    ALTER TABLE [Approvals] ADD [UserId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503174644_AddUserId')
BEGIN
    CREATE INDEX [IX_Approvals_ApplicationUserId] ON [Approvals] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503174644_AddUserId')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200503174644_AddUserId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200503174644_AddUserId', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    DROP INDEX [IX_Approvals_ApplicationUserId] ON [Approvals];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Approvals]') AND [c].[name] = N'ApplicationUserId');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Approvals] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Approvals] DROP COLUMN [ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Approvals]') AND [c].[name] = N'UserId');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Approvals] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Approvals] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    ALTER TABLE [Approvals] ADD [UserEmail] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514140049_ChangeUserIdToUserEmail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200514140049_ChangeUserIdToUserEmail', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Currencies_CurrencyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Requesters_RequesterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Devices_DeviceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_ITStaffs_ITStaffId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Statuses_StatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId] FOREIGN KEY ([ApprovalLevelId]) REFERENCES [ApprovalLevels] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId] FOREIGN KEY ([ApprovedStatusId]) REFERENCES [ApprovedStatuses] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Currencies_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currencies] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId] FOREIGN KEY ([PaymentModeId]) REFERENCES [PaymentModes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Requesters_RequesterId] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetRoleClaims] ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [AspNetUserTokens] ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_ITStaffs_ITStaffId] FOREIGN KEY ([ITStaffId]) REFERENCES [ITStaffs] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Statuses] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200517155736_DeleteBehaviorRestrict')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200517155736_DeleteBehaviorRestrict', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Currencies_CurrencyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Requesters_RequesterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Devices_DeviceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_ITStaffs_ITStaffId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Statuses_StatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId] FOREIGN KEY ([ApprovalLevelId]) REFERENCES [ApprovalLevels] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId] FOREIGN KEY ([ApprovedStatusId]) REFERENCES [ApprovedStatuses] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Currencies_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currencies] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId] FOREIGN KEY ([PaymentModeId]) REFERENCES [PaymentModes] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Requesters_RequesterId] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetRoleClaims] ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [AspNetUserTokens] ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_ITStaffs_ITStaffId] FOREIGN KEY ([ITStaffId]) REFERENCES [ITStaffs] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Statuses] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200519145155_Test')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200519145155_Test', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Currencies_CurrencyId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] DROP CONSTRAINT [FK_Approvals_Requesters_RequesterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Calls] DROP CONSTRAINT [FK_Calls_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Departments_DepartmentId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Devices_DeviceId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_ITStaffs_ITStaffId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Issues_IssueId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_Statuses_StatusId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovalLevels_ApprovalLevelId] FOREIGN KEY ([ApprovalLevelId]) REFERENCES [ApprovalLevels] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_ApprovedStatuses_ApprovedStatusId] FOREIGN KEY ([ApprovedStatusId]) REFERENCES [ApprovedStatuses] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Currencies_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currencies] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_PaymentModes_PaymentModeId] FOREIGN KEY ([PaymentModeId]) REFERENCES [PaymentModes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Approvals] ADD CONSTRAINT [FK_Approvals_Requesters_RequesterId] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetRoleClaims] ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserClaims] ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserLogins] ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserRoles] ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [AspNetUserTokens] ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Calls] ADD CONSTRAINT [FK_Calls_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_ITStaffs_ITStaffId] FOREIGN KEY ([ITStaffId]) REFERENCES [ITStaffs] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Issues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [Issues] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Statuses] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200520013151_mig')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200520013151_mig', N'3.1.1');
END;

GO

