IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Pagamentos_DT')
BEGIN
	DROP  Procedure  sp_Pagamentos_DT
END
GO
CREATE PROCEDURE [dbo].[sp_Pagamentos_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@UserName							varchar(25),
	@DataPagamento						datetime,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT TOP 1 * 
	  FROM Pagamentos 
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	UserName		= @UserName
	   AND	DataPagamento	= @DataPagamento
		
			  	
	RETURN @@RowCount	
	
END




GO
