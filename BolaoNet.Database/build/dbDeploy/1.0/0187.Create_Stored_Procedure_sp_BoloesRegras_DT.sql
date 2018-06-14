IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRegras_DT')
BEGIN
	DROP  Procedure  sp_BoloesRegras_DT
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRegras_DT]
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

	
	SELECT TOP 1 * 
	  FROM BoloesRegras
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	RegraID			= @RegraID
		
			  	
	RETURN @@RowCount	
	
END




GO
