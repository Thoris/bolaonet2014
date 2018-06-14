IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ResetPassword')
BEGIN
	DROP  Procedure  Framework_ResetPassword
END
GO
CREATE PROCEDURE [dbo].[Framework_ResetPassword]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@NewPassword						varchar(100),
    @MaxInvalidPasswordAttempts			int,
    @PasswordAttemptWindow				int,
    @PasswordFormat						int = 0,
    @PasswordAnswer						nvarchar(100) = NULL,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	DECLARE @CurrentTimeUtc							datetime
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime
    
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	SET @CurrentTimeUtc = GETDATE()
	
    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0


	IF (NOT EXISTS (
					SELECT * 
					  FROM Users
					 WHERE LOWER(UserName) = LOWER (@UserName)
				   ))
	BEGIN
	

		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
	
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    SELECT @IsLockedOut								= IsLockedOut,
           @LastLockoutDate							= LastLockoutDate,
           @FailedPasswordAttemptCount				= FailedPasswordAttemptCount,
           @FailedPasswordAttemptWindowStart		= FailedPasswordAttemptWindowStart,
           @FailedPasswordAnswerAttemptCount		= FailedPasswordAnswerAttemptCount,
           @FailedPasswordAnswerAttemptWindowStart	= FailedPasswordAnswerAttemptWindowStart
    FROM Users WITH ( UPDLOCK )
    WHERE LOWER(UserName) = LOWER(@UserName)

    IF( @IsLockedOut = 1 )
    BEGIN
    

		SET @ErrorNumber = 99
		SET @ErrorDescription = 'User is locked'
    
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    UPDATE Users
    SET    Password									= @NewPassword,
           LastPasswordChangedDate					= @CurrentTimeUtc,
           PasswordFormat							= @PasswordFormat
    WHERE  LOWER(UserName)							= LOWER(@UserName)
      AND ( 
			( @PasswordAnswer IS NULL OR LEN(@PasswordAnswer) = 0) 
			OR 
			( LOWER(PasswordAnswer) = LOWER(@PasswordAnswer ) ) 
		  )

    IF ( @@ROWCOUNT = 0 )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount		= 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount		= @FailedPasswordAnswerAttemptCount + 1
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END


			SET @ErrorNumber = 3
			SET @ErrorDescription = 'Password is invalid'

            SET @ErrorCode = 3
        END
    ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = NULL --CONVERT( datetime, '17540101', 112 )
            END
        END

    IF( NOT ( @PasswordAnswer IS NULL ) )
    BEGIN
        UPDATE Users
        SET IsLockedOut								= @IsLockedOut, 
			LastLockoutDate							= @LastLockoutDate,
            FailedPasswordAttemptCount				= @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart		= @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount		= @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart	= @FailedPasswordAnswerAttemptWindowStart
        WHERE LOWER(@UserName) = LOWER(UserName)

        IF( @@ERROR <> 0 )
        BEGIN
        

			SET @ErrorNumber = -1
			SET @ErrorDescription = 'Error Resetting the user'
        
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
		SET @TranStarted = 0
		COMMIT TRANSACTION
    END
    

    IF( @ErrorCode = 0 )
        SELECT @NewPassword as 'Password', @PasswordFormat as 'PasswordFormat', @IsLockedOut as 'IsLockedOut', @PasswordAnswer as 'PasswordAnswer'    
    

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END




GO
