IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_ChangePasswordQuestionAndAnswer')
BEGIN
	DROP  Procedure  Framework_ChangePasswordQuestionAndAnswer
END
GO
CREATE PROCEDURE [dbo].[Framework_ChangePasswordQuestionAndAnswer] 
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@NewPasswordQuestion				varchar(200),
	@NewPasswordAnswer					varchar(100),
	@PasswordFormat						int		 = 0,	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	IF (NOT EXISTS(
					SELECT * 
					  FROM Users
					 WHERE LOWER(UserName)		= LOWER(@UserName)
				  ))
	BEGIN
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'User was not found'
		RETURN (1)
	END

    UPDATE Users
    SET    PasswordQuestion = @NewPasswordQuestion, PasswordAnswer = @NewPasswordAnswer
    WHERE  LOWER(UserName) = LOWER(@UserName)
    
    
    RETURN(0)
END



GO
