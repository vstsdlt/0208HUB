CREATE TABLE [dbo].[EmployerUnit] (
    [EmployerUnitId]      INT           IDENTITY (1, 1) NOT NULL,
    [EmployerId]          INT           NOT NULL,
    [DoingBusinessAsName] VARCHAR (80)  NULL,
    [CountyCode]          VARCHAR (20)  NOT NULL,
    [StatusCode]          VARCHAR (20)  NOT NULL,
    [StatusDate]          DATETIME      NOT NULL,
    [CreateUserId]        VARCHAR (50)  NOT NULL,
    [CreateDateTime]      DATETIME      NOT NULL,
    [UpdateUserId]        VARCHAR (50)  NOT NULL,
    [UpdateDateTime]      DATETIME2 (7) NULL,
    [FirstWageDate]       DATETIME      NULL,
    [UpdateNumber]        INT           NULL,
    [UpdateProcess]       VARCHAR (100) NULL,
    CONSTRAINT [PK_EmployerUnit] PRIMARY KEY CLUSTERED ([EmployerUnitId] ASC),
    CONSTRAINT [FK_EmployerUnit_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);













