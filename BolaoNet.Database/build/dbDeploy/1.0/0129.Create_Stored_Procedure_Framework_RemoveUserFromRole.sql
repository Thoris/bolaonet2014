IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_RemoveUserFromRole')
BEGIN
	DROP  Procedure  Framework_RemoveUserFromRole
END
GO
CREATE PROCEDURE [dbo].[Framework_RemoveUserFromRole]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@RoleName							varchar(255),	
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
 
	IF (NOT EXISTS(SELECT UserName FROM Users WHERE UserName = @UserName))
	BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
		
		RETURN 1	
	END
 
	IF (NOT EXISTS(SELECT RoleName FROM Roles WHERE RoleName = @RoleName))
	BEGIN
		SET @ErrorNumber = 2
		SET @ErrorDescription = 'Role was not found'
		
		RETURN 2	
	END
 
 
	DELETE 
	  FROM UsersInRoles
	 WHERE UserName		= @UserName
	   AND RoleName		= @RoleName
 
 
 
	IF (@@ERROR > 0)
	BEGIN
		SET @ErrorNumber = -1
		SET @ErrorDescription = 'Error was raised'
		
		RETURN -1
	
	END
	
 
	RETURN 0;
 
 
    
END




GO
