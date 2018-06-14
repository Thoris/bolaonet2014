IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_All')
BEGIN
	DROP  Procedure  sp_BoloesMembros_All
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_All]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000)

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	
	SET @Execute = 
		'SELECT Boloes.*, BoloesMembros.UserName ' + CHAR(13) + 
		'  FROM BoloesMembros ' + CHAR(13) +
		' INNER JOIN Boloes ' + CHAR(13) + 
		'    ON Boloes.Nome = BoloesMembros.NomeBolao ' + CHAR(13) + 
		' WHERE UserName = ''' + @UserName + '''' + CHAR(13)
		
		--SET @Execute = @Execute + ' WHERE ' + @Condition

	--SET @Execute = @Execute + ' ORDER BY BoloesRequests.RequestedDate'

	
	EXEC (@Execute)


	RETURN 0

END




GO
