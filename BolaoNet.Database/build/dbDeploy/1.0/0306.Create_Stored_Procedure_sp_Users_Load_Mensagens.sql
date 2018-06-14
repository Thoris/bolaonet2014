IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Users_Load_Mensagens')
BEGIN
	DROP  Procedure  sp_Users_Load_Mensagens
END
GO
CREATE PROCEDURE [dbo].[sp_Users_Load_Mensagens]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SELECT *
	  FROM Mensagens
	 WHERE ToUser = @UserName
	   AND TotalRead = 0
	 
	  
	 

	RETURN @@RowCount

END



GO
