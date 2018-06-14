IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetUsersInRole')
BEGIN
	DROP  Procedure  Framework_GetUsersInRole
END
GO
CREATE PROCEDURE [dbo].[Framework_GetUsersInRole]
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
 
	
	SELECT * 
	  FROM UsersInRoles
	 WHERE RoleName = @RoleName
	 ORDER BY UserName
	
    
END




GO
