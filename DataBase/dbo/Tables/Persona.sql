CREATE TABLE [dbo].[Persona] (
    [Id]               BIGINT        IDENTITY (1, 1) NOT NULL,
    [Nombre_1]         VARCHAR (50)  NOT NULL,
    [Nombre_2]         VARCHAR (50)  NULL,
    [Apellido_1]       VARCHAR (50)  NOT NULL,
    [Apellido_2]       VARCHAR (50)  NULL,
    [Id_TipoDocumento] BIGINT        NOT NULL,
    [NumeroDocumento]  VARCHAR (50)  NOT NULL,
    [UrlFoto]          VARCHAR (200) NULL,
    [Email]            VARCHAR (50)  NOT NULL,
    [Password]         VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Persona_Tipos_documentos] FOREIGN KEY ([Id_TipoDocumento]) REFERENCES [dbo].[Tipos_documentos] ([Id])
);

