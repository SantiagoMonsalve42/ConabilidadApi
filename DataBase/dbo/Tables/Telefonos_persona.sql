CREATE TABLE [dbo].[Telefonos_persona] (
    [IdPersona]      BIGINT NOT NULL,
    [IdTipoTelefono] BIGINT NOT NULL,
    CONSTRAINT [FK_Telefonos_persona_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Persona] ([Id]),
    CONSTRAINT [FK_Telefonos_persona_Tipos_Telefonos] FOREIGN KEY ([IdTipoTelefono]) REFERENCES [dbo].[Tipos_Telefonos] ([Id])
);

