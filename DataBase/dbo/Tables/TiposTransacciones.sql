CREATE TABLE [dbo].[TiposTransacciones] (
    [Id]              BIGINT        IDENTITY (1, 1) NOT NULL,
    [TipoTransaccion] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_TiposTransacciones] PRIMARY KEY CLUSTERED ([Id] ASC)
);

