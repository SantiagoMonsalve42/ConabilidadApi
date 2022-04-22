CREATE TABLE [dbo].[Preguntas_Respuestas] (
    [IdPregunta] BIGINT        NOT NULL,
    [IdPersona]  BIGINT        NOT NULL,
    [Respuesta]  VARCHAR (100) NOT NULL,
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Preguntas_Respuestas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Preguntas_Respuestas_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Persona] ([Id]),
    CONSTRAINT [FK_Preguntas_Respuestas_PreguntasSeguridad] FOREIGN KEY ([IdPregunta]) REFERENCES [dbo].[PreguntasSeguridad] ([Id])
);



