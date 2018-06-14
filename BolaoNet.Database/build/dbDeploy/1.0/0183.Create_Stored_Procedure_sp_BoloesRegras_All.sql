IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRegras_All')
BEGIN
	DROP  Procedure  sp_BoloesRegras_All
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRegras_All]
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
		'SELECT * FROM BoloesRegras '
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
		SET @Execute = @Execute + ' WHERE ' + @Condition
		
	SET @Execute = @Execute + ' ORDER BY RegraID'
	
	EXEC (@Execute)


	RETURN 0

END




GO
