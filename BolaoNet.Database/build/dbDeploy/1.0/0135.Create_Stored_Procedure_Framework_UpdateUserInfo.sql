IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_UpdateUserInfo')
BEGIN
	DROP  Procedure  Framework_UpdateUserInfo
END
GO
CREATE PROCEDURE [dbo].[Framework_UpdateUserInfo]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@IsPasswordCorrect					bit,
    @UpdateLastLoginActivityDate		bit,
    @MaxInvalidPasswordAttempts			int,
    @PasswordAttemptWindow				int,
    @LastLoginDate						datetime,
    @LastActivityDate					datetime,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	DECLARE @CurrentTimeUtc							datetime
    DECLARE @IsApproved                             bit
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0
    
    SET @ErrorNumber = 0
    SET @ErrorDescription = NULL

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @IsApproved = m.IsApproved,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    Users m WITH ( UPDLOCK )
    WHERE   LOWER(@UserName) = LOWER (UserName)
    

    IF ( @@rowcount = 0 )
    BEGIN
    

		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
    
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
    

		SET @ErrorNumber = 0
		SET @ErrorDescription = 'User is locked'
    
        GOTO Cleanup
    END

    IF( @IsPasswordCorrect = 0 )
    BEGIN
        IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAttemptWindowStart ) )
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = 1
        END
        ELSE
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = @FailedPasswordAttemptCount + 1
        END

        BEGIN
            IF( @FailedPasswordAttemptCount >= @MaxInvalidPasswordAttempts )
            BEGIN
                SET @IsLockedOut = 1
                SET @LastLockoutDate = @CurrentTimeUtc
            END
        END
    END
    ELSE
    BEGIN
        IF( @FailedPasswordAttemptCount > 0 OR @FailedPasswordAnswerAttemptCount > 0 )
        BEGIN
            SET @FailedPasswordAttemptCount = 0
            SET @FailedPasswordAttemptWindowStart = NULL --CONVERT( datetime, '17540101', 112 )
            SET @FailedPasswordAnswerAttemptCount = 0
            SET @FailedPasswordAnswerAttemptWindowStart = NULL--CONVERT( datetime, '17540101', 112 )
            SET @LastLockoutDate = NULL --CONVERT( datetime, '17540101', 112 )
        END
    END

    IF( @UpdateLastLoginActivityDate = 1 )
    BEGIN
        UPDATE  Users
        SET     LastActivityDate = @LastActivityDate
        WHERE   LOWER(@UserName) = LOWER (UserName)

        IF( @@ERROR <> 0 )
        BEGIN
        

			SET @ErrorNumber = -1
			SET @ErrorDescription = 'Error updating user information'
        
            SET @ErrorCode = -1
            GOTO Cleanup
        END

        UPDATE  Users
        SET     LastLoginDate = @LastLoginDate
        WHERE   LOWER(@UserName) = LOWER (UserName)

        IF( @@ERROR <> 0 )
        BEGIN
        

			SET @ErrorNumber = -1
			SET @ErrorDescription = 'Error updating last login date'
        
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END


    UPDATE Users
    SET IsLockedOut = @IsLockedOut, 
		LastLockoutDate = @LastLockoutDate,
        FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
        FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
        FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
        FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
    WHERE LOWER(@UserName) = LOWER (UserName)

    IF( @@ERROR <> 0 )
    BEGIN
    

		SET @ErrorNumber = -1
		SET @ErrorDescription = 'Error Updating user information'
        
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

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
