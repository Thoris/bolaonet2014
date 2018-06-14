IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_IsUserInRole')
BEGIN
	DROP  Procedure  Framework_IsUserInRole
END
GO
CREATE PROCEDURE [dbo].[Framework_IsUserInRole]
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
	
		SET @ErrorNumber = 2
		SET @ErrorDescription = 'User not found'
		
		RETURN 2
	
	END
	
	IF (NOT EXISTS(SELECT RoleName FROM Roles WHERE RoleName = @RoleName))
	BEGIN
	
		SET @ErrorNumber = 3
		SET @ErrorDescription = 'Role not found'
		
		RETURN 3
	
	END
	
	
	
 
	IF (NOT EXISTS(SELECT * FROM UsersInRoles WHERE RoleName = @RoleName AND UserName = @UserName))
	BEGIN
	
		SET @ErrorNumber = 0
		SET @ErrorDescription = 'User is not in role'
		
		RETURN -1
	
	END
	
	
	IF (@@Error > 0)
	BEGIN
		SET @ErrorNumber = -1
		SET @ErrorDescription = 'An error was found when trying to get user information.'
		
		RETURN -1
	
	END
	
	
	RETURN 1
	
    
END




GO
