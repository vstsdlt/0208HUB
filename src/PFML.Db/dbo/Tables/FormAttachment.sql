CREATE TABLE [dbo].[FormAttachment] (
    [FormAttachmentId] INT           IDENTITY (1, 1) NOT NULL,
    [FormId]           INT           NOT NULL,
    [DocumentId]       INT           NOT NULL,
    [CreateUserId]     VARCHAR (50)  NOT NULL,
    [CreateDateTime]   DATETIME      NOT NULL,
    [UpdateUserId]     VARCHAR (50)  NOT NULL,
    [UpdateDateTime]   DATETIME      NOT NULL,
    [UpdateNumber]     INT           NULL,
    [UpdateProcess]    VARCHAR (100) NULL,
    CONSTRAINT [PK_FormAttachment] PRIMARY KEY CLUSTERED ([FormAttachmentId] ASC),
    CONSTRAINT [FK_FormAttachment_Document_DocumentId] FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Document] ([DocumentID]),
    CONSTRAINT [FK_FormAttachment_Form_FormId] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([FormId])
);

