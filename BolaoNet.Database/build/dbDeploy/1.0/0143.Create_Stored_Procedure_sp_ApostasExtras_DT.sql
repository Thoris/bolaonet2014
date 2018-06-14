IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_DT')
BEGIN
	DROP  Procedure  sp_ApostasExtras_DT
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_DT]
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

	
	SELECT TOP 1 * 
	  FROM ApostasExtras 
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	Posicao			= @Posicao
		
			  	
	RETURN @@RowCount	
	
END




GO
