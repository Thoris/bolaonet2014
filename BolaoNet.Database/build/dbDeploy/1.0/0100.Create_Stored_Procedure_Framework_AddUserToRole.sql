IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_AddUserToRole')
BEGIN
	DROP  Procedure  Framework_AddUserToRole
END
GO
CREATE PROCEDURE [dbo].[Framework_AddUserToRole]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@RoleName							varchar(255),	
	@UserName							varchar(25),
	@Description						varchar(255),	    
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
 
	IF ((SELECT ISNULL(Count(*), 0) FROM UsersInRoles WHERE RoleName = @RoleName AND UserName = @UserName) > 0)
	BEGIN
		SET @ErrorNumber = 3
		SET @ErrorDescription = 'User is already in role'
		
		RETURN 3		
	
	END
 
 
 
	INSERT INTO UsersInRoles
		(
		RoleName,
		UserName,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag
		)
		VALUES
		(
		@RoleName,
		@UserName,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		)
		
 
 
 
	IF (@@ERROR > 0)
	BEGIN
		SET @ErrorNumber = -1
		SET @ErrorDescription = 'Error was raised'
		
		RETURN -1
	
	END
	

		RETURN 0
 
	
 
 
    
END




GO
