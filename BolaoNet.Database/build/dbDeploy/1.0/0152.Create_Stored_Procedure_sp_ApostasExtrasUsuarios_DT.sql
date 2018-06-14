IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtrasUsuarios_DT')
BEGIN
	DROP  Procedure  sp_ApostasExtrasUsuarios_DT
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtrasUsuarios_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Username							varchar(25),
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
	  FROM ApostasExtrasUsuarios
	 WHERE 	Posicao			= @Posicao
	   AND	NomeBolao		= @NomeBolao
	   AND	UserName		= @UserName
			
			  	
	RETURN @@RowCount	
	
END



GO
