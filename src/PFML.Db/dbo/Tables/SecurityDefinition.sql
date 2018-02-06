CREATE TABLE [dbo].[SecurityDefinition] (
    [Type]           VARCHAR (10)   NOT NULL,
    [Name]           VARCHAR (100)  NOT NULL,
    [Description]    VARCHAR (1000) NOT NULL,
    [CreateUserId]   VARCHAR (85)   NOT NULL,
    [CreateDateTime] DATETIME       NOT NULL,
    [UpdateUserId]   VARCHAR (85)   NOT NULL,
    [UpdateDateTime] DATETIME       NOT NULL,
    [UpdateNumber]   INT            NULL,
    [UpdateProcess]  VARCHAR (100)  NULL,
    CONSTRAINT [PK_SecurityDefinition] PRIMARY KEY CLUSTERED ([Type] ASC, [Name] ASC)
);









