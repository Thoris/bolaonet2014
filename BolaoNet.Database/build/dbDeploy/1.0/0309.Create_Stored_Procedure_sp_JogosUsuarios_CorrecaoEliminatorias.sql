IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_CorrecaoEliminatorias')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_CorrecaoEliminatorias
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_CorrecaoEliminatorias]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT 

)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	




	
	DECLARE @CurIdJogo					int
	DECLARE @CurRodada					int
	DECLARE @CurPendenteTime1Ganhador	bit
	DECLARE @CurPendenteTime2Ganhador	bit
	DECLARE @CurPendenteTime1JogoId		int
	DECLARE @CurPendenteTime2JogoId		int

	DECLARE @AuxIdJogo					int
	DECLARE @AuxApostaTime1				int
	DECLARE @AuxApostaTime2				int
	DECLARE @AuxNomeTime1				VARCHAR(30)
	DECLARE @AuxNomeTime2				VARCHAR(30)
	DECLARE @AuxGanhador				int

	DECLARE @NomeTimeApplyTime1		VARCHAR(30)
	DECLARE @NomeTimeApplyTime2		VARCHAR(30)
	DECLARE @CurrentTime1			VARCHAR(30)
	DECLARE @CurrentTime2			VARCHAR(30)


	--select * from jogos where NomeCampeonato = 'CM2014'


	DECLARE curJogos CURSOR FOR
	SELECT jogo.IdJogo, jogo.Rodada, jogo.PendenteTime1Ganhador, jogo.PendenteTime1JogoID, jogo.PendenteTime2Ganhador, jogo.PendenteTime2JogoID
	  FROM JogosUsuarios usu
	 INNER JOIN Jogos jogo
		ON usu.NomeCampeonato	= jogo.NomeCampeonato
	   AND usu.IdJogo			= jogo.IdJogo
	 WHERE usu.NomeCampeonato	= @NomeCampeonato
	   AND usu.NomeBolao		= @NomeBolao
	   AND usu.UserName			= @UserName
	   AND (jogo.PendenteTime1JogoID > 0 OR jogo.PendenteTime2JogoID > 0)
	 ORDER BY jogo.Rodada
   

	OPEN curJogos

	FETCH NEXT FROM curJogos INTO @CurIdJogo, @CurRodada, @CurPendenteTime1Ganhador, @CurPendenteTime1JogoId, @CurPendenteTime2Ganhador, @CurPendenteTime2JogoId

	WHILE (@@FETCH_STATUS = 0)
	BEGIN


		IF (@CurPendenteTime1JogoId > 0)
		BEGIN

			PRINT 'Jogo: ' + Convert(VARCHAR, @CurIdJogo) + ' - PendenteTime1: ' + CONVERT(VARCHAR, @CurPendenteTime1JogoId) + ' - Ganhador: ' + CONVERT(VARCHAR, @CurPendenteTime1Ganhador)

			IF (EXISTS (SELECT * 
						  FROM JogosUsuarios 
						 WHERE NomeBolao		= @NomeBolao 
						   AND NomeCampeonato	= @NomeCampeonato
						   AND UserName			= @UserName
						   AND IdJogo			= @CurPendenteTime1JogoId))
			BEGIN

				  SELECT 
						@AuxIdJogo		= IdJogo,
						@AuxApostaTime1 = ApostaTime1,
						@AuxApostaTime2 = ApostaTime2,
						@AuxNomeTime1	= NomeTimeResult1,
						@AuxNomeTime2	= NomeTimeResult2,
						@AuxGanhador	= Ganhador
					FROM JogosUsuarios 
					WHERE NomeBolao			= @NomeBolao 
					  AND NomeCampeonato	= @NomeCampeonato
					  AND UserName			= @UserName
					  AND IdJogo			= @CurPendenteTime1JogoId



					SET @NomeTimeApplyTime1 = NULL

					IF (@CurPendenteTime1Ganhador = 1)
					BEGIN
						IF (@AuxApostaTime1 > @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime1 = @AuxNomeTime1
						END
						ELSE IF (@AuxApostaTime1 < @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime1= @AuxNomeTime2
						END
						ELSE
						BEGIN
							IF (@AuxGanhador = 1)
							BEGIN
								SET @NomeTimeApplyTime1= @AuxNomeTime1
							END
							ELSE
							BEGIN
								SET @NomeTimeApplyTime1= @AuxNomeTime2
							END
						END

						PRINT '		- Time 1 Ganhador: ' + @NomeTimeApplyTime1

					END
					ELSE
					BEGIN
						IF (@AuxApostaTime1 > @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime1 = @AuxNomeTime2
						END
						ELSE IF (@AuxApostaTime1 < @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime1= @AuxNomeTime1
						END
						ELSE
						BEGIN
							IF (@AuxGanhador = 1)
							BEGIN
								SET @NomeTimeApplyTime1= @AuxNomeTime2
							END
							ELSE
							BEGIN
								SET @NomeTimeApplyTime1= @AuxNomeTime1
							END
						END

						PRINT '		- Time 1 Perdedor: ' + @NomeTimeApplyTime1
					END
				
			END
			ELSE
			BEGIN
				PRINT 'Jogo 1 ainda não computado.'
			END


		
			IF (EXISTS (SELECT * 
						  FROM JogosUsuarios 
						 WHERE NomeBolao		= @NomeBolao 
						   AND NomeCampeonato	= @NomeCampeonato
						   AND UserName			= @UserName
						   AND IdJogo			= @CurPendenteTime2JogoId))
			BEGIN

				  SELECT 
						@AuxIdJogo = IdJogo,
						@AuxApostaTime1 = ApostaTime1,
						@AuxApostaTime2 = ApostaTime2,
						@AuxNomeTime1 = NomeTimeResult1,
						@AuxNomeTime2 = NomeTimeResult2,
						@AuxGanhador = Ganhador
					FROM JogosUsuarios 
					WHERE NomeBolao			= @NomeBolao 
					  AND NomeCampeonato	= @NomeCampeonato
					  AND UserName			= @UserName
					  AND IdJogo			= @CurPendenteTime2JogoId

					SET @NomeTimeApplyTime2 = NULL

					IF (@CurPendenteTime2Ganhador = 1)
					BEGIN
						IF (@AuxApostaTime1 > @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime2 = @AuxNomeTime1
						END
						ELSE IF (@AuxApostaTime1 < @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime2= @AuxNomeTime2
						END
						ELSE
						BEGIN
							IF (@AuxGanhador = 1)
							BEGIN
								SET @NomeTimeApplyTime2= @AuxNomeTime1
							END
							ELSE
							BEGIN
								SET @NomeTimeApplyTime2= @AuxNomeTime2
							END
						END

						PRINT '		- Time 2 Ganhador: ' + @NomeTimeApplyTime2

					END
					ELSE
					BEGIN
						IF (@AuxApostaTime1 > @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime2 = @AuxNomeTime2
						END
						ELSE IF (@AuxApostaTime1 < @AuxApostaTime2)
						BEGIN
							SET @NomeTimeApplyTime2= @AuxNomeTime1
						END
						ELSE
						BEGIN
							IF (@AuxGanhador = 1)
							BEGIN
								SET @NomeTimeApplyTime2= @AuxNomeTime2
							END
							ELSE
							BEGIN
								SET @NomeTimeApplyTime2= @AuxNomeTime1
							END
						END

						PRINT '		- Time 2 Perdedor: ' + @NomeTimeApplyTime2
					END
				
			END
			ELSE
			BEGIN 
				PRINT 'Jogo 2 ainda não computado.'
			END


		END


		SELECT @CurrentTime1 = NomeTimeResult1, @CurrentTime2 = NomeTimeResult2
		  FROM JogosUsuarios
		 WHERE NomeBolao		= @NomeBolao
		   AND NomeCampeonato	= @NomeCampeonato
		   AND UserName			= @UserName
		   AND IdJogo			= @CurIdJogo

		IF (@CurrentTime1 <> @NomeTimeApplyTime1 OR @CurrentTime2 <> @NomeTimeApplyTime2)
		BEGIN
			PRINT '		****************************************************************'
			PRINT '		**** Atualizando: ' + CONVERT(VARCHAR, @CurIdJogo) + '. Time1: [' + @CurrentTime1 + ']' + @NomeTimeApplyTime1 + ' - Time2:[' + @CurrentTime2 +'] ' + @NomeTimeApplyTime2
			PRINT '		****************************************************************'
	
	
			UPDATE JogosUsuarios
			   SET  NomeTimeResult1 = @NomeTimeApplyTime1,
					NomeTimeResult2 = @NomeTimeApplyTime2
			 WHERE NomeBolao		= @NomeBolao
			   AND NomeCampeonato	= @NomeCampeonato
			   AND UserName			= @UserName
			   AND IdJogo			= @CurIdJogo

				

	
	
		END

		FETCH NEXT FROM curJogos INTO @CurIdJogo, @CurRodada, @CurPendenteTime1Ganhador, @CurPendenteTime1JogoId, @CurPendenteTime2Ganhador, @CurPendenteTime2JogoId

	END



	CLOSE curJogos
	DEALLOCATE curJogos



	DECLARE @AuxNomeGrupo	VARCHAR(30)



	DECLARE curJogosFinais CURSOR FOR
	SELECT jogo.IdJogo, usu.ApostaTime1, usu.ApostaTime2, usu.NomeTimeResult1, usu.NomeTimeResult2, usu.Ganhador, jogo.NomeGrupo
	  FROM JogosUsuarios usu
	 INNER JOIN Jogos jogo
		ON usu.NomeCampeonato	= jogo.NomeCampeonato
	   AND usu.IdJogo			= jogo.IdJogo
	 WHERE usu.NomeCampeonato	= @NomeCampeonato
	   AND usu.NomeBolao		= @NomeBolao
	   AND usu.UserName			= @UserName
	   AND jogo.NomeFase        = 'Final'



	OPEN curJogosFinais

	FETCH NEXT FROM curJogosFinais INTO @AuxIdJogo, @AuxApostaTime1, @AuxApostaTime2, @AuxNomeTime1, @AuxNomeTime2, @AuxGanhador, @AuxNomeGrupo

	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		PRINT '**** FINAL : ID: ' + CONVERT(VARCHAR, @AuxIdJogo) + ' Time1=' + @AuxNomeTime1 + ' x Time2=' + @AuxNomeTime2



		EXEC [sp_JogosUsuarios_Calcule_Final] 
			@CurrentLogin,
			@ApplicationName,
			@NomeCampeonato,
			@AuxIdJogo,
			@NomeBolao,	
			@UserName,			
			'Final',
			@AuxNomeGrupo,
			@AuxNomeTime1,
			@AuxNomeTime2,
			@AuxApostaTime1,
			@AuxApostaTime2,
			@AuxGanhador,
			@ErrorNumber OUTPUT,
			@ErrorDescription OUTPUT





		FETCH NEXT FROM curJogosFinais INTO @AuxIdJogo, @AuxApostaTime1, @AuxApostaTime2, @AuxNomeTime1, @AuxNomeTime2, @AuxGanhador, @AuxNomeGrupo

	END
	
	
	CLOSE curJogosFinais
	DEALLOCATE curJogosFinais


END



GO
