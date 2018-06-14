IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_LoadAllUsers')
BEGIN
	DROP  Procedure  Framework_LoadAllUsers
END
GO
CREATE PROCEDURE [dbo].[Framework_LoadAllUsers]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SELECT * FROM Users ORDER BY UserName


		
	
	

    RETURN @@ROWCOUNT
END




GO
