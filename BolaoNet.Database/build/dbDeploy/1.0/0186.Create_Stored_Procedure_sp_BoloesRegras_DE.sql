IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRegras_DE')
BEGIN
	DROP  Procedure  sp_BoloesRegras_DE
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRegras_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@RegraID							bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DELETE 
	  FROM BoloesRegras
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	RegraID			= @RegraID
	   
	  
	
	
		
			  	
	RETURN @@RowCount
	
END




GO
