IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosTimes_Add')
BEGIN
	DROP  Procedure  sp_CampeonatosTimes_Add
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosTimes_Add]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeTime							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	INSERT INTO CampeonatosTimes
		(
			NomeCampeonato,
			NomeTime
		)
		VALUES
		(
			@NomeCampeonato,
			@NomeTime
		)
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
