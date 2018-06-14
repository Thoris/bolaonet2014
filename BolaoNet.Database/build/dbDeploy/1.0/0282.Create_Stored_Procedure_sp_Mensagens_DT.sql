IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_DT')
BEGIN
	DROP  Procedure  sp_Mensagens_DT
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_DT]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@FromUser							varchar(25),
	@MessageID							bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	SELECT TOP 1 * 
	  FROM Mensagens 
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	FromUser		= @FromUser
	   AND	MessageID		= @MessageID
		
			  	
	RETURN @@RowCount	
	
END




GO
