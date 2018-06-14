IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Select_Count')
BEGIN
	DROP  Procedure  sp_Select_Count
END
GO
CREATE PROCEDURE [dbo].[sp_Select_Count] 
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,		
	@From								nvarchar(1000),
	@Where								nvarchar(1000),
	@TotalRows							int OUTPUT,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT	
)
AS
BEGIN



	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	
	
	
	DECLARE @i int

	SET @i = 0

	SET NOCOUNT ON;

	DECLARE @Execute		nvarchar(4000);		
	
	SET @Execute = 'SELECT @i = Count(*) ' + CHAR(13) + 
		'  FROM ' + @From + CHAR(13) 

	IF (@Where IS NOT NULL AND LEN(RTrim(LTrim((@Where)))) > 0)
	BEGIN
		SET @Execute = @Execute +  '         WHERE ' + @Where + CHAR(13) 
	END 

	EXEC SP_EXECUTESQL @Execute, N'@i int output', @i output

	SET @TotalRows = @i
	
	RETURN @TotalRows

END






GO
