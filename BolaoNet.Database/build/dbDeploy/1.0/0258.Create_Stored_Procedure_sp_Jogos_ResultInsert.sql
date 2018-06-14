IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_ResultInsert')
BEGIN
	DROP  Procedure  sp_Jogos_ResultInsert
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_ResultInsert]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@IdJogo								bigint,
	@NomeCampeonato						varchar(50),
	@Gols1								smallint,
	@Penaltis1							smallint,
	@Gols2								smallint,
	@Penaltis2							smallint,
	@SetCurrentData						bit = false,
	@ValidadoBy							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @RowCountAffected			int

	DECLARE @CurrentRodada				int
	DECLARE @CurrentFase				varchar(50)
	DECLARE @CurrentGrupo				varchar(20)
	DECLARE @CurrentTime1				varchar(30)
	DECLARE @CurrentTime2				varchar(30)
	
	DECLARE @TimeGanhador				varchar(30)
	DECLARE @TimePerdedor				varchar(30)

	DECLARE @TotalPontos1				int
	DECLARE @TotalVitorias1				int
	DECLARE @TotalDerrotas1				int
	DECLARE @TotalEmpates1				int
	
	DECLARE @TotalPontos2				int
	DECLARE @TotalVitorias2				int
	DECLARE @TotalDerrotas2				int
	DECLARE @TotalEmpates2				int
	
	
	DECLARE @JogoIsAlreadyValid			bit
	
	
	
	
	SET @TotalPontos1		= 0
	SET @TotalVitorias1		= 0
	SET @TotalDerrotas1		= 0
	SET @TotalEmpates1		= 0
	

	SET @TotalPontos2		= 0
	SET @TotalVitorias2		= 0
	SET @TotalDerrotas2		= 0
	SET @TotalEmpates2		= 0
	
	
	
	
	
	

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DECLARE @TranStarted	bit
	SET @TranStarted = 0

	-- Se não tem nenhuma transação corrente
	IF( @@TRANCOUNT = 0 )
	BEGIN
		-- Iniciando a transação
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END	
		
	
	
	--BEGIN TRY


		PRINT 'Carregando os dados do jogo'

		-- Buscando os dados para utiliá-los posteriormente
		SELECT	@CurrentFase		= NomeFase,
				@CurrentRodada		= Rodada,
				@CurrentGrupo		= NomeGrupo,
				@CurrentTime1		= NomeTime1,
				@CurrentTime2		= NomeTime2,
				@JogoIsAlreadyValid	= IsValido
		  FROM Jogos
		 WHERE NomeCampeonato		= @NomeCampeonato
		   AND IDJogo				= @IDJogo
		   
		-- Se não conseguiu encontrar o jogo
		IF (@@ROWCOUNT <> 1)
		BEGIN
			SET @ErrorNumber = 1
			SET @ErrorDescription = 'Não foi encontrado o jogo que está tentando atribuir o resultado'
			
			RETURN 1			
		END --endif encontrou o erro


		

		
		
		-- Se deve atualizar os dados atuais do campeonato
		IF (@SetCurrentData = 1)
		BEGIN
		
			PRINT 'Atualizando dados do campeonato'
		
			-- Atualizando os dados atuais do campeonato
			UPDATE Campeonatos SET
					FaseAtual	= @CurrentFase,
					RodadaAtual	= @CurrentRodada
			 WHERE Nome			= @NomeCampeonato
			   

			-- Se não conseguiu encontrar o Campeonato
			IF (@@ROWCOUNT <> 1)
			BEGIN
				SET @ErrorNumber = 2
				SET @ErrorDescription = 'Não foi encontrado o campeonato que está tentando atribuir o resultado'
				
				RETURN 2			
			END --endif encontrou o erro			   
			   
			   
		END -- endif atualizar dados do campeonato
	

		PRINT 'Atualizando dados do jogo'
		
		-- Atualizando dados do jogo
		UPDATE Jogos SET		
			Gols1						= @Gols1,
			Penaltis1					= @Penaltis1,
			Gols2						= @Gols2,
			Penaltis2					= @Penaltis2,
			IsValido					= 1,
			DataValidacao				= GetDate(),
			ValidadoBy					= @ValidadoBy		
		 WHERE 
				NomeCampeonato			= @NomeCampeonato
		   AND	IDJogo					= @IDJogo
		   
		 SET @RowCountAffected = @@RowCount
		   
		   
		   
		-- Se tem informações suficientes para atualizar a classificacao
		IF (@CurrentFase IS NOT NULL AND
			@CurrentGrupo IS NOT NULL AND 
			@CurrentRodada IS NOT NULL AND
			LEN(LTRIM(@CurrentFase)) > 0 AND
			LEN(LTRIM(@CurrentGrupo)) > 0			
		   )
		BEGIN
		
			PRINT 'Atualizando os dados da classifição do campeonato'
		
		
		   
			IF (NOT EXISTS (SELECT * 
							  FROM CampeonatosClassificacao
							 WHERE NomeCampeonato			= @NomeCampeonato
							   AND NomeFase					= @CurrentFase
							   AND NomeGrupo				= @CurrentGrupo
							   AND NomeTime					= @CurrentTime1
							   AND Rodada					= @CurrentRodada))
			BEGIN
				PRINT 'Inserindo o time ' + @CurrentTime1
				
				
				
				INSERT INTO CampeonatosClassificacao
					(
						NomeCampeonato,
						NomeFase,
						NomeTime,
						NomeGrupo,
						Rodada,
						CreatedBy,
						CreatedDate,
						ModifiedBy,
						ModifiedDate,
						ActiveFlag
					)
					VALUES
					(
						@NomeCampeonato,
						@CurrentFase,
						@CurrentTime1,
						@Currentgrupo,
						@CurrentRodada,
						@CurrentLogin,
						GetDate(),
						@CurrentLogin,
						GetDate(),
						0
					)
				
				
			END  --endif time 1 inserindo
		   
		   

			IF (NOT EXISTS (SELECT * 
							  FROM CampeonatosClassificacao
							 WHERE NomeCampeonato			= @NomeCampeonato
							   AND NomeFase					= @CurrentFase
							   AND NomeGrupo				= @CurrentGrupo
							   AND NomeTime					= @CurrentTime2
							   AND Rodada					= @CurrentRodada))
			BEGIN
				PRINT 'Inserindo o time ' + @CurrentTime2
				
				INSERT INTO CampeonatosClassificacao
					(
						NomeCampeonato,
						NomeFase,
						NomeTime,
						NomeGrupo,
						Rodada,
						CreatedBy,
						CreatedDate,
						ModifiedBy,
						ModifiedDate,
						ActiveFlag
					)
					VALUES
					(
						@NomeCampeonato,
						@CurrentFase,
						@CurrentTime2,
						@Currentgrupo,
						@CurrentRodada,
						@CurrentLogin,
						GetDate(),
						@CurrentLogin,
						GetDate(),
						0
					)
				
				
			END  --endif time 2 inserindo		   		  		   
		END --Endif dados validos para atualizacao
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		   
		-----------------------------------------
		----------- EMPATE
		-----------------------------------------
		IF (@Gols1 = @Gols2)
		BEGIN
			PRINT 'Ocorreu empate no jogo'
			
			
			-- Verificando se teve disputa de penaltis
			IF (@Penaltis1 IS NOT NULL AND @Penaltis2 IS NOT NULL)
			BEGIN
				PRINT 'Teve disputa de penaltis'
				
				
				-- Se o time 1 ganhou nos penaltis
				IF (@Penaltis1 > @Penaltis2)
				BEGIN
					PRINT 'Time 1 ganhou nos penaltis'
					
					SET @TimeGanhador = @CurrentTime1
					SET @TimePerdedor = @CurrentTime2
					
				END
				-- Se o time 2 ganhou nos penaltis
				ELSE
				BEGIN
					PRINT 'Time 2 ganhou nos penaltis'
					
					
					SET @TimeGanhador = @CurrentTime2
					SET @TimePerdedor = @CurrentTime1
					
				END --endif time que ganhou nos penaltis
			
			END
			-- Se nao teve disputa de penaltis
			ELSE
			BEGIN
				PRINT 'Não teve disputa de penaltis'
			
			END -- endif disputa de penaltis
			
			
			SET @TotalPontos1 = 1
			SET @TotalPontos2 = 1
			SET @TotalEmpates1 = 1
			SET @TotalEmpates2 = 1
			
			
		END
		-----------------------------------------
		----------- TIME CASA GANHOU
		-----------------------------------------
		ELSE IF (@Gols1 > @Gols2)
		BEGIN		
			PRINT 'Time 1 ganhou o jogo'
		
			SET @TimeGanhador = @CurrentTime1
			SET @TimePerdedor = @CurrentTime2		


		
			SET @TotalPontos1 = 3
			SET @TotalPontos2 = 0
			SET @TotalVitorias1 = 1
			SET @TotalDerrotas2 = 1
			
			
		END		
		-----------------------------------------
		----------- TIME FORA GANHOU
		-----------------------------------------
		ELSE
		BEGIN
			PRINT 'Time 2 ganhou o jogo'
		
			SET @TimeGanhador = @CurrentTime2
			SET @TimePerdedor = @CurrentTime1
		
		
			SET @TotalPontos1 = 0
			SET @TotalPontos2 = 3
			SET @TotalVitorias2 = 1
			SET @TotalDerrotas1 = 1
			
		
		
		END -- endif o time que ganhou
		
		
		
		
		-- Atualizando os dados da classificação
		UPDATE CampeonatosClassificacao SET
			TotalVitorias		= @TotalVitorias1,
			TotalDerrotas		= @TotalDerrotas1,
			TotalEmpates		= @TotalEmpates1,
			TotalGolsContra		= @Gols2,
			TotalGolsPro		= @Gols1,
			TotalPontos			= @TotalPontos1
		 WHERE NomeCampeonato	= @NomeCampeonato
		   AND NomeFase			= @CurrentFase
		   AND NomeTime			= @CurrentTime1
		   AND NomeGrupo		= @CurrentGrupo
		   AND Rodada			= @CurrentRodada
		
		UPDATE CampeonatosClassificacao SET
			TotalVitorias		= @TotalVitorias2,
			TotalDerrotas		= @TotalDerrotas2,
			TotalEmpates		= @TotalEmpates2,
			TotalGolsContra		= @Gols1,
			TotalGolsPro		= @Gols2,
			TotalPontos			= @TotalPontos2
		 WHERE NomeCampeonato	= @NomeCampeonato
		   AND NomeFase			= @CurrentFase
		   AND NomeTime			= @CurrentTime2
		   AND NomeGrupo		= @CurrentGrupo
		   AND Rodada			= @CurrentRodada
		   
		   
		PRINT 'Atualizando apostas dos bolões'
		
		
		EXEC sp_JogosUsuariosValidacao
			@CurrentLogin,
			@ApplicationName, 
			@IDJogo,
			@NomeCampeonato,
			@CurrentGrupo,
			@CurrentFase,
			@CurrentRodada,
			@CurrentTime1,
			@Gols1,
			@Penaltis1,
			@CurrentTime2,
			@Gols2,
			@Penaltis2,
			@ValidadoBy,
			@ErrorNumber OUTPUT,
			@ErrorDescription OUTPUT
		
		PRINT 'Terminou atualização dos dados do usuário'
		
	
	
	
		-- Se o jogo faz parte de um grupo
		IF (@CurrentGrupo IS NOT NULL)
		BEGIN
		
			PRINT 'Organizando as posições dos times'
			
			EXECUTE [sp_CampeonatosClassificacao_Organize] 
			   @CurrentLogin
			  ,@ApplicationName
			  ,@CurrentRodada
			  ,@CurrentFase
			  ,@NomeCampeonato
			  ,@CurrentGrupo
			  ,@ErrorNumber OUTPUT
			  ,@ErrorDescription OUTPUT			
			
			PRINT 'Terminou atualização das posições dos times'
			

			--------------------------------------------
			------ TERMINOU JOGOS DO GRUPO
			--------------------------------------------
			IF ((SELECT IsNull(Count(*), 0)
				  FROM Jogos
				 WHERE IsValido				= 0
				   AND NomeCampeonato		= @NomeCampeonato
				   AND NomeFase				= @CurrentFase
				   AND NomeGrupo			= @CurrentGrupo) = 0)
			BEGIN
				PRINT 'Terminou os jogos da rodada do grupo'
			
			
				EXEC sp_Jogos_Calcule_Grupo		@CurrentLogin,
												@ApplicationName,
												@NomeCampeonato,
												@CurrentFase,
												@CurrentGrupo,
												@ErrorNumber,
												@ErrorDescription
			
			END --endif terminou jogos do grupo
			
			PRINT 'Terminou atualização do Grupo.'
			
		END -- se o jogo faz parte de um grupo
		
		
		PRINT 'Calculando a Dependência do jogo'
		
		EXEC sp_Jogos_Calcule_Dependencia		@CurrentLogin,
												@ApplicationName,
												@NomeCampeonato,
												@IDJogo,
												@CurrentFase,
												@CurrentGrupo,
												@CurrentTime1,
												@CurrentTime2,
												@Penaltis1,
												@Penaltis2,
												@Gols1,
												@Gols2,
												@ErrorNumber,
												@ErrorDescription
		
		
		
		PRINT 'Terminou o cálculo da dependência'
		
		--------------------------------------------
		------ TERMINOU O CAMPEONATO
		--------------------------------------------
		IF ((SELECT IsNull(Count(*), 0)
			  FROM Jogos
			 WHERE IsValido				= 0
			   AND NomeCampeonato		= @NomeCampeonato) = 0)
		BEGIN
			PRINT 'Terminou o campeonato'
		
		
		
		
		
		END --endif terminou jogos do grupo
		 
		PRINT 'Terminou atualização dos dados.'
		   

		-- Se ainda está ativa a transação
		IF( @TranStarted = 1 )
		BEGIN
			-- Completando a transação
			SET @TranStarted = 0
			COMMIT TRANSACTION
		END
		
	--END TRY
	--BEGIN CATCH


	--	-- Se ainda está ativa a transação
	--	IF( @TranStarted = 1 )
	--	BEGIN
	--		-- Completando a transação
	--		SET @TranStarted = 0
	--		ROLLBACK TRANSACTION
	--	END			   
		   
	--END CATCH
		   
		
			  	
	RETURN @RowCountAffected
	
END




GO
