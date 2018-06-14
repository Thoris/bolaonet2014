IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_SelectByPeriod')
BEGIN
	DROP  Procedure  sp_Jogos_SelectByPeriod
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_SelectByPeriod]
(
    @CurrentLogin						varchar(25),
    @ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
    @Rodada								int = 0,
    @DataInicial						datetime = null,
    @DataFinal							datetime = null,
	@NomeTime							varchar(30) = null,
	@NomeFase							varchar(50) = null,
	@NomeGrupo							varchar(20) = null,
	@Condition							nvarchar(1000),
	@Order								nvarchar(1000) = null,
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
		'  FROM Jogos ' + 
		' WHERE NomeCampeonato = ''' + @NomeCampeonato + ''''
		
		
		
	
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
	
	
	DECLARE @OrderItems varchar(1000)
	
	SET @OrderItems = @Order
	
	IF (@Order IS NULL OR LEN(@Order) = 0)
	BEGIN
		SET @OrderItems = ' Jogos.DataJogo, Jogos.NomeFase, Jogos.Rodada  '
	
	END
	
	
	
	SET @Execute = @Execute + ' ORDER BY ' + @OrderItems
	
	EXEC (@Execute)


	RETURN 0

END



GO
