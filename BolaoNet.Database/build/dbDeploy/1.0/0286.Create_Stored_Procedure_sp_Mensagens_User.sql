IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_User')
BEGIN
	DROP  Procedure  sp_Mensagens_User
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_User]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000);

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	UPDATE Mensagens
	   SET TotalRead	= TotalRead + 1
	 WHERE ToUser		= @UserName
	   AND NomeBolao	= @NomeBolao


	
	SET @Execute = 
		'SELECT Mensagens.*, Users.FullName ' + CHAR(13) + 
		'  FROM Mensagens ' + CHAR(13) + 
		' INNER JOIN Users '+ CHAR(13) + 
		'    ON Users.UserName = Mensagens.FromUser ' + CHAR(13) +
		' WHERE Mensagens.ToUser = ''' + @UserName + '''' + CHAR(13) +
		'   AND Mensagens.NomeBolao = ''' + @NomeBolao + '''' 
		
		
	SET @Execute = @Execute + ' ORDER BY Mensagens.CreationDate'
	
	EXEC (@Execute)


	RETURN 0

END




GO
