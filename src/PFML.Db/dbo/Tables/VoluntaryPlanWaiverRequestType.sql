CREATE TABLE [dbo].[VoluntaryPlanWaiverRequestType] (
	[FormId] [int] NOT NULL,
    [LeaveTypeCode]                    VARCHAR (20)   NOT NULL,
    [PercentagePaid]                   DECIMAL (5, 2) NOT NULL,
    [DurationInWeeksCode]              VARCHAR (20)   NOT NULL,
    [CreateUserId]                     VARCHAR (50)   NOT NULL,
    [CreateDateTime]                   DATETIME       NOT NULL,
    [UpdateUserId]                     VARCHAR (50)   NOT NULL,
    [UpdateDateTime]                   DATETIME       NOT NULL,
    [UpdateNumber]                     INT            NULL,
    [UpdateProcess]                    VARCHAR (100)  NULL,
    CONSTRAINT [PK_VoluntaryPlanWaiverRequestType] PRIMARY KEY CLUSTERED ([FormId] ASC,	[LeaveTypeCode] ASC),
    CONSTRAINT [FK_VoluntaryPlanWaiverRequestType_VoluntaryPlanWaiverRequest_FormId] FOREIGN KEY ([FormId]) REFERENCES [dbo].[VoluntaryPlanWaiverRequest] ([FormId])
);

