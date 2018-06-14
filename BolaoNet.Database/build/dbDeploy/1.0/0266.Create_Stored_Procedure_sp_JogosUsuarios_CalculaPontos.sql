IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_CalculaPontos')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_CalculaPontos
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_CalculaPontos]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	
	@Gols1								smallint,
	@Gols2								smallint,
	
	@Aposta1							smallint,
	@Aposta2							smallint,
	
	@PontosEmpate						int ,
	@PontosVitoria						int ,
	@PontosDerrota						int ,
	@PontosGanhador						int ,
	@PontosPerdedor						int ,
	@PontosTime1						int ,
	@PontosTime2						int ,
	@PontosVDE							int ,
	@PontosErro							int ,
	@PontosGanhadorFora					int ,
	@PontosGanhadorDentro				int ,
	@PontosPerdedorFora					int ,
	@PontosPerdedorDentro				int ,
	@PontosEmpateGols					int ,
	@PontosGolsTime1					int ,
	@PontosGolsTime2					int ,
	@PontosCheio						int ,
	
	
	@IsMultiploTime						bit,
	@MultiploTime						int,
	
	@PontosTime1Total					int OUTPUT,
	@PontosTime2Total					int OUTPUT,
	@PontosTotal						int OUTPUT,
		
	@CountEmpate						bit OUTPUT,
	@CountVitoria						bit OUTPUT,
	@CountDerrota						bit OUTPUT,
	@CountGanhador						bit OUTPUT,
	@CountPerdedor						bit OUTPUT,
	@CountTime1							bit	OUTPUT,
	@CountTime2							bit	OUTPUT,
	@CountVDE							bit OUTPUT,
	@CountErro							bit OUTPUT,
	@CountGanhadorFora					bit OUTPUT,
	@CountGanhadorDentro				bit OUTPUT,
	@CountPerdedorFora					bit OUTPUT,
	@CountPerdedorDentro				bit OUTPUT,
	@CountEmpateGols					bit OUTPUT,
	@CountGolsTime1						bit OUTPUT,
	@CountGolsTime2						bit OUTPUT,
	@CountCheio							bit OUTPUT,
	
	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SET @PontosTime1Total		= 0
	SET @PontosTime2Total		= 0
	SET @PontosTotal			= 0
		
	SET @CountEmpate			= 0		-- Se o usuário apostou empate e o jogo deu empate
	SET @CountVitoria			= 0		-- Se o usuário apostou vitória para o time e deu vitória para o time selecionado
	SET @CountDerrota			= 0		-- Se o usuário apostou derrota para o time e deu derrota para o time selecionado
	SET @CountGanhador			= 0		-- Se acertou o time ganhador, idependente se está jogando em casa ou fora
	SET @CountPerdedor			= 0		-- Se acertou o time perdedor, idependente se está jogando em casa ou fora
	SET @CountTime1				= 0		-- Se acertou a quantidade de gols do time 1 
	SET @CountTime2				= 0		-- Se acertou a quantidade de gols do time 2
	SET @CountVDE				= 0		-- Se acertou se deu empate/derrota ou vitória no jogo
	SET @CountErro				= 0		-- Se errou o jogo
	SET @CountGanhadorFora		= 0		-- Se acertou que o time foi ganhador jogando fora de casa
	SET @CountGanhadorDentro	= 0		-- Se acertou que o time foi ganhador dentro de casa
	SET @CountPerdedorFora		= 0		-- Se acertou que o time foi perdedor fora de casa
	SET @CountPerdedorDentro	= 0		-- Se acertou que o time foi perdedor dentro de casa
	SET @CountEmpateGols		= 0		-- Se acertou a quantidade de gols quando ocorrer empate
	SET @CountGolsTime1			= 0		-- Se acertou a quantidade de gols do time 1
	SET @CountGolsTime2			= 0		-- Se acertou a quantidade de gols do time 2
	SET @CountCheio				= 0		-- Se acertou em cheio o resultado





	-------------------------------------------------------
	-- PARTE 1 : Verificando o resultado do jogo
	-- Se ocorreu empate
	IF (@Gols1 = @Gols2)
	BEGIN
		PRINT 'JOGO: EMPATE'
		
		-- Calculando os pontos do time
		--SET @PontosTime1Total = 1
		--SET @PontosTime2Total = 1
		
		-- Se o usuário apostou empate
		IF (@Aposta1 = @Aposta2)
		BEGIN
			PRINT 'Usuário acertou o empate'
				
			SET @CountEmpate = 1
			SET @CountVDE = 1		
		
			
			-- Se acertou o resultado do ganhador
			IF (@Aposta1 = @Gols1)
			BEGIN
				PRINT 'Usuário acertou placar empate Time 1'
				
				SET @CountGanhador = 1
				--SET @CountEmpate = 1
				
				SET @CountTime1 = 1
				SET @CountEmpateGols = 1
			
			--END -- ganhador
			
			-- Se acertou o resultado do perdedor
			--IF (@VLR_USER_2 = @VLR_TIME_2)
			--BEGIN
				PRINT 'Usuário acertou placar empate Time 2'
				
				SET @CountPerdedor = 1				
				SET @CountTime2 = 1
				
				SET @CountCheio = 1
			
			END -- perdedor
			
		END -- aposta empate
		-- Se errou a aposta
		ELSE
		BEGIN
			PRINT 'Usuário Errou a aposta'
			
			SET @CountErro = 1
			
		END -- erro aposta
		
	END -- empate
	-- Se ocorreu vitória do time 1
	ELSE IF (@Gols1 > @Gols2)
	BEGIN
		PRINT 'JOGO: TIME 1 GANHOU'

		-- Calculando os pontos do time
		--SET @PontosTime1Total = 3
		
		
		-- Se o usuário apostou que o time de casa ganha
		IF (@Aposta1 > @Aposta2)
		BEGIN
			PRINT 'Usuário aposta vitória casa'
			
			
			SET @CountVitoria = 1
			SET @CountDerrota = 1
			SET @CountVDE = 1			
			
			-- Se acertou o placar em cheio
			IF (@Aposta1 = @Gols1 AND @Aposta2 = @Gols2)
			BEGIN
				PRINT 'Acertou o placar em cheio'
				
				SET @CountCheio = 1
				SET @CountGanhadorDentro = 1
				SET @CountPerdedorFora = 1
			END
			
				
			
			-- Se acertou o resultado do ganhador
			IF (@Aposta1 = @Gols1)
			BEGIN
				PRINT 'Usuário acertou placar ganhador do time dentro de casa'
				
				SET @CountGanhador = 1								
				SET @CountTime1 = 1
			
			END -- ganhador
			
			-- Se acertou o resultado do perdedor
			IF (@Aposta2 = @Gols2)
			BEGIN
				PRINT 'Usuário acertou placar perdedor do time fora de casa'
				
				SET @CountPerdedor = 1								
				SET @CountTime2 = 1
						
			END -- perdedor
			
			
			
			
			
		END -- aposta time 1 ganhou
		-- Se errou a aposta
		ELSE
		BEGIN
			PRINT 'Usuário Errou a aposta'
			
			SET @CountErro = 1
			
		END -- erro aposta

	END -- time 1 ganhador
	-- Se ocorreu derrota do time 1
	ELSE IF (@Gols1 < @Gols2)
	BEGIN
		PRINT 'JOGO: TIME 1 PERDEU'
		
		-- Calculando os pontos do time
		--SET @PontosTime2Total = 3
		
		-- Se o usuário apostou que o time de fora ganha
		IF (@Aposta1 < @Aposta2)
		BEGIN
			PRINT 'Usuário aposta fora casa'
			
			
			SET @CountVitoria = 1
			SET @CountDerrota = 1
			SET @CountVDE = 1				
			
			-- Se acertou o placar em cheio
			IF (@Aposta1 = @Gols1 AND @Aposta2 = @Gols2)
			BEGIN
				PRINT 'Acertou o placar em cheio'
				
				SET @CountCheio = 1
				SET @CountGanhadorFora = 1
				SET @CountPerdedorDentro = 1				
			END			
			
			
			-- Se acertou o resultado do ganhador
			IF (@Aposta2 = @Gols2)
			BEGIN
				PRINT 'Usuário acertou placar ganhador do time fora de casa'
				
				SET @CountGanhador = 1								
				SET @CountTime2 = 1
			
			END -- ganhador
			
			-- Se acertou o resultado do perdedor
			IF (@Aposta1 = @Gols1)
			BEGIN
				PRINT 'Usuário acertou placar perdedor do time dentro de casa'
				
				SET @CountPerdedor = 1				
				SET @CountTime1 = 1
			
			END -- perdedor
			
			
			
		END -- aposta time 2 ganhador
		-- Se errou a aposta
		ELSE
		BEGIN
			PRINT 'Usuário Errou a aposta'
			
			SET @CountErro = 1
			
		END -- erro aposta
		
	END -- time 2 ganhador
	-------------------------------------------------------
	
	-------------------------------------------------------
	---- PARTE 2 : Verificando a quantidade de gols do time casa/fora
	---- Se acertou a quantidade de gols do time 1
	--IF (@VLR_TIME_1 = @VLR_USER_1)
	--BEGIN
	--	PRINT 'Usuário acertou o Placar do time 1'
		
	--	SET @CountTime1 = 1
	--END

	---- Se acertou a quantidade de gols do time 2
	--IF (@VLR_TIME_2 = @VLR_USER_2)
	--BEGIN
	--	PRINT 'Usuário acertou o Placar do time 2'
		
	--	SET @CountTime2 = 1
	--END
	-------------------------------------------------------
	
	-- Se o usuário acertou a quantidade de gols
	IF (@Gols1 = @Aposta1)
	BEGIN
	
		PRINT 'Usuário acertou a quantidade de gols do time de casa'
		
		SET @CountGolsTime1 = 1
	END


	-- Se o usuário acertou a quantidade de gols
	IF (@Gols2 = @Aposta2)
	BEGIN
	
		PRINT 'Usuário acertou a quantidade de gols do time fora de casa'
		
		SET @CountGolsTime2 = 1
	END	
	
	
	
	
	
	
	
	-- Calculando o total de pontos do usuário
	SET @PontosTotal = @CountEmpate * @PontosEmpate + 
						@CountVitoria * @PontosVitoria +
						@CountDerrota * @PontosDerrota + 
						@CountGanhador * @PontosGanhador + 
						@CountPerdedor * @PontosPerdedor + 
						@CountTime1 * @PontosTime1 +
						@CountTime2 * @PontosTime2 + 
						@CountVDE * @PontosVDE +
						@CountErro * @PontosErro + 
						@CountGanhadorFora * @PontosGanhadorFora + 
						@CountGanhadorDentro * @PontosGanhadorDentro + 
						@CountPerdedorFora * @PontosPerdedorFora + 
						@CountPerdedorDentro * @PontosPerdedorDentro + 
						@CountEmpateGols * @PontosEmpateGols + 
						@CountGolsTime1 * @PontosGolsTime1 + 
						@CountGolsTime2 * @PontosGolsTime2 + 
						@CountCheio * @PontosCheio


	IF (@IsMultiploTime = 1)
		SET @PontosTotal = @PontosTotal * ISNULL(@MultiploTime, 1)



	--PRINT 'COUNT EMPATE: ' + LTRIM(STR(@CountEmpate * @PontosEmpate))
	--PRINT 'COUNT VITORIA: ' + LTRIM(STR(@CountVitoria * @PontosVitoria))
	--PRINT 'COUNT DERROTA: ' + LTRIM(STR(@CountDerrota * @PontosDerrota))
	--PRINT 'COUNT GANHADOR: ' + LTRIM(STR(@CountGanhador * @PontosGanhador))
	--PRINT 'COUNT PERDEDOR: ' + LTRIM(STR(@CountPerdedor * @PontosPerdedor))
	--PRINT 'COUNT TIME 1: ' + LTRIM(STR(@CountTime1 * @PontosTime1))
	--PRINT 'COUNT TIME 2: ' + LTRIM(STR(@CountTime2 * @PontosTime2))
	--PRINT 'COUNT VDE: ' + LTRIM(STR(@CountVDE * @PontosVDE))
	--PRINT 'COUNT ERRO: ' + LTRIM(STR(@CountErro * @PontosErro))
	--PRINT 'COUNT GANHADOR FORA: ' + LTRIM(STR(@CountGanhadorFora * @PontosGanhadorFora))
	--PRINT 'COUNT GANHADOR DENTRO: ' + LTRIM(STR(@CountGanhadorDentro * @PontosGanhadorDentro))
	--PRINT 'COUNT PERDEDOR FORA: ' + LTRIM(STR(@CountPerdedorFora * @PontosPerdedorFora))
	--PRINT 'COUNT PERDEDOR DENTRO: ' + LTRIM(STR(@CountPerdedorDentro * @PontosPerdedorDentro))
	--PRINT 'COUNT EMPATE GOLS: ' + LTRIM(STR(@CountEmpateGols * @PontosEmpateGols))
	--PRINT 'COUNT GOLS TIME 1: ' + LTRIM(STR(@CountGolsTime1 * @PontosGolsTime1))
	--PRINT 'COUNT GOLS TIME 2: ' + LTRIM(STR(@CountGolsTime2 * @PontosGolsTime2))
	--PRINT 'COUNT CHEIO: ' + LTRIM(STR(@CountCheio * @PontosCheio))


	PRINT 'Pontos do usuário: ' + LTRIM(Str(@PontosTotal))
	



END




GO
