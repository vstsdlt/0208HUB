CREATE TABLE [dbo].[ResourceTemplate] (
    [ResourceTemplateId]  INT           IDENTITY (1, 1) NOT NULL,
    [TemplateDescription] VARCHAR (30)  NOT NULL,
    [CreateUserId]        VARCHAR (50)  NOT NULL,
    [CreateDateTime]      DATETIME      NOT NULL,
    [UpdateUserId]        VARCHAR (50)  NOT NULL,
    [UpdateDateTime]      DATETIME      NOT NULL,
    [UpdateNumber]        INT           NULL,
    [UpdateProcess]       VARCHAR (100) NULL,
    CONSTRAINT [PK_ResourceTemplate] PRIMARY KEY CLUSTERED ([ResourceTemplateId] ASC)
);

