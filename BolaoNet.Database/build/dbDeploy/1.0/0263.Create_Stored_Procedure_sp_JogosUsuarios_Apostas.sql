IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Apostas')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Apostas
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Apostas]
(
    @CurrentLogin						varchar(25),
    @UserName							varchar(25) = null,
    @NomeBolao							varchar(30),
    @Rodada								int = 0,
    @DataInicial						datetime = null,
    @DataFinal							datetime = null,
	@ApplicationName					nvarchar(256) = null,
	@NomeTime							varchar(30) = null,
	@NomeFase							varchar(50) = null,
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


	DECLARE @NomeCampeonato varchar(50)
	
	SELECT @NomeCampeonato = NomeCampeonato FROM Boloes WHERE Nome = @NomeBolao


	
	SET @Execute = 
		'SELECT * ' + CHAR(13) + 
		'  FROM Jogos ' + CHAR(13) + 
		'  LEFT JOIN JogosUsuarios ' + CHAR(13) + 
		'    ON Jogos.IDJogo			= JogosUsuarios.IDJogo ' + CHAR(13) + 
		'   AND Jogos.NomeCampeonato	= JogosUsuarios.NomeCampeonato ' + CHAR(13) 
		
		
		
	IF (@UserName IS NOT NULL AND LEN(@UserName) > 0)
	BEGIN
		SET @Execute = @Execute + '   AND JogosUsuarios.UserName = ''' + @UserName + ''''
	END
		
	IF (@NomeBolao IS NOT NULL AND LEN(@NomeBolao) > 0)
	BEGIN
		SET @Execute = @Execute + '   AND JogosUsuarios.NomeBolao = ''' + @NomeBolao + ''''
	END
	
	SET @Execute = @Execute + ' WHERE Jogos.NomeCampeonato = ''' + @NomeCampeonato + ''''
	
	IF (@DataInicial IS NOT NULL AND @DataFinal IS NOT NULL)
	BEGIN
		SET @Execute = @Execute + ' AND Jogos.DataJogo >= CONVERT(DATETIME, ''' + CONVERT(VARCHAR, @DataInicial) + ''')' 
	
		IF (@DataInicial IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		
		SET @Execute = @Execute + ' Jogos.DataJogo <= CONVERT(DATETIME, ''' + CONVERT(VARCHAR, @DataFinal) + ''')'
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
		
		SET @Execute = @Execute + ' Jogos.Rodada = ' + CONVERT(VARCHAR, @Rodada)
	END
	
	
	IF (@NomeTime IS NOT NULL AND LEN(@NomeTime) > 0)
	BEGIN
		SET @Execute = @Execute + ' AND (Jogos.NomeTime1 = ''' + @NomeTime + ''' OR Jogos.NomeTime2 = ''' + @NomeTime + ''')'	
	END
	
	
	IF (@NomeFase IS NOT NULL AND LEN(@NomeFase) > 0)
	BEGIN
		SET @Execute = @Execute + ' AND Jogos.NomeFase = ''' + @NomeFase + ''''
	END
	
	
	IF (@NomeGrupo IS NOT NULL )
	BEGIN
		SET @Execute = @Execute + ' AND Jogos.NomeGrupo = ''' + @NomeGrupo + ''''
	END
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
	BEGIN
		IF (@DataFinal IS NULL AND @DataInicial IS NULL AND @Rodada = 0)
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND '
		END
	
		SET @Execute = @Execute + ' ' + @Condition
		
	END
	
	
	
	SET @Execute = @Execute + ' ORDER BY Jogos.DataJogo, Jogos.NomeFase, Jogos.Rodada  '
	
	EXEC (@Execute)


	RETURN 0

END



GO
