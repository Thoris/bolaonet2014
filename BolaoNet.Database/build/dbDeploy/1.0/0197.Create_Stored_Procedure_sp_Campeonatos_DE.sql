IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Campeonatos_DE')
BEGIN
	DROP  Procedure  sp_Campeonatos_DE
END
GO
CREATE PROCEDURE [dbo].[sp_Campeonatos_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(50),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DELETE 
	  FROM Campeonatos
	 WHERE 
			Nome	= @Nome
	  
	
	
		
			  	
	RETURN @@RowCount
	
END



GO
