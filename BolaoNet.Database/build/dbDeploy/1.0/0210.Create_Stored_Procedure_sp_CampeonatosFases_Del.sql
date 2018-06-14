IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosFases_Del')
BEGIN
	DROP  Procedure  sp_CampeonatosFases_Del
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosFases_Del]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DELETE FROM CampeonatosFases
	 WHERE NomeCampeonato		= @NomeCampeonato
	   AND Nome					= @NomeFase
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
