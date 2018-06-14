IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Campeonatos_LoadRodadas')
BEGIN
	DROP  Procedure  sp_Campeonatos_LoadRodadas
END
GO
CREATE PROCEDURE [dbo].[sp_Campeonatos_LoadRodadas]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(50),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT Distinct Rodada
	  FROM Jogos
	 WHERE 
		NomeCampeonato				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
