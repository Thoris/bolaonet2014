IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ApproveUser')
BEGIN
	DROP  Procedure  Framework_ApproveUser
END
GO
CREATE PROCEDURE [dbo].[Framework_ApproveUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),	
    @Email								varchar(200),
    @ActivateKey						varchar(100),
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @ActivateKeyUser	varchar(100)
	SET @ActivateKeyUser = NULL

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
    SELECT  @ActivateKeyUser = ActivateKey
    FROM    Users
    WHERE   LOWER(UserName) = LOWER(@UserName) 

    IF ( @@ROWCOUNT = 0)
    BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
        RETURN 1

	END
	
	
	IF (@ActivateKeyUser <> @ActivateKey)
	BEGIN
		SET @ErrorNumber = 2
		SET @ErrorDescription = 'Activation Key is not valid'
		RETURN 2
	
	END
	ELSE
	BEGIN


		UPDATE Users
		SET	IsApproved		= 1,
			ApprovedBy		= @CurrentLogin,
			ApprovedDate	= GetDate()
		WHERE @UserName = UserName

		IF (@@ERROR <> 0)
		BEGIN
			SET @ErrorNumber = -1
			SET @ErrorDescription = 'Cannot approve the user'
			RETURN -1
		END
		
	END

    RETURN 0
END




GO
