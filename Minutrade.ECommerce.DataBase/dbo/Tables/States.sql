CREATE TABLE [dbo].[States] (
    [id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [StatesName] VARCHAR (10) NULL,
    CONSTRAINT [IdStates_pk] PRIMARY KEY CLUSTERED ([id] ASC)
);

