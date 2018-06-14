IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_Insert_Jogo_Result')
BEGIN
	DROP  Procedure  _Insert_Jogo_Result
END
GO

CREATE PROCEDURE [dbo].[_Insert_Jogo_Result]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(50),
	@NomeGrupo							varchar(20),
	@NomeTime1							varchar(30),
	@Gols1								smallint = null,
	@Penaltis1							smallint = null,
	@NomeTime2							varchar(30),
	@Gols2								smallint = null,	
	@Penaltis2							smallint = null,
	@Rodada								int,
	@JogoLabel							varchar(5) = null
)
AS
BEGIN
	DECLARE @IdJogo int
	SET @IdJogo = 0

	DECLARE @ErrorNumber						int
    DECLARE @ErrorDescription					varchar(4000) 
    
	
		SELECT @IdJogo = IdJogo
		  FROM Jogos
		 WHERE NomeCampeonato	= @NomeCampeonato
		   AND (
		        NomeTime1		= @NomeTime1
		        OR 
		        @NomeTime1 IS NULL
		       )
		   AND (
				NomeTime2		= @NomeTime2
				OR 
				@NomeTime2 IS NULL
			   )
		   AND (
				Rodada			= @Rodada
				OR 
				@Rodada IS NULL
			   )
		   AND (
				NomeFase		= @NomeFase
				OR 
				@NomeFase IS NULL
			   )
		   AND (
				NomeGrupo		= @NomeGrupo
				OR 
				@NomeGrupo IS NULL
			   )
		   AND (
				JogoLabel		= @JogoLabel
				OR 
				@JogoLabel IS NULL
			   )
	

	IF (@IdJogo = 0)
	BEGIn
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'Jogo não encontrado.'
		RETURN 1
	END
	
	
	SET @ErrorDescription = ''
	SET @ErrorNumber = 0

	EXEC sp_Jogos_ResultInsert @CurrentLogin, @ApplicationName, 
							@IdJogo, @NomeCampeonato, @Gols1, @Penaltis1,
							@Gols2, @Penaltis2, true, @CurrentLogin, 
							@ErrorNumber OUTPUT, @ErrorDescription OUTPUT


END