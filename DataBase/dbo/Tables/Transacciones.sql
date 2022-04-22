CREATE TABLE [dbo].[Transacciones] (
    [Id]               BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdCuenta]         BIGINT          NOT NULL,
    [ValorTransaccion] NUMERIC (18, 2) NOT NULL,
    [Url]              VARCHAR (200)   NULL,
    [Fecha]            DATETIME        NOT NULL,
    [EsPositivo]       BIT             NOT NULL,
    CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transacciones_Cuenta] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[Cuenta] ([Id])
);





