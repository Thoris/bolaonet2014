IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosRecordGolsFrequencia')
BEGIN
	DROP  Procedure  sp_CampeonatosRecordGolsFrequencia
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosRecordGolsFrequencia]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	SELECT Gols1, Gols2, Count(*) as 'Total'
	  FROM Jogos
	 WHERE IsValido = 1
	   AND NomeCampeonato = @NomeCampeonato
	 GROUP BY NomeCampeonato, NomeFase, Gols1, Gols2
	 ORDER BY Count(*) DESC
	  

END



GO
