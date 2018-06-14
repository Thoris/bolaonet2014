IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosRecordTimeRecordJogosGols')
BEGIN
	DROP  Procedure  sp_CampeonatosRecordTimeRecordJogosGols
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosRecordTimeRecordJogosGols]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeTime							varchar(30),
	@GetRecord							bit = true,
	@JogosSemMarcar						int OUTPUT,
	@JogosSemMarcarDentro				int OUTPUT,
	@JogosSemMarcarFora					int OUTPUT,
	@JogosSemLevar						int OUTPUT,
	@JogosSemLevarDentro				int OUTPUT,
	@JogosSemLevarFora					int OUTPUT,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	



	DECLARE @DataJogo		datetime
	DECLARE @NomeTime1		varchar(30)
	DECLARE @NomeTime2		varchar(30)
	DECLARE @Gols1			smallint
	DECLARE @Gols2			smallint


	DECLARE @CurrentJogosSemMarcar				int
	DECLARE @CurrentJogosSemMarcarDentro		int
	DECLARE @CurrentJogosSemMarcarFora			int
	
	DECLARE @CurrentJogosSemLevar				int
	DECLARE @CurrentJogosSemLevarDentro			int
	DECLARE @CurrentJogosSemLevarFora			int
	


	DECLARE @MaxJogosSemMarcar				int
	DECLARE @MaxJogosSemMarcarDentro		int
	DECLARE @MaxJogosSemMarcarFora			int
	
	DECLARE @MaxJogosSemLevar				int
	DECLARE @MaxJogosSemLevarDentro			int
	DECLARE @MaxJogosSemLevarFora			int
	
	
	
	SET @CurrentJogosSemMarcar				= 0
	SET @CurrentJogosSemMarcarDentro		= 0
	SET @CurrentJogosSemMarcarFora			= 0
	
	SET @CurrentJogosSemLevar				= 0
	SET @CurrentJogosSemLevarDentro			= 0
	SET @CurrentJogosSemLevarFora			= 0
	
	
	SET @MaxJogosSemMarcar				= 0
	SET @MaxJogosSemMarcarDentro		= 0
	SET @MaxJogosSemMarcarFora			= 0
	
	SET @MaxJogosSemLevar				= 0
	SET @MaxJogosSemLevarDentro			= 0
	SET @MaxJogosSemLevarFora			= 0
	
	





	DECLARE curJogo CURSOR FOR
	 SELECT DataJogo, NomeTime1, Gols1, Gols2, NomeTime2
	  FROM Jogos
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND 
		  (
				NomeTime1		= @NomeTime
				OR
				NomeTime2		= @NomeTime
		  )
	   AND IsValido = 1
	   
	 ORDER BY DataJogo 


	 
	OPEN curJogo


	FETCH NEXT FROM curJogo INTO @DataJogo, @NomeTime1, @Gols1, @Gols2, @NomeTime2


	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		--PRINT	'DataJogo: ' + Convert(VARCHAR, @DataJogo) + 
		--		' < ' + @NomeTime1 + ' > [' + CONVERT(VARCHAR, @Gols1) + '] x ' +
		--		'[' + CONVERT(VARCHAR, @Gols2) + ']' + ' < ' + @NomeTime2 + ' >'


		IF (@NomeTime = @NomeTime1)
		BEGIN
			IF (@Gols1 = 0)
			BEGIN
				
				SET @CurrentJogosSemMarcar = @CurrentJogosSemMarcar + 1
				IF (@CurrentJogosSemMarcar > @MaxJogosSemMarcar)
					SET @MaxJogosSemMarcar = @CurrentJogosSemMarcar
				
				
				SET @CurrentJogosSemMarcarDentro = @CurrentJogosSemMarcarDentro + 1
				IF (@CurrentJogosSemMarcarDentro > @MaxJogosSemMarcarDentro)
					SET @MaxJogosSemMarcarDentro = @CurrentJogosSemMarcarDentro
				
			
			END		
			ELSE
			BEGIN
				SET @CurrentJogosSemMarcar = 0
				SET @CurrentJogosSemMarcarDentro = 0
			END
			
			IF (@Gols2 = 0)
			BEGIN
				
				SET @CurrentJogosSemLevar = @CurrentJogosSemLevar + 1
				IF (@CurrentJogosSemLevar > @MaxJogosSemLevar)
					SET @MaxJogosSemLevar = @CurrentJogosSemLevar
				
				
				SET @CurrentJogosSemLevarDentro = @CurrentJogosSemLevarDentro + 1
				IF (@CurrentJogosSemLevarDentro > @MaxJogosSemLevarDentro)
					SET @MaxJogosSemLevarDentro = @CurrentJogosSemLevarDentro
			
			END		
			ELSE
			BEGIN
				SET @CurrentJogosSemLevar = 0
				SET @CurrentJogosSemLevarDentro = 0
			END
		
		END
		ELSE IF (@NomeTIme = @NomeTime2)
		BEGIN
		

			IF (@Gols2 = 0)
			BEGIN
				
				SET @CurrentJogosSemMarcar = @CurrentJogosSemMarcar + 1
				IF (@CurrentJogosSemMarcar > @MaxJogosSemMarcar)
					SET @MaxJogosSemMarcar = @CurrentJogosSemMarcar
				
				
				SET @CurrentJogosSemMarcarFora = @CurrentJogosSemMarcarFora + 1
				IF (@CurrentJogosSemMarcarFora > @MaxJogosSemMarcarFora)
					SET @MaxJogosSemMarcarFora = @CurrentJogosSemMarcarFora
				
			
			END							
			ELSE
			BEGIN
				SET @CurrentJogosSemMarcar = 0
				SET @CurrentJogosSemMarcarFora = 0
			END
			
			IF (@Gols1 = 0)
			BEGIN
				
				SET @CurrentJogosSemLevar = @CurrentJogosSemLevar + 1
				IF (@CurrentJogosSemLevar > @MaxJogosSemLevar)
					SET @MaxJogosSemLevar = @CurrentJogosSemLevar
				
				
				SET @CurrentJogosSemLevarFora = @CurrentJogosSemLevarFora + 1
				IF (@CurrentJogosSemLevarFora > @MaxJogosSemLevarFora)
					SET @MaxJogosSemLevarFora = @CurrentJogosSemLevarFora
			
			END							
			ELSE
			BEGIN
				SET @CurrentJogosSemLevar = 0
				SET @CurrentJogosSemLevarFora = 0
			END
		END
		
		
		
		--PRINT 'CurrentVitoria: [' + CONVERT(VARCHAR, @CurrentVitoria) + '] CurrentEmpate: ['+ CONVERT(VARCHAR, @CurrentEmpate) + '] CurrentDerrota: [' + CONVERT(VARCHAR, @CurrentDerrota ) + ']'
		
		--PRINT 'MaxVitoria: [' + CONVERT(VARCHAR, @MaxVitoria) + '] MaxEmpate: ['+ CONVERT(VARCHAR, @MaxEmpate) + '] MaxDerrota: [' + CONVERT(VARCHAR, @MaxDerrota) + ']'
		
		
		FETCH NEXT FROM curJogo INTO @DataJogo, @NomeTime1, @Gols1, @Gols2, @NomeTime2
	END


	 
	CLOSE curJogo
	DEALLOCATE curJogo


	PRINT '--------------------------------'
	PRINT 'Sem Marcar: ' + CONVERT(VARCHAR, @MaxJogosSemMarcar)
	PRINT 'Sem Levar: ' + CONVERT(VARCHAR, @MaxJogosSemLevar)
	PRINT '--------------------------------'
	PRINT 'Sem Marcar Fora: ' + CONVERT(VARCHAR, @MaxJogosSemMarcarFora)
	PRINT 'Sem Levar Fora: ' + CONVERT(VARCHAR, @MaxJogosSemLevarFora)
	PRINT '--------------------------------'
	PRINT 'Sem Marcar Dentro: ' + CONVERT(VARCHAR, @MaxJogosSemMarcarDentro)
	PRINT 'Sem Levar Dentro: ' + CONVERT(VARCHAR, @MaxJogosSemLevardentro)
	PRINT '--------------------------------'


	if (@GetRecord = 1)
	BEGIN

		
		SET @JogosSemMarcar			= @MaxJogosSemMarcar
		SET @JogosSemMarcarDentro	= @MaxJogosSemMarcarDentro
		SET @JogosSemMarcarFora		= @MaxJogosSemMarcarFora
		
		SET @JogosSemLevar			= @MaxJogosSemLevar
		SET @JogosSemLevarDentro	= @MaxJogosSemLevarDentro
		SET @JogosSemLevarFora		= @MaxJogosSemLevarFora

	END
	ELSE
	BEGIN

		SET @JogosSemMarcar			= @CurrentJogosSemMarcar
		SET @JogosSemMarcarDentro	= @CurrentJogosSemMarcarDentro
		SET @JogosSemMarcarFora		= @CurrentJogosSemMarcarFora
		
		SET @JogosSemLevar			= @CurrentJogosSemLevar
		SET @JogosSemLevarDentro	= @CurrentJogosSemLevarDentro
		SET @JogosSemLevarFora		= @CurrentJogosSemLevarFora	
	END














END



GO
