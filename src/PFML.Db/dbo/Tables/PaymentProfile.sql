CREATE TABLE [dbo].[PaymentProfile] (
    [PaymentProfileId]       INT           IDENTITY (1, 1) NOT NULL,
    [EmployerId]             INT           NULL,
    [AgentId]                INT           NULL,
    [PaymentTypeCode]        VARCHAR (20)  NOT NULL,
    [PaymentAccountTypeCode] VARCHAR (20)  NULL,
    [RoutingTransitNumber]   VARCHAR (20)  NOT NULL,
    [BankAccountNumber]      VARCHAR (20)  NULL,
    [CreateUserId]           VARCHAR (50)  NOT NULL,
    [CreateDateTime]         DATETIME      NOT NULL,
    [UpdateUserId]           VARCHAR (50)  NOT NULL,
    [UpdateDateTime]         DATETIME      NOT NULL,
    [UpdateNumber]           INT           NULL,
    [UpdateProcess]          VARCHAR (100) NULL,
    CONSTRAINT [PK_PaymentProfile] PRIMARY KEY CLUSTERED ([PaymentProfileId] ASC),
    CONSTRAINT [FK_PaymentProfile_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);









