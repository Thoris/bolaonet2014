IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Calcule_Grupo')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Calcule_Grupo
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Calcule_Grupo]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeBolao							varchar(30),	
	@UserName							varchar(25),			
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	
	

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	SET NOCOUNT ON


	--DECLARE @CurrentLogin		varchar(25)
	--DECLARE @NomeCampeonato		VARCHAR(50)
	--DECLARE @NomeGrupo			VARCHAR(20)
	--DECLARE @NomeFase			VARCHAR(30)
	--DECLARE @NomeBolao			VARCHAR(30)
	--DECLARE @UserName			VARCHAR(25)



	--SET @CurrentLogin	= 'thoris'
	--SET @NomeCampeonato = 'Copa do Mundo 2010'
	--SET @NomeBolao		= 'Copa do Mundo 2010'
	--SET @NomeFase		= 'Classificatória'
	--SET @NomeGrupo		= 'G'
	--SET @UserName		= 'thoris'




	DECLARE @NomeTime			VARCHAR(30)			-- Time do grupo
	DECLARE @Count				int					-- Posicao do time no grupo
	DECLARE @Pontos				int					-- Pontos do grupo

	DECLARE @IDJogo1			int					-- Identificação do jogo que existe dependencia
	DECLARE @IDJogo2			int					-- Identificação do jogo que existe dependencia

	-- Declarando o cursor do grupo
	DECLARE curClassificacao CURSOR FOR
	SELECT NomeTime, TotalPontos
	  FROM BoloesCampeonatosClassificacaoUsuarios
	 WHERE NomeCampeonato				= @NomeCampeonato
	   AND NomeGrupo					= @NomeGrupo
	   AND NomeFase						= @NomeFase
	   AND UserName						= @UserName
	 --ORDER BY TotalPontos DESC, TotalVitorias DESC, TotalGolsPro DESC
	 ORDER BY TotalPontos DESC, TotalGolsPro-TotalGolsContra DESC, TotalGolsPro DESC

	   
	-- Zerando o contador
	SET @Count = 0

	-- Abrindo o cursor
	OPEN curClassificacao
	FETCH NEXT FROM curClassificacao INTO @NomeTime, @Pontos

	-- Entrando no laço para analisar a posição do time
	WHILE @@FETCH_STATUS = 0
	BEGIN

		-- Indicando a posição do time
		SET @Count = @Count + 1
		
		SET @IDJogo1 = NULL
		SET @IDJogo2 = NULL

		PRINT '----------------------------------------------------------------'
		PRINT 'Posição: ' + CONVERT(VARCHAR, @Count) + ' - Time: ' + @NomeTime + ' - Pontos: ' + CONVERT(VARCHAR, @Pontos)


		------------------------------------------------------
		--- TIME 1
		------------------------------------------------------
		-- Buscando o jogo que possui dependencia do time 1
	   SELECT @IDJogo1 = IDJogo
		 FROM Jogos
		WHERE NomeCampeonato			= @NomeCampeonato
		  AND PendenteTime1NomeGrupo	= @NomeGrupo
		  AND PendenteTime1PosGrupo		= @Count
	   

		-- Se encontrou algum registro
		IF (@IDJOGO1 IS NOT NULL )
		BEGIN
			
			--PRINT 'Existe pendencia do time 1 para este grupo: ' + @NomeGrupo
			
			-- Se não existe o registro inserido
			IF (NOT EXISTS (SELECT * 
						  FROM JogosUsuarios
						 WHERE NomeCampeonato		= @NomeCampeonato
						   AND IDJogo				= @IDJogo1
						   AND NomeBolao			= @NomeBolao
						   AND UserName				= @UserName
						)
				)
			BEGIN
				-- Inserindo o registro automático
				PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @IDJogo1) + ' Para o time 1'
				
				INSERT JogosUsuarios 
					  (IDJogo, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, Automatico, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
				VALUES
					  (@IDJogo1, @NomeCampeonato, @UserName, @NomeBolao, @NomeTime, NULL, 1, @CurrentLogin, GetDate(), @CurrentLogin, GetDate())
					  
			
			END
			-- Se já existe o registro		
			ELSE
			BEGIN
			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IDJogo1) + ' Para o time 1'
				
				UPDATE JogosUsuarios
				   SET NomeTimeResult1	= @NomeTime				   
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND IDJogo				= @IDJogo1
				   AND UserName				= @UserName
				   AND NomeBolao			= @NomeBolao
				
			
			END -- endif jogos dos usuários
			
			
		
		END -- endif dependencia
					




		------------------------------------------------------
		--- TIME 2
		------------------------------------------------------
		-- Buscando o jogo que possui dependencia do time 1
	   SELECT @IDJogo2 = IDJogo
		 FROM Jogos
		WHERE NomeCampeonato			= @NomeCampeonato
		  AND PendenteTime2NomeGrupo	= @NomeGrupo
		  AND PendenteTime2PosGrupo		= @Count
	   

		-- Se encontrou algum registro
		IF (@IDJogo2 IS NOT NULL)
		BEGIN
			
			--PRINT 'Existe pendencia para este grupo: ' + @NomeGrupo + ' Para o time 2'
			
			-- Se não existe o registro inserido
			IF (NOT EXISTS (SELECT * 
						  FROM JogosUsuarios
						 WHERE NomeCampeonato		= @NomeCampeonato
						   AND IDJogo				= @IDJogo2
						   AND NomeBolao			= @NomeBolao
						   AND UserName				= @UserName
						)
				)
			BEGIN
				-- Inserindo o registro automático
				PRINT 'Inserindo o registro automático: ' + CONVERT(VARCHAR, @IDJogo2) + ' Para o time 2'
				
				INSERT JogosUsuarios 
					  (IDJogo, NomeCampeonato, UserName, NomeBolao, NomeTimeResult1, NomeTimeResult2, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
				VALUES
					  (@IDJogo2, @NomeCampeonato, @UserName, @NomeBolao, NULL, @NomeTime, @CurrentLogin, GetDate(), @CurrentLogin, GetDate())
					  
			
			END
			-- Se já existe o registro		
			ELSE
			BEGIN
			
				PRINT 'Atualizando registro da aposta: ' + CONVERT(VARCHAR, @IDJogo2) + ' Para o time 2'
				
				UPDATE JogosUsuarios
				   SET NomeTimeResult2 = @NomeTime
				 WHERE NomeCampeonato		= @NomeCampeonato
				   AND IDJogo				= @IDJogo2
				   AND UserName				= @UserName
				   AND NomeBolao			= @NomeBolao
				
			
			END -- endif jogos dos usuários
			
			
		
		END -- endif dependencia




		FETCH NEXT FROM curClassificacao INTO @NomeTime, @Pontos
	END

	CLOSE curClassificacao
	DEALLOCATE curClassificacao
	
	
	PRINT 'Termino da verificação do grupo ' + @NomeGrupo


END



GO
