IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_DT')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_DT
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),	
	@IDJogo								bigint,
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT TOP 1 * 
	  FROM JogosUsuarios
	 WHERE 
			NomeCampeonato				= @NomeCampeonato
		AND	IDJogo						= @IdJogo
		AND	NomeBolao					= @NomeBolao
		AND	UserName					= @UserName
			  	
	RETURN @@RowCount	
	
END



GO
