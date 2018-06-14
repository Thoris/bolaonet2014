IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetNumberOfUsersOnline')
BEGIN
	DROP  Procedure  Framework_GetNumberOfUsersOnline
END
GO
CREATE PROCEDURE [dbo].[Framework_GetNumberOfUsersOnline]
(
	@CurrentLogin						varchar(25),	
    @ApplicationName					nvarchar(256),
    @MinutesSinceLastInActive			int,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN
    DECLARE @DateActive datetime
    SELECT  @DateActive = DATEADD(minute,  -(@MinutesSinceLastInActive), GETDATE())

    DECLARE @NumOnline int
    
    
    SELECT  @NumOnline = COUNT(*)
    FROM    Users u(NOLOCK)
    WHERE   LastActivityDate > @DateActive
    
            
    RETURN(@NumOnline)
END




GO
