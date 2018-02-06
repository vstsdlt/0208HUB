CREATE TABLE [dbo].[Employer] (
    [EmployerId]                INT           IDENTITY (1, 1) NOT NULL,
    [FEIN]                      INT           NULL,
    [EntityName]                VARCHAR (80)  NOT NULL,
    [EntityTypeCode]            VARCHAR (20)  NOT NULL,
    [BusinessTypeCode]          VARCHAR (20)  NOT NULL,
    [UserName]                  VARCHAR (10)  NOT NULL,
    [ReportMethodCode]          VARCHAR (20)  NOT NULL,
    [RegistrationDate]          DATETIME      NOT NULL,
    [StatusCode]                VARCHAR (20)  NOT NULL,
    [StatusDate]                DATETIME      NOT NULL,
    [IsServiceBegin]            BIT           NULL,
    [SubjectivityCode]          VARCHAR (20)  NOT NULL,
    [NoOfLocations]             INT           NULL,
    [LiabilityIncurredDate]     DATETIME      NULL,
    [LiabilityDate]             DATETIME      NULL,
    [CreateUserId]              VARCHAR (50)  NOT NULL,
    [CreateDateTime]            DATETIME      NOT NULL,
    [UpdateUserId]              VARCHAR (50)  NOT NULL,
    [UpdateDateTime]            DATETIME      NOT NULL,
    [NoOfEmployeesPaid]         INT           NULL,
    [ServiceBeginDate]          DATETIME      NULL,
    [UpdateNumber]              INT           NULL,
    [UpdateProcess]             VARCHAR (100) NULL,
    [HasTelecommuters]          BIT           NULL,
    [HasPhysicalLocation]       BIT           NULL,
    [IsIndividualContractor]    BIT           NULL,
    [IsAcquired]                BIT           NULL,
    [IsPresentInMultipleLoc]    BIT           NULL,
    [IsProfessionalEmployerOrg] BIT           NULL,
    [IsClientOfPEO]             BIT           NULL,
    [IsApplyingForREIM]         BIT           NULL,
    [IsExemptUnderIRS501C3]     BIT           NULL,
    [NaicsCode]                 VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_Employer] PRIMARY KEY CLUSTERED ([EmployerId] ASC)
);



















