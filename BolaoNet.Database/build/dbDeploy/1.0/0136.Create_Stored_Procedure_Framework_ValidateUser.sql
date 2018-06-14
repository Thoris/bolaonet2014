IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ValidateUser')
BEGIN
	DROP  Procedure  Framework_ValidateUser
END
GO
CREATE PROCEDURE [dbo].[Framework_ValidateUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@password							varchar(100),
    @PasswordAttemptWindow				int,
    @maxInvalidPasswordAttempts			int,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	
	DECLARE @CurrentTimeUtc							datetime
    DECLARE @PasswordFormat                         int
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime	
	DECLARE @PasswordStored							nvarchar(256)
	DECLARE @IsApproved								bit
    DECLARE @ErrorCode								int	
    DECLARE @TranStarted							bit
    DECLARE @LastLoginDate							datetime
    
    
    SET @ErrorNumber = 0
    SET @ErrorDescription = NULL
	
	SET @CurrentTimeUtc = GETDATE ()	
    SET @ErrorCode = 0	
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0	
	
	
	
	-- Buscando os dados do usuário
    SELECT  @PasswordStored = m.Password,
            @PasswordFormat = m.PasswordFormat,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart,
            @LastLoginDate = m.LastLoginDate,
            @IsApproved = m.IsApproved
    FROM    Users m WITH ( UPDLOCK )
    WHERE   LOWER(@UserName) = LOWER (UserName)

	-- Se não encontrou nenhum usuário
    IF ( @@rowcount = 0 )
    BEGIN    

		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
        
        SET @ErrorCode = 1
        GOTO Cleanup
    END
    
    -- Se o usuário não está aprovado
    IF( @IsApproved = 0 )
    BEGIN    

		SET @ErrorNumber = 3
		SET @ErrorDescription = 'User is not approved'
        
        SET @ErrorCode = 3
        GOTO Cleanup
    END
    

	-- Se o usuário está bloqueado
    IF( @IsLockedOut = 1 )
    BEGIN
    
		SET @ErrorNumber = 4
		SET @ErrorDescription = 'User is locked'
    
        SET @ErrorCode = 4
        GOTO Cleanup
    END
	
	
	IF ( NOT( @PasswordStored IS NULL ) )
    BEGIN
        IF( ( @password IS NULL) OR (  @PasswordStored  <> @password  ) )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END


			SET @ErrorNumber = 2
			SET @ErrorDescription = 'Password is invalid'

            SET @ErrorCode = 2
        END
        ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = NULL --CONVERT( datetime, '17540101', 112 )
                SET @LastLoginDate = @CurrentTimeUtc
            END
        END

        UPDATE Users
        SET IsLockedOut = @IsLockedOut, 
			LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart,
            LastLoginDate = @LastLoginDate
        WHERE LOWER(UserName) = LOWER(@UserName)

        IF( @@ERROR <> 0 )
        BEGIN
        

			SET @ErrorNumber = -1
			SET @ErrorDescription = 'Error updating user information'
        
            SET @ErrorCode = -1
            GOTO Cleanup
        END        
    END

    
    

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

  --  IF( @ErrorCode = 0 )
  --      SELECT @Password, @PasswordFormat
        
  --  IF (@@ERROR > 0)
		--RETURN @@ERROR

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
