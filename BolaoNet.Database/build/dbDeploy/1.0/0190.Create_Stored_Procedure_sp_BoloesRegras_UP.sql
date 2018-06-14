IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRegras_UP')
BEGIN
	DROP  Procedure  sp_BoloesRegras_UP
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRegras_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@RegraID							bigint,
	@Description						varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE BoloesRegras SET	
		Description			= @Description,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	RegraID			= @RegraID
		
			  	
	RETURN @@RowCount	
	
END




GO
