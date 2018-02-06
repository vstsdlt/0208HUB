CREATE TABLE [dbo].[EmployerLiability] (
    [EmployerId]                       INT             NOT NULL,
    [HasPaid1KDomesticWages]           BIT             NULL,
    [HasPaid20KAgriculturalLaborWages] BIT             NULL,
    [HasPaid450RegularWages]           BIT             NULL,
    [HasEmployed1In20Weeks]            BIT             NULL,
    [HasEmployed10In20Weeks]           BIT             NULL,
    [GrossWagesPaid]                   DECIMAL (14, 2) NULL,
    [CreateUserId]                     VARCHAR (50)    NOT NULL,
    [CreateDateTime]                   DATETIME        NOT NULL,
    [UpdateUserId]                     VARCHAR (50)    NOT NULL,
    [UpdateDateTime]                   DATETIME        NOT NULL,
    [LiabilityAmountMetYear]           SMALLINT        NULL,
    [LiabilityAmountMetQuarter]        VARCHAR (20)    NULL,
    [UpdateNumber]                     INT             NULL,
    [UpdateProcess]                    VARCHAR (100)   NULL,
    CONSTRAINT [PK_EmployerLiability] PRIMARY KEY CLUSTERED ([EmployerId] ASC),
    CONSTRAINT [FK_EmployerLiability_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);











