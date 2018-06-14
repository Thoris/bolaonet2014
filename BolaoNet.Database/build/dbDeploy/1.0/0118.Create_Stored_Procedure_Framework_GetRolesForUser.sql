IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetRolesForUser')
BEGIN
	DROP  Procedure  Framework_GetRolesForUser
END
GO
CREATE PROCEDURE [dbo].[Framework_GetRolesForUser]
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
 
	
	SELECT *
	  FROM UsersInRoles
	 WHERE UserName = @UserName
	 ORDER BY RoleName
	
	
	
    
END




GO
