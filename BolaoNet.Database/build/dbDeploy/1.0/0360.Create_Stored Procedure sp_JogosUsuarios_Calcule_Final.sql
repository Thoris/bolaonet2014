IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Calcule_Final')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Calcule_Final
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Calcule_Final] 
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@IDJogo								bigint,
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(30),
	@NomeTime1							varchar(30),
	@NomeTime2							varchar(30),
	@ApostaTime1						smallint,
	@ApostaTime2						smallint,
	@Ganhador							int = NULL,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	IF (@NomeFase <> 'Final')
	BEGIN
		PRINT 'Não é fase final.'
		RETURN 0
	END

	PRINT 'Encontrando a posição dos times na final'



	DECLARE @PendenteTime1Ganhador	int
	DECLARE @PendenteTime1JogoID	int
	DECLARE @PendenteTime2Ganhador	int
	DECLARE @PendenteTime2JogoID	int
	
	DECLARE @NomeTimeGanhador		varchar(30)
	DECLARE @NomeTimePerdedor		varchar(30)
	
	

	IF (@Ganhador IS NULL OR @Ganhador = 0)
	BEGIN
		-- Buscando qual time foi o ganhador
		IF (@ApostaTime1 >= @ApostaTime2)
		BEGIN
			SET @NomeTimeGanhador = @NomeTime1
			SET @NomeTimePerdedor = @NomeTime2
		END
		ELSE
		BEGIN
			SET @NomeTimeGanhador = @NomeTime2
			SET @NomeTimePerdedor = @NomeTime1	
		END
	END
	ELSE
	BEGIN
		IF (@Ganhador = 1)
		BEGIN
			SET @NomeTimeGanhador = @NomeTime1
			SET @NomeTimePerdedor = @NomeTime2		
		END
		ELSE
		BEGIN
			SET @NomeTimeGanhador = @NomeTime2
			SET @NomeTimePerdedor = @NomeTime1		
		END

	END
	
	SELECT	@PendenteTime1Ganhador	= PendenteTime1Ganhador,
			@PendenteTime1JogoID	= PendenteTime1JogoID,
			@PendenteTime2Ganhador	= PendenteTime2Ganhador,
			@PendenteTime2JogoID	= PendenteTime2JogoID
	  FROM JOGOS
	 WHERE IdJogo			= @IDJogo
	   AND NomeCampeonato	= @NomeCampeonato
	   AND NomeFase			= @NomeFase
	   AND NomeGrupo		= @NomeGrupo
	
	
	-- DISPUTA DE TERCEIRO E QUARTO LUGAR
	IF (@PendenteTime1JogoID > 0 AND @PendenteTime1Ganhador = 0 AND 
		@PendenteTime2JogoID > 0 AND @PendenteTime2Ganhador = 0) 
	BEGIN
		PRINT 'Disputa de terceiro lugar'
		PRINT '3 = ' + @NomeTimeGanhador + ' | 4 = ' + @NomeTimePerdedor
		
		-- Se existe a aposta do terceiro lugar a ser computada
		IF (EXISTS(SELECT * FROM ApostasExtras WHERE Posicao = 3 AND NomeBolao = @NomeBolao))
		BEGIN
		
			PRINT 'Buscando o terceiro lugar do usuário'
		
			--Se o usuário ainda não fez a sua aposta
			IF (NOT EXISTS(SELECT * 
						 FROM ApostasExtrasUsuarios 
						WHERE Posicao		= 3 
						  AND NomeBolao		= @NomeBolao 
						  AND UserName		= @UserName))
			BEGIN
			
				INSERT INTO ApostasExtrasUsuarios (NomeBolao, Posicao, UserName, NomeTime, IsApostaValida, Pontos, DataAposta, Automatico, 
													CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
				 VALUES	(@NomeBolao, 3, @UserName, @NomeTimeGanhador, 0, 0, GETDATE(), 1, @CurrentLogin, GetDate(), @CurrentLogin, GETDATE(), 0)			
			
			END
			--Se o usuário já fez a sua aposta
			ELSE
			BEGIN
			
				UPDATE ApostasExtrasUsuarios 
				   SET  NomeTime		= @NomeTimeGanhador,
						ModifiedBy		= @CurrentLogin,
						ModifiedDate	= GetDate(),
						DataAposta		= GETDATE(),
						Automatico		= 1
				 WHERE NomeBolao		= @NomeBolao
				   AND UserName			= @UserName
				   AND Posicao			= 3
			
			END
		END
		
		
		
		
		
		-- Se existe a aposta do quarto lugar a ser computada
		IF (EXISTS(SELECT * FROM ApostasExtras WHERE Posicao = 4 AND NomeBolao = @NomeBolao))
		BEGIN
		
		
			PRINT 'Buscando o quarto lugar do usuário'
		
			--Se o usuário ainda não fez a sua aposta
			IF (NOT EXISTS(SELECT * 
						 FROM ApostasExtrasUsuarios 
						WHERE Posicao		= 4 
						  AND NomeBolao		= @NomeBolao 
						  AND UserName		= @UserName))
			BEGIN
			
				INSERT INTO ApostasExtrasUsuarios (NomeBolao, Posicao, UserName, NomeTime, IsApostaValida, Pontos, DataAposta, Automatico,
													CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
				 VALUES	(@NomeBolao, 4, @UserName, @NomeTimePerdedor, 0, 0, GETDATE(), 1,  @CurrentLogin, GetDate(), @CurrentLogin, GETDATE(), 0)			
			
			END
			--Se o usuário já fez a sua aposta
			ELSE
			BEGIN
			
				UPDATE ApostasExtrasUsuarios 
				   SET  NomeTime		= @NomeTimePerdedor,
						ModifiedBy		= @CurrentLogin,
						ModifiedDate	= GetDate(),
						DataAposta		= GETDATE(),
						Automatico      = 1
				 WHERE NomeBolao		= @NomeBolao
				   AND UserName			= @UserName
				   AND Posicao			= 4
			
			END
		END
		
		
		
	END
	
	-- DISPUTA DE PRIMEIRO E SEGUNDO LUGAR
	IF (@PendenteTime1JogoID > 0 AND @PendenteTime1Ganhador = 1 AND 
		@PendenteTime2JogoID > 0 AND @PendenteTime2Ganhador = 1) 
	BEGIN
		PRINT 'Disputa de primeiro lugar'
		
		
		PRINT '1 = ' + @NomeTimeGanhador + ' | 2 = ' + @NomeTimePerdedor
		
		-- Se existe a aposta do primeiro lugar a ser computada
		IF (EXISTS(SELECT * FROM ApostasExtras WHERE Posicao = 1 AND NomeBolao = @NomeBolao))
		BEGIN
		
		
			PRINT 'Buscando o primeiro lugar do usuário'
		
		
			--Se o usuário ainda não fez a sua aposta
			IF (NOT EXISTS(SELECT * 
						 FROM ApostasExtrasUsuarios 
						WHERE Posicao		= 1
						  AND NomeBolao		= @NomeBolao 
						  AND UserName		= @UserName))
			BEGIN
			
				INSERT INTO ApostasExtrasUsuarios (NomeBolao, Posicao, UserName, NomeTime, IsApostaValida, Pontos, DataAposta, Automatico,
													CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
				 VALUES	(@NomeBolao, 1, @UserName, @NomeTimeGanhador, 0, 0, GETDATE(), 1, @CurrentLogin, GetDate(), @CurrentLogin, GETDATE(), 0)			
			
			END
			--Se o usuário já fez a sua aposta
			ELSE
			BEGIN
			
				UPDATE ApostasExtrasUsuarios 
				   SET  NomeTime		= @NomeTimeGanhador,
						ModifiedBy		= @CurrentLogin,
						ModifiedDate	= GetDate(),
						DataAposta		= GETDATE(),
						Automatico      = 1
				 WHERE NomeBolao		= @NomeBolao
				   AND UserName			= @UserName
				   AND Posicao			= 1
			
			END
		END
		
		
		
		-- Se existe a aposta do terceiro lugar a ser computada
		IF (EXISTS(SELECT * FROM ApostasExtras WHERE Posicao = 2 AND NomeBolao = @NomeBolao))
		BEGIN
		
			
			PRINT 'Buscando o segundo lugar do usuário'
		
			--Se o usuário ainda não fez a sua aposta
			IF (NOT EXISTS(SELECT * 
						 FROM ApostasExtrasUsuarios 
						WHERE Posicao		= 2 
						  AND NomeBolao		= @NomeBolao 
						  AND UserName		= @UserName))
			BEGIN
			
				INSERT INTO ApostasExtrasUsuarios (NomeBolao, Posicao, UserName, NomeTime, IsApostaValida, Pontos, DataAposta, Automatico,
													CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
				 VALUES	(@NomeBolao, 2, @UserName, @NomeTimePerdedor, 0, 0, GETDATE(), 1, @CurrentLogin, GetDate(), @CurrentLogin, GETDATE(), 0)			
			
			END
			--Se o usuário já fez a sua aposta
			ELSE
			BEGIN
			
				UPDATE ApostasExtrasUsuarios 
				   SET  NomeTime		= @NomeTimePerdedor,
						ModifiedBy		= @CurrentLogin,
						ModifiedDate	= GetDate(),
						DataAposta		= GETDATE(),
						Automatico      = 1
				 WHERE NomeBolao		= @NomeBolao
				   AND UserName			= @UserName
				   AND Posicao			= 2
			
			END
		END
		
		
		
		
	END

END


GO

