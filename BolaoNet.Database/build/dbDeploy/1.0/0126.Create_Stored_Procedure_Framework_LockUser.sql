IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_LockUser')
BEGIN
	DROP  Procedure  Framework_LockUser
END
GO
CREATE PROCEDURE [dbo].[Framework_LockUser]
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
 
 
    SELECT  *
    FROM    Users
    WHERE   LOWER(UserName) = LOWER(@UserName) 

    IF ( @@ROWCOUNT = 0)
    BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
    
        RETURN 1
	END


    UPDATE Users
    SET IsLockedOut = 1,
        LastLockoutDate = GetDate()
    WHERE LOWER(@UserName) = LOWER(UserName)

	IF (@@ERROR <> 0)
	BEGIN
		SET @ErrorNumber = -1
		SET @ErrorDescription = 'Cannot Lock the user'
	
		RETURN -1
	END

    RETURN 0
END




GO
