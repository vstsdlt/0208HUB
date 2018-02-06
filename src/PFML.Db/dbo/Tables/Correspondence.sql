CREATE TABLE [dbo].[Correspondence] (
    [CorrespondenceId]   INT           IDENTITY (1, 1) NOT NULL,
    [ResourceTemplateId] INT           NOT NULL,
    [EmployerId]         INT           NULL,
    [EmployerUnitId]     INT           NULL,
    [StatusCode]         VARCHAR (20)  NOT NULL,
    [MailByDate]         DATETIME      NULL,
    [NoteSetId]          INT           NULL,
    [AddressLinkId]      INT           NULL,
    [CreateUserId]       VARCHAR (50)  NOT NULL,
    [CreateDateTime]     DATETIME      NOT NULL,
    [UpdateUserId]       VARCHAR (50)  NOT NULL,
    [UpdateDateTime]     DATETIME      NOT NULL,
    [UpdateNumber]       INT           NULL,
    [UpdateProcess]      VARCHAR (100) NULL,
    CONSTRAINT [PK_Correspondence] PRIMARY KEY CLUSTERED ([CorrespondenceId] ASC),
    CONSTRAINT [FK_Correspondence_AddressLink_AddressLinkId] FOREIGN KEY ([AddressLinkId]) REFERENCES [dbo].[AddressLink] ([AddressLinkId]),
    CONSTRAINT [FK_Correspondence_Employer_EmployerId] FOREIGN KEY ([EmployerId]) REFERENCES [dbo].[Employer] ([EmployerId]),
    CONSTRAINT [FK_Correspondence_EmployerUnit_EmployerUnitId] FOREIGN KEY ([EmployerUnitId]) REFERENCES [dbo].[EmployerUnit] ([EmployerUnitId]),
    CONSTRAINT [FK_Correspondence_NoteSet_NoteSetId] FOREIGN KEY ([NoteSetId]) REFERENCES [dbo].[NoteSet] ([NoteSetId]),
    CONSTRAINT [FK_Correspondence_ResourceTemplate_ResourceTemplateId] FOREIGN KEY ([ResourceTemplateId]) REFERENCES [dbo].[ResourceTemplate] ([ResourceTemplateId])
);

