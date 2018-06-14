IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ChangePassword')
BEGIN
	DROP  Procedure  Framework_ChangePassword
END
GO
CREATE PROCEDURE [dbo].[Framework_ChangePassword] 
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@Password							varchar(100),
	@OldPassword						varchar(100),	
    @PasswordFormat						int		 = 0,	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @CurrentTimeUtc							datetime
    
    SET @CurrentTimeUtc = GetDate()
    
    SET @ErrorNumber = 0
    SET @ErrorDescription = NULL
    

	DECLARE @PasswordUser varchar(100)
	
	SELECT @PasswordUser = Password
	  FROM Users 
	 WHERE LOWER(UserName) = LOWER(@UserName)
	 
	 
	IF (@@RowCount <> 1)
	BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found.'
		
		RETURN 1	
	END


	IF (@PasswordUser <> @OldPassword)
	BEGIN
		SET @ErrorNumber = 2
		SET @ErrorDescription = 'User''s pasword is invalid.'
		
		RETURN 2	
	END



	UPDATE Users
	   SET LastPasswordChangedDate		= @CurrentTimeUtc,
	       Password						= @Password
	 WHERE LOWER(UserName) = LOWER(@UserName)
	

	RETURN 0
END




GO
