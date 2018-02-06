CREATE TABLE [dbo].[NoteSet] (
    [NoteSetId]      INT           IDENTITY (1, 1) NOT NULL,
    [OwnerTableName] VARCHAR (250) NULL,
    [CreateUserId]   VARCHAR (50)  NOT NULL,
    [CreateDateTime] DATETIME      NOT NULL,
    [UpdateUserId]   VARCHAR (50)  NOT NULL,
    [UpdateDateTime] DATETIME      NOT NULL,
    [UpdateNumber]   INT           NULL,
    [UpdateProcess]  VARCHAR (100) NULL,
    CONSTRAINT [PK_NoteSet] PRIMARY KEY CLUSTERED ([NoteSetId] ASC)
);

