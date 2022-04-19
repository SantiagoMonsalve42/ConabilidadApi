CREATE TABLE [dbo].[Tipos_Telefonos] (
    [Id]           BIGINT       IDENTITY (1, 1) NOT NULL,
    [TipoTelefono] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Tipos_Telefonos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

