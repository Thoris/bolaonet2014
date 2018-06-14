IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetAllUsers')
BEGIN
	DROP  Procedure  Framework_GetAllUsers
END
GO
CREATE PROCEDURE [dbo].[Framework_GetAllUsers]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@PageIndex							int,
    @PageSize							int,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

 

	
		---- Buscando os registro
		--SELECT * 
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row, 
		--			   *
		--		  FROM Users
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound
		  
		---- Buscando o total de registro
		--SELECT @TotalRecords = ISNULL(COUNT(*), 0)
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row
		--		  FROM Users
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound
		  	
	

		  
		  
		SELECT IDENTITY(INT, 1,1) AS Row, * 
		INTO #TMP
		  FROM Users
		 ORDER BY UserName
		 
		
		SELECT * FROM #TMP 
		 WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1	
	
	

		SELECT @TotalRecords
		  FROM #TMP
		  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
	

		DROP TABLE #TMP
		
	
	

    RETURN @TotalRecords
END




GO
