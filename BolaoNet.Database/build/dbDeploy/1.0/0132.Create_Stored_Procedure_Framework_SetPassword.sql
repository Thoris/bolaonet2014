IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_SetPassword')
BEGIN
	DROP  Procedure  Framework_SetPassword
END
GO
CREATE PROCEDURE [dbo].[Framework_SetPassword]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@NewPassword						varchar(100),
    @PasswordFormat						int = 0,     
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	DECLARE @CurrentTimeUtc   datetime
	SET @CurrentTimeUtc=GetDate()
    

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	    
    
    SELECT  *
    FROM    Users
    WHERE   LOWER (UserName) = LOWER(@UserName) 

    IF (@@ROWCOUNT = 0)
    BEGIN
    
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User is not found'
        
        RETURN(1)
    END

    UPDATE Users
    SET Password = @NewPassword, 
		PasswordFormat = @PasswordFormat, 
		LastPasswordChangedDate = @CurrentTimeUtc
    WHERE LOWER(UserName)= LOWER(@UserName)
    
    
    RETURN(0)
END




GO
