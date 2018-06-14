IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_DE')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_DE
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),		
	@IDJogo								bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DELETE 
	  FROM JogosUsuarios
	 WHERE 
			NomeCampeonato	= @NomeCampeonato
	   AND  IDJogo			= @IDJogo
	   AND	NomeBolao		= @NomeBolao
	   AND	UserName		= @UserName
	  
	
	
		
			  	
	RETURN @@RowCount
	
END



GO
