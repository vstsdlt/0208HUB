CREATE TABLE [dbo].[LookupProperty] (
    [Name]           VARCHAR (50)  NOT NULL,
    [Property]       VARCHAR (50)  NOT NULL,
    [DataType]       VARCHAR (50)  CONSTRAINT [DF_LookupProperty_DataType] DEFAULT ('String') NOT NULL,
    [Description]    VARCHAR (500) NULL,
    [CreateUserId]   VARCHAR (50)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (50)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_LookupProperty] PRIMARY KEY CLUSTERED ([Name] ASC, [Property] ASC),
    CONSTRAINT [FK_LookupProperty_LookupName_Name] FOREIGN KEY ([Name]) REFERENCES [dbo].[LookupName] ([Name])
);











