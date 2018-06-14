IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Estadios_DT')
BEGIN
	DROP  Procedure  sp_Estadios_DT
END
GO
CREATE PROCEDURE [dbo].[sp_Estadios_DT]
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
	  FROM Estadios 
	 WHERE 
		Nome				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
