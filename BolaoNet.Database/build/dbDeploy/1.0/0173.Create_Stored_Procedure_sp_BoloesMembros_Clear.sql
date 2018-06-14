IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_Clear')
BEGIN
	DROP  Procedure  sp_BoloesMembros_Clear
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_Clear]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DELETE FROM BoloesMembros
	 WHERE NomeBolao		= @NomeBolao
	   
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
