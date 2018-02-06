CREATE TABLE [dbo].[SecurityPermission] (
    [SourceType]     VARCHAR (10)  NOT NULL,
    [SourceName]     VARCHAR (100) NOT NULL,
    [TargetType]     VARCHAR (10)  NOT NULL,
    [TargetName]     VARCHAR (100) NOT NULL,
    [AccessType]     VARCHAR (10)  NOT NULL,
    [CreateUserId]   VARCHAR (85)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (85)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_SecurityPermission] PRIMARY KEY CLUSTERED ([SourceType] ASC, [SourceName] ASC, [TargetType] ASC, [TargetName] ASC)
);









