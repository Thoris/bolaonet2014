IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_DesapproveUser')
BEGIN
	DROP  Procedure  Framework_DesapproveUser
END
GO
CREATE PROCEDURE [dbo].[Framework_DesapproveUser]
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
        SET @ErrorDescription = 'User was not found'
        RETURN 1
	END

    UPDATE Users
    SET IsApproved = 0
    WHERE LOWER(@UserName) = LOWER(UserName)

	IF (@@ERROR <> 0)
	BEGIN
	
        SET @ErrorNumber = -1
        SET @ErrorDescription = 'Error desapproving the user'
        
		RETURN -1
	END


    RETURN 0
END




GO
