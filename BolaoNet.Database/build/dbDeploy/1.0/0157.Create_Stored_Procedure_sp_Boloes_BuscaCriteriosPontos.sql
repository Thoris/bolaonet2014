IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_BuscaCriteriosPontos')
BEGIN
	DROP  Procedure  sp_Boloes_BuscaCriteriosPontos
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_BuscaCriteriosPontos]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@NomeBolao							varchar(30),
	@PontosEmpate						int OUTPUT,
	@PontosVitoria						int OUTPUT,
	@PontosDerrota						int OUTPUT,
	@PontosGanhador						int OUTPUT,
	@PontosPerdedor						int OUTPUT,
	@PontosTime1						int OUTPUT,
	@PontosTime2						int OUTPUT,
	@PontosVDE							int OUTPUT,
	@PontosErro							int OUTPUT,
	@PontosGanhadorFora					int OUTPUT,
	@PontosGanhadorDentro				int OUTPUT,
	@PontosPerdedorFora					int OUTPUT,
	@PontosPerdedorDentro				int OUTPUT,
	@PontosEmpateGols					int OUTPUT,
	@PontosGolsTime1					int OUTPUT,
	@PontosGolsTime2					int OUTPUT,
	@PontosCheio						int OUTPUT,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT		
)
AS
BEGIN

	DECLARE @ValorPontos			int
	DECLARE @CriterioID				int


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


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
	SET @PontosEmpateGols		= 0
	SET @PontosGolsTime1		= 0
	SET @PontosGolsTime2		= 0
	SET @PontosCheio			= 0


	PRINT 'Buscando os pontos dos critérios.'

	-- Buscando os pontos usados no bolão para cada critério
	DECLARE curCriterios CURSOR FOR
		SELECT a.Pontos, a.CriterioID
		  FROM BoloesCriteriosPontos a
		 WHERE a.NomeBolao		= @NomeBolao
	 
	
	-- Abrindo o cursor para carregar os critérios 
	OPEN curCriterios

	-- Executando o cursor
	FETCH NEXT FROM curCriterios INTO @ValorPontos, @CriterioID

	-- Enquanto existir registro do cursor
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		-- Verificando os pontos dos critérios
		IF(ISNULL(@CriterioID, 0) = 1)		
			SET @PontosEmpate = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 2)	
			SET @PontosVitoria = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 3)	
			SET @PontosDerrota = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 4)	
			SET @PontosGanhador = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 5)	
			SET @PontosPerdedor = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 6)	
			SET @PontosTime1 = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 7)	
			SET @PontosTime2 = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 8)	
			SET @PontosVDE = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 9)	
			SET @PontosErro = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 10)	
			SET @PontosGanhadorFora = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 11)	
			SET @PontosGanhadorDentro = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 12)	
			SET @PontosPerdedorFora = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 13)	
			SET @PontosPerdedorDentro = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 14)	
			SET @PontosEmpateGols = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 15)	
			SET @PontosGolsTime1 = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 16)	
			SET @PontosGolsTime2 = @ValorPontos
		ELSE IF (ISNULL(@CriterioID, 0) = 17)	
			SET @PontosCheio = @ValorPontos


		-- Passando para o próximo registro
		FETCH NEXT FROM curCriterios INTO @ValorPontos, @CriterioID
	END -- Cursor


	PRINT '-------- BOLAO ' + @NomeBolao + ' ---------'
	PRINT 'PONTOS EMPATE: ' + LTRIM(STR(@PontosEmpate))
	PRINT 'PONTOS VITORIA: ' + LTRIM(STR(@PontosVitoria))
	PRINT 'PONTOS DERROTA: ' + LTRIM(STR(@PontosDerrota))
	PRINT 'PONTOS GANHADOR: ' + LTRIM(STR(@PontosGanhador))
	PRINT 'PONTOS PERDEDOR: ' + LTRIM(STR(@PontosPerdedor))
	PRINT 'PONTOS TIME 1: ' + LTRIM(STR(@PontosTime1))
	PRINT 'PONTOS TIME 2: ' + LTRIM(STR(@PontosTime2))
	PRINT 'PONTOS VDE: ' + LTRIM(STR(@PontosVDE))
	PRINT 'PONTOS ERRO: ' + LTRIM(STR(@PontosErro))
	PRINT 'PONTOS GANHADOR FORA: ' + LTRIM(STR(@PontosGanhadorFora))
	PRINT 'PONTOS GANHADOR DENTRO: ' + LTRIM(STR(@PontosGanhadorDentro))
	PRINT 'PONTOS PERDEDOR FORA: ' + LTRIM(STR(@PontosPerdedorFora))
	PRINT 'PONTOS PERDEDOR DENTRO: ' + LTRIM(STR(@PontosPerdedorDentro))
	PRINT 'PONTOS EMPATE GOLS: ' + LTRIM(STR(@PontosEmpateGols))
	PRINT 'PONTOS GOLS TIME 1: ' + LTRIM(STR(@PontosGolsTime1))
	PRINT 'PONTOS GOLS TIME 2: ' + LTRIM(STR(@PontosGolsTime2))
	PRINT 'PONTOS CHEIO: ' + LTRIM(STR(@PontosCheio))
	
	-- Fechando o cursor
	CLOSE curCriterios
	
	-- Desalocando o cursor
	DEALLOCATE curCriterios	 


END






GO
