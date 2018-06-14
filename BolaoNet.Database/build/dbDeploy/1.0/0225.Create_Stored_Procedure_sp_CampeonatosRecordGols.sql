IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosRecordGols')
BEGIN
	DROP  Procedure  sp_CampeonatosRecordGols
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosRecordGols]
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



	SELECT NomeFase, Rodada,
			Count(*) as 'Jogos',
			ISNULL(SUM(Gols1),0) as 'GolsMandantes',
			ISNULL(SUM(Gols2),0) as 'GolsVisitantes',
			SUM(Gols1) + SUM(Gols2) as 'Total',
			(SUM(Gols1) + SUM(Gols2)) / Count(*) as 'Media'
	  FROM Jogos
	 WHERE IsValido			= 1
	   AND NomeCampeonato	= @NomeCampeonato 
	 GROUP BY NomeCampeonato, NomeFase, Rodada



END



GO
