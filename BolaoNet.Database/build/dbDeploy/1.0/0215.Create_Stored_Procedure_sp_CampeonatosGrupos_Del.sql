IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosGrupos_Del')
BEGIN
	DROP  Procedure  sp_CampeonatosGrupos_Del
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosGrupos_Del]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DELETE FROM CampeonatosGrupos
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND Nome					= @NomeGrupo
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
