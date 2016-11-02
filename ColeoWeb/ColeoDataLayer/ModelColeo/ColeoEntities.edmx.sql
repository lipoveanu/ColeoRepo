
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2016 14:42:48
-- Generated from EDMX file: C:\Users\glipoveanu.BELERSOFT\Documents\Visual Studio 2013\Projects\ColeoWeb\ColeoDataLayer\ModelColeo\ColeoEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Coleo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_History_IdIssue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[History] DROP CONSTRAINT [FK_History_IdIssue];
GO
IF OBJECT_ID(N'[dbo].[FK_History_IdUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[History] DROP CONSTRAINT [FK_History_IdUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdPriority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdPriority];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdProject];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdReproducibility]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdReproducibility];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdSeverity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdSeverity];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdUserAssigned]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdUserAssigned];
GO
IF OBJECT_ID(N'[dbo].[FK_Issue_IdUserReporter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Issue] DROP CONSTRAINT [FK_Issue_IdUserReporter];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueFile_IdFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueFile] DROP CONSTRAINT [FK_IssueFile_IdFile];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueFile_IdIssue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueFile] DROP CONSTRAINT [FK_IssueFile_IdIssue];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueFile_IdNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueFile] DROP CONSTRAINT [FK_IssueFile_IdNote];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueFile_IdUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueFile] DROP CONSTRAINT [FK_IssueFile_IdUser];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueLabel_IdIssue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueLabel] DROP CONSTRAINT [FK_IssueLabel_IdIssue];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueLabel_IdLabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueLabel] DROP CONSTRAINT [FK_IssueLabel_IdLabel];
GO
IF OBJECT_ID(N'[dbo].[FK_Label_IdProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Label] DROP CONSTRAINT [FK_Label_IdProject];
GO
IF OBJECT_ID(N'[dbo].[FK_Note_IdIssue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_IdIssue];
GO
IF OBJECT_ID(N'[dbo].[FK_Note_IdUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_Note_IdUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_IdFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_IdFile];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_IdParentProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_IdParentProject];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_IdStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_IdStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_IdUserCreated]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_IdUserCreated];
GO
IF OBJECT_ID(N'[dbo].[FK_RelatedIssue_IdIssue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelatedIssue] DROP CONSTRAINT [FK_RelatedIssue_IdIssue];
GO
IF OBJECT_ID(N'[dbo].[FK_RelatedIssue_IdIssueRelated]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelatedIssue] DROP CONSTRAINT [FK_RelatedIssue_IdIssueRelated];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_IdProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProject] DROP CONSTRAINT [FK_UserProject_IdProject];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_IdUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProject] DROP CONSTRAINT [FK_UserProject_IdUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[File];
GO
IF OBJECT_ID(N'[dbo].[History]', 'U') IS NOT NULL
    DROP TABLE [dbo].[History];
GO
IF OBJECT_ID(N'[dbo].[Issue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Issue];
GO
IF OBJECT_ID(N'[dbo].[IssueFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueFile];
GO
IF OBJECT_ID(N'[dbo].[IssueLabel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueLabel];
GO
IF OBJECT_ID(N'[dbo].[IssueStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueStatus];
GO
IF OBJECT_ID(N'[dbo].[Label]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Label];
GO
IF OBJECT_ID(N'[dbo].[Note]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Note];
GO
IF OBJECT_ID(N'[dbo].[Priority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Priority];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[ProjectStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectStatus];
GO
IF OBJECT_ID(N'[dbo].[RelatedIssue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelatedIssue];
GO
IF OBJECT_ID(N'[dbo].[Reproducibility]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reproducibility];
GO
IF OBJECT_ID(N'[dbo].[Severity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Severity];
GO
IF OBJECT_ID(N'[dbo].[UserProject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Image] nvarchar(max)  NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocalName] nvarchar(500)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Extension] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Histories'
CREATE TABLE [dbo].[Histories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateModified] datetime  NOT NULL,
    [IdUser] nvarchar(128)  NOT NULL,
    [IdIssue] int  NOT NULL,
    [Field] nvarchar(250)  NOT NULL,
    [Change] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Issues'
CREATE TABLE [dbo].[Issues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdProject] int  NOT NULL,
    [IdUserReporter] nvarchar(128)  NOT NULL,
    [IdUserAssigned] nvarchar(128)  NOT NULL,
    [IdStatus] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [AdditionalInformation] nvarchar(max)  NULL,
    [StepsToReproduce] nvarchar(max)  NULL,
    [DateCreated] datetime  NOT NULL,
    [DateLastUpdate] datetime  NOT NULL,
    [Platform] nvarchar(250)  NULL,
    [Os] nvarchar(150)  NULL,
    [OsVersion] nvarchar(150)  NULL,
    [IdPriority] int  NOT NULL,
    [IdSeverity] int  NOT NULL,
    [IdReproducibility] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'IssueFiles'
CREATE TABLE [dbo].[IssueFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdUser] nvarchar(128)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [IdIssue] int  NULL,
    [IdNote] int  NULL,
    [IdFile] int  NOT NULL
);
GO

-- Creating table 'IssueLabels'
CREATE TABLE [dbo].[IssueLabels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdIssue] int  NOT NULL,
    [IdLabel] int  NOT NULL
);
GO

-- Creating table 'IssueStatus'
CREATE TABLE [dbo].[IssueStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL
);
GO

-- Creating table 'Labels'
CREATE TABLE [dbo].[Labels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL,
    [IdProject] int  NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [IdIssue] int  NOT NULL,
    [IdUser] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Priorities'
CREATE TABLE [dbo].[Priorities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Color] nvarchar(7)  NOT NULL,
    [IdUserCreated] nvarchar(128)  NOT NULL,
    [IdParentProject] int  NULL,
    [IdStatus] int  NOT NULL,
    [IdFile] int  NULL
);
GO

-- Creating table 'ProjectStatus'
CREATE TABLE [dbo].[ProjectStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL
);
GO

-- Creating table 'RelatedIssues'
CREATE TABLE [dbo].[RelatedIssues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdIssue] int  NOT NULL,
    [IdIssueRelated] int  NOT NULL
);
GO

-- Creating table 'Reproducibilities'
CREATE TABLE [dbo].[Reproducibilities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL
);
GO

-- Creating table 'Severities'
CREATE TABLE [dbo].[Severities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Color] nvarchar(7)  NOT NULL
);
GO

-- Creating table 'UserProjects'
CREATE TABLE [dbo].[UserProjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdProject] int  NOT NULL,
    [IdUser] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Histories'
ALTER TABLE [dbo].[Histories]
ADD CONSTRAINT [PK_Histories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [PK_Issues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IssueFiles'
ALTER TABLE [dbo].[IssueFiles]
ADD CONSTRAINT [PK_IssueFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IssueLabels'
ALTER TABLE [dbo].[IssueLabels]
ADD CONSTRAINT [PK_IssueLabels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IssueStatus'
ALTER TABLE [dbo].[IssueStatus]
ADD CONSTRAINT [PK_IssueStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Labels'
ALTER TABLE [dbo].[Labels]
ADD CONSTRAINT [PK_Labels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Priorities'
ALTER TABLE [dbo].[Priorities]
ADD CONSTRAINT [PK_Priorities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectStatus'
ALTER TABLE [dbo].[ProjectStatus]
ADD CONSTRAINT [PK_ProjectStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelatedIssues'
ALTER TABLE [dbo].[RelatedIssues]
ADD CONSTRAINT [PK_RelatedIssues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reproducibilities'
ALTER TABLE [dbo].[Reproducibilities]
ADD CONSTRAINT [PK_Reproducibilities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Severities'
ALTER TABLE [dbo].[Severities]
ADD CONSTRAINT [PK_Severities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [PK_UserProjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [IdUser] in table 'Histories'
ALTER TABLE [dbo].[Histories]
ADD CONSTRAINT [FK_History_IdUser]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_History_IdUser'
CREATE INDEX [IX_FK_History_IdUser]
ON [dbo].[Histories]
    ([IdUser]);
GO

-- Creating foreign key on [IdUserAssigned] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdUserAssigned]
    FOREIGN KEY ([IdUserAssigned])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdUserAssigned'
CREATE INDEX [IX_FK_Issue_IdUserAssigned]
ON [dbo].[Issues]
    ([IdUserAssigned]);
GO

-- Creating foreign key on [IdUserReporter] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdUserReporter]
    FOREIGN KEY ([IdUserReporter])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdUserReporter'
CREATE INDEX [IX_FK_Issue_IdUserReporter]
ON [dbo].[Issues]
    ([IdUserReporter]);
GO

-- Creating foreign key on [IdUser] in table 'IssueFiles'
ALTER TABLE [dbo].[IssueFiles]
ADD CONSTRAINT [FK_IssueFile_IdUser]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueFile_IdUser'
CREATE INDEX [IX_FK_IssueFile_IdUser]
ON [dbo].[IssueFiles]
    ([IdUser]);
GO

-- Creating foreign key on [IdUser] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_Note_IdUser]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Note_IdUser'
CREATE INDEX [IX_FK_Note_IdUser]
ON [dbo].[Notes]
    ([IdUser]);
GO

-- Creating foreign key on [IdUserCreated] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_IdUserCreated]
    FOREIGN KEY ([IdUserCreated])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_IdUserCreated'
CREATE INDEX [IX_FK_Project_IdUserCreated]
ON [dbo].[Projects]
    ([IdUserCreated]);
GO

-- Creating foreign key on [IdUser] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProject_IdUser]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject_IdUser'
CREATE INDEX [IX_FK_UserProject_IdUser]
ON [dbo].[UserProjects]
    ([IdUser]);
GO

-- Creating foreign key on [IdFile] in table 'IssueFiles'
ALTER TABLE [dbo].[IssueFiles]
ADD CONSTRAINT [FK_IssueFile_IdFile]
    FOREIGN KEY ([IdFile])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueFile_IdFile'
CREATE INDEX [IX_FK_IssueFile_IdFile]
ON [dbo].[IssueFiles]
    ([IdFile]);
GO

-- Creating foreign key on [IdFile] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_IdFile]
    FOREIGN KEY ([IdFile])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_IdFile'
CREATE INDEX [IX_FK_Project_IdFile]
ON [dbo].[Projects]
    ([IdFile]);
GO

-- Creating foreign key on [IdIssue] in table 'Histories'
ALTER TABLE [dbo].[Histories]
ADD CONSTRAINT [FK_History_IdIssue]
    FOREIGN KEY ([IdIssue])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_History_IdIssue'
CREATE INDEX [IX_FK_History_IdIssue]
ON [dbo].[Histories]
    ([IdIssue]);
GO

-- Creating foreign key on [IdPriority] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdPriority]
    FOREIGN KEY ([IdPriority])
    REFERENCES [dbo].[Priorities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdPriority'
CREATE INDEX [IX_FK_Issue_IdPriority]
ON [dbo].[Issues]
    ([IdPriority]);
GO

-- Creating foreign key on [IdProject] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdProject]
    FOREIGN KEY ([IdProject])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdProject'
CREATE INDEX [IX_FK_Issue_IdProject]
ON [dbo].[Issues]
    ([IdProject]);
GO

-- Creating foreign key on [IdReproducibility] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdReproducibility]
    FOREIGN KEY ([IdReproducibility])
    REFERENCES [dbo].[Reproducibilities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdReproducibility'
CREATE INDEX [IX_FK_Issue_IdReproducibility]
ON [dbo].[Issues]
    ([IdReproducibility]);
GO

-- Creating foreign key on [IdSeverity] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdSeverity]
    FOREIGN KEY ([IdSeverity])
    REFERENCES [dbo].[Severities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdSeverity'
CREATE INDEX [IX_FK_Issue_IdSeverity]
ON [dbo].[Issues]
    ([IdSeverity]);
GO

-- Creating foreign key on [IdStatus] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [FK_Issue_IdStatus]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[IssueStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Issue_IdStatus'
CREATE INDEX [IX_FK_Issue_IdStatus]
ON [dbo].[Issues]
    ([IdStatus]);
GO

-- Creating foreign key on [IdIssue] in table 'IssueFiles'
ALTER TABLE [dbo].[IssueFiles]
ADD CONSTRAINT [FK_IssueFile_IdIssue]
    FOREIGN KEY ([IdIssue])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueFile_IdIssue'
CREATE INDEX [IX_FK_IssueFile_IdIssue]
ON [dbo].[IssueFiles]
    ([IdIssue]);
GO

-- Creating foreign key on [IdIssue] in table 'IssueLabels'
ALTER TABLE [dbo].[IssueLabels]
ADD CONSTRAINT [FK_IssueLabel_IdIssue]
    FOREIGN KEY ([IdIssue])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueLabel_IdIssue'
CREATE INDEX [IX_FK_IssueLabel_IdIssue]
ON [dbo].[IssueLabels]
    ([IdIssue]);
GO

-- Creating foreign key on [IdIssue] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_Note_IdIssue]
    FOREIGN KEY ([IdIssue])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Note_IdIssue'
CREATE INDEX [IX_FK_Note_IdIssue]
ON [dbo].[Notes]
    ([IdIssue]);
GO

-- Creating foreign key on [IdIssue] in table 'RelatedIssues'
ALTER TABLE [dbo].[RelatedIssues]
ADD CONSTRAINT [FK_RelatedIssue_IdIssue]
    FOREIGN KEY ([IdIssue])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelatedIssue_IdIssue'
CREATE INDEX [IX_FK_RelatedIssue_IdIssue]
ON [dbo].[RelatedIssues]
    ([IdIssue]);
GO

-- Creating foreign key on [IdIssueRelated] in table 'RelatedIssues'
ALTER TABLE [dbo].[RelatedIssues]
ADD CONSTRAINT [FK_RelatedIssue_IdIssueRelated]
    FOREIGN KEY ([IdIssueRelated])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelatedIssue_IdIssueRelated'
CREATE INDEX [IX_FK_RelatedIssue_IdIssueRelated]
ON [dbo].[RelatedIssues]
    ([IdIssueRelated]);
GO

-- Creating foreign key on [IdNote] in table 'IssueFiles'
ALTER TABLE [dbo].[IssueFiles]
ADD CONSTRAINT [FK_IssueFile_IdNote]
    FOREIGN KEY ([IdNote])
    REFERENCES [dbo].[Notes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueFile_IdNote'
CREATE INDEX [IX_FK_IssueFile_IdNote]
ON [dbo].[IssueFiles]
    ([IdNote]);
GO

-- Creating foreign key on [IdLabel] in table 'IssueLabels'
ALTER TABLE [dbo].[IssueLabels]
ADD CONSTRAINT [FK_IssueLabel_IdLabel]
    FOREIGN KEY ([IdLabel])
    REFERENCES [dbo].[Labels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueLabel_IdLabel'
CREATE INDEX [IX_FK_IssueLabel_IdLabel]
ON [dbo].[IssueLabels]
    ([IdLabel]);
GO

-- Creating foreign key on [IdProject] in table 'Labels'
ALTER TABLE [dbo].[Labels]
ADD CONSTRAINT [FK_Label_IdProject]
    FOREIGN KEY ([IdProject])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Label_IdProject'
CREATE INDEX [IX_FK_Label_IdProject]
ON [dbo].[Labels]
    ([IdProject]);
GO

-- Creating foreign key on [IdParentProject] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_IdParentProject]
    FOREIGN KEY ([IdParentProject])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_IdParentProject'
CREATE INDEX [IX_FK_Project_IdParentProject]
ON [dbo].[Projects]
    ([IdParentProject]);
GO

-- Creating foreign key on [IdStatus] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_IdStatus]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[ProjectStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_IdStatus'
CREATE INDEX [IX_FK_Project_IdStatus]
ON [dbo].[Projects]
    ([IdStatus]);
GO

-- Creating foreign key on [IdProject] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProject_IdProject]
    FOREIGN KEY ([IdProject])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject_IdProject'
CREATE INDEX [IX_FK_UserProject_IdProject]
ON [dbo].[UserProjects]
    ([IdProject]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------