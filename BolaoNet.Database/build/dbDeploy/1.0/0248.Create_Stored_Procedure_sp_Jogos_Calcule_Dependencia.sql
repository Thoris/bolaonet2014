IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_Calcule_Dependencia')
BEGIN
	DROP  Procedure  sp_Jogos_Calcule_Dependencia
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_Calcule_Dependencia] 
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@IDJogo								bigint,
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(30),
	@NomeTime1							varchar(30),
	@NomeTime2							varchar(30),
	@GolsTime1							smallint,
	@GolsTime2							smallint,
	@PenaltisTime1						smallint,
	@PenaltisTime2						smallint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @PendNomeGanhador		varchar(30)
	DECLARE @PendNomePerdedor		varchar(30)
	DECLARE @NomeTimeToApply		varchar(30)
	 
	 
	DECLARE @Pend1IDJogo			int			-- Variável auxiliar para atribuir o id do jogo analisado
	DECLARE @Pend1Ganhador			bit			-- Variável auxiliar para identificar se deve atribuir o ganhador ou perdedor do jogo

	DECLARE @Pend2IDJogo			int			-- Variável auxiliar para atribuir o id do jogo analisado
	DECLARE @Pend2Ganhador			bit			-- Variável auxiliar para identificar se deve atribuir o ganhador ou perdedor do jogo


	---- Buscando se existe um time a ser analisado
	--SELECT	@Pend1IDJogo	= IDJogo,
	--		@Pend1Ganhador	= PendenteTime1Ganhador
	--  FROM Jogos 
	-- WHERE NomeCampeonato		= @NomeCampeonato
	--   AND PendenteTime1JogoID	= @IDJogo
		
		
	---- Buscando se existe um time a ser analisado
	--SELECT	@Pend2IDJogo	= IDJogo,
	--		@Pend2Ganhador	= PendenteTime2Ganhador
	--  FROM Jogos 
	-- WHERE NomeCampeonato		= @NomeCampeonato
	--   AND PendenteTime2JogoID	= @IDJogo
		

	-- Se o time de casa ganhou
	IF (@GolsTime1 > @GolsTime2)
	BEGIN
		SET @PendNomeGanhador = @NomeTime1
		SET @PendNomePerdedor = @NomeTime2
	END
	--Se o time fora de casa ganhou
	ELSE IF (@GolsTime1 < @GolsTime2)
	BEGIN
		SET @PendNomeGanhador = @NomeTime2
		SET @PendNomePerdedor = @NomeTime1
	END
	ELSE
	BEGIN
		IF (@PenaltisTime1 > @PenaltisTime2)
		BEGIN
			SET @PendNomeGanhador = @NomeTime1
			SET @PendNomePerdedor = @NomeTime2
		END
		ELSE
		BEGIN		
			SET @PendNomeGanhador = @NomeTime2
			SET @PendNomePerdedor = @NomeTime1
		END
	
	END --endif time que ganhou
	




	-- Buscando se existe um time a ser analisado
	DECLARE curJogosTime1 CURSOR FOR
	SELECT	IDJogo, PendenteTime1Ganhador
	  FROM Jogos 
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND PendenteTime1JogoID	= @IDJogo
		
	-- Abrindo o cursor do time 1	
	OPEN curJogosTime1


	-- Executando o cursor
	FETCH NEXT FROM curJogosTime1 INTO @Pend1IDJogo, @Pend1Ganhador

	-- Enquanto existir registros
	WHILE (@@FETCH_STATUS = 0)
	BEGIN



	---- Se tem pendencias para o time 1
	--IF (@Pend1IDJogo IS NOT NULL)
	--BEGIN
		
		PRINT 'Encontrou jogos pendentes para a posição 1 - Jogo: ' + CONVERT(VARCHAR, @Pend1IDJogo) + ' - Campeonato: ' + @NomeCampeonato 
		
		
		IF (@Pend1Ganhador = 1)
			SET @NomeTimeToApply = @PendNomeGanhador
		ELSE
			SET @NomeTimeToApply = @PendNomePerdedor
			
		
		PRINT 'Atualizando o time ' + @NomeTimeToApply
	

		UPDATE Jogos
		   SET NomeTime1			= @NomeTimeToApply
		 WHERE NomeCampeonato		= @NomeCampeonato
		   AND IDJogo				= @Pend1IDJogo

		-- Executando o cursor
		FETCH NEXT FROM curJogosTime1 INTO @Pend1IDJogo, @Pend1Ganhador


		   								
	END --endif pendencias time 1

	CLOSE curJogosTime1
	DEALLOCATE curJogosTime1




	-- Buscando se existe um time a ser analisado
	DECLARE curJogosTime2 CURSOR FOR
	SELECT	IDJogo, PendenteTime1Ganhador
	  FROM Jogos 
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND PendenteTime2JogoID	= @IDJogo
		
	-- Abrindo o cursor do time 2	
	OPEN curJogosTime2


	-- Executando o cursor
	FETCH NEXT FROM curJogosTime2 INTO @Pend2IDJogo, @Pend2Ganhador

	-- Enquanto existir registros
	WHILE (@@FETCH_STATUS = 0)
	BEGIN

	---- Se tem pendencias para o time 2
	--IF (@Pend2IDJogo IS NOT NULL)
	--BEGIN
		PRINT 'Encontrou jogos pendentes para a posição 2 - Jogo: ' + CONVERT(VARCHAR, @Pend2IDJogo) + ' - Campeonato: ' + @NomeCampeonato 
		
		IF (@Pend2Ganhador = 1)
			SET @NomeTimeToApply = @PendNomeGanhador
		ELSE
			SET @NomeTimeToApply = @PendNomePerdedor
		
		PRINT 'Atualizando o time ' + @NomeTimeToApply
	

		UPDATE Jogos
		   SET NomeTime2			= @NomeTimeToApply
		 WHERE NomeCampeonato		= @NomeCampeonato
		   AND IDJogo				= @Pend2IDJogo


		-- Executando o cursor
		FETCH NEXT FROM curJogosTime2 INTO @Pend2IDJogo, @Pend2Ganhador


		   
	END --endif pendencias time 2

	CLOSE curJogosTime2
	DEALLOCATE curJogosTime2




END




GO
