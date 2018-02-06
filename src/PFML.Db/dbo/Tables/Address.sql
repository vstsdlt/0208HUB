CREATE TABLE [dbo].[Address] (
    [AddressId]               INT           IDENTITY (1, 1) NOT NULL,
    [Attention]               VARCHAR (50)  NULL,
    [AddressLine1]            VARCHAR (45)  NOT NULL,
    [AddressLine2]            VARCHAR (45)  NULL,
    [City]                    VARCHAR (35)  NOT NULL,
    [StateCode]               VARCHAR (20)  NULL,
    [Zip]                     VARCHAR (10)  NULL,
    [CountyCode]              VARCHAR (20)  NULL,
    [CountryCode]             VARCHAR (20)  NOT NULL,
    [Email]                   VARCHAR (80)  NULL,
    [AddressVerificationCode] VARCHAR (20)  NOT NULL,
    [BusinessWebAddress]      VARCHAR (80)  NULL,
    [CreateUserId]            VARCHAR (50)  NOT NULL,
    [CreateDateTime]          DATETIME      NOT NULL,
    [UpdateUserId]            VARCHAR (50)  NOT NULL,
    [UpdateDateTime]          DATETIME      NOT NULL,
    [UpdateNumber]            INT           NULL,
    [UpdateProcess]           VARCHAR (100) NULL,
    [PhoneNumber]             VARCHAR (10)  NULL,
    [PhoneNumberExtn]         VARCHAR (5)   NULL,
    [IntPhoneNumber]          VARCHAR (10)  NULL,
    [IntPhoneNumberExtn]      VARCHAR (5)   NULL,
    [OtherPhoneNumber]        VARCHAR (10)  NULL,
    [OtherPhoneNumberExtn]    VARCHAR (5)   NULL,
    [FaxNumber]               VARCHAR (10)  NULL,
    [IntFaxNumber]            VARCHAR (10)  NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);













