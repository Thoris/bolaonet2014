IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetProfiles')
BEGIN
	DROP  Procedure  Framework_GetProfiles
END
GO
CREATE PROCEDURE [dbo].[Framework_GetProfiles]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserNameToMatch					varchar(25),
	@AuthenticationOption				int,
	@UserInactiveSinceDate				DateTime,
	@PageIndex							int,
	@PageSize							int,
	@TotalRecords						int OUTPUT,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound	



	SELECT @TotalRecords = ISNULL(Count(*),0)
	  FROM [Profiles]
			 WHERE (@UserInactiveSinceDate IS NULL OR LastActivityDate <= @UserInactiveSinceDate)
			   AND (     (@AuthenticationOption = 2)
					  OR (@AuthenticationOption = 0 AND IsAnonymous = 1)
					  OR (@AuthenticationOption = 1 AND IsAnonymous = 0)
				   )
			   AND (@UserNameToMatch IS NULL OR LOWER(UserName) LIKE LOWER(@UserNameToMatch))
 

	
	--SELECT * 
	--  FROM (
	--		SELECT  ROW_NUMBER () OVER (ORDER BY UserName) AS Row, 
	--				ProfileID, UserName, IsAnonymous, LastActivityDate, LastUpdatedDate,
	--				(DATALENGTH(PropertyNames) + DATALENGTH(PropertyValuesString) + DATALENGTH(PropertyValuesBinary)) as size
	--		  FROM [Profiles]
	--		 WHERE (@UserInactiveSinceDate IS NULL OR LastActivityDate <= @UserInactiveSinceDate)
	--		   AND (     (@AuthenticationOption = 2)
	--				  OR (@AuthenticationOption = 0 AND IsAnonymous = 1)
	--				  OR (@AuthenticationOption = 1 AND IsAnonymous = 0)
	--			   )
	--		   AND (@UserNameToMatch IS NULL OR LOWER(UserName) LIKE LOWER(@UserNameToMatch))	 
	--	   ) as Subquery
	-- WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1		   
 
 
 
 
 --------------------------------------- TO FIX IT -----------------------------------
 
	--SELECT IDENTITY(INT, 1,1) AS Row, 
	--       ProfileID, UserName, IsAnonymous, LastActivityDate, LastUpdatedDate,
	--		(DATALENGTH(PropertyNames) + DATALENGTH(PropertyValuesString) + DATALENGTH(PropertyValuesBinary)) as size
	--  INTO #TMP
	--  FROM [Profiles]
	-- WHERE (@UserInactiveSinceDate IS NULL OR LastActivityDate <= @UserInactiveSinceDate)
	--   AND (     (@AuthenticationOption = 2)
	--		  OR (@AuthenticationOption = 0 AND IsAnonymous = 1)
	--		  OR (@AuthenticationOption = 1 AND IsAnonymous = 0)
	--	   )
	--   AND (@UserNameToMatch IS NULL OR LOWER(UserName) LIKE LOWER(@UserNameToMatch)) 
	-- ORDER BY UserName
			
	--SELECT *
	--  FROM #TMP
	-- WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1			 
			
 
	--DROP TABLE #TMP
 
 ----------------------------------------------------------------------------------------
 
 
 
 
	
	RETURN @@RowCount
 
 
    
END




GO
