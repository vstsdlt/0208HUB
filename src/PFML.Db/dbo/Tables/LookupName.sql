CREATE TABLE [dbo].[LookupName] (
    [Name]           VARCHAR (50)  NOT NULL,
    [Description]    VARCHAR (500) NULL,
    [CreateUserId]   VARCHAR (50)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (50)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_LookupName] PRIMARY KEY CLUSTERED ([Name] ASC)
);









