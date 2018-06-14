IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_All')
BEGIN
	DROP  Procedure  sp_Mensagens_All
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_All]
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
		'SELECT Mensagens.*, Users.FullName ' + CHAR(13) + 
		'  FROM Mensagens ' + CHAR(13) + 
		' INNER JOIN Users '+ CHAR(13) + 
		'    ON Users.UserName = Mensagens.FromUser '
		
	IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
		SET @Execute = @Execute + ' WHERE ' + @Condition
		
	SET @Execute = @Execute + ' ORDER BY Mensagens.CreationDate'
	
	EXEC (@Execute)


	RETURN 0

END




GO
