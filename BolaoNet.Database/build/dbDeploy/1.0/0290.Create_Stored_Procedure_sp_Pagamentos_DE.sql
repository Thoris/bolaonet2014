IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Pagamentos_DE')
BEGIN
	DROP  Procedure  sp_Pagamentos_DE
END
GO
CREATE PROCEDURE [dbo].[sp_Pagamentos_DE]
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

	
	DELETE 
	  FROM Pagamentos
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	UserName		= @UserName
	   AND	DataPagamento	= @DataPagamento
	   
	  
	
	
		
			  	
	RETURN @@RowCount
	
END




GO
