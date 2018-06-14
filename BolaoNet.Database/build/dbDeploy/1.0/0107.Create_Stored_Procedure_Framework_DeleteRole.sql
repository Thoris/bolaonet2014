IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_DeleteRole')
BEGIN
	DROP  Procedure  Framework_DeleteRole
END
GO
CREATE PROCEDURE [dbo].[Framework_DeleteRole]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@RoleName							varchar(255),	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
 
	IF (NOT EXISTS (SELECT * FROM Roles WHERE RoleName = @RoleName))
	BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'Role was not found'
		
		RETURN 1	
	END
 
 
	IF ((SELECT ISNULL(COUNT(*), 0) FROM UsersInRoles WHERE RoleName = @RoleName) > 0)
	BEGIN
		SET @ErrorNumber = 2
		SET @ErrorDescription = 'There is a user assigned to this role'
		
		RETURN 2
	END
 
	DELETE 
	  FROM Roles 
	 WHERE RoleName = @RoleName
 
 
 
		 
	IF (@@ERROR > 0)
	BEGIN
		SET @ErrorNumber = @@Error
		SET @ErrorDescription = 'Error raised when deleting the role.'
		
		RETURN -1
	END
	
	RETURN 0
 
 
    
END




GO
