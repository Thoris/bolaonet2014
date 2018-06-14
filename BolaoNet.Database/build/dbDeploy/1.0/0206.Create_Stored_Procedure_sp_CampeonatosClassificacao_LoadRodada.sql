IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosClassificacao_LoadRodada')
BEGIN
	DROP  Procedure  sp_CampeonatosClassificacao_LoadRodada
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosClassificacao_LoadRodada]
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






	DECLARE @Classificacao  Table
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

	--DECLARE curClassificacao CURSOR FOR
	--SELECT ROW_NUMBER() OVER(ORDER BY SUM(TotalPontos) DESC, SUM(TotalVitorias) DESC,
	--						 SUM(TotalGolsPro - TotalGolsContra) DESC, SUM(TotalGolsPro) DESC),
	--		NomeTime as NomeTime,
	--		Sum(TotalPontos) as TotalPontos,
	--		Sum(TotalVitorias) as TotalVitorias, 
	--		Sum(TotalEmpates) as TotalEmpates, 
	--		Sum(TotalDerrotas) as TotalDerrotas,
	--		Sum(TotalGolsPro) as TotalGolsPro, 
	--		Sum(TotalGolsContra) as TotalGolsContra,
	--		Sum(TotalGolsPro - TotalGolsContra) as Saldo
	--  FROM CampeonatosClassificacao
	-- WHERE NomeCampeonato	= @NomeCampeonato
	--   AND NomeFase			= @CurrentNomeFase
	--   AND NomeGrupo		= @CurrentNomeGrupo
	--   AND Rodada			<= @CurrentRodada
	-- GROUP BY NomeCampeonato, NomeFase, NomeGrupo, NomeTime
	-- ORDER BY SUM(TotalPontos) DESC, SUM(TotalVitorias) DESC, 
	--		  SUM(TotalGolsPro - TotalGolsContra) DESC, SUM(TotalGolsPro) DESC
			  
				  
	CREATE TABLE #TMP
	(
		Row				[int] IDENTITY(1,1),
		NomeTime		varchar(30),
		TotalPontos		int,
		TotalVitorias	int,
		TotalEmpates	int,
		TotalDerrotas	int,
		TotalGolsPro	int,
		TotalGolsContra	int,
		Saldo			int
	)			  
			  


	INSERT #TMP (NomeTime, TotalPontos,TotalVItorias, TotalEmpates, TotalDerrotas,TotalGolsPro, TOtalGolsContra, Saldo)
	SELECT 	NomeTime as NomeTime,
			Sum(TotalPontos) as TotalPontos,
			Sum(TotalVitorias) as TotalVitorias, 
			Sum(TotalEmpates) as TotalEmpates, 
			Sum(TotalDerrotas) as TotalDerrotas,
			Sum(TotalGolsPro) as TotalGolsPro, 
			Sum(TotalGolsContra) as TotalGolsContra,
			Sum(TotalGolsPro - TotalGolsContra) as Saldo			
	  FROM CampeonatosClassificacao
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @CurrentNomeFase
	   AND NomeGrupo		= @CurrentNomeGrupo
	   AND Rodada			<= @CurrentRodada
	 GROUP BY NomeCampeonato, NomeFase, NomeGrupo, NomeTime
	 ORDER BY SUM(TotalPontos) DESC, SUM(TotalVitorias) DESC, 
			  SUM(TotalGolsPro - TotalGolsContra) DESC, SUM(TotalGolsPro) DESC







			  

	--SELECT IDENTITY(INT, 1,1) AS Row, 
	--		NomeTime as NomeTime,
	--		Sum(TotalPontos) as TotalPontos,
	--		Sum(TotalVitorias) as TotalVitorias, 
	--		Sum(TotalEmpates) as TotalEmpates, 
	--		Sum(TotalDerrotas) as TotalDerrotas,
	--		Sum(TotalGolsPro) as TotalGolsPro, 
	--		Sum(TotalGolsContra) as TotalGolsContra,
	--		Sum(TotalGolsPro - TotalGolsContra) as Saldo	
	--INTO #TMP
	--  FROM CampeonatosClassificacao
	-- WHERE NomeCampeonato	= @NomeCampeonato
	--   AND NomeFase			= @CurrentNomeFase
	--   AND NomeGrupo		= @CurrentNomeGrupo
	--   AND Rodada			<= @CurrentRodada
	-- GROUP BY NomeCampeonato, NomeFase, NomeGrupo, NomeTime
	-- ORDER BY SUM(TotalPontos) DESC, SUM(TotalVitorias) DESC, 
	--		  SUM(TotalGolsPro - TotalGolsContra) DESC, SUM(TotalGolsPro) DESC
	 			  
			  
	DECLARE curClassificacao CURSOR FOR
	 SELECT * FROM #TMP ORDER BY TotalPontos DESC, TotalVitorias DESC, TotalEmpates DESC, Saldo DESC
	 		  
			  
			  
			  
			  



	DECLARE @NomeTime				varchar(30)
	DECLARE @Posicao				int
	DECLARE @TotalPontos			int
	DECLARE @TotalVitorias			int
	DECLARE @TotalEmpates			int
	DECLARE @TotalDerrotas			int
	DECLARE @TotalGolsPro			int
	DECLARE @TotalGolsContra		int
	DECLARE @Saldo					int

	DECLARE @LastPosicao			int
	DECLARE @LastTotalPontos		int
	DECLARE @LastTotalVitorias		int
	DECLARE @LastTotalEmpates		int
	DECLARE @LastTotalDerrotas		int
	DECLARE @LastTotalGolsPro		int
	DECLARE @LastTotalGolsContra	int
	DECLARE @LastSaldo				int



	OPEN curClassificacao
	FETCH curClassificacao INTO @Posicao, @NomeTime, @TotalPontos, @TotalVitorias, 
								@TotalEmpates, @TotalDerrotas, @TotalGolsPro, @TotalGolsContra, @Saldo



	WHILE @@FETCH_STATUS = 0
	BEGIN



		IF (@LastTotalPontos	= @TotalPontos AND 
			@LastTotalVitorias	= @TotalVitorias AND
			@LastSaldo			= @Saldo AND
			@LastTotalGolsPro	= @TotalGOlsPro)
		BEGIN

			SET @Posicao = @LastPosicao

		END


		INSERT INTO @Classificacao
			(
			Posicao			,
			NomeTime		, 
			TotalPontos		,
			TotalVitorias	,
			TotalEmpates	,
			TotalDerrotas	,
			TotalGolsPro	,
			TotalGolsContra	,
			Saldo			
			)
			VALUES
			(
			@Posicao,
			@NomeTime,
			@TotalPontos,
			@TotalVitorias,
			@TotalEmpates,
			@TotalDerrotas,
			@TotalGolsPro,
			@TotalGolsContra,
			@Saldo
			)

		SET @LastPosicao			= @Posicao
		SET @LastTotalPontos		= @TotalPontos
		SET @LastTotalVitorias		= @TotalVitorias
		SET @LastTotalEmpates		= @TotalEmpates
		SET @LastTotalDerrotas		= @TotalDerrotas
		SET @LastTotalGolsPro		= @TotalGolsPro
		SET @LastTotalGolsContra	= @TotalGolsContra
		SET @LastSaldo				= @Saldo


		

		FETCH curClassificacao INTO @Posicao, @NomeTime, @TotalPontos, @TotalVitorias, 
								@TotalEmpates, @TotalDerrotas, @TotalGolsPro, @TotalGolsContra, @Saldo




		


	END --while


	DROP TABLE #TMP
	CLOSE curClassificacao
	DEALLOCATE curClassificacao



	SELECT * FROM @Classificacao ORDER BY TotalPontos DESC




	RETURN 0

END





GO
