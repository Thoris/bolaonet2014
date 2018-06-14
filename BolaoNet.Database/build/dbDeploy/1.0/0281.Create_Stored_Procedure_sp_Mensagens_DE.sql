IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_DE')
BEGIN
	DROP  Procedure  sp_Mensagens_DE
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ToUser								varchar(25),
	@MessageID							bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	DELETE 
	  FROM Mensagens
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	ToUser			= @ToUser
	   AND	MessageID		= @MessageID
	   
	  
	
	
		
			  	
	RETURN @@RowCount
	
END




GO
