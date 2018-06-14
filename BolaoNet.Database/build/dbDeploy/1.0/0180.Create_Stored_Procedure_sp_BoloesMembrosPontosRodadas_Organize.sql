IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosPontosRodadas_Organize')
BEGIN
	DROP  Procedure  sp_BoloesMembrosPontosRodadas_Organize
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosPontosRodadas_Organize]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(20),
	@NomeFase							varchar(30),
	@NomeBolao							varchar(30),
	@Rodada								int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	
	

	PRINT 'Inserindo os pontos dos usuários que ainda não foram computados'

	-- Inserindo os registros faltantes
	INSERT INTO BoloesMembrosPontos
		(UserName, NomeBolao, NomeGrupo, NomeCampeonato, NomeFase, Rodada,
		 Posicao, LastPosicao, TotalPontos, TotalEmpate, TotalVitoria,
		 TotalGolsGanhador, TotalGolsPerdedor, TotalResultTime1,
		 TotalResultTime2, TotalVDE, TotalErro, TotalGolsGanhadorFora,
		 TotalGolsGanhadorDentro, TotalPerdedorFora, TotalPerdedorDentro,
		 TotalGolsEmpate, TotalGolsTime1, TotalGolsTime2, TotalPlacarCheio,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
	SELECT UserName, NomeBolao, NomeGrupo, NomeCampeonato, NomeFase, (c.Rodada + 1),
		   Posicao, lastPosicao, 0, 0, 0,
		   0, 0, 0, 
		   0, 0, 0, 0, 
		   0, 0, 0,
		   0, 0, 0, 0,
		   @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0
	  FROM BoloesMembrosPontos c
	 WHERE Rodada			= (@Rodada - 1)
	   AND NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @NomeFase
	   AND NomeGrupo		= @NomeGrupo
	   AND NomeBolao		= @NomeBolao
	   AND NOT EXISTS (SELECT * 
						 FROM BoloesMembrosPontos l
						WHERE l.NomeCampeonato		= c.NomeCampeonato
						  AND l.NomeFase			= c.NomeFase
						  AND l.NomeGrupo			= c.NomeGrupo
						  AND l.UserName			= c.UserName
						  AND l.NomeBolao			= c.NomeBolao
						  AND l.Rodada				= (c.Rodada + 1)
					   )





	PRINT 'Declarando a tabela virtual de rodadas'
	---------------------------------------------------------------------
	DECLARE @ClassificacaoRodadas Table
		(
			NomeFase				varchar(30),
			Rodada					int,
			--Posicao					int,
			UserName				varchar(25),
			TotalPontos				int,
			TotalEmpate				int,
			TotalVitoria			int,
			TotalGolsGanhador		int,
			TotalGolsPerdedor		int,
			TotalResultTime1		int,
			TotalResultTime2		int,
			TotalVDE				int,
			TotalErro				int,
			TotalGolsGanhadorFora	int,
			TotalGolsGanhadorDentro	int,
			TotalPerdedorFora		int,
			TotalPerdedorDentro		int,
			TotalGolsEmpate			int,
			TotalGolsTime1			int,
			TotalGolsTime2			int,
			TotalPlacarCheio		int,
			TotalApostaExtra		int
		)

	PRINT 'Inserindo dados na tabela de rodada'
	-- Buscando os dados necessários para realizar a conversão
	INSERT @ClassificacaoRodadas
	SELECT t.NomeFase,
		   t.Rodada, 
		   t.UserName, 
		   SUM(t.TotalPontos) as TotalPontos, 
		   SUM(t.TotalEmpate) as TotalEmpate, 
		   SUM(t.TotalVitoria) as TotalVitoria,
		   SUM(t.TotalGolsGanhador) as TotalGolsGanhador, 
		   SUM(t.TotalGolsPerdedor) as TotalGolsPerdedor, 
		   SUM(t.TotalResultTime1) as TotalResultTime1, 
		   SUM(t.TotalResultTime2) as TotalResultTime2, 
		   SUM(t.TotalVDE) as TotalVDE,
		   SUM(t.TotalErro) as TotalErro, 
		   SUM(t.TotalGolsGanhadorFora) as TotalGolsGanhadorFora, 
		   SUM(t.TotalGolsGanhadorDentro) as TotalGolsGanhadorDentro,
		   SUM(t.TOtalPerdedorFora) as TotalPerdedorFora, 
		   SUM(t.TotalPerdedorDentro) as TotalPerdedorDentro, 
		   SUM(t.TotalEmpate) as TotalGolsEmpate,
		   SUM(t.TotalGolsTime1) as TotalGolsTime1,
		   SUM(t.TotalGolsTime2) as TotalGolsTime2,
		   SUM(t.TotalPlacarCheio) as TotalPlacarCheio,
		  -- (
				--SELECT ISNULL(Sum(ex.Pontos), 0)
				--  FROM ApostasExtrasUsuarios ex
				-- WHERE ex.NomeBolao			= @NomeBolao
				--   AND ex.UserName			= t.UserName
				-- GROUP BY ex.NomeBolao, ex.UserName
		  -- )
		  -- as TotalApostaExtra
		  0 as TotalApostaExtra
		   
	  FROM BoloesMembrosPontos t
	 WHERE t.NomeBolao = @NomeBolao
	 GROUP BY t.NomeBolao, t.NomeFase, t.Rodada, t.UserName
	 
	PRINT 'Declarando a tabela de pontos corrente'
	---------------------------------------------------------------------
	DECLARE @ClassificacaoCurrent Table
		(
			Posicao					int,
			LastPosicao				int,
			UserName				varchar(25),
			TotalPontos				int,
			TotalEmpate				int,
			TotalVitoria			int,
			TotalGolsGanhador		int,
			TotalGolsPerdedor		int,
			TotalResultTime1		int,
			TotalResultTime2		int,
			TotalVDE				int,
			TotalErro				int,
			TotalGolsGanhadorFora	int,
			TotalGolsGanhadorDentro	int,
			TotalPerdedorFora		int,
			TotalPerdedorDentro		int,
			TotalGolsEmpate			int,
			TotalGolsTime1			int,
			TotalGolsTime2			int,
			TotalPlacarCheio		int,			
			TotalApostaExtra		int
		)

	PRINT 'Inserindo dados na tabela corrente'
	

	SELECT 0 as Posicao, 
		   NULL as LastPosicao,
		   t.UserName, 
		   --(SUM(t.TotalPontos)) as TotalPontos, 
		   (SUM(t.TotalPontos) + ISNULL((
				SELECT ISNULL(Sum(ex.Pontos), 0)
				  FROM ApostasExtrasUsuarios ex
				 WHERE ex.NomeBolao	COLLATE DATABASE_DEFAULT 		= @NomeBolao COLLATE DATABASE_DEFAULT 
				   AND ex.UserName	COLLATE DATABASE_DEFAULT 		= t.UserName COLLATE DATABASE_DEFAULT 
				 GROUP BY ex.NomeBolao, ex.UserName
		   ),0) ) as TotalPontos, 		   
		   SUM(t.TotalEmpate) as TotalEmpate, 
		   SUM(t.TotalVitoria) as TotalVitoria,
		   SUM(t.TotalGolsGanhador) as TotalGOlsGanhador, 
		   SUM(t.TotalGolsPerdedor) as TotalGolsPerdedor, 
		   SUM(t.TotalResultTime1) as TotalResultTime1, 
		   SUM(t.TotalResultTime2) as TotalResultTime2, 
		   SUM(t.TotalVDE) as TotalVDE,
		   SUM(t.TotalErro) as TotalErro, 
		   SUM(t.TotalGolsGanhadorFora) as TotalGolsGanhadorFora, 
		   SUM(t.TotalGolsGanhadorDentro) as TotalGolsGanhadorDentro,
		   SUM(t.TOtalPerdedorFora) as TotalPerdedorFora, 
		   SUM(t.TotalPerdedorDentro) as TOtalPerdedorDentro, 
		   SUM(t.TotalEmpate) as TotalGolsEmpate,
		   SUM(t.TotalGolsTime1) as TotalGolsTime1,
		   SUM(t.TotalGolsTime2) as TotalGolsTime2,
		   SUM(t.TotalPlacarCheio) as TotalPlacarCheio,
		   --SUM(t.TotalApostaExtra) as TotalApostaExtra
		   ISNULL((
				SELECT ISNULL(Sum(ex.Pontos), 0)
				  FROM ApostasExtrasUsuarios ex
				 WHERE ex.NomeBolao	COLLATE DATABASE_DEFAULT 		= @NomeBolao COLLATE DATABASE_DEFAULT 
				   AND ex.UserName	COLLATE DATABASE_DEFAULT 		= t.UserName COLLATE DATABASE_DEFAULT 
				 GROUP BY ex.NomeBolao, ex.UserName
		   ),0) as TotalApostaExtra			   
	INTO #TMPClassificacao
	FROM @ClassificacaoRodadas t
   GROUP BY t.UserName
   ORDER BY SUM(t.TotalPontos) DESC, t.UserName 
	 	 
	PRINT 'Atribuindo a classificação da tela corrente'
	 
   INSERT @ClassificacaoCurrent
   SELECT  *
     FROM #TMPClassificacao

	PRINT 'Apagando a tabela temporária'

	DROP TABLE #TMPClassificacao


	DECLARE @Posicao		int
	DECLARE @UserName		varchar(25)
	DECLARE @TotalPontos	int
	DECLARE @LastPosicao	int
	DECLARE @LastPontos		int



	PRINT 'Criando o cursor para analisar a posição de cada usuário'
	DECLARE curClassificacao CURSOR FOR
	  --SELECT Posicao, UserName, TotalPontos 
	  SELECT UserName, TotalPontos 
		FROM @ClassificacaoCurrent 
	   --ORDER BY Posicao
	   ORDER BY TotalPontos DESC

	OPEN curClassificacao
	--FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos
	FETCH curClassificacao INTO @UserName, @TotalPontos

	SET @Posicao = 1


	SET @LastPosicao = @Posicao
	SET @LastPontos	= @TotalPontos



	WHILE @@FETCH_STATUS = 0
	BEGIN
PRINT 'Posicao : ' + CONVERT(VARCHAR, @posicao)	+ ' - LastPontos: ' + CONVERT(VARCHAR, @LastPontos) + ' - TotalPontos: ' + CONVERT(VARCHAR, @TotalPontos)
	
		--IF (@LastPontos = @TotalPontos)
		--BEGIN
			

		--END
		--ELSE
		IF (@LastPontos <> @TotalPontos)
		
		BEGIN
			SET @LastPosicao = @Posicao
			SET @LastPontos	= @TotalPontos
		END


			UPDATE @ClassificacaoCurrent SET
				Posicao		= @LastPosicao
			 WHERE UserName	= @UserName



		--FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos
		
		
		SET @Posicao = @Posicao + 1
		
		FETCH curClassificacao INTO @UserName, @TotalPontos
		
	END



	CLOSE curClassificacao
	DEALLOCATE curClassificacao


	---------------------------------------------------------------------

	PRINT 'Apagando dados da rodada atual para analisar a diferença de posição dos antigos'
	-- Apagando os dados da última rodada para realizar a comparação
	DELETE 
	  FROM @ClassificacaoRodadas
     WHERE NomeFase			= @NomeFase
	   AND Rodada			= @Rodada
    

	PRINT 'Abrindo o cursor para analisar a posição da rodada anterior'	

	 
	 
	 
	SELECT IDENTITY(INT, 1,1) AS Row, 
		   t.UserName, 
		   SUM(t.TotalPontos) as TotalPontos 		   
	INTO #TMP2
	  FROM @ClassificacaoRodadas t
	 GROUP BY t.UserName
	 ORDER BY SUM(t.TotalPontos) DESC



	 
	DECLARE curClassificacao CURSOR FOR
	 SELECT Row, UserName, TotalPontos FROM #TMP2 
	 
	 
	 
	 
	 
	 


	OPEN curClassificacao
	FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos

	SET @LastPosicao = @Posicao
	SET @LastPontos	= @TotalPontos


	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@LastPontos <> @TotalPontos)		
		BEGIN

			SET @LastPosicao = @Posicao
			SET @LastPontos	= @TotalPontos


		END

		UPDATE @ClassificacaoCurrent SET
			LastPosicao		= @LastPosicao
		 WHERE UserName	= @UserName



		FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos
	END


	CLOSE curClassificacao
	DEALLOCATE curClassificacao


	DECLARE @MaxLastPosicao		int

	PRINT 'Buscando o maior valor de posição da rodada'	
	SELECT @MaxLastPosicao	= MAX(ISNULL(LastPosicao, 0))
	  FROM @ClassificacaoCurrent

	PRINT 'Atualizando o valor da última posição da rodada'
	UPDATE @ClassificacaoCurrent
       SET LastPosicao = @MaxLastPosicao + 1
     WHERE LastPosicao IS NULL


	PRINT 'Apagando a última atualização da rodada'
	DELETE  
	  FROM BoloesMembrosClassificacao
     WHERE NomeBolao = @NomeBolao

	PRINT 'Inserindo dados computados na tabela física'
	INSERT INTO BoloesMembrosClassificacao
		(
			NomeBolao,
			UserName, 
			Posicao,
			LastPosicao,
			TotalPontos,
			TotalEmpate,
			TotalVitoria,
			TotalGolsGanhador,
			TotalGolsPerdedor,
			TotalResultTime1,
			TotalResultTime2,
			TotalVDE,
			TotalErro,
			TotalGolsGanhadorFora,
			TotalGolsGanhadorDentro,
			TotalPerdedorFora,
			TotalPerdedorDentro,
			TotalGolsEmpate,
			TotalGolsTime1,
			TotalGolsTime2,
			TotalPlacarCheio,			
			TotalApostaExtra,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag			
		)
		SELECT
			@NomeBolao,
			UserName, 
			Posicao,
			ISNULL(LastPosicao, 0),
			TotalPontos,
			TotalEmpate,
			TotalVitoria,
			TotalGolsGanhador,
			TotalGolsPerdedor,
			TotalResultTime1,
			TotalResultTime2,
			TotalVDE,
			TotalErro,
			TotalGolsGanhadorFora,
			TotalGolsGanhadorDentro,
			TotalPerdedorFora,
			TotalPerdedorDentro,
			TotalGolsEmpate,
			TotalGolsTime1,
			TotalGolsTime2,
			TotalPlacarCheio,
			TotalApostaExtra,
			@CurrentLogin,
			GetDate(),
			@CurrentLogin,
			GetDate(),
			0
		  FROM	@ClassificacaoCurrent
		 


	 DROP TABLE #TMP2
	 




	RETURN 0





	PRINT ''

END




GO
