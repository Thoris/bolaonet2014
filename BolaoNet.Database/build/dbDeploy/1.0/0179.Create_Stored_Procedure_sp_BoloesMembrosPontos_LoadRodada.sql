IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosPontos_LoadRodada')
BEGIN
	DROP  Procedure  sp_BoloesMembrosPontos_LoadRodada
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosPontos_LoadRodada]
(
    @CurrentLogin						varchar(25),
    @ApplicationName					nvarchar(256) = null,
	@Rodada								int,
    @NomeFase							varchar(30), 
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(20),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	






	DECLARE @Classificacao  Table
		(
			Posicao					int,
			UserName				varchar(25),
			TotalPontos				int
			--TotalEmpate				int,
			--TotalVitoria			int,
			--TotalGolsGanhador		int,
			--TotalGolsPerdedor		int,
			--TotalResultTime1		int,
			--TotalResultTime2		int,
			--TotalVDE				int,
			--TotalErro				int,
			--TotalGolsGanhadorFora	int,
			--TotalGolsGanhadorDentro	int,
			--TotalPerdedorFora		int,
			--TotalPerdedorDentro		int,
			--TotalGolsEmpate			int,
			--TotalGolsTime1			int,
			--TotalGolsTime2			int,
			--TotalPlacarCheio		int
		)
		
		

	SELECT IDENTITY(INT, 1,1) AS Row, 
			UserName,
			Sum(TotalPontos)				as TotalPontos			
  	  INTO #TMP
	  FROM BoloesMembrosPontos
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @NomeFase
	   AND NomeGrupo		= @NomeGrupo
	   AND NomeBolao		= @NomeBolao
	   AND Rodada			<= @Rodada
	 GROUP BY NomeCampeonato, NomeFase, NomeGrupo, NomeBolao, UserName
	 ORDER BY SUM(TotalPontos) DESC


	DECLARE curClassificacao CURSOR FOR
	 SELECT	Row, UserName, SUM(TotalPontos)
	   FROM #TMP
	 ORDER BY SUM(TotalPontos) DESC	 
		
		
		
		
		
		
		
		
		
		
		
		
		

	--DECLARE curClassificacao CURSOR FOR
	--SELECT ROW_NUMBER() OVER(ORDER BY SUM(TotalPontos) DESC),
	--		UserName,
	--		Sum(TotalPontos)				as TotalPontos
	--		--Sum(TotalEmpate)				as TotalEmpate,
	--		--Sum(TotalVitoria)				as TotalVitoria,
	--		--Sum(TotalGolsGanhador)			as TotalGolsGanhador
	--		--Sum(TotalGolsPerdedor)			as TotalGolsPerdedor
	--		--Sum(TotalResultTime1)			as TotalResultTime1
	--		--Sum(TotalResultTime2)			as TotalResultTime2
	--		--Sum(TotalVDE)					as TotalVDE
	--		--Sum(TotalErro)					as TotalErro
	--		--Sum(TotalGolsGanhadorFora)		as TotalGolsGanhadorFora
	--		--Sum(TotalGolsGanhadorDentro)	as TotalGolsGanhadorDentro
	--		--Sum(TotalPerdedorFora)			as TotalPerdedorFora
	--		--Sum(TotalPerdedorDentro)		as TotalPerdedorDentro
	--		--Sum(TotalGolsEmpate)			as TotalGolsEmpate
	--		--Sum(TotalGolsTime1)				as TotalGolsTime1
	--		--Sum(TotalGolsTime2)				as TotalGolsTime2
	--		--Sum(TotalPlacarCheio)			as TotalPlacarCheio
	--  FROM BoloesMembrosPontos
	-- WHERE NomeCampeonato	= @NomeCampeonato
	--   AND NomeFase			= @NomeFase
	--   AND NomeGrupo		= @NomeGrupo
	--   AND NomeBolao		= @NomeBolao
	--   AND Rodada			<= @Rodada
	-- GROUP BY NomeCampeonato, NomeFase, NomeGrupo, NomeBolao, UserName
	-- ORDER BY SUM(TotalPontos) DESC



	DECLARE @UserName				varchar(25)
	DECLARE @Posicao				int
	DECLARE @TotalPontos			int

	DECLARE @LastTotalPontos		int
	DECLARE @LastPosicao			int
	
	SET @LastTotalPontos	= 0
	SET @LastPosicao		= 0


	OPEN curClassificacao
	FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos


	WHILE @@FETCH_STATUS = 0
	BEGIN



		IF (@LastTotalPontos	= @TotalPontos)
		BEGIN

			SET @Posicao = @LastPosicao

		END


		INSERT INTO @Classificacao
			(			
			Posicao					,
			UserName				,
			TotalPontos				
			)
			VALUES
			(
			@Posicao,
			@UserName,
			@TotalPontos
			)

		SET @LastPosicao			= @Posicao
		SET @LastTotalPontos		= @TotalPontos
		

		

		FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos




		


	END --while



	CLOSE curClassificacao
	DEALLOCATE curClassificacao


	DROP TABLE #TMP



	SELECT * FROM @Classificacao




	RETURN 0

END





GO
