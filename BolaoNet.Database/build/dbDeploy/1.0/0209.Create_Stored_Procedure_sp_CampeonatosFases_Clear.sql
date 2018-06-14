IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosFases_Clear')
BEGIN
	DROP  Procedure  sp_CampeonatosFases_Clear
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosFases_Clear]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DELETE FROM CampeonatosFases
	 WHERE NomeCampeonato		= @NomeCampeonato
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
