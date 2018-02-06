CREATE TABLE [dbo].[AddressLink] (
    [AddressLinkId]   INT           IDENTITY (1, 1) NOT NULL,
    [AddressTypeCode] VARCHAR (20)  NOT NULL,
    [EmployerId]      INT           NULL,
    [AgentId]         INT           NULL,
    [EmployerUnitId]  INT           NULL,
    [AddressId]       INT           NOT NULL,
    [StatusCode]      VARCHAR (20)  NULL,
    [CreateUserId]    VARCHAR (50)  NOT NULL,
    [CreateDateTime]  DATETIME      NOT NULL,
    [UpdateUserId]    VARCHAR (50)  NOT NULL,
    [UpdateDateTime]  DATETIME      NOT NULL,
    [UpdateNumber]    INT           NULL,
    [UpdateProcess]   VARCHAR (100) NULL,
    CONSTRAINT [PK_AddressLink] PRIMARY KEY CLUSTERED ([AddressLinkId] ASC),
    CONSTRAINT [FK_AddressLink_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_AddressLink_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId]),
    CONSTRAINT [FK_AddressLink_EmployerUnit_EmployerUnitId] FOREIGN KEY ([EmployerUnitId]) REFERENCES [dbo].[EmployerUnit] ([EmployerUnitId])
);











