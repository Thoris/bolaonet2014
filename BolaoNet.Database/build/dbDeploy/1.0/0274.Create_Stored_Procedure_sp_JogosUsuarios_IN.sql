IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_IN')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_IN
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@IDJogo								bigint,
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@Automatico							smallint,
	@ApostaTime1						smallint,
	@ApostaTime2						smallint,	
	@Ganhador							int = null,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @RowCount			int
	
	

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	IF ((@Ganhador IS NULL OR @Ganhador = 0) AND @ApostaTime1 = @ApostaTime2)
	BEGIN
		SET @Ganhador = 2
	END


	-- Se encontrou um registro com esta chave
	IF (NOT EXISTS(SELECT * 
				 FROM JogosUsuarios
				WHERE	NomeCampeonato				= @NomeCampeonato
				  AND	IDJogo						= @IdJogo
				  AND	NomeBolao					= @NomeBolao
				  AND	UserName					= @UserName))
	BEGIN
	
		INSERT INTO JogosUsuarios
			(
			IDJogo,
			NomeCampeonato,
			UserName, 
			NomeBolao,
			DataAposta,
			Automatico,
			ApostaTime1,
			ApostaTime2,
			Ganhador,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag
			)
			VALUES
			(
			@IdJogo,
			@NomeCampeonato,
			@UserName,
			@NomeBolao,
			GetDate(),
			@Automatico,
			@ApostaTime1,
			@ApostaTime2,
			@Ganhador,
			@CurrentLogin,
			GetDate(),
			@CurrentLogin,
			GetDate(),
			0
			)
	
	END
	-- Se não existe nenhum registro com esta chave
	ELSE
	BEGIN
	
		UPDATE JogosUsuarios
		   SET	DataAposta			= GetDate(),
				Automatico			= @Automatico,
				ApostaTime1			= @ApostaTime1,
				ApostaTime2			= @ApostaTime2,
				Ganhador			= @Ganhador
		 WHERE	
				IDJogo				= @IdJogo
		   AND	NomeCampeonato		= @NomeCampeonato
		   AND	UserName			= @UserName
		   AND	NomeBolao			= @NomeBolao
				
	END
	
	SET @RowCOunt =  @@RowCount  	
	

	-- Declarando as variaveis para buscar os dados
	DECLARE @NomeFase			varchar(30)
	DECLARE @NomeGrupo			varchar(20)
	DECLARE @NomeTime1			varchar(30)
	DECLARE @NomeTime2			varchar(30)
	
	
	
	-- Buscando detalhes do jogo apostado
	SELECT	@NomeFase = NomeFase, @NomeGrupo = NomeGrupo, 
			@NomeTime1 = NomeTime1, @NomeTime2 = NomeTime2
	  FROM Jogos 
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND IDJogo			= @IDJogo 
	
	
	IF (@NomeGrupo IS NOT NULL)
	BEGIN
		
		PRINT 'calculando dados do time ' + @NomeTime1 + ' que joga em casa atribuído'
		
		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@ApplicationName,
			@NomeCampeonato,
			@IDJogo,
			@NomeBolao,
			@UserName,
			@NomeTime1,
			@NomeFase,
			@NomeGrupo,
			@ErrorNumber,
			@ErrorDescription
		
		PRINT 'calculando dados do time ' + @NomeTime2 + ' que joga em fora atribuído'
		

		-- Calculando os dados do time
		EXEC sp_JogosUsuarios_Calcule_Time 
			@CurrentLogin,
			@ApplicationName,
			@NomeCampeonato,
			@IDJogo,
			@NomeBolao,
			@UserName,
			@NomeTime2,
			@NomeFase,
			@NomeGrupo,
			@ErrorNumber,
			@ErrorDescription
		
	END -- Grupo is not null
	
	
	PRINT 'Calculando pendencias do jogo '
		
	
	DECLARE @NomeTimeResult1	varchar(30)
	DECLARE @NomeTimeResult2	varchar(30)
	
	-- Buscando o time que gerou a dependência
	SELECT @NomeTimeResult1 = NomeTimeResult1, @NomeTimeResult2 = NomeTimeResult2
	  FROM JogosUsuarios
	 WHERE NomeCampeonato	= @NomeCampeonato
	   AND IDJogo			= @IDJogo
	   AND UserName			= @UserName
	   
	
	-- Se não encontrou valor para a dependencia
	IF (@NomeTimeResult1 IS NULL)
		SET @NomeTimeResult1 = @NomeTime1
		
	-- Se não encontrou valor para a dependencia	
	IF (@NomeTimeResult2 IS NULL)
		SET @NomeTimeResult2 = @NomeTime2
		
		
	-- Calculando a dependencia do jogo
	EXEC sp_JogosUsuarios_Calcule_Dependencia		@CurrentLogin,
													@ApplicationName,
													@NomeCampeonato,
													@IDJogo,
													@NomeBolao,
													@UserName,
													@Nomefase,
													@NomeGrupo,
													@NomeTimeResult1,
													@NomeTimeResult2,
													@ApostaTime1,
													@ApostaTime2,
													@Ganhador,
													@ErrorNumber,
													@ErrorDescription



	EXEC sp_JogosUsuarios_Calcule_Final				@CurrentLogin,
													@ApplicationName,
													@NomeCampeonato,
													@IDJogo,
													@NomeBolao,
													@UserName,
													@Nomefase,
													@NomeGrupo,
													@NomeTimeResult1,
													@NomeTimeResult2,
													@ApostaTime1,
													@ApostaTime2,
													@Ganhador,
													@ErrorNumber,
													@ErrorDescription

	RETURN @RowCount	
END



GO
