CREATE TABLE [dbo].[Tipos_documentos] (
    [Id]            BIGINT       IDENTITY (1, 1) NOT NULL,
    [TipoDocumento] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Tipos_documentos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

