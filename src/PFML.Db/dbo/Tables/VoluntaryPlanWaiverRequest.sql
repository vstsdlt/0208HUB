CREATE TABLE [dbo].[VoluntaryPlanWaiverRequest] (   
    [FormId]                                   INT           NOT NULL,
    [EmployerId]                               INT           NOT NULL,
    [StartDate]                                DATETIME      NOT NULL,
    [EndDate]                                  DATETIME      NOT NULL,
    [IsVoluntaryPlanWaiverRequestAcknowledged] BIT           NOT NULL,
    [CreateUserId]                             VARCHAR (50)  NOT NULL,
    [CreateDateTime]                           DATETIME      NOT NULL,
    [UpdateUserId]                             VARCHAR (50)  NOT NULL,
    [UpdateDateTime]                           DATETIME      NOT NULL,
    [UpdateNumber]                             INT           NULL,
    [UpdateProcess]                            VARCHAR (100) NULL,
    CONSTRAINT [PK_VoluntaryPlanWaiverRequest] PRIMARY KEY CLUSTERED ([FormId] ASC),
    CONSTRAINT [FK_VoluntaryPlanWaiverRequest_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId]),
    CONSTRAINT [FK_VoluntaryPlanWaiverRequest_Form_FormId] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([FormId])
);

