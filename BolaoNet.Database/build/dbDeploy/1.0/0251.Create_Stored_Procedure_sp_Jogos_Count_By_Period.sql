IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_Count_By_Period')
BEGIN
	DROP  Procedure  sp_Jogos_Count_By_Period
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_Count_By_Period]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@UserName							varchar(25),
	@NomeBolao							varchar(30),		
	@TypeAposta							smallint = 0, -- 0=Todos, 1=Não apostados, 2=Já Apostados
	@TypeAutomatico						smallint = 0, -- 0=Todos, 1=Automático, 2=Manual
	@DataInicial						datetime,
	@DataFinal							datetime,
	@Rodada								int,
	@Condition							nvarchar(1000) = null,	
	@TotalRows							int OUTPUT,	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT	
)
AS
BEGIN


	DECLARE @Execute		nvarchar(4000);
	DECLARE @i				int;

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SET @Execute = 
		'SELECT @i = Count(*) ' + CHAR(13) + 
		'  FROM Jogos ' + CHAR(13) + 
		'  LEFT JOIN JogosUsuarios ' + CHAR(13) + 
		'    ON Jogos.IDJogo			= JogosUsuarios.IDJogo ' + CHAR(13) + 
		'   AND Jogos.NomeCampeonato	= JogosUsuarios.NomeCampeonato ' +
		'	AND JogosUsuarios.NomeBolao	= ''' + @NomeBolao + '''' +
		'   AND JogosUsuarios.UserName = ''' + @UserName + '''' +
		' WHERE (Jogos.IsValido = 0 OR Jogos.IsValido IS NULL)  '
	



	IF (@DataInicial IS NOT NULL)
	BEGIN
		SET @Execute = @Execute + ' AND Jogos.DataJogo >= CONVERT(DATETIME, ''' + CONVERT(VARCHAR,@DataInicial) + ''')'
	END
	
	IF (@DataFinal IS NOT NULL)
	BEGIN
		IF (@DataInicial IS NOT NULL)
		BEGIN
			SET @Execute = @Execute + ' AND Jogos.DataJogo <= CONVERT(DATETIME, ''' + CONVERT(VARCHAR,@DataFinal) + ''')'
		END
		ELSE
		BEGIN		
			SET @Execute = @Execute + ' AND jogos.DataJogo <= CONVERT(DATETIME, ''' + CONVERT(VARCHAR,@DataFinal) + ''')'
		END
	END


	IF (@Rodada > 0)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL)
		BEGIN
			SET @Execute = @Execute + ' AND Jogos.Rodada = ' + CONVERT(VARCHAR, @Rodada)
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND Jogos.Rodada = ' + CONVERT(VARCHAR, @Rodada)
		END
	
	END
	
	
	IF (@TypeAposta = 1)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0)
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NULL '	
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NULL '	
		END
	END
	ELSE IF (@TypeAposta = 2)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0)
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL '	
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL '	
		END
	END


	IF (@TypeAutomatico = 1)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0 AND @TypeAposta = 0)
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL ' + 
				' AND JogosUsuarios.Automatico = 1 '			
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL ' + 
				' AND JogosUsuarios.Automatico = 1 '					
		END
				
	END
	ELSE IF (@TypeAutomatico = 2)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0 AND @TypeAposta = 0)
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL ' + 
				' AND JogosUsuarios.Automatico = 2 '			
		END
		ELSE
		BEGIN
			SET @Execute = @Execute + ' AND JogosUsuarios.UserName IS NOT NULL ' + 
				' AND JogosUsuarios.Automatico = 2 '					
		END
	END
	
	
	
	
	IF (@Condition IS NOT NULL AND LEN(@Condition) > 0)
	BEGIN
		IF (@DataInicial IS NULL AND @DataFinal IS NULL AND @Rodada = 0)
		BEGIN
			SET @Execute = @Execute + ' AND ' + @Condition
		END
		ELSE
		BEGIN		
			SET @Execute = @Execute + ' AND ' + @Condition
		END
	END
	

	EXEC SP_EXECUTESQL @Execute, N'@i int output', @i output

	SET @TotalRows = @i	

END



GO
