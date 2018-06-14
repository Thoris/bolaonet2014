IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosPosicoes_LoadAll')
BEGIN
	DROP  Procedure  sp_CampeonatosPosicoes_LoadAll
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosPosicoes_LoadAll]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(20),	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000);

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SELECT * 
	  FROM CampeonatosPosicoes
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND NomeFase				= @NomeFase
	   AND NomeGrupo			= @NomeGrupo	
	 ORDER BY Posicao   


	RETURN @@RowCount

END



GO
