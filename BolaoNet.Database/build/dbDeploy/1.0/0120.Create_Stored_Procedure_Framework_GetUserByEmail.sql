IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetUserByEmail')
BEGIN
	DROP  Procedure  Framework_GetUserByEmail
END
GO
CREATE PROCEDURE [dbo].[Framework_GetUserByEmail]
(    
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@Email								varchar(200),	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
    IF( @Email IS NULL )
        SELECT  UserName
        FROM    Users
        WHERE   Email IS NULL
    ELSE
        SELECT  UserName
        FROM    Users
        WHERE   LOWER(@Email) = LOWER (Email)

    IF (@@rowcount = 0)
        RETURN(1)
    RETURN(0)
END




GO
