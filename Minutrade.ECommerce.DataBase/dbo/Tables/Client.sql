CREATE TABLE [dbo].[Client] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [MaritalStatusId]      BIGINT        NULL,
    [StateId]              BIGINT        NOT NULL,
    [Cpf]                  VARCHAR (14)  NOT NULL,
    [Name]                 VARCHAR (200) NOT NULL,
    [Email]                VARCHAR (100) NOT NULL,
    [Street]               VARCHAR (100) NOT NULL,
    [Neighborhood]         VARCHAR (100) NOT NULL,
    [Number]               INT           NOT NULL,
    [CEP]                  VARCHAR (10)  NOT NULL,
    [Complement]           VARCHAR (20)  NULL,
    [ReferenceInformation] VARCHAR (100) NULL,
    CONSTRAINT [Id_client_pk] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_States] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([id]),
    CONSTRAINT [MaritalStatus_fk] FOREIGN KEY ([MaritalStatusId]) REFERENCES [dbo].[MaritalStatus] ([id]),
    CONSTRAINT [Cpf_un] UNIQUE NONCLUSTERED ([Cpf] ASC)
);





