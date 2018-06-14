IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_DE')
BEGIN
	DROP  Procedure  sp_Jogos_DE
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_DE]
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

	
	DELETE 
	  FROM Jogos
	 WHERE 
			NomeCampeonato	= @NomeCampeonato
	   AND  IDJogo			= @IDJogo
	  
	
	
		
			  	
	RETURN @@RowCount
	
END



GO
