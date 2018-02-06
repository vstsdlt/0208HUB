CREATE TABLE [dbo].[WageUnitDetail] (
    [EmployerId]         INT             NOT NULL,
    [EmployerUnitId]     INT             NOT NULL,
    [ReportingYear]      SMALLINT        NOT NULL,
    [ReportingQuarter]   VARCHAR (20)    NOT NULL,
    [SSN]                VARCHAR (9)     NOT NULL,
    [LastName]           VARCHAR (30)    NULL,
    [FirstName]          VARCHAR (30)    NULL,
    [MiddleInitialName]  VARCHAR (1)     NULL,
    [WageAmount]         DECIMAL (12, 2) NOT NULL,
    [FilingMethod]       VARCHAR (20)    NOT NULL,
    [AdjReasonCode]      VARCHAR (20)    NOT NULL,
    [IsEmploymentMonth1] BIT             NULL,
    [IsEmploymentMonth2] BIT             NULL,
    [IsEmploymentMonth3] BIT             NULL,
    [IsOwnerOrOfficer]   BIT             NULL,
    [Occupation]         VARCHAR (50)    NULL,
    [HoursWorked]        INT             NULL,
    [CreateUserId]       VARCHAR (50)    NOT NULL,
    [CreateDateTime]     DATETIME        NOT NULL,
    [UpdateUserId]       VARCHAR (50)    NOT NULL,
    [UpdateDateTime]     DATETIME        NOT NULL,
    [UpdateNumber]       INT             NULL,
    [UpdateProcess]      VARCHAR (100)   NULL,
    CONSTRAINT [PK_WageUnitDetail] PRIMARY KEY CLUSTERED ([EmployerId] ASC, [EmployerUnitId] ASC, [ReportingYear] ASC, [ReportingQuarter] ASC, [SSN] ASC),
    CONSTRAINT [FK_WageUnitDetail_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);











