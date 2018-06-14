IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_DE')
BEGIN
	DROP  Procedure  sp_ApostasExtras_DE
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@Posicao							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DELETE 
	  FROM ApostasExtras
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	Posicao			= @Posicao
	   
	  
	
	
		
			  	
	RETURN @@RowCount
	
END




GO
