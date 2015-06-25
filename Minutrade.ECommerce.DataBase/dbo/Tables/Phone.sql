CREATE TABLE [dbo].[Phone] (
    [id]       BIGINT       IDENTITY (1, 1) NOT NULL,
    [ClientId] BIGINT       NULL,
    [CodArea]  SMALLINT     NOT NULL,
    [Number]   VARCHAR (10) NOT NULL,
    CONSTRAINT [IdPhone_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Phone_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);



