CREATE TABLE [dbo].[MaritalStatus] (
    [id]            BIGINT       IDENTITY (1, 1) NOT NULL,
    [MaritalStatus] VARCHAR (15) NULL,
    CONSTRAINT [idMaritalStatus_pk] PRIMARY KEY CLUSTERED ([id] ASC)
);

