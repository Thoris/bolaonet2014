IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Select_PG')
BEGIN
	DROP  Procedure  sp_Select_PG
END
GO
CREATE PROCEDURE [dbo].[sp_Select_PG] 
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@Fields								nvarchar(1000),
	@From								nvarchar(1000),
	@Where								nvarchar(1000),
	@Order								nvarchar(1000),
	@PageNumber							int,
	@PageSize							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT

)
AS
BEGIN
	

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	
	

	DECLARE @Execute		varchar(5000);		
	DECLARE @Execute_Count	nvarchar(4000);		
	DECLARE @i				int					

	IF (@Fields IS NULL OR LEN(RTrim(LTrim(@Where))) = 0)
	BEGIN 
		SET @Fields = '*'
	END



	SET @Execute = 'SELECT * ' + CHAR(13) + 
		'  FROM (' + CHAR(13) + 
		'        SELECT ROW_NUMBER() '  + CHAR(13) + 
		'               OVER (ORDER BY ' + @Order + ' ) AS Row, ' + CHAR(13) + 
		'               ' + @Fields + CHAR(13) + 
		'          FROM ' + @From + CHAR(13) 

	IF (@Where IS NOT NULL AND LEN(RTrim(LTrim((@Where)))) > 0)
	BEGIN
		SET @Execute = @Execute +  '         WHERE ' + @Where + CHAR(13) 
	END 


	SET @Execute = @Execute +  '       ) As Subquery ' + CHAR(13) + 
		' WHERE Row BETWEEN ' + LTRIM(STR((@PageNumber + 1))) + ' AND ' + 
			LTRIM(STR(((@PageNumber + 1) * @PageSize) + 1))


	EXEC (@Execute)
	
	RETURN @@RowCount
END








GO
