IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_RoleExists')
BEGIN
	DROP  Procedure  Framework_RoleExists
END
GO
CREATE PROCEDURE [dbo].[Framework_RoleExists]
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
	
	DECLARE @TotalRows INT
	
	
	SELECT @TotalRows = ISNULL(Count(*), 0) 
	  FROM Roles 
	 WHERE RoleName = @RoleName
	
	
	
	RETURN @TotalRows
	
    
END




GO
