IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_DT')
BEGIN
	DROP  Procedure  sp_Boloes_DT
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT TOP 1 * 
	  FROM Boloes 
	 WHERE 
		Nome				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
