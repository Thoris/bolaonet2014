IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosClassificacao_Organize')
BEGIN
	DROP  Procedure  sp_CampeonatosClassificacao_Organize
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosClassificacao_Organize]
(
    @CurrentLogin						varchar(25),
    @ApplicationName					nvarchar(256) = null,
	@CurrentRodada						int,
    @CurrentNomeFase					varchar(30), 
	@NomeCampeonato						varchar(50),
	@CurrentNomeGrupo					varchar(20),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	
	



	-- Inserindo os registros faltantes
	INSERT INTO CampeonatosClassificacao 
		(NomeCampeonato, NomeFase, NomeTime, NomeGrupo, Rodada,
		 Posicao, LastPosicao, TotalVitorias, TotalDerrotas, TotalEmpates, 
		 TotalGolsContra, TotalGolsPro, TotalPontos, CreatedBy,
		 CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
	SELECT NomeCampeonato, NomeFase, NomeTime, NomeGrupo, (c.Rodada + 1),
		   Posicao, lastPosicao, 0, 0, 0,
		   0, 0, 0, @CurrentLogin, 
		   GetDate(), @CurrentLogin, GetDate(), 0
	  FROM CampeonatosClassificacao c
	 WHERE Rodada			= (@CurrentRodada - 1)
	   AND NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @CurrentNomeFase
	   AND NomeGrupo		= @CurrentNomeGrupo
	   AND NOT EXISTS (SELECT * 
						 FROM CampeonatosClassificacao l
						WHERE l.NomeCampeonato		= c.NomeCampeonato
						  AND l.NomeFase			= c.NomeFase
						  AND l.NomeGrupo			= c.NomeGrupo
						  AND l.NomeTime			= c.NomeTime
						  AND l.Rodada				= (c.Rodada + 1)
					   )






	SET @CurrentRodada = @CurrentRodada - 1
	

	CREATE TABLE #LastClassificacao 
		(
			Posicao			int,
			NomeTime		varchar(30), 
			TotalPontos		int,
			TotalVitorias	int,
			TotalEmpates	int,
			TotalDerrotas	int,
			TotalGolsPro	int,
			TotalGolsContra	int,
			Saldo			int
		)


	-- Inserindo os dados da última atualização
	INSERT #LastClassificacao
	EXECUTE sp_CampeonatosClassificacao_LoadRodada
		   @CurrentLogin
		  ,@ApplicationName
		  ,@CurrentRodada
		  ,@CurrentNomeFase
		  ,@NomeCampeonato
		  ,@CurrentNomeGrupo
		  ,@ErrorNumber OUTPUT
		  ,@ErrorDescription OUTPUT


	SET @CurrentRodada = @CurrentRodada + 1


	CREATE TABLE #CurrentClassificacao 
		(
			Posicao			int,
			NomeTime		varchar(30), 
			TotalPontos		int,
			TotalVitorias	int,
			TotalEmpates	int,
			TotalDerrotas	int,
			TotalGolsPro	int,
			TotalGolsContra	int,
			Saldo			int
		)

	-- Inserindo os dados da rodada atual
	INSERT #CurrentClassificacao
	EXECUTE sp_CampeonatosClassificacao_LoadRodada
		   @CurrentLogin
		  ,@ApplicationName
		  ,@CurrentRodada
		  ,@CurrentNomeFase
		  ,@NomeCampeonato
		  ,@CurrentNomeGrupo
		  ,@ErrorNumber OUTPUT
		  ,@ErrorDescription OUTPUT



	UPDATE t
	   SET	t.Posicao		= c.Posicao,
			t.LastPosicao	= l.Posicao
	  FROM CampeonatosClassificacao as t
	 LEFT JOIN #CurrentClassificacao as c
		ON t.NomeTime COLLATE DATABASE_DEFAULT		= c.NomeTime COLLATE DATABASE_DEFAULT
	 LEFT JOIN #LastClassificacao as l
		ON t.NomeTime COLLATE DATABASE_DEFAULT		= l.NomeTime COLLATE DATABASE_DEFAULT
	 WHERE NomeCampeonato	= @NomeCampeonato
       AND NomeGrupo		= @CurrentNomeGrupo
	   AND NomeFase			= @CurrentNomeFase
	   AND Rodada			= @CurrentRodada


	DROP TABLE #LastClassificacao
	DROP TABLE #CurrentClassificacao



	RETURN 0

END





GO
