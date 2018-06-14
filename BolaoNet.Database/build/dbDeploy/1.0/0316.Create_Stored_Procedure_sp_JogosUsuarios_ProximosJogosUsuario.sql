IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_ProximosJogosUsuario')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_ProximosJogosUsuario
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_ProximosJogosUsuario]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SELECT TOP 3 *
	 FROM JogosUsuarios u
	INNER JOIN Jogos j
	   ON u.NomeCampeonato	= j.NomeCampeonato
	  AND u.IdJogo			= j.IdJogo
	WHERE u.UserName		= @UserName
	  AND j.IsValido		= 0
	ORDER BY j.DataJogo



	 

	RETURN @@RowCount

END



GO
