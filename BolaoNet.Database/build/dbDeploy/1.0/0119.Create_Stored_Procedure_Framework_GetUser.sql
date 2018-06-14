IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetUser')
BEGIN
	DROP  Procedure  Framework_GetUser
END
GO
CREATE PROCEDURE [dbo].[Framework_GetUser]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@UpdateLastActivity					bit,
	@UserIsOnline						bit,
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SELECT TOP 1 * 
	  FROM Users
	 WHERE LOWER(@UserName)		=	UserName


END




GO
