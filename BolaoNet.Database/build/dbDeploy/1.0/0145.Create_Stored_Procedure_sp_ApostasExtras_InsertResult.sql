IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_InsertResult')
BEGIN
	DROP  Procedure  sp_ApostasExtras_InsertResult
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_InsertResult]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@NomeTime							varchar(30),
	@Posicao							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DECLARE @UserName			varchar(25)
	DECLARE @NomeTimeUsuario	varchar(30)
	
	DECLARE @Pontos				int
	
	DECLARE @PontosUsuario		int
	
	
	DECLARE @TranStarted	bit
	SET @TranStarted = 0

	-- Se não tem nenhuma transação corrente
	IF( @@TRANCOUNT = 0 )
	BEGIN
		-- Iniciando a transação
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END		
	
	-- Buscando os pontos do bolao
	SELECT @Pontos = TotalPontos
	  FROM ApostasExtras
	 WHERE NomeBolao		= @NomeBolao
	   AND Posicao			= @Posicao
	
	
	-- Atualizando o time que deve ser validado
	UPDATE ApostasExtras
	   SET ModifiedBy		= @CurrentLogin,
	       ModifiedDate		= GetDate(),
	       IsValido			= 1,
	       DataValidacao	= GetDate(),
	       ValidadoBy		= @CurrentLogin,
	       NomeTimeValidado	= @NomeTime
	 WHERE Posicao			= @Posicao
	   AND NomeBolao		= @NomeBolao
	  









	-- Declarando o cursor para buscar as apostas dos usuários para o jogo
	DECLARE curApostas CURSOR FOR
		SELECT	UserName, NomeTime
		  FROM ApostasExtrasUsuarios
		 WHERE NomeBolao			= @NomeBolao
		   AND Posicao				= @Posicao		   
		 ORDER BY UserName
		 

	-- Abrindo o cursor para carregar os critérios 
	OPEN curApostas

	-- Executando o cursor
	FETCH NEXT FROM curApostas INTO @UserName, @NomeTimeUsuario

	-- Enquanto existir registros
	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		-- Zerando a variável para ser analisada posteriormente
		SET @PontosUsuario = 0
		
		-- Se o usuário acertou os pontos
		IF (@NomeTimeUsuario = @NomeTime)
			SET @PontosUsuario = @Pontos
		ELSE
			SET @PontosUsuario = 0
		   
		
		-- Atualizando os dados do usuário
		UPDATE ApostasExtrasUsuarios
		   SET Pontos				= @PontosUsuario,
		       IsApostavalida		= 1
		 WHERE Username				= @Username
		   AND NomeBolao			= @NomeBolao
		   AND Posicao				= @Posicao
		   



		-- Executando o cursor
		FETCH NEXT FROM curApostas INTO @UserName, @NomeTimeUsuario

	END


	-- Fechando o cursor
	CLOSE curApostas
	
	-- Desalocando o cursor
	DEALLOCATE curApostas





	-- Se ainda está ativa a transação
	IF( @TranStarted = 1 )
	BEGIN
		-- Completando a transação
		SET @TranStarted = 0
		COMMIT TRANSACTION
	END	

	
		
	RETURN 1  	
	
	
END




GO
