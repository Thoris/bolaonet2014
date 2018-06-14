IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosFases_Add')
BEGIN
	DROP  Procedure  sp_CampeonatosFases_Add
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosFases_Add]
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
	
	INSERT INTO CampeonatosFases
		(
			NomeCampeonato,
			Nome, 
			Descricao
		)
		VALUES
		(
			@NomeCampeonato,
			@NomeFase, 
			@Descricao
		)
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
