CREATE TABLE [dbo].[EmployerPreference] (
    [EmployerId]             INT           NOT NULL,
    [CorrespondanceTypeCode] VARCHAR (20)  NOT NULL,
    [Email]                  VARCHAR (80)  NULL,
    [CreateUserId]           VARCHAR (50)  NOT NULL,
    [CreateDateTime]         DATETIME      NOT NULL,
    [UpdateUserId]           VARCHAR (50)  NOT NULL,
    [UpdateDateTime]         DATETIME      NOT NULL,
    [UpdateNumber]           INT           NULL,
    [UpdateProcess]          VARCHAR (100) NULL,
    CONSTRAINT [PK_EmployerPreference] PRIMARY KEY CLUSTERED ([EmployerId] ASC),
    CONSTRAINT [FK_EmployerPreference_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);









