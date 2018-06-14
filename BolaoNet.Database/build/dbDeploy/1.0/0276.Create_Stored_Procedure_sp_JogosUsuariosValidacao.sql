IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuariosValidacao')
BEGIN
	DROP  Procedure  sp_JogosUsuariosValidacao
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuariosValidacao]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@IdJogo								bigint,
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(20),
	@NomeFase							varchar(30),
	@Rodada								int,
	@NomeTime1							varchar(30),
	@Gols1								smallint,
	@Penaltis1							smallint,
	@NomeTime2							varchar(30),
	@Gols2								smallint,
	@Penaltis2							smallint,
	@ValidadoBy							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	PRINT 'Iniciando atualização dos usuários'


	DECLARE @Aposta1				smallint		-- Valor da aposta do time 1 do usuário
	DECLARE @Aposta2				smallint		-- Valor da aposta do time 2 do usuário
	DECLARE @NomeBolao				varchar(30)		-- Bolão
	DECLARE @UserName				varchar(25)
	

	DECLARE @UltimoNomeBolao		varchar(30)		-- Último bolão encontrado

	DECLARE @TotalPontosTime1		int
	DECLARE @TotalPontosTime2		int
	DECLARE @TotalPontos			int	


	DECLARE @PontosEmpate			int 		-- Total de pontos para empate	
	DECLARE @PontosVitoria			int 		-- Total de pontos para vitoria
	DECLARE	@PontosDerrota			int 		-- Total de pontos para derrota
	DECLARE @PontosGanhador			int 		-- Total de pontos para o time ganhador
	DECLARE @PontosPerdedor			int 		-- Total de pontos para o time perdedor
	DECLARE @PontosTime1			int			-- Total de pontos para o time de casa
	DECLARE @PontosTime2			int			-- Total de pontos para o time fora de casa
	DECLARE @PontosVDE				int 		-- Total de pontos se acertou vitória/derrota ou empate
	DECLARE @PontosErro				int 		-- Total de pontos se errou o resultado
	DECLARE @PontosGanhadorFora		int
	DECLARE @PontosGanhadorDentro	int
	DECLARE @PontosPerdedorFora		int
	DECLARE @PontosPerdedorDentro	int
	DECLARE @PontosEmpate_GOLS		int
	DECLARE @PontosGolsTime1		int
	DECLARE @PontosGolsTime2		int
	DECLARE @PontosCheio			int
	
	DECLARE @MultiploTime			int



	DECLARE @CountEmpate			int 		-- Contador de empate
	DECLARE @CountVitoria			int 		-- Contador de vitoria
	DECLARE	@CountDerrota			int 		-- Contador de derrota
	DECLARE @CountGanhador			int 		-- Contador de ganhador
	DECLARE @CountPerdedor			int 		-- Contador de perdedor
	DECLARE @CountTime1				int			-- Contador do time de casa
	DECLARE @CountTime2				int			-- Contador do time fora de casa
	DECLARE @CountVDE				int 		-- Contador de vitória/empate/derrota
	DECLARE @CountErro				int 		-- Contador de erros
	DECLARE @CountGanhadorFora		int
	DECLARE @CountPerdedorDentro	int
	DECLARE @CountGanhadorDentro	int
	DECLARE @CountPerdedorFora		int
	DECLARE @CountEmpate_GOLS		int
	DECLARE @CountGolsTime1			int
	DECLARE @CountGolsTime2			int
	DECLARE @CountCheio				int
	
	DECLARE @IsMultiploTime			bit



	SET @PontosEmpate			= 0		-- Total de pontos para empate	
	SET @PontosVitoria			= 0		-- Total de pontos para vitoria
	SET	@PontosDerrota			= 0		-- Total de pontos para derrota
	SET @PontosGanhador			= 0		-- Total de pontos para o time ganhador
	SET @PontosPerdedor			= 0		-- Total de pontos para o time perdedor
	SET @PontosTime1			= 0		-- Total de pontos para o time de casa
	SET @PontosTime2			= 0		-- Total de pontos para o time fora de casa
	SET @PontosVDE				= 0		-- Total de pontos se acertou vitória/derrota ou empate
	SET @PontosErro				= 0		-- Total de pontos se errou o resultado
	SET @PontosGanhadorFora		= 0
	SET @PontosGanhadorDentro	= 0
	SET @PontosPerdedorFora		= 0
	SET @PontosPerdedorDentro	= 0
	SET @PontosEmpate_GOLS		= 0
	SET @PontosGolsTime1		= 0
	SET @PontosGolsTime2		= 0
	SET @PontosCheio			= 0

	SET @MultiploTime			= 1

	SET @CountEmpate			= 0		-- Contador de empate
	SET @CountVitoria			= 0		-- Contador de vitoria
	SET	@CountDerrota			= 0		-- Contador de derrota
	SET @CountGanhador			= 0		-- Contador de ganhador
	SET @CountPerdedor			= 0		-- Contador de perdedor
	SET @CountTime1				= 0		-- Contador do time de casa
	SET @CountTime2				= 0		-- Contador do time fora de casa
	SET @CountVDE				= 0		-- Contador de vitória/empate/derrota
	SET @CountErro				= 0		-- Contador de erros
	SET @CountGanhadorFora		= 0
	SET @CountGanhadorDentro	= 0
	SET @CountPerdedorFora		= 0
	SET @CountPerdedorDentro	= 0
	SET @CountEmpate_GOLS		= 0
	SET @CountGolsTime1			= 0
	SET @CountGolsTime2			= 0
	SET @CountCheio				= 0
	
	SET @IsMultiploTime			= 0


	PRINT 'Declarando o cursor'

	-- Declarando o cursor para buscar as apostas dos usuários para o jogo
	DECLARE curJogosUsuarios CURSOR FOR
		SELECT	NomeBolao, UserName, ApostaTime1, ApostaTime2
		  FROM JogosUsuarios
		 WHERE IDJogo			= @IDJogo
		   AND NomeCampeonato	= @NomeCampeonato
		 ORDER BY NomeBolao, UserName
		 

	DECLARE @TranStarted	bit
	SET @TranStarted = 0

	-- Se não tem nenhuma transação corrente
	IF( @@TRANCOUNT = 0 )
	BEGIN
		-- Iniciando a transação
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END	
	
	
	-- Criando a tabela temporária para comparar o retorno
	DECLARE @UsuariosPontos  Table
	(
		NomeBolao		varchar(30),
		UserName		varchar(25),
		Aposta1			smallint,
		Aposta2			smallint,
		Pontos			int
	)
	
		 
		-- Abrindo o cursor para carregar os critérios 
		OPEN curJogosUsuarios

		-- Executando o cursor
		FETCH NEXT FROM curJogosUsuarios INTO @NomeBolao, @UserName, @Aposta1, @Aposta2

		-- Identificando o último bolão
		SET @UltimoNomeBolao = ''

		-- Enquanto existir registros
		WHILE (@@FETCH_STATUS = 0)
		BEGIN

			-- Se encontrou outro bolão 
			IF (@UltimoNomeBolao <> @NomeBolao)
			BEGIN
			
			
				IF (@UltimoNomeBolao IS NOT NULL AND LEN(@UltimoNomeBolao) > 0)
				BEGIN
					EXECUTE [sp_BoloesMembrosPontosRodadas_Organize]
						@CurrentLogin,
						@ApplicationName,
						@NomeCampeonato,
						@NomeGrupo,
						@NomeFase,
						@NomeBolao,
						@Rodada,
						@ErrorNumber OUTPUT,
						@ErrorDescription OUTPUT				
				
				END
		
				
				--EXECUTE [sp_BoloesPontosRodadas_Organize] 
				--   @CurrentLogin
				--  ,@ApplicationName		  
				--  ,@NomeCampeonato		  
				--  ,@CurrentGrupo
				--  ,@CurrentFase
				--  ,@NomeBolao
				--  ,@CurrentRodada
				--  ,@ErrorNumber OUTPUT
				--  ,@ErrorDescription OUTPUT		
				  
	  
			
			
				-- Atribuindo o último bolão encontrado
				SET @UltimoNomeBolao = @NomeBolao
				
				-- zerando os valores encontrados
				SET @PontosEmpate			= 0
				SET @PontosVitoria			= 0
				SET @PontosDerrota			= 0
				SET @PontosGanhador			= 0
				SET @PontosPerdedor			= 0
				SET @PontosTime1			= 0
				SET @PontosTime2			= 0
				SET @PontosVDE				= 0
				SET @PontosErro				= 0
				SET @PontosGanhadorFora		= 0
				SET @PontosGanhadorDentro	= 0
				SET @PontosPerdedorFora		= 0
				SET @PontosPerdedorDentro	= 0
				SET @PontosEmpate_GOLS		= 0
				SET @PontosGolsTime1		= 0
				SET @PontosGolsTime2		= 0
				SET @PontosCheio			= 0
				
				
				PRINT 'Buscando pontos do bolão ' + @NomeBolao

				

				-- Buscando os critérios para o bolão
				EXEC sp_Boloes_BuscaCriteriosPontos
											@CurrentLogin,
											@ApplicationName,
											@NomeBolao,
											@PontosEmpate			OUTPUT,
											@PontosVitoria			OUTPUT,
											@PontosDerrota			OUTPUT,
											@PontosGanhador			OUTPUT,
											@PontosPerdedor			OUTPUT,
											@PontosTime1			OUTPUT,
											@PontosTime2			OUTPUT,
											@PontosVDE				OUTPUT,
											@PontosErro				OUTPUT,
											@PontosGanhadorFora		OUTPUT,
											@PontosGanhadorDentro	OUTPUT,
											@PontosPerdedorFora		OUTPUT,
											@PontosPerdedorDentro	OUTPUT,
											@PontosEmpate_GOLS		OUTPUT,
											@PontosGolsTime1		OUTPUT,
											@PontosGolsTime2		OUTPUT,
											@PontosCheio			OUTPUT,
											@ErrorNumber			OUTPUT,
											@ErrorDescription		OUTPUT
											
											
				PRINT 'Buscando o multiplo do time'
				
				-- Buscando o múltiplo do time
				SELECT TOP 1 @MultiploTime = Multiplo
				  FROM BoloesCriteriosPontosTimes
				 WHERE NomeBolao	= @NomeBolao
				   AND (
						NomeTime	= @NomeTime1
					   OR
					    NomeTime	= @NomeTime2
					   )
					   
				-- Se não tem nenhuma informação do time jogado
				IF (@@RowCount = 0)
					SET @IsMultiploTime = 0
				ELSE
					SET @IsMultiploTime = 1
											
											
							
			END -- endif novo bolão
			
			
			

			---- Se não existir os pontos do usuário cadastrado							
			--IF (NOT EXISTS(SELECT * 
			--				 FROM BoloesMembrosPontos
			--				WHERE UserName			= @UserName
			--				  AND NomeBolao			= @NomeBolao
			--				  AND NomeGrupo			= @NomeGrupo
			--				  AND NomeCampeonato	= @NomeCampeonato
			--				  AND NomeFase			= @NomeFase
			--				  AND Rodada			= @Rodada
			--			   )
			--	)
			--BEGIN
			
			--	INSERT INTO BoloesMembrosPontos
			--			(
			--			Username,
			--			NomeBolao,
			--			NomeGrupo,
			--			NomeCampeonato,
			--			NomeFase,
			--			Rodada,
			--			CreatedBy,
			--			Createddate,
			--			ModifiedBy,
			--			ModifiedDate,
			--			ActiveFlag
			--			)
			--		VALUES
			--			(
			--			@Username,
			--			@NomeBolao,
			--			@NomeGrupo,
			--			@NomeCampeonato,
			--			@NomeFase,
			--			@Rodada,
			--			@CurrentLogin,
			--			GetDate(),
			--			@CurrentLogin,
			--			GetDate(),
			--			0
			--			)
			
			--END 
						
			
				
				
				
			-- Zerando os contadores		
			SET @CountEmpate			= 0
			SET @CountVitoria			= 0
			SET @CountDerrota			= 0
			SET @CountGanhador			= 0
			SET @CountPerdedor			= 0
			SET @CountTime1				= 0
			SET @CountTime2				= 0
			SET @CountVDE				= 0
			SET @CountErro				= 0
			SET @CountGanhadorDentro	= 0
			SET @CountGanhadorFora		= 0
			SET @CountPerdedorDentro	= 0
			SET @CountPerdedorFora		= 0
			SET @CountEmpate_GOLS		= 0
			SET @CountGolsTime1			= 0
			SET @CountGolsTime2			= 0			
			SET @CountCheio				= 0
			
			
			SET @TotalPontos			= 0
			SET @TotalPontosTime1		= 0
			SET @TotalPontosTime2		= 0

									
			PRINT '**** ATUALIZANDO O USUARIO ' + @UserName +  ' ****'									
									
									
			-- Buscando os pontos encontrados através dos resultados
			EXEC sp_JogosUsuarios_CalculaPontos		
										@CurrentLogin,
										@ApplicationName,
										@Gols1,
										@Gols2,	
										@Aposta1,
										@Aposta2,			
										@PontosEmpate,
										@PontosVitoria,
										@PontosDerrota,
										@PontosGanhador,
										@PontosPerdedor,
										@PontosTime1,
										@PontosTime2,
										@PontosVDE,
										@PontosErro,
										@PontosGanhadorFora,
										@PontosGanhadorDentro,
										@PontosPerdedorFora,
										@PontosPerdedorDentro,	
										@PontosEmpate_GOLS,
										@PontosGolsTime1,
										@PontosGolsTime2,
										@PontosCheio,
										@IsMultiploTime			,
										@MultiploTime			,										
										@TotalPontosTime1		OUTPUT,
										@TotalPontosTime2		OUTPUT,
										@TotalPontos			OUTPUT,											
										@CountEmpate			OUTPUT,
										@CountVitoria			OUTPUT,
										@CountDerrota			OUTPUT,
										@CountGanhador			OUTPUT,
										@CountPerdedor			OUTPUT,
										@CountTime1				OUTPUT,
										@CountTime2				OUTPUT,
										@CountVDE				OUTPUT,
										@CountErro				OUTPUT,	
										@CountGanhadorFora		OUTPUT,
										@CountGanhadorDentro	OUTPUT,
										@CountPerdedorFora		OUTPUT,
										@CountPerdedorDentro	OUTPUT,
										@CountEmpate_GOLS		OUTPUT,
										@CountGolsTime1			OUTPUT,
										@CountGolsTime2			OUTPUT,
										@CountCheio				OUTPUT,
										@ErrorNumber			OUTPUT,
										@ErrorDescription		OUTPUT
													

			
			PRINT 'Atualizando pontuação do usuário ' + @UserName
			
			-- Atualizando a quantidade de pontos do usuário
			UPDATE JogosUsuarios
			   SET	Valido					= 1,
					Pontos					= @TotalPontos,
					IsEmpate				= @CountEmpate,
					IsVitoria				= @CountVitoria,
					IsDerrota				= @CountDerrota,
					IsGolsGanhador			= @CountGanhador,
					IsGolsPerdedor			= @CountPerdedor,
					IsResultTime1			= @CountTime1,
					IsResultTime2			= @CountTime2,
					IsVDE					= @CountVDE,
					IsErro					= @CountErro,
					IsGolsGanhadorFora		= @CountGanhadorFora,
					IsGolsGanhadorDentro	= @CountGanhadorDentro,
					IsGolsPerdedorFora		= @CountPerdedorFora,
					IsGolsPerdedorDentro	= @CountPerdedorDentro,
					IsGolsEmpate			= @CountEmpate_GOLS,
					IsGolsTime1				= @CountGolsTime1,
					IsGolsTime2				= @CountGolsTime2,
					IsPlacarCheio			= @CountCheio,
					IsMultiploTime			= @IsMultiploTime,
					MultiploTime			= @MultiploTime
			 WHERE IdJogo			= @IdJogo
			   AND NomeBolao		= @NomeBolao
			   AND NomeCampeonato	= @NomeCampeonato			   
			   AND UserName			= @UserName
			   


			-- Inserindo na tabela temporária o valor de pontos do usuário relacionado ao jogo
			INSERT INTO @UsuariosPontos
			   (NomeBolao, UserName, Aposta1, Aposta2, Pontos)
			  VALUES
			   (@NomeBolao, @UserName, @Aposta1, @Aposta2, @TotalPontos)







			-- Apagando os registros anteriores
			DELETE 
			  FROM BoloesMembrosPontos
			 WHERE UserName					= @UserName
			   AND NomeBolao				= @NomeBolao
			   AND NomeGrupo				= @NomeGrupo
			   AND NomeCampeonato			= @NomeCampeonato
			   AND NomeFase					= @NomeFase
			   AND Rodada					= @Rodada			  
			  


			-- Inserindo os dados dos pontos dos usuários
			INSERT BoloesMembrosPontos
					(UserName, 
					 NomeBolao, 
					 NomeCampeonato, 
					 NomeFase, 
					 Rodada,
					 NomeGrupo, 
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
					 IsMultiploTime, 
					 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)					 
			SELECT	a.UserName, 
					a.NomeBolao,
					b.NomeCampeonato,
					b.NomeFase,
					b.Rodada,
					b.NomeGrupo,
					ISNULL(SUM(CONVERT(INT, a.Pontos)),0),
					ISNULL(SUM(CONVERT(INT, a.IsEmpate)),0),
					ISNULL(SUM(CONVERT(INT, a.IsVitoria)),0),
					--ISNULL(SUM(CONVERT(INT, a.IsDerrota)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsGanhador)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsPerdedor)),0),
					ISNULL(SUM(CONVERT(INT, a.IsResultTime1)),0),
					ISNULL(SUM(CONVERT(INT, a.IsResultTime2)),0),
					ISNULL(SUM(CONVERT(INT, a.IsVDE)),0),
					ISNULL(SUM(CONVERT(INT, a.IsErro)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsGanhadorFora)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsGanhadorDentro)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsPerdedorFora)),0), 
					ISNULL(SUM(CONVERT(INT, a.IsGolsPerdedorDentro)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsEmpate)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsTime1)),0),
					ISNULL(SUM(CONVERT(INT, a.IsGolsTime2)),0),
					ISNULL(SUM(CONVERT(INT, a.IsPlacarCheio)),0),					
					ISNULL(SUM(CONVERT(INT, a.IsMultiploTime)),0),
					@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0
					--b.IDJogo							
			  FROM JogosUsuarios a
			 INNER JOIN Jogos b
				ON a.NomeCampeonato			= b.NomeCampeonato
			   AND a.IDJogo					= b.IDJogo  
			 WHERE a.UserName				= @UserName
			   AND a.NomeBolao				= @NomeBolao
			   AND b.NomeGrupo				= @NomeGrupo
			   AND b.NomeCampeonato			= @NomeCampeonato
			   AND b.NomeFase				= @NomeFase
			   AND b.Rodada					= @Rodada
			GROUP BY b.NomeCampeonato, b.NomeFase, b.Nomegrupo, b.Rodada, a.NomeBolao, a.UserName
			
			

			---- Atualizando os pontos do usuário calculado pelo jogo
			--UPDATE BoloesMembrosPontos
			--   SET Posicao					= NULL,
			--       LastPosicao				= NULL,
			--       TotalPontos				= @TotalPontos,
			--       TotalEmpate				= @CountEmpate,
			--       TotalVitoria				= @CountVitoria,
			--       TotalGolsGanhador		= @CountGanhador,
			--       TotalGolsPerdedor		= @CountPerdedor,
			--       TotalResultTime1			= @CountTime1,
			--       TotalResultTime2			= @CountTime2,
			--       TotalVDE					= @CountVDE,
			--       TotalErro				= @CountErro,
			--       TotalGolsGanhadorFora	= @CountGanhadorFora,
			--       TotalGolsGanhadorDentro	= @CountGanhadorDentro,
			--       TotalPerdedorFora		= @CountPerdedorFora,
			--       TotalPerdedorDentro		= @CountPerdedorDentro,
			--       totalGolsEmpate			= @CountEmpate_Gols,
			--       TotalGolsTime1			= @CountGolsTime1,
			--       TotalGolsTime2			= @CountGolsTime2,
			--       TotalPlacarCheio			= @CountCheio,
			--       IsMultiploTime			= @IsMultiploTime,
			--       MultiploTime				= @MultiploTime
			-- WHERE UserName					= @UserName
			--   AND NomeBolao				= @NomeBolao
			--   AND NomeGrupo				= @NomeGrupo
			--   AND NomeCampeonato			= @NomeCampeonato
			--   AND NomeFase					= @NomeFase
			--   AND Rodada					= @Rodada
			   






		
			-- Passando para o próximo registro
			FETCH NEXT FROM curJogosUsuarios INTO @NomeBolao, @UserName, @Aposta1, @Aposta2


		END	--registro
		
		
		--IF (@UltimoNomeBolao IS NOT NULL AND LEN(@UltimoNomeBolao) > 0)
		--BEGIN
		--	EXECUTE [sp_BoloesMembrosPontosRodadas_Organize]
		--		@CurrentLogin,
		--		@ApplicationName,
		--		@NomeCampeonato,
		--		@NomeGrupo,
		--		@NomeFase,
		--		@NomeBolao,
		--		@Rodada,
		--		@ErrorNumber OUTPUT,
		--		@ErrorDescription OUTPUT				
		
		--END		
		
		-----------------------------------------------------------
		-- ATUALIZANDO A CLASSIFICACAO DE CADA USUARIO NO BOLAO
		-- Declarando o cursor para buscar todos os boloes para atualização
		DECLARE curBoloes CURSOR FOR
			SELECT	Nome
			  FROM Boloes
			 WHERE NomeCampeonato	= @NomeCampeonato
			 ORDER BY Nome

		-- Abrindo o cursor para carregar os critérios 
		OPEN curBoloes
		-- Executando o cursor
		FETCH NEXT FROM curBoloes INTO @NomeBolao

		-- Enquanto existir registros
		WHILE (@@FETCH_STATUS = 0)
		BEGIN

			EXECUTE [sp_BoloesMembrosPontosRodadas_Organize]
				@CurrentLogin,
				@ApplicationName,
				@NomeCampeonato,
				@NomeGrupo,
				@NomeFase,
				@NomeBolao,
				@Rodada,
				@ErrorNumber OUTPUT,
				@ErrorDescription OUTPUT	

			FETCH NEXT FROM curBoloes INTO @NomeBolao
		END
		-- Fechando o cursor
		CLOSE curBoloes
		-- Desalocando o cursor
		DEALLOCATE curBoloes
		-----------------------------------------------------------
		
		-- Se ainda está ativa a transação
		IF( @TranStarted = 1 )
		BEGIN
			-- Completando a transação
			SET @TranStarted = 0
			COMMIT TRANSACTION
		END		
		
		
		-- Selecionando os registros encontrados
		SELECT * 
		  FROM @UsuariosPontos
		 ORDER BY NomeBolao, UserName
		
		
		-- Fechando o cursor
		CLOSE curJogosUsuarios
		
		-- Desalocando o cursor
		DEALLOCATE curJogosUsuarios
		
		
	
	



 END




GO
