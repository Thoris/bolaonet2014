IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Pagamentos_UP')
BEGIN
	DROP  Procedure  sp_Pagamentos_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Pagamentos_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@UserName							varchar(25),
	@DataPagamento						datetime,
	@TipoPagamento						int,
	@Valor								decimal,
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE Pagamentos SET	
		TipoPagamento		= @TipoPagamento,
		Valor				= @Valor,
		Descricao			= @Descricao,	
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	UserName		= @UserName
	   AND	DataPagamento	= @DataPagamento
		
			  	
	RETURN @@RowCount	
	
END




GO
