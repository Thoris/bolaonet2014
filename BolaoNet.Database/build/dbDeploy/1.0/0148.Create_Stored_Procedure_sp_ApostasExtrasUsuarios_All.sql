IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtrasUsuarios_All')
BEGIN
	DROP  Procedure  sp_ApostasExtrasUsuarios_All
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtrasUsuarios_All]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25) = null,
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
		'  FROM ApostasExtras ' + CHAR(13) + 
		'  LEFT JOIN ApostasExtrasUsuarios ' + CHAR(13) + 
		'    ON ApostasExtras.Posicao			= ApostasExtrasUsuarios.Posicao ' + CHAR(13) + 
		'   AND ApostasExtras.NomeBolao			= ApostasExtrasUsuarios.NomeBolao '
		

	IF (@UserName IS NOT NULL AND LEN(@UserName) > 0)
	BEGIN
		SET @Execute = @Execute + '   AND ApostasExtrasUsuarios.UserName = ''' + @UserName + ''''

	END
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
		SET @Execute = @Execute + ' WHERE ' + @Condition
		
	SET @Execute = @Execute + ' ORDER BY ApostasExtras.NomeBolao, ApostasExtras.Posicao '
	
	EXEC (@Execute)


	RETURN 0

END




GO
