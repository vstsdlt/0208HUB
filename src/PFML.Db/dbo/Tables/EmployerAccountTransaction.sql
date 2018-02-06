CREATE TABLE [dbo].[EmployerAccountTransaction] (
    [EmployerId]       INT             NOT NULL,
    [ReportingYear]    SMALLINT        NOT NULL,
    [ReportingQuarter] VARCHAR (20)    NOT NULL,
    [TypeCode]         VARCHAR (20)    NOT NULL,
    [TransactionSeqNo] INT             NOT NULL,
    [OwedAmount]       DECIMAL (12, 2) NOT NULL,
    [UnpaidAmount]     DECIMAL (12, 2) NOT NULL,
    [ThresholdAmount]  DECIMAL (12, 2) NOT NULL,
    [DueDate]          DATETIME        NOT NULL,
    [StatusCode]       VARCHAR (20)    NOT NULL,
    [CreateUserId]     VARCHAR (50)    NOT NULL,
    [CreateDateTime]   DATETIME        NOT NULL,
    [UpdateUserId]     VARCHAR (50)    NOT NULL,
    [UpdateDateTime]   DATETIME        NOT NULL,
    [UpdateNumber]     INT             NULL,
    [UpdateProcess]    VARCHAR (100)   NULL,
    CONSTRAINT [PK_EmployerAccountTransaction] PRIMARY KEY CLUSTERED ([EmployerId] ASC, [ReportingYear] ASC, [ReportingQuarter] ASC, [TypeCode] ASC, [TransactionSeqNo] ASC),
    CONSTRAINT [FK_EmployerAccountTransaction_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);









