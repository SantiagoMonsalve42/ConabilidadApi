-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[SaldoCuenta]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	SELECT @Id as id,
		   sum(t.ValorTransaccion) as total, 
		   SUM(CASE WHEN t.EsPositivo = 1 THEN t.ValorTransaccion ELSE 0 END) as activos,
		   SUM(CASE WHEN t.EsPositivo = 0 THEN t.ValorTransaccion ELSE 0 END) as pasivos
		   FROM Transacciones t join Cuenta c
		   on t.IdCuenta = c.Id
		   join Persona p on c.PersonaId = p.Id
		   where p.Id= @Id
END