IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosGruposTimes_Del')
BEGIN
	DROP  Procedure  sp_CampeonatosGruposTimes_Del
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosGruposTimes_Del]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(30),		
	@NomeTime							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DELETE FROM CampeonatosGruposTimes
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND NomeTime				= @NomeTime
	   AND NomeGrupo			= @NomeGrupo
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
