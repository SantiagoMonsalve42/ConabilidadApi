CREATE TABLE [dbo].[PreguntasSeguridad] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Pregunta] VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_PreguntasSeguridad] PRIMARY KEY CLUSTERED ([Id] ASC)
);

