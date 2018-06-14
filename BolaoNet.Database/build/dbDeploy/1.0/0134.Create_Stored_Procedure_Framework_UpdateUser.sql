IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_UpdateUser')
BEGIN
	DROP  Procedure  Framework_UpdateUser
END
GO
CREATE PROCEDURE [dbo].[Framework_UpdateUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@Email								varchar(200),
    @Comment							varchar(4000),
    @IsApproved							bit,
    @LastLoginDate						datetime,
    
    
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
	@ActivateKey						varchar(100),   
	@ReceiveEmails						bit, 
	
	@PostalCode							varchar(20),
	@IDMaritalStatus					int,
    
    
    @UniqueEmail						int,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
    DECLARE @CurrentTimeUtc       datetime
	SET @CurrentTimeUtc = GETDATE ()
	
	DECLARE @LastActivityDate     datetime
	SET @LastActivityDate = GETDATE ()		
	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
    

    SELECT  *
    FROM    Users
    WHERE   LOWER(UserName) = LOWER(@UserName) 

    IF (@@ROWCOUNT = 0)
	BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User is not found'
		RETURN(1)
	END

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  Users WITH (UPDLOCK, HOLDLOCK)
                    WHERE LOWER(Email) = LOWER(@Email)))
        BEGIN
			SET @ErrorNumber = 7
			SET @ErrorDescription = 'There is an user with the same email'
            RETURN(7)
        END
    END

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    UPDATE Users WITH (ROWLOCK)
    SET
         Email				= @Email,
         [Comments]			= @Comment,
         IsApproved			= @IsApproved,
         LastLoginDate		= @LastLoginDate,
         LastActivityDate	= @LastActivityDate,
         
		 FullName			= @FullName,
		 BirthDate			= @BirthDate,
		 Male				= @Male,
		 CellPhone			= @CellPhone,
		 PhoneNumber		= @PhoneNumber,
		 CompanyPhone		= @CompanyPhone,
		 City				= @City,
		 Country			= @Country,
		 State				= @State,
		 Street				= @Street,
		 StreetNumber		= @StreetNumber,
		 CPF				= @CPF,
		 RG					= @RG,
		 MSN				= @MSN,
		 Skype				= @Skype,
		 --ActivateKey		= @ActivateKey,
		 ReceiveEmails		= @ReceiveEmails,
		 IDMaritalStatus	= @IDMaritalStatus,
		 PostalCode			= @PostalCode
         
         
    WHERE
       LOWER(UserName) = LOWER(@UserName)

    IF( @@ERROR <> 0 )
    BEGIN
		SET @ErrorNumber = @@ERROR
		SET @ErrorDescription = 'Could not update the user in database.'
        GOTO Cleanup
	END
	

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN -1
END




GO
