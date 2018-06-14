IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_ApostasAutomatica')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_ApostasAutomatica
END
GO

CREATE PROCEDURE [sp_JogosUsuarios_ApostasAutomatica]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@TipoAutomatico						int = 0,
	-- 0 - Todos
	-- 1 - Automatico
	-- 2 - Manual
	@TipoAposta							int = 0,
	-- 0 - Todos
	-- 1 - Não Apostados
	-- 2 - Apostados
	@Rodada								int = 0,
	@DataInicial						datetime = null,
	@DataFinal							datetime = null,
	@NomeTime							varchar(30) = null,
	@UserName							varchar(25),
	@GolsTime1							smallint = 0,
	@GolsTime2							smallint = 0,
	@RandomInicial						smallint = 0,
	@RandomFinal						smallint = 0,
	@Randomizado						bit,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	DECLARE @CurIdJogo					bigint
	DECLARE @CurNomeCampeonato			varchar(50)
	DECLARE @CurNomeTime1				varchar(30)
	DECLARE @CurNomeTime2				varchar(30)
	DECLARE @CurDataJogo				datetime
	DECLARE @CurApostaBack1				smallint
	DECLARE @CurApostaBack2				smallint

	DECLARE @ValorTime1					smallint
	DECLARE @ValorTime2					smallint

	
	DECLARE @CurNomeTime				varchar(30)
	
	DECLARE @CurNomeGrupo				varchar(20)
	DECLARE @CurNomeFase				varchar(30)


	DECLARE @NomeCampeonato				varchar(50)


	SELECT @NomeCampeonato = NomeCampeonato FROM Boloes WHERE Nome = @NomeBolao

	
	DECLARE CurJogos									-- Cursor usado para carregar os jogos do campeonato
	  CURSOR FOR
	  SELECT Jogos.IdJogo, Jogos.NomeCampeonato, Jogos.NomeTime1, Jogos.NomeTime2, Jogos.DataJogo,
			JogosUsuarios.ApostaTime1, JogosUsuarios.ApostaTime2, Jogos.Nomegrupo, Jogos.NomeFase
		FROM Jogos 
		LEFT JOIN JogosUsuarios
		  ON Jogos.IdJogo				= JogosUsuarios.IdJogo
		 AND Jogos.NomeCampeonato		= JogosUsuarios.NomeCampeonato
		 AND JogosUsuarios.NomeBolao	= @NomeBolao
		 AND JogosUsuarios.UserName		= @UserName
	   WHERE 
		    Jogos.NomeCampeonato		= @NomeCampeonato
			AND
 	        (
				@TipoAposta = 0
				OR
				(@TipoAposta = 1 AND JogosUsuarios.UserName IS NULL)
				OR
				(@TipoAposta = 2 AND JogosUsuarios.UserName IS NOT NULL)
			)
		 AND
			(
				@TipoAutomatico = 0
				OR
				(@TipoAutomatico = 1 AND JogosUsuarios.Automatico = 1)
				OR 
				(@TipoAutomatico = 2 AND JogosUsuarios.Automatico = 0)
			)	
		 AND 
			(
				@Rodada IS NULL
				OR
				@Rodada = 0
				OR 
				@Rodada = Jogos.Rodada
			)
		 AND 
			(
				@DataInicial IS NULL
				OR
				(@DataInicial IS NOT NULL AND Jogos.DataJogo >= @DataInicial)
			)
		 AND 
			(
				@DataFinal IS NULL
				OR
				(@DataFinal IS NOT NULL AND Jogos.DataJogo <= @DataFinal)
			)
		 AND 
			(
				@NomeTime IS NULL
				OR 
				(@NomeTime IS NOT NULL AND Jogos.NomeTime1 = @NomeTime)
				OR
				(@NomeTime IS NOT NULL AND Jogos.NomeTime2 = @NomeTime)
				
			)
		 AND 
			(
			IsValido <> 1
			)

	DECLARE @Jogos  Table	
	(
		IDJogo			int,
		NomeCampeonato	varchar(30),
		NomeTime1		varchar(30),
		ApostaTime1		smallint,
		NomeTime2		varchar(30),
		ApostaTime2		smallint,
		DataJogo		datetime,
		ApostaBack1		smallint,
		ApostaBack2		smallint,
		NomeGrupo		varchar(25),
		NomeFase		varchar(30)		
	)
	
	
	
	
	

	
		
		-- Abrindo o cursor para analisar os jogos
		OPEN curJogos
		FETCH NEXT FROM CurJogos INTO @CurIdJogo, @CurNomeCampeonato, @CurNomeTime1, @CurNomeTime2, @CurDataJogo,
		                              @CurApostaBack1, @CurApostaBack2, @CurNomeGrupo, @CurNomeFase


		--Iniciando laço
		WHILE @@FETCH_STATUS = 0
		BEGIN
		
			SET @ValorTime1 = @GolsTime1
			SET @ValorTime2	= @GolsTime2
		
		
			-- Se deve randomizar o resultado
			IF (@Randomizado <> 0)
			BEGIN
				
				-- Calculando os valores dos jogos
				SET @ValorTime1 = CEILING (RAND() * (@RandomFinal - @RandomInicial  + 1)) + @RandomInicial - 1
				SET @ValorTime2 = CEILING (RAND() * (@RandomFinal - @RandomInicial + 1)) + @RandomInicial - 1
				
				
			END	--endif randomizado		
		
		
			-- Inserindo na lista o jogo encontrado
			INSERT INTO @Jogos
				(
					IDJogo,
					NomeCampeonato,
					NomeTime1,
					ApostaTime1,
					NomeTime2,
					ApostaTime2,
					DataJogo,
					ApostaBack1,
					ApostaBack2,
					NomeGrupo,
					NomeFase
				)
			  VALUES
				(
					@CurIdJogo,
					@CurNomeCampeonato,
					@CurNomeTime1,
					@ValorTime1,
					@CurNomeTime2,
					@ValorTime2,
					@CurDataJogo,
					@CurApostaBack1,
					@CurApostaBack2,
					@CurNomegrupo,
					@CurNomeFase
				)
		
			-- Se não existir o jogo
			IF (NOT EXISTS (SELECT *
							  FROM JogosUsuarios
							 WHERE NomeCampeonato	= @CurNomeCampeonato
							   AND NomeBolao		= @NomeBolao
							   AND UserName			= @UserName
							   AND IdJogo			= @CurIDJogo
							)
				)
			BEGIN
			
				PRINT 'Inserindo a aposta : [' + @CurNomeTime1 + ' ' + CONVERT(VARCHAR, @ValorTime1) + ' x ' + CONVERT(VARCHAR, @ValorTime2) + ' ' + @CurNomeTime2 + ']' 
			
			
				INSERT INTO JogosUsuarios
					(
						IDJogo,
						NomeCampeonato,
						UserName,
						NomeBolao,
						DataAposta,
						Automatico,
						ApostaTime1,
						ApostaTime2,
						Pontos,
						Valido,
						CreatedBy,
						CreatedDate,
						ModifiedBy,
						ModifiedDate,
						ActiveFlag
					)
					VALUES
					(
						@CurIDJogo,
						@CurNomeCampeonato,
						@UserName,
						@NomeBolao,
						Getdate(),
						1,
						@ValorTime1,
						@ValorTime2,
						0,
						0,
						@CurrentLogin,
						GetDate(),
						@CurrentLogin,
						GetDate(),
						0
					)
			
			
			END
			-- Se existir o jogo
			ELSE
			BEGIN
			
				PRINT 'Atualizando a aposta : [' + @CurNomeTime1 + ' ' + CONVERT(VARCHAR, @ValorTime1) + ' x ' + CONVERT(VARCHAR, @ValorTime2) + ' ' + @CurNomeTime2 + ']' 
			
			
			
				UPDATE JogosUsuarios SET
						DataAposta			= GetDate(),
						Automatico			= 1,
						ApostaTime1			= @ValorTime1,
						ApostaTime2			= @ValorTime2,
						Pontos				= 0,
						Valido				= 0,
						CreatedBy			= @CurrentLogin,
						CreatedDate			= GetDate(),
						ModifiedBy			= @CurrentLogin,
						ModifiedDate		= Getdate(),
						ActiveFlag			= 0
				 WHERE 	IDJogo				= @CurIDJogo
				   AND	NomeCampeonato		= @CurNomeCampeonato	
				   AND	UserName			= @Username
				   AND	NomeBolao			= @NomeBolao
						
			
			
			
			END --endif existe o jogo



			--Próxima linha do cursor
			FETCH NEXT FROM CurJogos INTO @CurIdJogo, @CurNomeCampeonato, @CurNomeTime1, @CurNomeTime2, @CurDataJogo, 
			                              @CurApostaBack1, @CurApostaBack2, @CurNomeGrupo, @CurNomeFase
		END


		CLOSE curJogos
		DEALLOCATE curJogos







	-- Declarando o cursor para analisar todos os times
	DECLARE curTimes Cursor FOR
		SELECT NomeCampeonato, IDJogo, NomeFase, NomeGrupo, NomeTime1, NomeTime2, ApostaTime1, ApostaTime2
		  FROM @Jogos
		  
		 
		 

	-- Abrindo o cursor
	OPEN curTimes

	-- Atribuindo o registro inicial
	FETCH NEXT FROM curTimes INTO @CurNomeCampeonato, @CurIDJogo, @CurNomeFase, @CurNomeGrupo, @CurNomeTime1, @CurNomeTime2, @ValorTime1, @ValorTime2


	DECLARE @NomeTimeResult1	varchar(30)
	DECLARE @NomeTimeResult2	varchar(30)


	-- enquanto existir registros a serem analisados
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@ApplicationName,
			@CurNomeCampeonato,
			@CurIDJogo,
			@NomeBolao,
			@UserName,
			@CurNomeTime1,
			@CurNomeFase,
			@CurNomeGrupo,
			@ErrorNumber,
			@ErrorDescription	
	
	
		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@ApplicationName,
			@CurNomeCampeonato,
			@CurIDJogo,
			@NomeBolao,
			@UserName,
			@CurNomeTime2,
			@CurNomeFase,
			@CurNomeGrupo,
			@ErrorNumber,
			@ErrorDescription	
	
	
	
	
		
		

		PRINT 'Calculando pendencias do jogo '
		
		-- Buscando o time que gerou a dependência
		SELECT @NomeTimeResult1 = NomeTimeResult1, @NomeTimeResult2 = NomeTimeResult2
		  FROM JogosUsuarios
		 WHERE NomeCampeonato	= @CurNomeCampeonato
		   AND IDJogo			= @CurIdJogo
		   AND UserName			= @UserName
		   
		
		-- Se não encontrou valor para a dependencia
		IF (@NomeTimeResult1 IS NULL)
			SET @NomeTimeResult1 = @CurNomeTime1
			
		-- Se não encontrou valor para a dependencia	
		IF (@NomeTimeResult2 IS NULL)
			SET @NomeTimeResult2 = @CurNomeTime2
			
			
		-- Calculando a dependencia do jogo
		EXEC sp_JogosUsuarios_Calcule_Dependencia		@CurrentLogin,
														@ApplicationName,
														@CurNomeCampeonato,
														@CurIdJogo,
														@NomeBolao,
														@UserName,
														@CurNomeFase,
														@CurNomeGrupo,
														@NomeTimeResult1,
														@NomeTimeResult2,
														@ValorTime1,
														@ValorTime2,
														null,
														@ErrorNumber,
														@ErrorDescription



		EXEC sp_JogosUsuarios_Calcule_Final				@CurrentLogin,
														@ApplicationName,
														@CurNomeCampeonato,
														@CurIdJogo,
														@NomeBolao,
														@UserName,
														@CurNomeFase,
														@CurNomeGrupo,
														@NomeTimeResult1,
														@NomeTimeResult2,
														@ValorTime1,
														@ValorTime2,
														null,
														@ErrorNumber,
														@ErrorDescription



	
		----------------------------------------------------

		-- Movendo para o próximo registro
		FETCH NEXT FROM curTimes INTO @CurNomeCampeonato, @CurIDJogo, @CurNomeFase, @CurNomeGrupo, @CurNomeTime1, @CurNomeTime2, @ValorTime1, @ValorTime2
	END	

	CLOSE curTimes
	DEALLOCATE curTimes	
	
	
	
	
	
	SELECT * FROM @Jogos
	
	
END


GO
