IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Social_DT')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Social_DT
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Social_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@NomeBolao							varchar(30),
	@IdJogo								int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	SELECT * 
	  FROM JogosUsuarios
	 WHERE NomeBolao		= @NomeBolao
	   AND IdJogo			= @IdJogo
	   AND UserName			= @UserName

	
	RETURN @@RowCount	  	
	
	
END



GO
