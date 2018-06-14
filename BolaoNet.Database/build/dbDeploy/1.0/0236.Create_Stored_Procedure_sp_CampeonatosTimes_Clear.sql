IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosTimes_Clear')
BEGIN
	DROP  Procedure  sp_CampeonatosTimes_Clear
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosTimes_Clear]
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
	
	DELETE FROM CampeonatosTimes
	 WHERE NomeCampeonato		= @NomeCampeonato
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
