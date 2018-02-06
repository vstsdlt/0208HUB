CREATE TABLE [dbo].[EmployerContact] (
    [EmployerContactId]        INT           IDENTITY (1, 1) NOT NULL,
    [EmployerId]               INT           NOT NULL,
    [ContactTypeCode]          VARCHAR (20)  NOT NULL,
    [LastName]                 VARCHAR (30)  NOT NULL,
    [FirstName]                VARCHAR (30)  NOT NULL,
    [MiddleInitial]            CHAR (1)      NULL,
    [Title]                    VARCHAR (20)  NOT NULL,
    [Email]                    VARCHAR (80)  NULL,
    [StatusCode]               VARCHAR (20)  NOT NULL,
    [CreateUserId]             VARCHAR (50)  NOT NULL,
    [CreateDateTime]           DATETIME      NOT NULL,
    [UpdateUserId]             VARCHAR (50)  NOT NULL,
    [UpdateDateTime]           DATETIME      NOT NULL,
    [UpdateNumber]             INT           NULL,
    [UpdateProcess]            VARCHAR (100) NULL,
    [PhoneNumber]              VARCHAR (10)  NOT NULL,
    [PhoneNumberExtn]          VARCHAR (5)   NULL,
    [SecondaryPhoneNumber]     VARCHAR (10)  NULL,
    [SecondaryPhoneNumberExtn] VARCHAR (5)   NULL,
    CONSTRAINT [PK_EmployerContact] PRIMARY KEY CLUSTERED ([EmployerContactId] ASC),
    CONSTRAINT [FK_EmployerContact_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);















