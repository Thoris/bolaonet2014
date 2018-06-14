IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_FindUsersByEmail')
BEGIN
	DROP  Procedure  Framework_FindUsersByEmail
END
GO
CREATE PROCEDURE [dbo].[Framework_FindUsersByEmail]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@EmailToMatch						varchar(200),
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

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
	IF (@EmailToMatch IS NULL)
	BEGIN
	
		-- Buscando os registro
		--SELECT * 
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row, 
		--			   *
		--		  FROM Users
		--		 WHERE Email IS NULL
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
		  
		  
		  
		  
		SELECT IDENTITY(INT, 1,1) AS Row, * 
		INTO #TMP
		  FROM Users
		 WHERE Email IS NULL
		 ORDER BY UserName
		 
		
		SELECT * FROM #TMP 
		 WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1

		  
		  
		  
		-- Buscando o total de registro
		--SELECT @TotalRecords = ISNULL(COUNT(*), 0)
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row
		--		  FROM Users
		--		 WHERE Email IS NULL
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
		  
		  
		  
		SELECT @TotalRecords
		  FROM #TMP
		  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
	

		DROP TABLE #TMP
	
		  
		  
	END
	ELSE
	BEGIN
	
		-- Buscando os registro
		--SELECT * 
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row, 
		--			   *
		--		  FROM Users
		--		 WHERE Email like  @EmailToMatch + '%'
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
		  
		  
		SELECT IDENTITY(INT, 1,1) AS Row, * 
		INTO #TMP2
		  FROM Users
		 WHERE Email like  @EmailToMatch + '%'
		 ORDER BY UserName
		  
		
		SELECT * 
		  FROM #TMP2		 
		 WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
		  
		  
		  
		  
		  
		-- Buscando o total de registro
		--SELECT @TotalRecords = ISNULL(COUNT(*), 0)
		--  FROM (
		--		SELECT ROW_NUMBER ()
		--			   OVER (ORDER BY UserName) AS Row
		--		  FROM Users
		--		 WHERE Email like @EmailToMatch + '%'
		--	   ) AS SubQuery
		--  WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
		  	
		SELECT @TotalRecords = ISNULL(COUNT(*), 0)
		  FROM #TMP2		 
		 WHERE Row BETWEEN @PageLowerBound AND @PageUpperBound + 1
	
	
		DROP TABLE #TMP2

	
	END
 
 
		  
	
    RETURN @TotalRecords
END




GO
