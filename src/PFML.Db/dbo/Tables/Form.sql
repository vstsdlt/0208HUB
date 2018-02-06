CREATE TABLE [dbo].[Form] (
    [FormId]         INT           IDENTITY (1, 1) NOT NULL,
    [FormTypeCode]   VARCHAR (20)  NOT NULL,
    [StatusCode]     VARCHAR (20)  NOT NULL,
    [CreateUserId]   VARCHAR (50)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (50)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([FormId] ASC)
);

