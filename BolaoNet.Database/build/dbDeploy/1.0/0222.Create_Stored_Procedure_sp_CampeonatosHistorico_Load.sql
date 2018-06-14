IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosHistorico_Load')
BEGIN
	DROP  Procedure  sp_CampeonatosHistorico_Load
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosHistorico_Load]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
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
		'  FROM Campeonatoshistorico ' + CHAR(13) + 
		' WHERE Nome = ''' + @NomeCampeonato + '''' + CHAR(13)
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
		SET @Execute = @Execute + ' WHERE ' + @Condition
	
	
	SET @Execute = @Execute + ' ORDER BY Ano'
	
	
	EXEC (@Execute)


	RETURN 0

END



GO
