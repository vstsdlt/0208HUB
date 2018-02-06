CREATE TABLE [dbo].[Note] (
    [NoteId]         INT            NOT NULL,
    [NoteSetId]      INT            NOT NULL,
    [NoteTypeCode]   VARCHAR (20)   NOT NULL,
    [NoteText]       VARCHAR (3800) NOT NULL,
    [CreateUserId]   VARCHAR (50)   NOT NULL,
    [CreateDateTime] DATETIME       NOT NULL,
    [UpdateUserId]   VARCHAR (50)   NOT NULL,
    [UpdateDateTime] DATETIME       NOT NULL,
    [UpdateNumber]   INT            NULL,
    [UpdateProcess]  VARCHAR (100)  NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([NoteId] ASC),
    CONSTRAINT [FK_Note_NoteSet_NoteSetId] FOREIGN KEY ([NoteSetId]) REFERENCES [dbo].[NoteSet] ([NoteSetId])
);

