IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Pagamentos_IN')
BEGIN
	DROP  Procedure  sp_Pagamentos_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Pagamentos_IN]
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
	
	
	
	INSERT INTO Pagamentos 
		(
		NomeBolao,
		UserName,
		DataPagamento,
		TipoPagamento,
		Valor,
		Descricao,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@NomeBolao,
		@UserName,
		@DataPagamento,
		@TipoPagamento,
		@Valor,
		@Descricao,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END




GO
