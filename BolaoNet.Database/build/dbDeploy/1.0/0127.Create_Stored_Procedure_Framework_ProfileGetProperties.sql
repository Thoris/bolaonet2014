IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ProfileGetProperties')
BEGIN
	DROP  Procedure  Framework_ProfileGetProperties
END
GO
CREATE PROCEDURE [dbo].[Framework_ProfileGetProperties]
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
	
	SELECT TOP 1 PropertyNames, PropertyValuesString, PropertyValuesBinary
	  FROM [Profiles]
	 WHERE LOWER(UserName) = LOWER(@UserName)
	 
	 
    IF (@@ROWCOUNT > 0)
    BEGIN
        UPDATE [Users]
        SET    LastActivityDate=GetDate()
        WHERE  UserName = @UserName
        
        UPDATE [Profiles]
        SET	   LastActivityDate=GetDate()
        WHERE  UserName = @UserName        
    END	 
	 
	 

    	
	RETURN 0
 
 
    
END




GO
