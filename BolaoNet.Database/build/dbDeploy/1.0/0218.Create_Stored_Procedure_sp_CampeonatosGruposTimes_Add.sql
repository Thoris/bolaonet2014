IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosGruposTimes_Add')
BEGIN
	DROP  Procedure  sp_CampeonatosGruposTimes_Add
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosGruposTimes_Add]
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
	
	INSERT INTO CampeonatosGruposTimes
		(
			NomeCampeonato,
			NomeGrupo,
			NomeTime
		)
		VALUES
		(
			@NomeCampeonato,
			@NomeGrupo,
			@NomeTime
		)
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
