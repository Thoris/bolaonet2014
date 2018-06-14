IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetPasswordWithFormat')
BEGIN
	DROP  Procedure  Framework_GetPasswordWithFormat
END
GO
CREATE PROCEDURE [dbo].[Framework_GetPasswordWithFormat]
(
	@CurrentLogin						varchar(25),	
    @ApplicationName					nvarchar(256),
    @UserName							varchar(25),
	@UpdateLastLoginActivityDate		bit,	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
	DECLARE @CurrentTimeUtc						datetime
    DECLARE @IsLockedOut                        bit
    DECLARE @Password                           nvarchar(128)
    DECLARE @PasswordFormat                     int
    DECLARE @FailedPasswordAttemptCount         int
    DECLARE @FailedPasswordAnswerAttemptCount   int
    DECLARE @IsApproved                         bit
    DECLARE @LastActivityDate                   datetime
    DECLARE @LastLoginDate                      datetime



	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL


    SELECT  @IsLockedOut						= IsLockedOut, 
			@Password							= Password, 
			@PasswordFormat						= PasswordFormat,
            @FailedPasswordAttemptCount			= FailedPasswordAttemptCount,
		    @FailedPasswordAnswerAttemptCount	= FailedPasswordAnswerAttemptCount, 
		    @IsApproved							= IsApproved,
            @LastActivityDate					= LastActivityDate, 
            @LastLoginDate						= LastLoginDate
    FROM    Users 
    WHERE   LOWER(@UserName)					= LOWER(UserName)

    IF (@@ROWCOUNT = 0)
    BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
    
        RETURN 1
	END

    IF (@IsLockedOut = 1)
    BEGIN
		SET @ErrorNumber = 99
		SET @ErrorDescription = 'User is locked'
        
        RETURN 99
	END



    SELECT  @Password as Password, 
			@PasswordFormat as PasswordFormat, 
			@FailedPasswordAttemptCount as FailedPasswordAttemptCount,
            @FailedPasswordAnswerAttemptCount as FailedPasswordAnswerAttemptCount, 
            @IsApproved as IsApproved, 
            @LastLoginDate as LastLoginDate, 
            @LastActivityDate as LastActivityDate,
            @IsLockedOut as IsLockedOut

    IF (@UpdateLastLoginActivityDate = 1 AND @IsApproved = 1)
    BEGIN
        UPDATE  Users
        SET     LastLoginDate		= @CurrentTimeUtc
        WHERE   LOWER(UserName)		= LOWER(@UserName)
    END


    RETURN 0
END




GO
