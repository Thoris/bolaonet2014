IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosFases_Update')
BEGIN
	DROP  Procedure  sp_CampeonatosFases_Update
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosFases_Update]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	UPDATE CampeonatosFases
	   SET Descricao		= @Descricao
	 WHERE Nome				= @NomeFase
	   AND NomeCampeonato	= @NomeCampeonato
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
