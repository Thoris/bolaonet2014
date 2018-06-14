IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_DeleteInactiveProfiles')
BEGIN
	DROP  Procedure  Framework_DeleteInactiveProfiles
END
GO
CREATE PROCEDURE [dbo].[Framework_DeleteInactiveProfiles] 
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
    @ProfileAuthOptions					int,
    @InactiveSinceDate					datetime,     	
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

    SET @ErrorNumber = 0
    SET @ErrorDescription = NULL
    
	DELETE
    FROM    Profiles
    WHERE   (LastActivityDate <= @InactiveSinceDate)
      AND (
               (@ProfileAuthOptions = 2)
            OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
            OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)            
          )

    SELECT  @@ROWCOUNT    
    
    
	RETURN 0
END




GO
