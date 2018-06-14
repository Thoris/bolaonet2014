IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_DeleteUser')
BEGIN
	DROP  Procedure  Framework_DeleteUser
END
GO
CREATE PROCEDURE [dbo].[Framework_DeleteUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),	
    @DeleteAllRelatedData				bit,
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN


	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	DELETE 
	  FROM Users 
	 WHERE UserName = @UserName


END




GO
