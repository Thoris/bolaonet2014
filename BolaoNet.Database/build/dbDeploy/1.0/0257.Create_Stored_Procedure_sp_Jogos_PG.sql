IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_PG')
BEGIN
	DROP  Procedure  sp_Jogos_PG
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_PG]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Fields								nvarchar(1000),
	@Where								nvarchar(1000),
	@Order								nvarchar(1000),
	@PageNumber							int,
	@PageSize							int,	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	IF (@Order IS NULL OR LEN(LTRIM(RTRIM(@Order))) = 0)
		SET @Order = 'IdJogo'

	EXEC sp_Select_PG
		@CurrentLogin, 
		@ApplicationName,
		@Fields, 
		'Jogos', 
		@Where, 
		@Order, 
		@PageNumber, @PageSize,
		@ErrorNumber, @ErrorDescription


END



GO
