CREATE TABLE [dbo].[PaymentMain] (
    [PaymentMainId]          INT             IDENTITY (1, 1) NOT NULL,
    [IsAgent]                BIT             NOT NULL,
    [EmployerId]             INT             NULL,
    [AgentId]                INT             NULL,
    [PaymentMethodCode]      VARCHAR (20)    NOT NULL,
    [PaymentAmount]          DECIMAL (14, 2) NOT NULL,
    [PaymentTransactionDate] DATETIME        NULL,
    [RoutingTransitNumber]   VARCHAR (20)    NULL,
    [BankAccountNumber]      VARCHAR (20)    NULL,
    [BankAccountTypeCode]    VARCHAR (20)    NULL,
    [PaymentStatusCode]      VARCHAR (20)    NOT NULL,
    [PaymentStatusDate]      DATETIME        NOT NULL,
    [PaymentSubmittedDate]   DATETIME        NULL,
    [CreateUserId]           VARCHAR (50)    NOT NULL,
    [CreateDateTime]         DATETIME        NOT NULL,
    [UpdateUserId]           VARCHAR (50)    NOT NULL,
    [UpdateDateTime]         DATETIME        NOT NULL,
    [UpdateNumber]           INT             NULL,
    [UpdateProcess]          VARCHAR (100)   NULL,
    CONSTRAINT [PK_PaymentMain] PRIMARY KEY CLUSTERED ([PaymentMainId] ASC),
    CONSTRAINT [FK_PaymentMain_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);









