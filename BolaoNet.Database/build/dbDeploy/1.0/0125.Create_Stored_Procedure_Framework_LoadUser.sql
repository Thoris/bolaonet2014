IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_LoadUser')
BEGIN
	DROP  Procedure  Framework_LoadUser
END
GO
CREATE PROCEDURE [dbo].[Framework_LoadUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT

)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	SELECT TOP 1 *
	  FROM Users 
	 WHERE LOWER(@UserName) = LOWER(UserName)
	 
	 RETURN (0)


END



GO
