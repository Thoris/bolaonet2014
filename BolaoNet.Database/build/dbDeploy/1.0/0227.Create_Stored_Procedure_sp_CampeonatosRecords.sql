IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosRecords')
BEGIN
	DROP  Procedure  sp_CampeonatosRecords
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosRecords]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@TipoPesquisa						int,
	-- 1 = Quantidade de jogos sem ganhar
	-- 2 = Quantidade de jogos sem perder
	-- 3 = Sequencia de derrotas
	-- 4 = Sequencia de empates
	-- 5 = Sequencia de vitorias
	-- 6 = Record de Quantidade de jogos sem ganhar
	-- 7 = Record de Quantidade de jogos sem perder
	-- 8 = Record de Sequencia de derrotas
	-- 9 = Record de Sequencia de empates
	-- 10 = Record de Sequencia de vitorias	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	DECLARE @General TABLE
		(
			Posicao			int,
			NomeTime		varchar(30),
			Vitoria			int,
			Empate			int,
			Derrota			int
		)
		

	DECLARE @Fora TABLE
		(
			Posicao			int,
			NomeTime		varchar(30),
			Vitoria			int,
			Empate			int,
			Derrota			int
		)		
		

	DECLARE @Casa TABLE
		(
			Posicao			int,
			NomeTime		varchar(30),
			Vitoria			int,
			Empate			int,
			Derrota			int
		)		
		
		
		
	INSERT @General
	SELECT 0, NomeTime, 0, 0, 0
	  FROM CampeonatosTimes
	 WHERE NomeCampeonato		= @NomeCampeonato

	DECLARE @NomeTime				varchar(30)

	DECLARE @MaxEmpate				int
	DECLARE @MaxVitoria				int
	DECLARE @MaxDerrota				int

	DECLARE @MaxEmpateFora			int
	DECLARE @MaxVitoriaFora			int
	DECLARE @MaxDerrotaFora			int

	DECLARE @MaxEmpateDentro		int
	DECLARE @MaxVitoriaDentro		int
	DECLARE @MaxDerrotaDentro		int




	DECLARE curTimes CURSOR FOR
	 SELECT NomeTime
	  FROM @General
	 ORDER BY NomeTime
	 
	OPEN curTimes
	

	FETCH NEXT FROM curTimes INTO @NomeTime


	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		-- 1 = Quantidade de jogos sem ganhar	
		IF (@TipoPesquisa = 1)
		BEGIN
			PRINT 'Quantidade de jogos sem ganhar'

			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSemGanhar]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 0,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT


		
		END
		-- 2 = Quantidade de jogos sem perder		
		ELSE IF (@TipoPesquisa = 2)
		BEGIN
			PRINT 'Quantidade de jogos sem perder'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSemPerder]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 0,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT		
		END	
		-- 3 = Sequencia de derrotas
		ELSE IF (@TipoPesquisa = 3)
		BEGIN
			PRINT 'Sequencia de derrotas'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqDerrotas]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 0,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		
		END
		-- 4 = Sequencia de empates
		ELSE IF (@TipoPesquisa = 4)
		BEGIN
			PRINT 'Sequencia de empates'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqEmpates]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 0,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		END
		-- 5 = Sequencia de vitorias
		ELSE IF (@TipoPesquisa = 5)
		BEGIN
			PRINT 'Sequencia de vitorias'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqVitorias]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 0,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		END		
		-- 6 = Record de Quantidade de jogos sem ganhar
		IF (@TipoPesquisa = 6)
		BEGIN
			PRINT 'Record de Quantidade de jogos sem ganhar'

			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSemGanhar]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 1,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT


		
		END
		-- 7 = Record de Quantidade de jogos sem perder		
		ELSE IF (@TipoPesquisa = 7)
		BEGIN
			PRINT 'Record de Quantidade de jogos sem perder'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSemPerder]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 1,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT		
		END	
		-- 8 = Record Sequencia de derrotas
		ELSE IF (@TipoPesquisa = 8)
		BEGIN
			PRINT 'Record de Sequencia de derrotas'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqDerrotas]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 1,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		
		END
		-- 9 = Record de Sequencia de empates
		ELSE IF (@TipoPesquisa = 9)
		BEGIN
			PRINT 'Record de Sequencia de empates'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqEmpates]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 1,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		END
		-- 10 = Sequencia de vitorias
		ELSE IF (@TipoPesquisa = 10)
		BEGIN
			PRINT 'Record de Sequencia de vitorias'
		
			EXEC	[dbo].[sp_CampeonatosRecordTimeRecordSeqVitorias]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = @ApplicationName,
					@NomeCampeonato = @NomeCampeonato,
					@NomeTime = @NomeTime,
					@GetRecord = 1,
					@Vitorias = @MaxVitoria OUTPUT,
					@Empates = @MaxEmpate OUTPUT,
					@Derrotas = @MaxDerrota OUTPUT,
					@VitoriasCasa = @MaxVitoriadentro OUTPUT,
					@EmpatesCasa = @MaxEmpateDentro OUTPUT,
					@DerrotasCasa = @MaxDerrotaDentro OUTPUT,
					@VitoriasFora = @MaxVitoriaFora OUTPUT,
					@EmpatesFora = @MaxEmpateFora OUTPUT,
					@DerrotasFora = @MaxDerrotaFora OUTPUT,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT			
		END				
		
	
	
		-- Atualizando os dados gerais
		UPDATE @General SET 
			Vitoria			= @MaxVitoria,
			Empate			= @MaxEmpate,
			Derrota			= @MaxDerrota
		 WHERE NomeTime		= @NomeTime
	
	
		-- Inserindo os valores de casa
		INSERT INTO @Casa (Posicao, NomeTime, Vitoria, Empate, Derrota) 
			VALUES	(0,	@NomeTime, @MaxVitoriaDentro, @MaxEmpateDentro, @MaxDerrotaDentro)
			
	
		-- Inserindo os valores de fora de casa
		INSERT INTO @Fora (Posicao, NomeTime, Vitoria, Empate, Derrota) 
			VALUES	(0,	@NomeTime, @MaxVitoriaFora, @MaxEmpateFora, @MaxDerrotaFora)
	
	
	

	
	
		FETCH NEXT FROM curTimes INTO @NomeTime
	END

	CLOSE curTimes
	DEALLOCATE curTimes	 
	
	SELECT * FROM @General Where Vitoria > 0 OR Derrota > 0 OR Empate > 0 ORDER BY Vitoria + Empate + Derrota DESC
	SELECT * FROM @Casa Where Vitoria > 0 OR Derrota > 0 OR Empate > 0 ORDER BY Vitoria + Empate + Derrota DESC
	SELECT * FROM @Fora Where Vitoria > 0 OR Derrota > 0 OR Empate > 0 ORDER BY Vitoria + Empate + Derrota DESC
END



GO
