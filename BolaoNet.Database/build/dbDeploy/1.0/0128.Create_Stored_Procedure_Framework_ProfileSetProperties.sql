IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ProfileSetProperties')
BEGIN
	DROP  Procedure  Framework_ProfileSetProperties
END
GO
CREATE PROCEDURE [dbo].[Framework_ProfileSetProperties]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@PropertyNames						ntext,
    @PropertyValuesString				ntext,
    @PropertyValuesBinary				image,
    @IsUserAnonymous					bit,    
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	 
	DECLARE @CurrentTimeUtc         datetime 
	SET @CurrentTimeUtc				= GetDate()
	

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
    		

    DECLARE @UserId					uniqueidentifier
    DECLARE @LastActivityDate		datetime
    SELECT  @UserId					= NULL
    SELECT  @LastActivityDate		= @CurrentTimeUtc


    UPDATE [Users]
    SET    LastActivityDate	=	@CurrentTimeUtc
    WHERE  LOWER(UserName) = LOWER(@UserName)

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS( SELECT *
               FROM   [Profiles]
               WHERE  LOWER(UserName) = LOWER(@UserName)))
        UPDATE [Profiles]
        SET		PropertyNames			= @PropertyNames, 
				PropertyValuesString	= @PropertyValuesString,
				PropertyValuesBinary	= @PropertyValuesBinary, 
				LastUpdatedDate			= @CurrentTimeUtc
        WHERE  LOWER(Username) = LOWER(@UserName)
    ELSE
        INSERT INTO [Profiles]
             (
              UserName, 
              PropertyNames, 
              PropertyValuesString, 
              PropertyValuesBinary, 
              LastUpdatedDate
             )
             VALUES 
             (
              @UserName, 
              @PropertyNames, 
              @PropertyValuesString, 
              @PropertyValuesBinary, 
              @CurrentTimeUtc
             )

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
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

    RETURN @ErrorCode
	

    	
	RETURN -1
 
 
    
END




GO
