IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_DT')
BEGIN
	DROP  Procedure  sp_Jogos_DT
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),	
	@IDJogo								bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT TOP 1 * 
	  FROM Jogos 
	 WHERE 
			NomeCampeonato				= @NomeCampeonato
	   AND	IDJogo						= @IdJogo
		
			  	
	RETURN @@RowCount	
	
END



GO
