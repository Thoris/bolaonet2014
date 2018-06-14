IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosPontos_Classificacao')
BEGIN
	DROP  Procedure  sp_BoloesMembrosPontos_Classificacao
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosPontos_Classificacao]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT	
)
AS
BEGIN
	 
	 
	DECLARE @MaxRodada			int


	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	 

SELECT BoloesMembros.UserName, BoloesMembrosClassificacao.*, Users.FullName
  FROM BoloesMembros
 INNER JOIN Users
    ON Users.UserName	= BoloesMembros.UserName
 LEFT JOIN BoloesMembrosClassificacao
    ON BoloesMembros.UserName	= BoloesMembrosClassificacao.UserName
   AND BoloesMembros.NomeBolao	= BoloesMembrosClassificacao.NomeBolao
 WHERE BoloesMembros.NomeBolao	= @NomeBolao
 ORDER BY BoloesMembrosClassificacao.Posicao, 
		  BoloesMembrosClassificacao.LastPosicao,
		  BOloesMembrosClassificacao.TotalPontos



	--SELECT * 
	--  FROM BoloesMembrosClassificacao
 --    WHERE NomeBolao		= @NomeBolao
	-- ORDER BY Posicao, LastPosicao, TotalPontos












/*
	DECLARE @Classificacao as Table
		(
			Posicao					int,
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
			TotalPlacarCheio		int
		)


	INSERT @Classificacao
	SELECT ROW_NUMBER() OVER(ORDER BY SUM(TotalPontos) DESC) as Posicao, 
		   t.UserName, 
		   SUM(t.TotalPontos) as TotalPontos, 
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
		   SUM(t.TotalEmpate) as TotalEmpate,
		   SUM(t.TotalGolsTime1) as TotalGolsTime1,
		   SUM(t.TotalGolsTime2) as TotalGolsTime2,
		   SUM(t.TotalPlacarCheio) as TotalPlacarCheio
	  FROM BoloesMembrosPontos t
	 WHERE t.NomeBolao = @NomeBolao
	 GROUP BY t.NomeBolao, t.UserName
	 ORDER BY SUM(t.TotalPontos) DESC



	DECLARE @Posicao		int
	DECLARE @UserName		varchar(25)
	DECLARE @TotalPontos	int

	DECLARE @LastPosicao	int
	DECLARE @LastPontos		int




	DECLARE curClassificacao CURSOR FOR
	  SELECT Posicao, UserName, TotalPontos 
		FROM @Classificacao 
	   ORDER BY Posicao

	OPEN curClassificacao
	FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos

	SET @LastPosicao = @Posicao
	SET @LastPontos	= @TotalPontos


	WHILE @@FETCH_STATUS = 0
	BEGIN


		--PRINT 'Posicao: ' + CONVERT(VARCHAR, @Posicao) + ' - LastPosicao: ' + CONVERT(VARCHAR, @lastPosicao) + ' UserName: ' + @UserName

		IF (@LastPontos = @TotalPontos)
		BEGIN
			--PRINT 'Atualizando : ' +CONVERT(VARCHAR, @LastPosicao)
			
			UPDATE @Classificacao SET
				Posicao		= @LastPosicao
			 WHERE UserName	= @UserName

		END
		ELSE
		BEGIN
			SET @LastPosicao = @Posicao
			SET @LastPontos	= @TotalPontos
		END




		FETCH curClassificacao INTO @Posicao, @UserName, @TotalPontos
	END





	CLOSE curClassificacao
	DEALLOCATE curClassificacao


	select * from @classificacao
*/













/*
	IF (@Rodada = 0)
	BEGIN
		SELECT @Rodada = Max(Rodada)
		  FROM BoloesMembrosPontos l
		 WHERE l.NomeCampeonato		= @NomeCampeonato
		   AND l.NomeBolao			= @NomeBolao	   
	END

	PRINT 'Buscando dados da rodada ' + CONVERT(VARCHAR, @Rodada)

	SELECT t.NomeBolao, t.NomeCampeonato, t.UserName
		   SUM(t.TotalPontos) as TotalPontos, 
		   SUM(t.TotalEmpate) as TotalEmpate, 
		   SUM(t.TotalVitoria) as TotalVitoria,
		   SUM(t.TotalGolsGanhador) as TotalGOlsGanhador, 
		   SUM(t.TotalGolsPerderdor) as TotalGolsPerdedor, 
		   SUM(t.TotalResultTime1) as TotalResultTime1, 
		   SUM(t.TotalResultTime2) as TotalResultTime2, 
		   SUM(t.TotalVDE) as TotalVDE,
		   SUM(t.TotalErro) as TotalErro, 
		   SUM(t.TotalGolsGanhadorFora) as TotalGolsGanhadorFora, 
		   SUM(t.TotalGolsGanhadorDentro) as TotalGolsGanhadorDentro,
		   SUM(t.TOtalPerdedorFora) as TotalPerdedorFora, 
		   SUM(t.TotalPerdedorDentro) as TOtalPerdedorDentro, 
		   SUM(t.TotalEmpate) as TotalEmpate,
		   SUM(t.TotalGolsTime1) as TotalGolsTime1,
		   SUM(t.TotalGolsTime2) as TotalGolsTime2,
		   SUM(t.TotalPlacarCheio) as TotalPlacarCheio,
		   (
				SELECT Posicao
				  FROM BoloesMembrosPontos
				 WHERE l.NomeBolao		= @
		   )



	
		
		SELECT t.NomeCampeonato, c.NomeFase, t.NomeGrupo, t.NomeTime, Count(*) as 'Jogos',
				SUM(c.TotalVitorias) as 'TotalVitorias', SUM(c.TotalDerrotas) as 'TotalDerrotas', SUM(c.TotalEmpates) as 'TotalEmpates', 
				SUM(c.TotalGolsContra) as 'TotalGolsContra', SUM(c.TotalGolsPro) as 'TotalGolsPro', SUM(c.TotalPontos) as 'TotalPontos',
				SUM(c.TotalGolsPro) - SUM(c.TotalGolsContra) as 'Saldo',
				(
					SELECT Posicao 
					  FROM CampeonatosClassificacao l
					 WHERE l.NomeCampeonato		= @NomeCampeonato
					   AND l.NomeGrupo			= @NomeGrupo
					   AND l.NomeFase			= @NomeFase
					   AND l.NomeTime			= t.NomeTime
					   AND l.Rodada				= @Rodada					   
				) as 'Posicao',
				(
					SELECT LastPosicao 
					  FROM CampeonatosClassificacao l
					 WHERE l.NomeCampeonato		= @NomeCampeonato
					   AND l.NomeGrupo			= @NomeGrupo
					   AND l.NomeFase			= @NomeFase
					   AND l.NomeTime			= t.NomeTime
					   AND l.Rodada				= @Rodada					   
				) as 'LastPosicao' 				
		  FROM CampeonatosClassificacao c
		 RIGHT JOIN CampeonatosGruposTimes t
			ON t.NomeCampeonato		= c.NomeCampeonato
		   --AND t.NomeFase			= c.NomeFase
		   AND t.NomeGrupo			= c.NomeGrupo
		   AND t.NomeTime			= c.NomeTime
		 WHERE c.NomeCampeonato		= @NomeCampeonato
		   AND c.NomeFase			= @NomeFase
		   AND c.NomeGrupo			= @NomeGrupo
		 GROUP BY t.NomeCampeonato, c.NomeFase, t.NomeGrupo, t.NomeTime
		 ORDER BY t.NomeCampeonato, c.NomeFase, t.NomeGrupo,
					(
		 			SELECT Posicao 
					  FROM CampeonatosClassificacao l
					 WHERE l.NomeCampeonato		= @NomeCampeonato
					   AND l.NomeGrupo			= @NomeGrupo
					   AND l.NomeFase			= @NomeFase
					   AND l.NomeTime			= t.NomeTime
					   AND l.Rodada				= @Rodada					  		
					)
		
*/	
		
	RETURN @@RowCount	  		 
	 
	 


END





GO
