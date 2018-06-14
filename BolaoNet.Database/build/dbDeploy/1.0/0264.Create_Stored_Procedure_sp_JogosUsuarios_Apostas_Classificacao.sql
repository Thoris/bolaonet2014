IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Apostas_Classificacao')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Apostas_Classificacao
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Apostas_Classificacao]
(
    @CurrentLogin						varchar(25),
    @ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25) = null,
    @NomeBolao							varchar(30),
    @NomeFase							varchar(30),
    @NomeGrupo							varchar(20),
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	DECLARE @NomeCampeonato varchar(50)
	
	SELECT @NomeCampeonato = NomeCampeonato FROM Boloes WHERE Nome = @NomeBolao


	SELECT ISNULL(TotalVitorias, 0) as TotalVitorias,
		   ISNULL(TotalDerrotas, 0) as TotalDerrotas,
		   ISNULL(TotalEmpates, 0) as TotalEmpates,
		   ISNULL(TotalPontos, 0) as TotalPontos,
		   ISNULL(TotalGolsPro, 0) as TotalGolsPro,
		   ISNULL(TotalGolsContra, 0) as TotalGolsContra,
		   (ISNULL(TotalGolsPro, 0) - ISNULL(TotalGolsContra, 0)) as Saldo,
		   NomeCampeonato,
		   NomeFase,
		   NomeBolao,
		   NomeGrupo,
		   UserName,
		   NomeTime,
		   ISNULL(TotalDerrotas, 0) + ISNULL(TotalEmpates,0) + ISNULL(TotalVitorias,0) as Jogos
	  FROM BoloesCampeonatosClassificacaoUsuarios
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND NomeFase				= @NomeFase
	   AND NomeBolao			= @NomeBolao
	   AND NomeGrupo			= @NomeGrupo
	   AND UserName				= @UserName
	 ORDER BY TotalPontos DESC, TotalVitorias DESC, (TotalGolsPro - TotalGolsContra) DESC
	

END



GO
