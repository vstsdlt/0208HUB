CREATE TABLE [dbo].[Document] (
    [DocumentID]          INT              IDENTITY (1, 1) NOT NULL,
    [DocumentName]        VARCHAR (255)    NOT NULL,
    [DocumentDescription] VARCHAR (500)    NULL,
    [CreateUserId]        VARCHAR (50)     NOT NULL,
    [CreateDateTime]      DATETIME         NOT NULL,
    [UpdateUserId]        VARCHAR (50)     NOT NULL,
    [UpdateDateTime]      DATETIME         NOT NULL,
    [UpdateNumber]        INT              NULL,
    [UpdateProcess]       VARCHAR (100)    NULL,
    CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED ([DocumentID] ASC)
);

