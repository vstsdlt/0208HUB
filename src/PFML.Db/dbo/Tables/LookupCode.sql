CREATE TABLE [dbo].[LookupCode] (
    [Name]           VARCHAR (50)  NOT NULL,
    [Code]           VARCHAR (20)  NOT NULL,
    [Display]        VARCHAR (50)  NOT NULL,
    [Description]    VARCHAR (500) NULL,
    [CreateUserId]   VARCHAR (50)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (50)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_LookupCode] PRIMARY KEY CLUSTERED ([Name] ASC, [Code] ASC),
    CONSTRAINT [FK_LookupCode_LookupName_Name] FOREIGN KEY ([Name]) REFERENCES [dbo].[LookupName] ([Name])
);











