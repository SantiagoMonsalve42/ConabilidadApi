CREATE TABLE [dbo].[Cuenta] (
    [Id]           BIGINT       IDENTITY (1, 1) NOT NULL,
    [NumeroCuenta] VARCHAR (50) NOT NULL,
    [PersonaId]    BIGINT       NOT NULL,
    [SaldoTotal]   NUMERIC (18) NOT NULL,
    CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cuenta_Persona] FOREIGN KEY ([PersonaId]) REFERENCES [dbo].[Persona] ([Id])
);

