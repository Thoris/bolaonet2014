IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_UnlockUser')
BEGIN
	DROP  Procedure  Framework_UnlockUser
END
GO
CREATE PROCEDURE [dbo].[Framework_UnlockUser]
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
		SET @ErrorDescription = 'User is not found'
	    
        RETURN 1
    END

    UPDATE Users
    SET IsLockedOut = 0,
        FailedPasswordAttemptCount = 0,
        FailedPasswordAttemptWindowStart = NULL, --CONVERT( datetime, '17540101', 112 ),
        FailedPasswordAnswerAttemptCount = 0,
        FailedPasswordAnswerAttemptWindowStart = NULL, --CONVERT( datetime, '17540101', 112 ),
        LastLockoutDate = NULL --CONVERT( datetime, '17540101', 112 )
    WHERE LOWER(@UserName) = LOWER(UserName)

	IF (@@ERROR <> 0)
	BEGIN
		SET @ErrorNumber = -1
		SET @ErrorDescription = 'Error unlocking the user'
	
		RETURN -1
	END

    RETURN 0
END




GO
