CREATE TABLE [dbo].[TaxableAmountSum] (
    [EmployerId]         INT             NOT NULL,
    [ReportingYear]      SMALLINT        NOT NULL,
    [TaxableAmountSeqNo] SMALLINT        NOT NULL,
    [Quarter1GrossAmt]   DECIMAL (14, 2) NOT NULL,
    [Quarter2GrossAmt]   DECIMAL (14, 2) NOT NULL,
    [Quarter3GrossAmt]   DECIMAL (14, 2) NOT NULL,
    [Quarter4GrossAmt]   DECIMAL (14, 2) NOT NULL,
    [Quarter1TaxableAmt] DECIMAL (14, 2) NOT NULL,
    [Quarter2TaxableAmt] DECIMAL (14, 2) NOT NULL,
    [Quarter3TaxableAmt] DECIMAL (14, 2) NOT NULL,
    [Quarter4TaxableAmt] DECIMAL (14, 2) NOT NULL,
    [StatusCode]         VARCHAR (20)    NOT NULL,
    [CreateUserId]       VARCHAR (50)    NOT NULL,
    [CreateDateTime]     DATETIME        NOT NULL,
    [UpdateUserId]       VARCHAR (50)    NOT NULL,
    [UpdateDateTime]     DATETIME        NOT NULL,
    [ReportingQuarter]   VARCHAR (20)    NOT NULL,
    [UpdateNumber]       INT             NULL,
    [UpdateProcess]      VARCHAR (100)   NULL,
    CONSTRAINT [PK_TaxableAmountSum] PRIMARY KEY CLUSTERED ([EmployerId] ASC, [ReportingYear] ASC, [TaxableAmountSeqNo] ASC),
    CONSTRAINT [FK_TaxableAmountSum_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);









