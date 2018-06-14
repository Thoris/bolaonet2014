IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Campeonatos_LoadJogos')
BEGIN
	DROP  Procedure  sp_Campeonatos_LoadJogos
END
GO
CREATE PROCEDURE [dbo].[sp_Campeonatos_LoadJogos]
(
    @CurrentLogin						varchar(25),
    @ApplicationName					nvarchar(256) = null,
	@Rodada								int = 0,
    @DataInicial						datetime = null,
    @DataFinal							datetime = null,
	@NomeFase							varchar(30) = null, 
	@NomeCampeonato						varchar(50),
	@NomeGrupo							varchar(20) = null,
	@Condition							nvarchar(1000),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000);

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	
	SET @Execute = 
		'SELECT * ' + CHAR(13) + 
		'  FROM Jogos ' + CHAR(13) +
		' WHERE NomeCampeonato = ''' + @NomeCampeonato + ''''
		
	
	IF (@DataInicial IS NOT NULL)
	BEGIN
		SET @Execute = @Execute + ' AND DataJogo >= CONVERT(DATETIME, ''' + CONVERT(VARCHAR, @DataInicial) + ''')' 
	END	
	
	IF (@DataFinal IS NOT NULL)
	BEGIN
		IF (@DataInicial IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		
		SET @Execute = @Execute + ' DataJogo <= CONVERT(DATETIME, ''' + CONVERT(VARCHAR, @DataFinal) + ''')'
	END
		
	IF (@Rodada > 0)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		
		SET @Execute = @Execute + ' Rodada = ' + CONVERT(VARCHAR, @Rodada)
	END
	
	
	IF (@NomeFase IS NOT NULL)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0)
		BEGIN
			SET @Execute = @Execute + ' AND '	
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		
		SET @Execute = @Execute + ' NomeFase = ' + @NomeFase
	END
	
	
	IF (@NomeGrupo IS NOT NULL)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0 AND @NomeFase IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND '	
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		
		SET @Execute = @Execute + ' NomeGrupo = ' + @NomeGrupo
	END
	
	
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0 AND @NomeFase IS NULL AND @NomeGrupo IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
	
		SET @Execute = @Execute + ' ' + @Condition
		
	END
	
	
	
	SET @Execute = @Execute + ' ORDER BY DataJogo, NomeFase, Rodada  '
	
	EXEC (@Execute)


	RETURN 0

END



GO
