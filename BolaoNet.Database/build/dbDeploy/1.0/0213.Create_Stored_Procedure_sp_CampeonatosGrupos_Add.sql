IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosGrupos_Add')
BEGIN
	DROP  Procedure  sp_CampeonatosGrupos_Add
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosGrupos_Add]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(30),
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	INSERT INTO CampeonatosGrupos
		(
			NomeCampeonato,
			Nome, 
			Descricao
		)
		VALUES
		(
			@NomeCampeonato,
			@NomeGrupo, 
			@Descricao
		)
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
