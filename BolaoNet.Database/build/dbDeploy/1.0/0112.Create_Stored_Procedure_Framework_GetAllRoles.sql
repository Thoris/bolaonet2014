IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetAllRoles')
BEGIN
	DROP  Procedure  Framework_GetAllRoles
END
GO
CREATE PROCEDURE [dbo].[Framework_GetAllRoles]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
	SELECT * 
	  FROM Roles
	 ORDER BY RoleName
 
    
END




GO
