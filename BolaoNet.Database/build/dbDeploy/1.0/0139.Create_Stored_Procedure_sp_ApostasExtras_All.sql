IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_All')
BEGIN
	DROP  Procedure  sp_ApostasExtras_All
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_All]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
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
		'  FROM ApostasExtras ' + CHAR(13)  
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
		SET @Execute = @Execute + ' WHERE ' + @Condition
		
	SET @Execute = @Execute + ' ORDER BY Posicao'
	
	EXEC (@Execute)


	RETURN 0

END





GO
