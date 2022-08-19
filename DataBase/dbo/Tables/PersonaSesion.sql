CREATE TABLE [dbo].[PersonaSesion] (
    [IdPersona]   BIGINT        NOT NULL,
    [TokenSesion] VARCHAR (256) NOT NULL,
    [Token512]    VARCHAR (MAX) NOT NULL,
    [Hora]        DATE          NOT NULL,
    [IdSesion]    BIGINT        IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_PersonaSesion] PRIMARY KEY CLUSTERED ([IdSesion] ASC),
    CONSTRAINT [FK_PersonaSesion_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Persona] ([Id])
);

