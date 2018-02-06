CREATE TABLE [dbo].[PremiumRate] (
    [PremiumRateId]      INT            IDENTITY (1, 1) NOT NULL,
    [EffectiveBeginDate] DATETIME       NOT NULL,
    [EffectiveEndDate]   DATETIME       NULL,
    [PremiumRate]        DECIMAL (6, 3) NOT NULL,
    [CreateUserId]       VARCHAR (50)   NOT NULL,
    [CreateDateTime]     DATETIME       NOT NULL,
    [UpdateUserId]       VARCHAR (50)   NOT NULL,
    [UpdateDateTime]     DATETIME       NOT NULL,
    [UpdateNumber]       INT            NULL,
    [UpdateProcess]      VARCHAR (100)  NULL,
    CONSTRAINT [PK_PremiumRate] PRIMARY KEY CLUSTERED ([PremiumRateId] ASC)
);

