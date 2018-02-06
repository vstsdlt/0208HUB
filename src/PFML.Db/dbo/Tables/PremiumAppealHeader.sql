CREATE TABLE [dbo].[PremiumAppealHeader] (
    [PremiumAppealHeaderId] INT           IDENTITY (1, 1) NOT NULL,
    [EmployerId]            INT           NOT NULL,
    [CreateUserId]          VARCHAR (50)  NOT NULL,
    [CreateDateTime]        DATETIME      NOT NULL,
    [UpdateUserId]          VARCHAR (50)  NOT NULL,
    [UpdateDateTime]        DATETIME      NOT NULL,
    [UpdateNumber]          INT           NULL,
    [UpdateProcess]         VARCHAR (100) NULL,
    CONSTRAINT [PK_PremiumAppealHeader] PRIMARY KEY CLUSTERED ([PremiumAppealHeaderId] ASC),
    CONSTRAINT [FK_PremiumAppealHeader_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId])
);

