CREATE TABLE [dbo].[Transacciones] (
    [Id]                BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdCuenta]          BIGINT          NOT NULL,
    [ValorTransaccion]  NUMERIC (18, 2) NOT NULL,
    [Url]               VARCHAR (200)   NULL,
    [Fecha]             DATETIME        NOT NULL,
    [EsPositivo]        BIT             NOT NULL,
    [Descripcion]       VARCHAR (256)   NOT NULL,
    [IdTipoTransaccion] BIGINT          NOT NULL,
    CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transacciones_Cuenta] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[Cuenta] ([Id]),
    CONSTRAINT [FK_Transacciones_TiposTransacciones] FOREIGN KEY ([IdTipoTransaccion]) REFERENCES [dbo].[TiposTransacciones] ([Id])
);







