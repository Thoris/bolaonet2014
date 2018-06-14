IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosPontos_HistClassificacao')
BEGIN
	DROP  Procedure  sp_BoloesMembrosPontos_HistClassificacao
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosPontos_HistClassificacao]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT	
)
AS
BEGIN
	 
	 
	SELECT Rodada, UserName, Sum(TotalPontos) as Pontos
	  FROM BoloesMembrosPontos
	 GROUP BY NomeBolao, NomeCampeonato, Rodada, UserName
	 ORDER BY NomeBolao, NomeCampeonato, Rodada, Sum(TotalPontos) DESC	 
	 
	 
	 
	 
	RETURN @@RowCount	  		 
	 
END





GO
