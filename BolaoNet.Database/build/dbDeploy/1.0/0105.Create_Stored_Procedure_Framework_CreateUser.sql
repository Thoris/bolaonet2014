IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_CreateUser')
BEGIN
	DROP  Procedure  Framework_CreateUser
END
GO
CREATE PROCEDURE [dbo].[Framework_CreateUser]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@FullName							varchar(100),
	@BirthDate							datetime,
	@Male								bit,
	@CellPhone							varchar(20),
	@PhoneNumber						varchar(20),
	@CompanyPhone						varchar(20),
	@City								varchar(50),	
	@Country							varchar(25),
	@State								varchar(30),
	@Street								varchar(50),
	@StreetNumber						int,
	@CPF								varchar(20),
	@RG									varchar(20),
	@MSN								varchar(100),
	@Skype								varchar(100),
	@Email								varchar(200),
	@IDMaritalStatus					int,
	@PostalCode							varchar(20),
	@IsApproved							bit, 
	@IsLockedOut						bit,
	@PasswordQuestion					varchar(200),
	@PasswordAnswer						varchar(100),
	@Password							varchar(100),
	@UniqueEmail                        int      = 0,
    @PasswordFormat						int		 = 0,
    @ActivateKey						varchar(100),
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
	
	
)
AS
BEGIN

	DECLARE @TranStarted								bit
    DECLARE @NewUserName								varchar(20)    
    DECLARE @ErrorCode									int
    DECLARE @NewUserCreated								bit
    DECLARE @CurrentTimeUtc								datetime
    
    
	DECLARE @FailedPasswordAttemptCount					int
    DECLARE @FailedPasswordAnswerAttemptCount			int
        
    
    SET @ErrorNumber								= 0
    SET @ErrorDescription							= NULL
	
	SET @CurrentTimeUtc								= GetDate()   
    SET @IsLockedOut								= 0
    SET @FailedPasswordAttemptCount					= 0
    SET @FailedPasswordAnswerAttemptCount			= 0
    SET @ErrorCode									= 0
    SET @TranStarted								= 0

	
	
	
    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0	
	
	
    SELECT @NewUserName = UserName
      FROM Users 
     WHERE LOWER(@UserName) = LOWER(UserName)	
	
	
	
	IF ( @NewUserName IS NULL )
    BEGIN
        SET @NewUserName = @UserName
        
        
        IF (@UniqueEmail = 1)
		BEGIN
			IF (EXISTS (SELECT *
						  FROM  Users m WITH ( UPDLOCK, HOLDLOCK )
						 WHERE LOWER(Email) = LOWER(@Email)))
			BEGIN        
				-- Duplicate email
				SET @ErrorCode = 7
				SET @ErrorDescription = 'User has duplicated email'
				GOTO Cleanup
			END
		END
        
        
		INSERT INTO Users
					(
						UserName, 
						FullName,
						BirthDate,
						Male,
						CellPhone,
						PhoneNumber,
						CompanyPhone,
						City,
						Country,
						State,
						Street,
						StreetNumber,
						CPF,
						RG,
						MSN,
						Skype,
						Email,
						IsApproved,
						IsLockedOut,
						PasswordQuestion,
						PasswordFormat,
						PasswordAnswer,
						Password,
						FailedPasswordAttemptCount,
						FailedPasswordAnswerAttemptCount,
						ActivateKey,
						PostalCode,
						IDMaritalStatus,
						CreatedBy,
						CreatedDate,
						ModifiedBy,
						ModifiedDate,
						RequestedBy,
						RequestedDate									
					)
			VALUES
					(
						@UserName, 
						@FullName,
						@BirthDate,
						@Male,
						@CellPhone,
						@PhoneNumber,
						@CompanyPhone,
						@City,
						@Country,
						@State,
						@Street,
						@StreetNumber,
						@CPF,
						@RG,
						@MSN,
						@Skype,
						@Email,
						@IsApproved,
						@IsLockedOut,
						@PasswordQuestion,
						@PasswordFormat,
						@PasswordAnswer,
						@Password,
						@FailedPasswordAttemptCount,
						@FailedPasswordAnswerAttemptCount,
						@ActivateKey,
						@PostalCode,
						@IDMaritalStatus,
						@CurrentLogin, 
						@CurrentTimeUtc,
						@CurrentLogin,
						@CurrentTimeUtc,
						@CurrentLogin,
						@CurrentTimeUtc				
					)		
		
					

		IF( @@ERROR <> 0 )
		BEGIN
			SET @ErrorCode = -1
			SET @ErrorDescription = 'Error inserting the user into the database.'
			GOTO Cleanup
		END        
        
               
        SET @NewUserCreated = 1
    END	
    ELSE
    BEGIN
        SET @NewUserCreated = 0
         
        IF( LEN(@NewUserName) > 0)
        BEGIN
        
			-- Duplicate user name
            SET @ErrorCode = 6
            SET @ErrorDescription = 'Login is already existing.'
            GOTO Cleanup
        END
    END

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        SET @ErrorDescription = 'Error inserting the user.'
        GOTO Cleanup
    END


    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END
    
    SET @ErrorNumber = 0
    SET @ErrorDescription = NULL

    RETURN 0	
    
Cleanup:

	-- Se existe ação a ser executada
    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END
    
    SET @ErrorNumber = @ErrorCode

    RETURN @ErrorCode
	

END



GO
